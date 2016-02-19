using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using GenericCustomLog.Model;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Newtonsoft.Json;

namespace GenericCustomLog.Persistence
{
    public class LogDAO
    {
        public List<Log> getAllLogs()
        {
            List<Log> lista = new List<Log>();
            GenericDatabase db = new GenericDatabase((ConfigurationManager.ConnectionStrings["BBTur"].ConnectionString), System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient"));
            
            string sqlCommand = "getAllLogs";
            
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            StringBuilder readerData = new StringBuilder();

            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    Log log = new Log();
                    log.LogId = int.Parse(dataReader["LogId"].ToString());
                    log.CategoryId = int.Parse(dataReader["CategoryID"].ToString());
                    log.Category = dataReader["CategoryName"].ToString();
                    log.ModuleId = int.Parse(dataReader["ModuleId"].ToString());
                    log.Module = dataReader["ModuleName"].ToString();
                    log.RecordLocator = dataReader["RecordLocator"].ToString();
                    log.Message = dataReader["Message"].ToString();
                    log.Date = dataReader["Date"].ToString();
                    log.AppUserName = dataReader["UserName"].ToString();
                    log.Priority = int.Parse(dataReader["priority"].ToString());
                    lista.Add(log);
                }
            }            
            return lista;
        }

        public List<Log> getLogsParameters(DateTime dtInitial,
                                           DateTime dtFinal,
                                           int intModuleId,
                                           int intCategoryId,
                                           string strRecordLocator,
                                           int intUserId)
        {
            List<Log> lista = new List<Log>();
            GenericDatabase db = new GenericDatabase((ConfigurationManager.ConnectionStrings["BBTur"].ConnectionString), System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient"));
            string sqlCommand = "getLogsParameter";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);


            if (intModuleId == 0 && intCategoryId == 0 && intUserId == 0 && strRecordLocator.Trim().Length == 0)
            {
                sqlCommand = "getLogsParameter";
                dbCommand.CommandText = sqlCommand;
                db.AddInParameter(dbCommand, "dtInitial", DbType.DateTime, DateTime.Parse(dtInitial.ToString("MM/dd/yyyy")));
                db.AddInParameter(dbCommand, "dtFinal", DbType.DateTime, DateTime.Parse(dtFinal.ToString("MM/dd/yyyy")));                
            }

            if (intModuleId > 0 && intCategoryId == 0 && intUserId == 0 && strRecordLocator.Trim().Length == 0)
            {
                sqlCommand = "getLogsParameter1";
                dbCommand.CommandText = sqlCommand;
                db.AddInParameter(dbCommand, "dtInitial", DbType.DateTime, dtInitial);
                db.AddInParameter(dbCommand, "dtFinal", DbType.DateTime, dtFinal);                  
                db.AddInParameter(dbCommand, "intModuleId", DbType.Int16, intModuleId);                 
            }

            if (intModuleId == 0 && intCategoryId > 0 && intUserId == 0 && strRecordLocator.Trim().Length == 0)
            {
                sqlCommand = "getLogsParameter2";
                dbCommand.CommandText = sqlCommand;
                db.AddInParameter(dbCommand, "dtInitial", DbType.DateTime, dtInitial);
                db.AddInParameter(dbCommand, "dtFinal", DbType.DateTime, dtFinal);                   
                db.AddInParameter(dbCommand, "intCategoryId", DbType.Int16, intCategoryId);                 
            }

            if (intModuleId == 0 && intCategoryId == 0 && intUserId > 0 && strRecordLocator.Trim().Length == 0)
            {
                sqlCommand = "getLogsParameter3";
                dbCommand.CommandText = sqlCommand;
                db.AddInParameter(dbCommand, "dtInitial", DbType.DateTime, dtInitial);
                db.AddInParameter(dbCommand, "dtFinal", DbType.DateTime, dtFinal);                  
                db.AddInParameter(dbCommand, "intUserId", DbType.Int16, intUserId);                 
            }

            if (intModuleId == 0 && intCategoryId == 0 && intUserId == 0 && strRecordLocator.Trim().Length > 0)
            {
                sqlCommand = "getLogsParameter4";
                dbCommand.CommandText = sqlCommand;
                db.AddInParameter(dbCommand, "dtInitial", DbType.DateTime, dtInitial);
                db.AddInParameter(dbCommand, "dtFinal", DbType.DateTime, dtFinal);                  
                db.AddInParameter(dbCommand, "strRecordLocator", DbType.String , strRecordLocator);                  
            }

            if (intModuleId > 0 && intCategoryId > 0 && intUserId == 0 && strRecordLocator.Trim().Length == 0)
            {
                sqlCommand = "getLogsParameter5";
                dbCommand.CommandText = sqlCommand;
                db.AddInParameter(dbCommand, "dtInitial", DbType.DateTime, dtInitial);
                db.AddInParameter(dbCommand, "dtFinal", DbType.DateTime, dtFinal);                  
                db.AddInParameter(dbCommand, "intModuleId", DbType.Int16, intModuleId);
                db.AddInParameter(dbCommand, "intCategoryId", DbType.Int16, intCategoryId);                 
            }

            if (intModuleId > 0 && intCategoryId == 0 && intUserId > 0 && strRecordLocator.Trim().Length == 0)
            {
                sqlCommand = "getLogsParameter6";
                dbCommand.CommandText = sqlCommand;
                db.AddInParameter(dbCommand, "dtInitial", DbType.DateTime, dtInitial);
                db.AddInParameter(dbCommand, "dtFinal", DbType.DateTime, dtFinal);                  
                db.AddInParameter(dbCommand, "intModuleId", DbType.Int16, intModuleId);
                db.AddInParameter(dbCommand, "intUserId", DbType.Int16, intUserId);                                 
            }

            if (intModuleId > 0 && intCategoryId == 0 && intUserId == 0 && strRecordLocator.Trim().Length > 0)
            {
                sqlCommand = "getLogsParameter7";
                dbCommand.CommandText = sqlCommand;
                db.AddInParameter(dbCommand, "dtInitial", DbType.DateTime, dtInitial);
                db.AddInParameter(dbCommand, "dtFinal", DbType.DateTime, dtFinal);                
                db.AddInParameter(dbCommand, "intModuleId", DbType.Int16, intModuleId);
                db.AddInParameter(dbCommand, "strRecordLocator", DbType.String , strRecordLocator);                                                 
            }

            if (intModuleId == 0 && intCategoryId > 0 && intUserId > 0 && strRecordLocator.Trim().Length == 0)
            {
                sqlCommand = "getLogsParameter8";
                dbCommand.CommandText = sqlCommand;
                db.AddInParameter(dbCommand, "dtInitial", DbType.DateTime, dtInitial);
                db.AddInParameter(dbCommand, "dtFinal", DbType.DateTime, dtFinal);     
                db.AddInParameter(dbCommand, "intCategoryId", DbType.Int16, intCategoryId);
                db.AddInParameter(dbCommand, "intUserId", DbType.Int16, intUserId);                
            }

            if (intModuleId == 0 && intCategoryId > 0 && intUserId == 0 && strRecordLocator.Trim().Length > 0)
            {
                sqlCommand = "getLogsParameter9";
                dbCommand.CommandText = sqlCommand;
                db.AddInParameter(dbCommand, "dtInitial", DbType.DateTime, dtInitial);
                db.AddInParameter(dbCommand, "dtFinal", DbType.DateTime, dtFinal);   
                db.AddInParameter(dbCommand, "intCategoryId", DbType.Int16, intCategoryId);
                db.AddInParameter(dbCommand, "strRecordLocator", DbType.String , strRecordLocator);                    
            }

            if (intModuleId == 0 && intCategoryId == 0 && intUserId > 0 && strRecordLocator.Trim().Length > 0)
            {
                sqlCommand = "getLogsParameter10";
                dbCommand.CommandText = sqlCommand;
                db.AddInParameter(dbCommand, "dtInitial", DbType.DateTime, dtInitial);
                db.AddInParameter(dbCommand, "dtFinal", DbType.DateTime, dtFinal);                   
                db.AddInParameter(dbCommand, "intUserId", DbType.Int16, intUserId);
                db.AddInParameter(dbCommand, "strRecordLocator", DbType.String, strRecordLocator);                                   
            }

            if (intModuleId > 0 && intCategoryId > 0 && intUserId > 0 && strRecordLocator.Trim().Length == 0)
            {
                sqlCommand = "getLogsParameter11";
                dbCommand.CommandText = sqlCommand;
                db.AddInParameter(dbCommand, "dtInitial", DbType.DateTime, dtInitial);
                db.AddInParameter(dbCommand, "dtFinal", DbType.DateTime, dtFinal);                   
                db.AddInParameter(dbCommand, "intModuleId", DbType.Int16, intModuleId);
                db.AddInParameter(dbCommand, "intCategoryId", DbType.Int16, intCategoryId);
                db.AddInParameter(dbCommand, "intUserId", DbType.Int16, intUserId);                  
            }

            if (intModuleId > 0 && intCategoryId > 0 && intUserId > 0 && strRecordLocator.Trim().Length > 0)
            {
                sqlCommand = "getLogsParameter12";
                dbCommand.CommandText = sqlCommand;
                db.AddInParameter(dbCommand, "dtInitial", DbType.DateTime, dtInitial);
                db.AddInParameter(dbCommand, "dtFinal", DbType.DateTime, dtFinal);   
                db.AddInParameter(dbCommand, "intModuleId", DbType.Int16, intModuleId);
                db.AddInParameter(dbCommand, "intCategoryId", DbType.Int16, intCategoryId);
                db.AddInParameter(dbCommand, "intUserId", DbType.Int16, intUserId);
                db.AddInParameter(dbCommand, "strRecordLocator", DbType.String , strRecordLocator);                 
            }

            StringBuilder readerData = new StringBuilder();
            try
            {
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        Log log = new Log();
                        log.LogId = int.Parse(dataReader["LogId"].ToString());
                        log.CategoryId = int.Parse(dataReader["CategoryID"].ToString());
                        log.Category = dataReader["CategoryName"].ToString();
                        log.ModuleId = int.Parse(dataReader["ModuleId"].ToString());
                        log.Module = dataReader["ModuleName"].ToString();
                        log.RecordLocator = dataReader["RecordLocator"].ToString();
                        log.Message = dataReader["Message"].ToString();
                        log.Date = dataReader["Date"].ToString();
                        log.AppUserName = dataReader["UserName"].ToString();
                        log.Priority = int.Parse(dataReader["priority"].ToString());
                        
                        lista.Add(log);
                    }

                    Log log1 = new Log();
                    log1.logEntry.Categories.Add("Trace");
                    log1.logEntry.Categories.Add("Database");
                    log1.logEntry.Severity = System.Diagnostics.TraceEventType.Information;
                    log1.Message = "List Log: " + DateTime.Parse(dtInitial.ToString("MM/dd/yyyy")).ToString() + "," + DateTime.Parse(dtFinal.ToString("MM/dd/yyyy")).ToString() + "," + intModuleId + "," + intCategoryId;
                    log1.Priority = 5;
                    log1.RecordLocator = "NA";
                    log1.ModuleId = 0;
                    if (Logger.ShouldLog(log1.logEntry))
                    {
                        Logger.Write(log1.logEntry);
                    }
                }
            }
            catch (SqlException Ex)
            {
                Log log1 = new Log();
                log1.logEntry.Categories.Add("Error");
                log1.logEntry.Categories.Add("Database");
                log1.logEntry.Severity = System.Diagnostics.TraceEventType.Error;
                log1.Message = Ex.Message + "-" + Ex.StackTrace;
                log1.Priority = 1;
                log1.RecordLocator = "NA";
                log1.ModuleId = 0;
                Logger.Write(log1.logEntry);
            }

            return lista;
            
        }



        public List<ExceptionMessage> getAllLogMessages()
        {
            List<ExceptionMessage> messages = new List<ExceptionMessage>();
            ExceptionMessage message = null;
            using (new GenericTracer("Database"))
            {
                // DataReader that will hold the returned results		
                // Create the Database object, using the default database service. The
                // default database service is determined through configuration.

                GenericDatabase db = new GenericDatabase((ConfigurationManager.ConnectionStrings["BBTur"].ConnectionString), System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient"));

                string sqlCommand = "getAllExceptionMessages";

                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                //db.AddInParameter(dbCommand, "mnemonic", DbType.String, mnemonic);

                StringBuilder readerData = new StringBuilder();

                // The ExecuteReader call will request the connection to be closed upon
                // the closing of the DataReader. The DataReader will be closed 
                // automatically when it is disposed.
                try
                {
                    using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                    {
                        // Iterate through DataReader and put results to the text box.
                        // DataReaders cannot be bound to Windows Form controls (e.g. the
                        // resultsDataGrid), but may be bound to Web Form controls.
                        while (dataReader.Read())
                        {
                            message = new ExceptionMessage();

                            //messageHash.Add(dataReader["mnemonic"].ToString() + "-" + dataReader["subcategory"].ToString(), dataReader["message"].ToString());
                            message.Id = int.Parse(dataReader["id"].ToString());
                            message.Mnemonic = dataReader["mnemonic"].ToString();
                            message.Subcategory = dataReader["subcategory"].ToString();
                            message.Message = dataReader["message"].ToString();

                            messages.Add(message);
                        }
                        //Logging information for tracing purpose
                        Log log = new Log();

                        log.logEntry.Categories.Add("Log");
                        log.logEntry.Severity = System.Diagnostics.TraceEventType.Information;
                        log.Message = messages.ToString();
                        log.Priority = 5;
                        log.RecordLocator = "";
                        log.ModuleId = 0;
                        log.Action = "Get Exception Messages";
                        if (Logger.ShouldLog(log.logEntry))
                        {
                            Logger.Write(log.logEntry);
                        }
                    }
                }
                catch (SqlException e)
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

        internal int getTotalLogs()
        {
            int total = 0;
            // DataReader that will hold the returned results		
            // Create the Database object, using the default database service. The
            // default database service is determined through configuration.

            GenericDatabase db = new GenericDatabase((ConfigurationManager.ConnectionStrings["BBTur"].ConnectionString), System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient"));

            string sqlCommand = "GetTotalLogs";

            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            StringBuilder readerData = new StringBuilder();

            // The ExecuteReader call will request the connection to be closed upon
            // the closing of the DataReader. The DataReader will be closed 
            // automatically when it is disposed.
            try
            {
                Object obj = db.ExecuteScalar(dbCommand);
                total = obj != null ? int.Parse(obj.ToString()) : 0;

            }
            catch (SqlException e)
            {
                bool rethrow = ExceptionPolicy.HandleException(e, "Log policy");
                if (rethrow)
                {
                    throw;
                }
            }
            return total;
        }

        internal List<Log> getAllLogs(string sortParam, string sortOrder, int bottom, int top, bool search, string signin, string severity, string logId, string recordLocator, string from, string to)
        {
            List<Log> logs = new List<Log>();
            Log log = null;
            // DataReader that will hold the returned results		
            // Create the Database object, using the default database service. The
            // default database service is determined through configuration.

            GenericDatabase db = new GenericDatabase((ConfigurationManager.ConnectionStrings["BBTur"].ConnectionString), System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient"));

            string searchQuery = "";
            if (search)
            {
                if (!String.IsNullOrEmpty(signin))
                {
                    searchQuery += " AND signin LIKE '" + signin + "'";
                }
                if (!String.IsNullOrEmpty(severity))
                {
                    searchQuery += " AND severity LIKE '" + severity + "'";
                }
                if (!String.IsNullOrEmpty(logId))
                {
                    searchQuery += " AND LogId = " + logId + "";
                }
                if (!String.IsNullOrEmpty(recordLocator))
                {
                    searchQuery += " AND RecordLocator like '" + recordLocator + "'";
                }

                if (!String.IsNullOrEmpty(from) && !String.IsNullOrEmpty(to))
                {
                    searchQuery += " AND Date BETWEEN '" + from + "' AND '" + to + "' ";
                }
            }

            string innerQuery = "SELECT ROW_NUMBER() OVER(ORDER BY " + sortParam + " " + sortOrder + ") AS rownum" + 
            ", LogId, ModuleId, RecordLocator, Message, Date, signin, priority, method, action, isTrace, severity FROM BBTurLog" +
            " WHERE isTrace <> 1" + searchQuery;
            
            string sqlQuery = "SELECT * FROM   (" + innerQuery + ") AS BBTurLog1";
            sqlQuery += " WHERE  rownum >= " + bottom + " AND rownum <= " + top + " ORDER BY " + sortParam + " " + sortOrder;

            DbCommand dbCommand = db.GetSqlStringCommand(sqlQuery);

            StringBuilder readerData = new StringBuilder();

            // The ExecuteReader call will request the connection to be closed upon
            // the closing of the DataReader. The DataReader will be closed 
            // automatically when it is disposed.
            try
            {
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    // Iterate through DataReader and put results to the text box.
                    // DataReaders cannot be bound to Windows Form controls (e.g. the
                    // resultsDataGrid), but may be bound to Web Form controls.
                    while (dataReader.Read())
                    {
                        log = new Log();
                        log.LogId = int.Parse(dataReader["LogId"].ToString());
                        log.ModuleId = int.Parse(dataReader["ModuleId"].ToString());
                        //log.Module = dataReader["ModuleName"].ToString();
                        log.RecordLocator = dataReader["RecordLocator"].ToString();
                        log.Message = dataReader["Message"].ToString();
                        log.Date = dataReader["Date"].ToString();
                        log.AppUserName = dataReader["signin"].ToString();
                        log.Priority = int.Parse(dataReader["priority"].ToString());
                        log.Title = dataReader["method"].ToString();
                        log.Action = dataReader["action"].ToString();
                        log.Severity = dataReader["severity"].ToString();
                        
                        logs.Add(log);
                    }
                    //Logging information for tracing purpose
                    Log logTmp = new Log();
                    logTmp.logEntry.Categories.Add("Trace");
                    logTmp.logEntry.Categories.Add("Database");
                    logTmp.logEntry.Severity = System.Diagnostics.TraceEventType.Information;
                    //logTmp.Message = JsonConvert.SerializeObject(airports);
                    logTmp.Priority = 5;
                    logTmp.RecordLocator = "NA";
                    logTmp.ModuleId = 0;
                    if (Logger.ShouldLog(logTmp.logEntry))
                    {
                        Logger.Write(logTmp.logEntry);
                    }
                }
            }
            catch (SqlException e)
            {
                bool rethrow = ExceptionPolicy.HandleException(e, "Log policy");
                if (rethrow)
                {
                    throw;
                }
            }
            return logs;
        }

        internal Log getLog(int logId)
        {
            Log log = null;
            // DataReader that will hold the returned results		
            // Create the Database object, using the default database service. The
            // default database service is determined through configuration.

            GenericDatabase db = new GenericDatabase((ConfigurationManager.ConnectionStrings["BBTur"].ConnectionString), System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient"));

            string sqlCommand = "GetLogById";

            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            db.AddInParameter(dbCommand, "logId", DbType.Int32, logId);

            StringBuilder readerData = new StringBuilder();

            // The ExecuteReader call will request the connection to be closed upon
            // the closing of the DataReader. The DataReader will be closed 
            // automatically when it is disposed.
            try
            {
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    // Iterate through DataReader and put results to the text box.
                    // DataReaders cannot be bound to Windows Form controls (e.g. the
                    // resultsDataGrid), but may be bound to Web Form controls.
                    if (dataReader.Read())
                    {
                        log = new Log();
                        log.LogId = int.Parse(dataReader["LogId"].ToString());
                        log.ModuleId = int.Parse(dataReader["ModuleId"].ToString());
                        //log.Module = dataReader["ModuleName"].ToString();
                        log.RecordLocator = dataReader["RecordLocator"].ToString();
                        log.Message = dataReader["Message"].ToString();
                        log.Date = dataReader["Date"].ToString();
                        log.AppUserName = dataReader["signin"].ToString();
                        log.Priority = int.Parse(dataReader["priority"].ToString());
                        log.Title = dataReader["method"].ToString();
                        log.Action = dataReader["action"].ToString();
                        log.Severity = dataReader["severity"].ToString();
                    }
                    //Logging information for tracing purpose
                    Log logTmp = new Log();
                    logTmp.logEntry.Categories.Add("Trace");
                    logTmp.logEntry.Categories.Add("Database");
                    logTmp.logEntry.Severity = System.Diagnostics.TraceEventType.Information;
                    //logTmp.Message = JsonConvert.SerializeObject(airports);
                    logTmp.Priority = 5;
                    logTmp.RecordLocator = "NA";
                    logTmp.ModuleId = 0;
                    if (Logger.ShouldLog(logTmp.logEntry))
                    {
                        Logger.Write(logTmp.logEntry);
                    }
                }
            }
            catch (SqlException e)
            {
                bool rethrow = ExceptionPolicy.HandleException(e, "Log policy");
                if (rethrow)
                {
                    throw;
                }
            }
            return log;
        }

        internal int getSearchTotalLogs(string signin, string severity, string logId, string recordLocator, string from, string to)
        {
            int total = 0;
            // DataReader that will hold the returned results		
            // Create the Database object, using the default database service. The
            // default database service is determined through configuration.

            GenericDatabase db = new GenericDatabase((ConfigurationManager.ConnectionStrings["BBTur"].ConnectionString), System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient"));

            string searchQuery = "";
            if (!String.IsNullOrEmpty(signin))
            {
                searchQuery += " AND signin LIKE '" + signin + "'";
            }
            if (!String.IsNullOrEmpty(severity))
            {
                searchQuery += " AND severity LIKE '" + severity + "'";
            }
            if (!String.IsNullOrEmpty(logId))
            {
                searchQuery += " AND LogId = " + logId + "";
            }
            if (!String.IsNullOrEmpty(recordLocator))
            {
                searchQuery += " AND RecordLocator like '" + recordLocator + "'";
            }

            if (!String.IsNullOrEmpty(from) && !String.IsNullOrEmpty(to))
            {
                searchQuery += " AND Date BETWEEN '" + from + "' AND '" + to + "' ";
            }


            string sqlQuery = "SELECT Count(LogId) FROM BBTurLog WHERE isTrace <> 1" + searchQuery;

            DbCommand dbCommand = db.GetSqlStringCommand(sqlQuery);

            StringBuilder readerData = new StringBuilder();

            // The ExecuteReader call will request the connection to be closed upon
            // the closing of the DataReader. The DataReader will be closed 
            // automatically when it is disposed.
            try
            {
                Object obj = db.ExecuteScalar(dbCommand);
                total = obj != null ? int.Parse(obj.ToString()) : 0;

            }
            catch (SqlException e)
            {
                bool rethrow = ExceptionPolicy.HandleException(e, "Log policy");
                if (rethrow)
                {
                    throw;
                }
            }
            return total;
        }

        internal int AddExceptionMessage(string mnemonic, string subcategory, string message)
        {
            int messageId = 0;
            using (new GenericTracer("Database"))
            {
                // DataReader that will hold the returned results		
                // Create the Database object, using the default database service. The
                // default database service is determined through configuration.
                try
                {
                    string sqlCommand = "AddExceptionMessage";

                    GenericDatabase db = new GenericDatabase((ConfigurationManager.ConnectionStrings["BBTur"].ConnectionString), System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient"));

                    DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                    db.AddInParameter(dbCommand, "mnemonic", DbType.String, mnemonic);
                    db.AddInParameter(dbCommand, "subcategory", DbType.String, subcategory);
                    db.AddInParameter(dbCommand, "message", DbType.String, message);

                    // The ExecuteReader call will request the connection to be closed upon
                    // the closing of the DataReader. The DataReader will be closed 
                    // automatically when it is disposed.

                    messageId = int.Parse(db.ExecuteScalar(dbCommand).ToString());
                    //Logging information for tracing purpose

                    Log log = new Log();
                    log.logEntry.Categories.Add("Database");
                    log.logEntry.Severity = System.Diagnostics.TraceEventType.Information;
                    log.Priority = 5;
                    log.RecordLocator = "";
                    log.ModuleId = 0;
                    if (Logger.ShouldLog(log.logEntry))
                    {
                        ExceptionMessage exceptionmessage = new ExceptionMessage();
                        exceptionmessage.Id = messageId;
                        exceptionmessage.Mnemonic = mnemonic;
                        exceptionmessage.Subcategory = subcategory;
                        exceptionmessage.Message = message;

                        log.Message = "addUser: " + JsonConvert.SerializeObject(exceptionmessage);
                        Logger.Write(log.logEntry);
                    }

                }
                catch (SqlException e)
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

        internal int EditExceptionMessage(int messageId, string mnemonic, string subcategory, string message)
        {
            int messageTempId = 0;
            using (new GenericTracer("Database"))
            {
                // DataReader that will hold the returned results		
                // Create the Database object, using the default database service. The
                // default database service is determined through configuration.
                try
                {
                    string sqlCommand = "EditExceptionMessage";

                    GenericDatabase db = new GenericDatabase((ConfigurationManager.ConnectionStrings["BBTur"].ConnectionString), System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient"));

                    DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                    db.AddInParameter(dbCommand, "messageId", DbType.Int32, messageId);
                    db.AddInParameter(dbCommand, "mnemonic", DbType.String, mnemonic);
                    db.AddInParameter(dbCommand, "subcategory", DbType.String, subcategory);
                    db.AddInParameter(dbCommand, "message", DbType.String, message);

                    // The ExecuteReader call will request the connection to be closed upon
                    // the closing of the DataReader. The DataReader will be closed 
                    // automatically when it is disposed.

                    messageTempId = db.ExecuteNonQuery(dbCommand);
                    //Logging information for tracing purpose

                    Log log = new Log();
                    log.logEntry.Categories.Add("Database");
                    log.logEntry.Severity = System.Diagnostics.TraceEventType.Information;
                    log.Priority = 5;
                    log.RecordLocator = "";
                    log.ModuleId = 0;
                    if (Logger.ShouldLog(log.logEntry))
                    {
                        ExceptionMessage exceptionmessage = new ExceptionMessage();
                        exceptionmessage.Id = messageId;
                        exceptionmessage.Mnemonic = mnemonic;
                        exceptionmessage.Subcategory = subcategory;
                        exceptionmessage.Message = message;

                        log.Message = "editUser: " + JsonConvert.SerializeObject(exceptionmessage);
                        Logger.Write(log.logEntry);
                    }

                }
                catch (SqlException e)
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
    }
}