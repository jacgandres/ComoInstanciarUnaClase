using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.ObjectBuilder;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Logging.Instrumentation;

namespace GenericCustomLog
{
    public class GenericTracer : IDisposable
    {
        private TracerInstrumentationListener instrumentationListener;

        private Stopwatch stopwatch;
        private long tracingStartTicks;
        private bool tracerDisposed = false;
        private bool tracingAvailable = false;
        private LogWriter writer = null;
        private readonly Guid? previousActivityId = null;

        private Dictionary<string, object> extendedProperties;

        /// <summary>
        /// Priority value for Trace messages
        /// </summary>
        public const int priority = 5;

        /// <summary>
        /// Event id for Trace messages
        /// </summary>
        public const int eventId = 1;

        /// <summary>
        /// Initializes a new instance of the <see cref="Tracer"/> class with the given logical operation name.
        /// </summary>
        /// <remarks>
        /// If an existing activity id is already set, it will be kept. Otherwise, a new activity id will be created.
        /// </remarks>
        /// <param name="operation">The operation for the <see cref="Tracer"/></param>
        public GenericTracer(string operation)
        {
            if (CheckTracingAvailable())
            {
                if (GetActivityId().Equals(Guid.Empty))
                {
                    SetActivityId(Guid.NewGuid());
                }
                if (PeekLogicalOperationStack() == null)
                {
                    extendedProperties = new Dictionary<string, object>();
                    extendedProperties.Add("appUsuarioCorreo", 0);
                    extendedProperties.Add("action", "");
                    extendedProperties.Add("NumeroProducto", "");
                    extendedProperties.Add("appUsuarioNombre", "");
                    extendedProperties.Add("layer", operation);
                    extendedProperties.Add("GUID", GetActivityId());
                }
                else
                {
                    extendedProperties = (Dictionary<string, object>)PeekLogicalOperationStack();
                }

                Initialize(extendedProperties, GetInstrumentationListener(ConfigurationSourceFactory.Create()));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CategorySource"></param>
        /// <param name="userId"></param>
        /// <param name="action"></param>
        /// <param name="appUsuarioNombre"></param>
        /// <param name="pIdentificationProduct">Id de la Cotizacion</param>
        public GenericTracer(string CategorySource, string userId, string action, string appUsuarioNombre, string pIdentificationProduct)
        {
            if (CheckTracingAvailable())
            {
                if (GetActivityId().Equals(Guid.Empty))
                {
                    SetActivityId(Guid.NewGuid());
                }
                if (PeekLogicalOperationStack() == null)
                {
                    extendedProperties = new Dictionary<string, object>();
                    extendedProperties.Add("appUsuarioCorreo", userId);
                    extendedProperties.Add("appUsuarioNombre", appUsuarioNombre);
                    extendedProperties.Add("action", action);
                    extendedProperties.Add("NumeroProducto", pIdentificationProduct);
                    extendedProperties.Add("layer", CategorySource);
                    extendedProperties.Add("GUID", GetActivityId());
                }
                else
                {
                    extendedProperties = (Dictionary<string, object>)PeekLogicalOperationStack();
                }

                Initialize(extendedProperties, GetInstrumentationListener(ConfigurationSourceFactory.Create()));
            }
        }

        //<summary>
        /// Initializes a new instance of the <see cref="Tracer"/> class with the given logical operation name and activity id.
        /// </summary>
        /// <remarks>
        /// The activity id will override a previous activity id
        /// </remarks>
        /// <param name="operation">The operation for the <see cref="Tracer"/></param>
        /// <param name="activityId">The activity id</param>
        public GenericTracer(string operation, Guid activityId, string userId, string action, string appUsuarioNombre, string pIdentificationProduct)
        {
            if (CheckTracingAvailable())
            {
                SetActivityId(activityId);

                extendedProperties = new Dictionary<string, object>();
                extendedProperties.Add("appUsuarioCorreo", userId);
                extendedProperties.Add("appUsuarioNombre", appUsuarioNombre);
                extendedProperties.Add("action", action);
                extendedProperties.Add("layer", operation);
                extendedProperties.Add("NumeroProducto", pIdentificationProduct);
                extendedProperties.Add("GUID", GetActivityId());

                Initialize(extendedProperties, GetInstrumentationListener(ConfigurationSourceFactory.Create()));
            }
        }

        /// <summary>
        /// Causes the <see cref="Tracer"/> to output its closing message.
        /// </summary>
        public void Dispose()
        {
            if (!tracerDisposed)
            {
                if (tracingAvailable)
                {
                    try
                    {
                        if (IsTracingEnabled()) WriteTraceEndMessage(extendedProperties);
                    }
                    finally
                    {
                        try
                        {
                            StopLogicalOperation();
                            if (this.previousActivityId != null)
                            {
                                SetActivityId(this.previousActivityId.Value);
                            }
                        }
                        catch (SecurityException)
                        {
                        }
                    }
                }

                tracerDisposed = true;
            }
        }

        /// <summary>
        /// Answers whether tracing is enabled
        /// </summary>
        /// <returns>true if tracing is enabled</returns>
        public bool IsTracingEnabled()
        {
            LogWriter writer = GetWriter();
            return writer.IsTracingEnabled();
        }

        private static TracerInstrumentationListener GetInstrumentationListener(IConfigurationSource configurationSource)
        {
            TracerInstrumentationListener instrumentationListener;
            if (configurationSource != null)
            {
                instrumentationListener = EnterpriseLibraryFactory.BuildUp<TracerInstrumentationListener>(configurationSource);
            }
            else
            {
                instrumentationListener = new TracerInstrumentationListener(false);
            }

            return instrumentationListener;
        }

        private void Initialize(Dictionary<string, object> extendedProperties, TracerInstrumentationListener instrumentationListener)
        {
            this.instrumentationListener = instrumentationListener;

            StartLogicalOperation(extendedProperties);
            if (IsTracingEnabled())
            {
                instrumentationListener.TracerOperationStarted(((Dictionary<string, object>)PeekLogicalOperationStack())["layer"].ToString());

                stopwatch = Stopwatch.StartNew();
                tracingStartTicks = Stopwatch.GetTimestamp();

                WriteTraceStartMessage(extendedProperties);
            }
        }

        private void WriteTraceStartMessage(Dictionary<string, object> extendedProperties)
        {
            string methodName = GetExecutingMethodName();
            string unFormattedMessage = "Start Trace: Activity '{0}' in method '{1}' at {2} ticks";
            string message = string.Format(unFormattedMessage, GetActivityId(), methodName, tracingStartTicks);
            if (extendedProperties.Keys.Contains<string>("elapsedTime"))
            {
                extendedProperties.Remove("elapsedTime");
            }
            extendedProperties.Add("elapsedTime", 0);
            WriteTraceMessage(message, methodName, TraceEventType.Start, extendedProperties);
        }

        private void WriteTraceEndMessage(Dictionary<string, object> extendedProperties)
        {
            string unFormattedMessage = "End Trace: Activity '{0}' in method '{1}' at {2} ticks (elapsed time: {3} seconds)";
            long tracingEndTicks = Stopwatch.GetTimestamp();
            decimal secondsElapsed = GetSecondsElapsed(stopwatch.ElapsedMilliseconds);

            string methodName = GetExecutingMethodName();
            string message = string.Format(unFormattedMessage, GetActivityId(), methodName, tracingEndTicks, secondsElapsed);
            if (extendedProperties.Keys.Contains<string>("elapsedTime"))
            {
                extendedProperties.Remove("elapsedTime");
            }
            extendedProperties.Add("elapsedTime", secondsElapsed);
            WriteTraceMessage(message, methodName, TraceEventType.Stop, extendedProperties);

            instrumentationListener.TracerOperationEnded(((Dictionary<string, object>)PeekLogicalOperationStack())["layer"].ToString() as string, stopwatch.ElapsedMilliseconds);
        }

        private void WriteTraceMessage(string message, string entryTitle, TraceEventType eventType, Dictionary<string, object> extendedProperties)
        {
            LogEntry entry = new LogEntry(message, ((Dictionary<string, object>)PeekLogicalOperationStack())["layer"].ToString() as string, priority, eventId, eventType, entryTitle, extendedProperties);

            LogWriter writer = GetWriter();
            writer.Write(entry);
        }

        private decimal GetSecondsElapsed(long milliseconds)
        {
            decimal result = Convert.ToDecimal(milliseconds) / 1000m;
            return Math.Round(result, 6);
        }

        private LogWriter GetWriter()
        {
            return (writer != null) ? writer : Logger.Writer;
        }

        private string GetExecutingMethodName()
        {
            string result = "Unknown";
            StackTrace trace = new StackTrace(false);

            for (int index = 0; index < trace.FrameCount; ++index)
            {
                StackFrame frame = trace.GetFrame(index);
                MethodBase method = frame.GetMethod();
                if (method.DeclaringType != GetType())
                {
                    result = string.Concat(method.DeclaringType.FullName, ".", method.Name);
                    break;
                }
            }

            return result;
        }

        private static void StopLogicalOperation()
        {
            Trace.CorrelationManager.StopLogicalOperation();
        }


        private static object PeekLogicalOperationStack()
        {
            object peek = null;
            if (Trace.CorrelationManager.LogicalOperationStack.Count > 0)
            {
                peek = Trace.CorrelationManager.LogicalOperationStack.Peek();
            }
            return peek;
        }

        private static void StartLogicalOperation(object operation)
        {
            Trace.CorrelationManager.StartLogicalOperation(operation);
        }

        private static Guid GetActivityId()
        {
            return Trace.CorrelationManager.ActivityId;
        }

        private static Guid SetActivityId(Guid activityId)
        {
            return Trace.CorrelationManager.ActivityId = activityId;
        }

        private bool CheckTracingAvailable()
        {
            tracingAvailable = IsTracingEnabled();

            return tracingAvailable;
        }
    }
}
