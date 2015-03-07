using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using GenericCustomLog;
using GenericCustomLog.Model;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;
 

namespace Custom
{
    [ConfigurationElementType(typeof(GenericLogginExceptionHandlerData))]
    public class GenericLoggingExceptionHandler : IExceptionHandler
    {
        private readonly string logCategory;
        private readonly int eventId;
        private readonly TraceEventType severity;
        private readonly string defaultTitle;
        private readonly Type formatterType;
        private readonly int minimumPriority;
        private readonly LogWriter logWriter;
        private readonly Type replaceExceptionType;
        private readonly int layer;
        private readonly int moduleId;
        private readonly string mnemonic;
        private readonly string subcategory;


        /// <summary>
        /// Initializes a new instance of the <see cref="LoggingExceptionHandler"/> class with the log category, the event ID, the <see cref="TraceEventType"/>,
        /// the title, minimum priority, the formatter type, and the <see cref="LogWriter"/>.
        /// </summary>
        /// <param name="logCategory">The default category</param>
        /// <param name="eventId">An event id.</param>
        /// <param name="severity">The severity.</param>
        /// <param name="title">The log title.</param>
        /// <param name="priority">The minimum priority.</param>
        /// <param name="formatterType">The type <see cref="ExceptionFormatter"/> type.</param>
        /// <param name="writer">The <see cref="LogWriter"/> to use.</param>
        /// <remarks>
        /// The type specified for the <paramref name="formatterType"/> attribute must have a public constructor with
        /// parameters of type <see name="TextWriter"/>, <see cref="Exception"/> and <see cref="Guid"/>.
        /// </remarks>
        public GenericLoggingExceptionHandler(
            string logCategory,
            int eventId,
            int moduleId,
            TraceEventType severity,
            string title,
            int priority,
            Type formatterType,
            LogWriter writer,
            Type replaceExceptionType,
            int layer,
            string mnemonic,
            string subcategory)
        {
            this.logCategory = logCategory;
            this.eventId = eventId;
            this.moduleId = moduleId;
            this.severity = severity;
            this.defaultTitle = title;
            this.minimumPriority = priority;
            this.formatterType = formatterType;
            this.logWriter = writer;
            this.replaceExceptionType = replaceExceptionType;
            this.layer = layer;
            this.mnemonic = mnemonic;
            this.subcategory = subcategory;
        }

        /// <summary>
        /// <para>Handles the specified <see cref="Exception"/> object by formatting it and writing to the configured log.</para>
        /// </summary>
        /// <param name="exception"><para>The exception to handle.</para></param>        
        /// <param name="handlingInstanceId">
        /// <para>The unique ID attached to the handling chain for this handling instance.</para>
        /// </param>
        /// <returns><para>Modified exception to pass to the next handler in the chain.</para></returns>
        public Exception HandleException(Exception exception, Guid handlingInstanceId)
        {
            string logId = WriteToLog(CreateMessage(exception, handlingInstanceId), exception.Data);
            //return WrapException(exception, ExceptionMessageDictionary.Instance.getExceptionMessage(mnemonic, subcategory), logId);
            return WrapException(exception, ExceptionUtility.FormatExceptionMessage(exception.Message, handlingInstanceId), logId);
        }

        /// <summary>
        /// Writes the specified log message using 
        /// the Logging Application Block's <see cref="Logger.Write(LogEntry)"/>
        /// method.
        /// </summary>
        /// <param name="logMessage">The message to write to the log.</param>
        /// <param name="exceptionData">The exception's data.</param>
        protected virtual string WriteToLog(string logMessage, IDictionary exceptionData)
        {
            Log log = new Log();
            log.logEntry.Categories.Add(logCategory);
            log.logEntry.Severity = severity;
            log.Priority = minimumPriority;
            log.ModuleId = moduleId;
            log.Message = logMessage;
            StackTrace stackTrace = new StackTrace();
            log.Title = stackTrace.GetFrame(7).GetMethod().ReflectedType.FullName + "." + stackTrace.GetFrame(7).GetMethod().Name;

            foreach (DictionaryEntry dataEntry in exceptionData)
            {
                if (dataEntry.Key is string)
                {
                    if (dataEntry.Key.Equals("appUsuarioCorreo"))
                    {
                        log.AppUserName = dataEntry.Value as string;
                    }
                    else if (dataEntry.Key.Equals("appUsuarioNombre"))
                    {
                        log.appUsuarioNombre = dataEntry.Value as string;
                    }
                    else if (dataEntry.Key.Equals("NumeroProducto"))
                    {
                        log.RecordLocator = dataEntry.Value as string;
                    }
                    else if (dataEntry.Key.Equals("action"))
                    {
                        log.Action = dataEntry.Value as string;
                    }
                    else if (dataEntry.Key.Equals("Params"))
                    {
                        log.Params = dataEntry.Value as string;
                    }
                }
            }

            this.logWriter.Write(log.logEntry);
            if (log.logEntry.ExtendedProperties.ContainsKey("logId") != false)
            {
                return log.logEntry.ExtendedProperties["logId"].ToString();
            }
            else
            {
                return "0";
            }
        }

        private Exception WrapException(Exception originalException, string wrapExceptionMessage, string logId)
        {
            object[] extraParameters = new object[7];
            extraParameters[0] = wrapExceptionMessage;
            extraParameters[1] = originalException;
            extraParameters[2] = logId;
            extraParameters[3] = layer;
            extraParameters[4] = mnemonic;
            extraParameters[5] = subcategory;
            extraParameters[6] = moduleId;

            return (Exception)Activator.CreateInstance(replaceExceptionType, extraParameters);
        }


        /// <summary>
        /// Creates an instance of the <see cref="StringWriter"/>
        /// class using its default constructor.
        /// </summary>
        /// <returns>A newly created <see cref="StringWriter"/></returns>
        protected virtual StringWriter CreateStringWriter()
        {
            return new StringWriter(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Creates an <see cref="ExceptionFormatter"/>
        /// object based on the configured ExceptionFormatter
        /// type name.
        /// </summary>
        /// <param name="writer">The stream to write to.</param>
        /// <param name="exception">The <see cref="Exception"/> to pass into the formatter.</param>
        /// <param name="handlingInstanceID">The id of the handling chain.</param>
        /// <returns>A newly created <see cref="ExceptionFormatter"/></returns>
        protected virtual Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.ExceptionFormatter CreateFormatter(StringWriter writer, Exception exception, Guid handlingInstanceID)
        {
            ConstructorInfo constructor = GetFormatterConstructor();
            return (Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.ExceptionFormatter)constructor.Invoke(new object[] { writer, exception, handlingInstanceID });
        }

        private ConstructorInfo GetFormatterConstructor()
        {
            Type[] types = new Type[] { typeof(TextWriter), typeof(Exception), typeof(Guid) };
            ConstructorInfo constructor = formatterType.GetConstructor(types);
            if (constructor == null)
            {
                throw new ExceptionHandlingException(formatterType.AssemblyQualifiedName);
            }
            return constructor;
        }

        private string CreateMessage(Exception exception, Guid handlingInstanceID)
        {
            StringWriter writer = null;
            StringBuilder stringBuilder = null;
            try
            {
                writer = CreateStringWriter();
                Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.ExceptionFormatter formatter = CreateFormatter(writer, exception, handlingInstanceID);
                formatter.Format();
                stringBuilder = writer.GetStringBuilder();

            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }

            return stringBuilder.ToString();
        }
    }
}
