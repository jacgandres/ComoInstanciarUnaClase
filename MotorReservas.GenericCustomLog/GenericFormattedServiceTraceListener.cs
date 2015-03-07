using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using MotorReservas.GenericCustomLog; 

namespace GenericCustomLog
{
    [ConfigurationElementType(typeof(GenericFormattedServiceTraceListenerData))]
    public class GenericFormattedServiceTraceListener : Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners.CustomTraceListener
    {
        public GenericFormattedServiceTraceListener() : base() { }
        /// <summary>
        /// The Write method 
        /// </summary>
        /// <param name="message">The message to log</param>
        public override void Write(string message)
        {
            //ExecuteWriteLogStoredProcedure(0, 5, TraceEventType.Information, string.Empty, DateTime.Now, string.Empty,  string.Empty, string.Empty, string.Empty, null, null, message, database);
        }

        /// <summary>
        /// The WriteLine method.
        /// </summary>
        /// <param name="message">The message to log</param>
        public override void WriteLine(string message)
        {
            Write(message);
        }


        /// <summary>
        /// Delivers the trace data to the underlying database.
        /// </summary>
        /// <param name="eventCache">The context information provided by <see cref="System.Diagnostics"/>.</param>
        /// <param name="source">The name of the trace source that delivered the trace data.</param>
        /// <param name="eventType">The type of event.</param>
        /// <param name="id">The id of the event.</param>
        /// <param name="data">The data to trace.</param>
        public override void TraceData(TraceEventCache eventCache, string source, TraceEventType eventType, int id, object data)
        {
            if ((this.Filter == null) || this.Filter.ShouldTrace(eventCache, source, eventType, id, null, null, data, null))
            {
                if (data is LogEntry)
                {
                    LogEntry logEntry = data as LogEntry;

                    CallEnterLogServices(logEntry);
                }
                else if (data is string)
                {
                    Write(data as string);
                }
                else
                {
                    base.TraceData(eventCache, source, eventType, id, data);
                }
            }
        }

        private void CallEnterLogServices(LogEntry logEntry)
        {
            long idLog = 0L;
            GenericTracerLogListener tracerLog = new GenericTracerLogListener();

            tracerLog.ModuleId = logEntry.ExtendedProperties.Keys.Contains("moduleId") ? int.Parse(logEntry.ExtendedProperties["moduleId"].ToString()) : 0;
            tracerLog.IsTrace = (logEntry.Severity == TraceEventType.Stop) || (logEntry.Severity == TraceEventType.Start);
            tracerLog.RecordLocator = logEntry.ExtendedProperties.Keys.Contains("NumeroProducto") ? logEntry.ExtendedProperties["NumeroProducto"].ToString() : "";
            tracerLog.Action = logEntry.ExtendedProperties.Keys.Contains("action") ? logEntry.ExtendedProperties["action"].ToString() : "";
            tracerLog.ElapsedTime = logEntry.ExtendedProperties.Keys.Contains("elapsedTime") ? decimal.Parse(logEntry.ExtendedProperties["elapsedTime"].ToString()) : 0;
            tracerLog.AppUserId = logEntry.ExtendedProperties.Keys.Contains("appUsuarioCorreo") ? logEntry.ExtendedProperties["appUsuarioCorreo"].ToString() : "";
            tracerLog.appUsuarioNombre = logEntry.ExtendedProperties.Keys.Contains("appUsuarioNombre") ? logEntry.ExtendedProperties["appUsuarioNombre"].ToString() : "";
            tracerLog.TracerGuid = logEntry.ExtendedProperties.Keys.Contains("GUID") ? (Guid)logEntry.ExtendedProperties["GUID"] : Guid.NewGuid();
            tracerLog.FormattedMessage = "";
            tracerLog.Categories = new List<string>();
            tracerLog.ExtendedProperties = new List<string>();
            tracerLog.TracerDate = logEntry.TimeStamp.ToShortDateString() + " " + logEntry.TimeStamp.ToLongTimeString();
            tracerLog.Priority = logEntry.Priority.ToString();
            tracerLog.Severity = logEntry.Severity.ToString();
            tracerLog.Title = logEntry.Title;
            tracerLog.Params = logEntry.ExtendedProperties.Keys.Contains("Params") ? logEntry.ExtendedProperties["Params"].ToString() : "";
            tracerLog = this.GetMoreInfo(tracerLog, logEntry.Message);
            idLog = this.GetMaxIdLog();

            if (Formatter != null)
                tracerLog.FormattedMessage = Formatter.Format(logEntry);

            logEntry.ExtendedProperties.ToList().ForEach(kvp => tracerLog.ExtendedProperties.Add(kvp.Key + "-" + kvp.Value + "-" + idLog.ToString()));
            logEntry.Categories.ToList().ForEach(ctg => tracerLog.Categories.Add(ctg + "-" + idLog.ToString()));

            this.SaveLog(tracerLog); 

            idLog = tracerLog.LogId;

            if (logEntry.ExtendedProperties.Keys.Contains<string>("logId"))
                logEntry.ExtendedProperties.Remove("logId");


            logEntry.ExtendedProperties.Add("logId", idLog);
        }

