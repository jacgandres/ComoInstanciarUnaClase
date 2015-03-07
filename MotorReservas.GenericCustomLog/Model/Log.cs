using System.Collections.Generic;
using System.Diagnostics;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace GenericCustomLog.Model
{
    public class Log
    {
        private int logId;
        private int categoryId;
        private string category;
        private int moduleId;
        private string module;
        private string recordLocator;
        private string message;
        private string date;
        private int appUserId;
        private string appOfficeId;
        private string appUserName;
        private string severity;
        private string action;
        private int priority;
        private LogEntry _logEntry;
        private string pParams;

        public int LogId
        {
            get { return logId; }
            set { logId = value; }
        }

        public int CategoryId
        {
            get { return categoryId; }
            set
            {
                categoryId = value;
            }
        }

        public string Category
        {
            get { return category; }
            set
            {
                category = value;
                List<string> cat = new List<string>();
                cat.Add(category);
                _logEntry.Categories = cat;
            }
        }

        public int ModuleId
        {
            get { return moduleId; }
            set
            {
                moduleId = value;
                if (_logEntry.ExtendedProperties.Keys.Contains("moduleId"))
                    _logEntry.ExtendedProperties.Remove("moduleId");
                _logEntry.ExtendedProperties.Add("moduleId", moduleId);
            }
        }

        public string Module
        {
            get { return module; }
            set { module = value; }
        }

        public string RecordLocator
        {
            get { return recordLocator; }
            set
            {
                recordLocator = value;
                if (_logEntry.ExtendedProperties.Keys.Contains("NumeroProducto"))
                    _logEntry.ExtendedProperties.Remove("NumeroProducto");
                _logEntry.ExtendedProperties.Add("NumeroProducto", recordLocator);
            }
        }

        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                _logEntry.Message = message;
            }
        }

        public string Date
        {
            get { return date; }
            set { date = value; }
        }

        public int AppUserId
        {
            get { return appUserId; }
        }

        public string appUsuarioNombre
        {
            get { return appUsuarioNombre; }
            set
            {
                appOfficeId = value;
                if (_logEntry.ExtendedProperties.Keys.Contains("appUsuarioNombre"))
                    _logEntry.ExtendedProperties.Remove("appUsuarioNombre");
                _logEntry.ExtendedProperties.Add("appUsuarioNombre", appUsuarioNombre);
            }
        }

        public string Params
        {
            get { return pParams; }
            set
            {
                pParams = value;
                if (_logEntry.ExtendedProperties.Keys.Contains("Params"))
                    _logEntry.ExtendedProperties.Remove("Params");
                _logEntry.ExtendedProperties.Add("Params", pParams);
            }
        }
        public string AppUserName
        {
            get { return appUserName; }
            set
            {
                appUserName = value;
                if (_logEntry.ExtendedProperties.Keys.Contains("appUsuarioCorreo"))
                    _logEntry.ExtendedProperties.Remove("appUsuarioCorreo");
                _logEntry.ExtendedProperties.Add("appUsuarioCorreo", appUserName);
            }
        }

        public string Severity
        {
            get { return severity; }
            set
            {
                severity = value;
            }
        }

        public int Priority
        {
            get { return priority; }
            set
            {
                priority = value;
                _logEntry.Priority = priority;
            }
        }

        public string Action
        {
            get { return action; }
            set
            {
                action = value;
                if (_logEntry.ExtendedProperties.Keys.Contains("action"))
                    _logEntry.ExtendedProperties.Remove("action");
                _logEntry.ExtendedProperties.Add("action", action);
            }
        }

        public string Title
        {
            get
            {
                return _logEntry.Title;
            }
            set
            {
                _logEntry.Title = value;
            }
        }

        public LogEntry logEntry
        {
            get { return _logEntry; }
        }

        public Log()
        {
            StackTrace stackTrace = new StackTrace();
            _logEntry = new LogEntry();
            _logEntry.ExtendedProperties = new Dictionary<string, object>();
            _logEntry.Categories = new List<string>();
            _logEntry.Title = validateTitle(stackTrace.GetFrame(1).GetMethod().ReflectedType.FullName, stackTrace.GetFrame(1).GetMethod().Name);
            if (PeekLogicalOperationStack() == null)
            {
                if (HttpContext.Current != null && HttpContext.Current.Session != null && HttpContext.Current.Session["BBTurUserId"] != null)
                {
                    appUserId = int.Parse(HttpContext.Current.Session["BBTurUserId"].ToString());
                }
                else
                {
                    appUserId = 0;
                }

                if (_logEntry.ExtendedProperties.Keys.Contains("appUsuarioCorreo"))
                    _logEntry.ExtendedProperties.Remove("appUsuarioCorreo");
                _logEntry.ExtendedProperties.Add("appUsuarioCorreo", appUserId);
            }
            else
            {
                _logEntry.ExtendedProperties = (Dictionary<string, object>)PeekLogicalOperationStack();
            }
        }

        private string validateTitle(string clazz, string method)
        {
            if (clazz.Contains("+"))
            {
                clazz = clazz.Remove(clazz.IndexOf('+'));
            }
            if (method.Contains("+"))
            {
                method = method.Remove(clazz.IndexOf('+'));
            }
            return clazz + "." + method;
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

    }
}