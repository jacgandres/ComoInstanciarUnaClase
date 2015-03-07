using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GenericCustomLog.Exceptions;
using GenericCustomLog.Model;
using GenericCustomLog.Persistence;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace GenericCustomLog.BusinessLogic
{
    public class LogFacade : ICustomLog
    {
        private LogDAO logdao;

        public LogFacade()
        {
            logdao = new LogDAO();
        }


        #region Miembros de ICustomLog

        public List<Log> getAllLogs()
        {
            List<Log> logs = new List<Log>();
            using (new GenericTracer("Facade"))
            {
                try
                {
                   logs = logdao.getAllLogs();
                }
                catch (AmadeusBBTurGeneralException)
                {
                    throw;
                }
                catch (Exception e)
                {
                    bool rethrow = ExceptionPolicy.HandleException(e, "Log policy");
                    if (rethrow)
                    {
                        throw;
                    }
                }
                return logs;
            }
        }

        public List<Log> getLogsParameters(DateTime dtInitial, DateTime dtFinal, int intModuleId, int intCategoryId, string strRecordLocator, int intUserId)
        {
            try
            {
                return logdao.getLogsParameters(dtInitial, dtFinal, intModuleId, intCategoryId, strRecordLocator, intUserId);
            }
            catch (Exception ex)
            {
                //TODO:agregar el LOG
                Log log1 = new Log();
                log1.logEntry.Categories.Add("Error");
                log1.logEntry.Severity = System.Diagnostics.TraceEventType.Error;
                log1.Message = ex.Message + "-" + ex.StackTrace ;
                log1.Priority = 1;
                log1.RecordLocator = "NA";
                log1.ModuleId = 0;
                Logger.Write(log1.logEntry);
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ExceptionMessage> getLogMessages()
        {
            List<ExceptionMessage> messages = new List<ExceptionMessage>();
            using (new GenericTracer("Facade"))
            {
                try
                {
                    messages = logdao.getAllLogMessages();
                }
                catch (AmadeusBBTurGeneralException)
                {
                    throw;
                }
                catch (Exception e)
                {
                    bool rethrow = ExceptionPolicy.HandleException(e, "Log policy");
                    if (rethrow)
                    {
                        throw;
                    }
                }
            }
            return messages;
        }

        public Hashtable getAllLogMessages()
        {
            Hashtable messages = new Hashtable();
            using (new GenericTracer("Facade"))
            {
                try
                {
                    messages = new Hashtable(logdao.getAllLogMessages().ToDictionary(o => o.Mnemonic + "-" + o.Subcategory, o => o.Message));
                }
                catch (AmadeusBBTurGeneralException)
                {
                    throw;
                }
                catch (Exception e)
                {
                    bool rethrow = ExceptionPolicy.HandleException(e, "Log policy");
                    if (rethrow)
                    {
                        throw;
                    }
                }
            }

            return messages;
        }

        public List<Log> getAllLogs(int page, int rows, string sortParam, string sortOrder, bool search, string signin, string severity, string logId, string recordLocator, string from, string to)
        {
            List<Log> logs = new List<Log>();
            using (new GenericTracer("Facade"))
            {
                try
                {
                    int bottom = (page - 1) * rows;
                    int top = rows * page;
                    logs = logdao.getAllLogs(sortParam, sortOrder, bottom, top, search, signin, severity, logId, recordLocator, from, to);
                }
                catch (AmadeusBBTurGeneralException)
                {
                    throw;
                }
                catch (Exception e)
                {
                    bool rethrow = ExceptionPolicy.HandleException(e, "Log policy");
                    if (rethrow)
                    {
                        throw;
                    }
                }
            }
            return logs;
        }

        public int totalLogs()
        {
            int total = 0;
            using (new GenericTracer("Facade"))
            {
                try
                {
                    total = logdao.getTotalLogs();
                }
                catch (AmadeusBBTurGeneralException)
                {
                    throw;
                }
                catch (Exception e)
                {
                    bool rethrow = ExceptionPolicy.HandleException(e, "Log policy");
                    if (rethrow)
                    {
                        throw;
                    }
                }
            }
            return total;
        }

        public Log getLog(int logId)
        {
            Log log = null;
            using (new GenericTracer("Facade"))
            {
                try
                {
                    log = logdao.getLog(logId);
                }
                catch (AmadeusBBTurGeneralException)
                {
                    throw;
                }
                catch (Exception e)
                {
                    bool rethrow = ExceptionPolicy.HandleException(e, "Log policy");
                    if (rethrow)
                    {
                        throw;
                    }
                }
            }
            return log;
        }

        public int totalSearchLogs(string signin, string severity, string logId, string recordLocator, string from , string to)
        {
            int total = 0;
            using (new GenericTracer("Facade"))
            {
                try
                {
                    total = logdao.getSearchTotalLogs(signin, severity, logId, recordLocator, from , to);
                }
                catch (AmadeusBBTurGeneralException)
                {
                    throw;
                }
                catch (Exception e)
                {
                    bool rethrow = ExceptionPolicy.HandleException(e, "Log policy");
                    if (rethrow)
                    {
                        throw;
                    }
                }
            }
            return total;
        }

        public int AddExceptionMessage(string mnemonic, string subcategory, string message)
        {
            int messageId = 0;
            using (new GenericTracer("Facade"))
            {
                try
                {
                    messageId = logdao.AddExceptionMessage(mnemonic, subcategory, message);
                }
                catch (AmadeusBBTurGeneralException)
                {
                    throw;
                }
                catch (Exception e)
                {
                    bool rethrow = ExceptionPolicy.HandleException(e, "Log policy");
                    if (rethrow)
                    {
                        throw;
                    }
                }
            }
            return messageId;
        }

        public int EditExceptionMessage(int messageId, string mnemonic, string subcategory, string message)
        {
            int messageTempId = 0;
            using (new GenericTracer("Facade"))
            {
                try
                {
                    messageTempId = logdao.EditExceptionMessage(messageId, mnemonic, subcategory, message);
                }
                catch (AmadeusBBTurGeneralException)
                {
                    throw;
                }
                catch (Exception e)
                {
                    bool rethrow = ExceptionPolicy.HandleException(e, "Log policy");
                    if (rethrow)
                    {
                        throw;
                    }
                }
            }
            return messageTempId;
        }
        #endregion
    }
}