        private GenericTracerLogListener GetMoreInfo(GenericTracerLogListener pTracerLog, string pMessage)
        {
            List<string> errorLinesMessage = pMessage.Split('\n').ToList<string>();

            for (int i = 0; i < errorLinesMessage.Count; i++)
            {
                string line = errorLinesMessage[i];
                if (line.Contains(":"))
                {
                    string LineToSearch = "";
                    switch (line.Split(':')[0].Trim())
                    {
                        case "Type":
                            DateTime dt = new DateTime();
                            System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
                            if (DateTime.TryParse(errorLinesMessage[i - 1], culture, System.Globalization.DateTimeStyles.None, out dt))
                                pTracerLog.TracerDate = dt.ToShortDateString() + " " + dt.ToLongTimeString();

                            LineToSearch = "Message";
                            pTracerLog.Type = this.ExtractLineIfo(errorLinesMessage, ref i, ref line, LineToSearch);
                            break;
                        case "Message":
                            LineToSearch = "Source";
                            pTracerLog.MessageExplicitError = this.ExtractLineIfo(errorLinesMessage, ref i, ref line, LineToSearch);
                            break;
                        case "Status":
                            LineToSearch = "Stack Trace";
                            pTracerLog.Status = this.ExtractLineIfo(errorLinesMessage, ref i, ref line, LineToSearch);
                            break;
                        case "Stack Trace":
                            LineToSearch = "Additional Info";
                            pTracerLog.StackTrace = this.ExtractLineIfo(errorLinesMessage, ref i, ref line, LineToSearch);
                            i = errorLinesMessage.Count;
                            break;
                    }
                }
            }

            return pTracerLog;
        }

        private string ExtractLineIfo(List<string> errorLinesMessage, ref int i, ref string line, string LineToSearch)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(line.Trim());
            while (true)
            {
                if (i + 1 < errorLinesMessage.Count)
                {
                    line = errorLinesMessage[i + 1];
                    if (line.Contains(LineToSearch) == false)
                        sb.AppendLine(line.Trim());
                    else
                        break;
                }
                else
                    break;
                i++;
            }
            return sb.ToString();
        }
        private long GetMaxIdLog()
        {
            long idLog = 0L;
            string pathLogFile = "";

            if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Application != null && System.Web.HttpContext.Current.Application["LOG_PATH"] != null)
                pathLogFile = (string)System.Web.HttpContext.Current.Application["LOG_PATH"];
            else
                pathLogFile = LogSettings.Default.PathLog;

            if (System.IO.File.Exists(pathLogFile) == false)
                return 1L;

            string content = System.IO.File.ReadAllText(pathLogFile);
            List<GenericTracerLogListener> aviaLogs = new List<GenericTracerLogListener>();

            if (string.IsNullOrEmpty(content) == false)
            {
                aviaLogs = ObjectUnSerialize<List<GenericTracerLogListener>>(content);

                var result = from log in aviaLogs
                             orderby log.LogId descending
                             select log;
                idLog = result.ToList<GenericTracerLogListener>()[0].LogId + 1L;
            }
            else
                idLog = 1L;

            return idLog;
        }


        private void SaveLog(GenericTracerLogListener tracertLog)
        {
            using (LogGenericDAO logBd = new  LogGenericDAO())
            {
                 logBd.CreateLog(tracertLog);
            }
        }


        /// <summary>
        /// Marshall
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pObjetoConvertir"></param>
        /// <returns></returns>
        private string ObjectSerialize<T>(T pObjetoConvertir)
        {
            System.Xml.Serialization.XmlSerializer serializadorEntrada = new System.Xml.Serialization.XmlSerializer(pObjetoConvertir.GetType());
            System.IO.StringWriter writerEntrada = new System.IO.StringWriter();
            serializadorEntrada.Serialize(writerEntrada, pObjetoConvertir);

            return writerEntrada.ToString();
        }
        private static T ObjectUnSerialize<T>(string pXmlSerializado)
        {
            T t = default(T);
            System.Xml.XmlDocument xmlDocument = new System.Xml.XmlDocument();
            xmlDocument.LoadXml(pXmlSerializado);
            // Deserializa el modelo a partir de un lector de XML
            System.Xml.XmlNodeReader reader = new System.Xml.XmlNodeReader(xmlDocument);
            System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(T));
            t = (T)ser.Deserialize(reader);
            reader.Close();
            return t;
        }
    }

    [Serializable]
    public class GenericTracerLogListener : IComparable
    {
        public bool IsTrace { get; set; }
        public int ModuleId { get; set; }
        public long LogId { get; set; }
        public decimal ElapsedTime { get; set; }
        public string RecordLocator { get; set; }
        public string Action { get; set; }
        public string AppUserId { get; set; }
        public string appUsuarioNombre { get; set; }
        public string FormattedMessage { get; set; }
        public string Priority { get; set; }
        public string Severity { get; set; }
        public string Title { get; set; }

        public string Type { get; set; }
        public string MessageExplicitError { get; set; }
        public string Status { get; set; }
        public string StackTrace { get; set; }

        public string Params { get; set; }
        public List<string> Categories { get; set; }
        public Guid TracerGuid { get; set; }

        public string TracerDate { get; set; }

        #region IComparable Members

        public int CompareTo(object obj)
        {
            return this.LogId.CompareTo(obj);
        }

        #endregion

        public List<string> ExtendedProperties { get; set; }

    }
}
