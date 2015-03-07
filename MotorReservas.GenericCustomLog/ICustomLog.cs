using System;
using System.Collections;
using System.Collections.Generic;
using GenericCustomLog.Model;

public interface ICustomLog
{
    List<Log> getAllLogs();
    List<Log> getLogsParameters(DateTime dtInitial,
                                DateTime dtFinal,
                                int intModuleId,
                                int intCategoryId,
                                string strRecordLocator,
                                int intUserId);

    List<Log> getAllLogs(int page, int rows, string sortParam, string sortOrder, bool search, string signin, string severity, string logId, string recordLocator, string from, string to);

    int totalLogs();

    Log getLog(int logId);

    int totalSearchLogs(string signin, string severity, string logId, string recordLocator, string from , string to);

    List<ExceptionMessage> getLogMessages();

    Hashtable getAllLogMessages();

    int AddExceptionMessage(string mnemonic, string subcategory, string message);

    int EditExceptionMessage(int messageId, string mnemonic, string subcategory, string message);
}