using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace GenericCustomLog
{
    public class LogGenericDAO : IDisposable
    {  
        public LogGenericDAO() {   }
        ~LogGenericDAO() {  }

        public long CreateLog(GenericTracerLogListener pLogEntry)
        {
            long logId = 1;
            try
            {
                System.Text.StringBuilder properties = new System.Text.StringBuilder();
                System.Text.StringBuilder categories = new System.Text.StringBuilder();

                pLogEntry.Categories.ForEach(cat => categories.AppendLine(cat));
                pLogEntry.ExtendedProperties.ForEach(cat => properties.AppendLine(cat));

                GenericDatabase db = new GenericDatabase((MotorReservas.GenericCustomLog.LogSettings.Default.StringConection), System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient"));
                DbCommand dbCommand = db.GetStoredProcCommand("CreateLog");
                db.AddInParameter(dbCommand, "IsTrace", DbType.Byte, pLogEntry.IsTrace);
                db.AddInParameter(dbCommand, "ModuleId", DbType.Int16, pLogEntry.ModuleId);
                db.AddInParameter(dbCommand, "ElapsedTime", DbType.Decimal, pLogEntry.ElapsedTime);
                db.AddInParameter(dbCommand, "RecordLocator", DbType.String, pLogEntry.RecordLocator);
                db.AddInParameter(dbCommand, "Action", DbType.String, pLogEntry.Action);
                db.AddInParameter(dbCommand, "appUsuarioCorreo", DbType.String, pLogEntry.AppUserId);
                db.AddInParameter(dbCommand, "appUsuarioNombre", DbType.String, pLogEntry.appUsuarioNombre);
                db.AddInParameter(dbCommand, "FormattedMessage", DbType.String, pLogEntry.FormattedMessage);
                db.AddInParameter(dbCommand, "Priority", DbType.String, pLogEntry.Priority);
                db.AddInParameter(dbCommand, "Severity", DbType.String, pLogEntry.Severity);
                db.AddInParameter(dbCommand, "Title", DbType.String, pLogEntry.Title);
                db.AddInParameter(dbCommand, "Type", DbType.String, pLogEntry.Type);
                db.AddInParameter(dbCommand, "MessageExplicitError", DbType.String, pLogEntry.MessageExplicitError);
                db.AddInParameter(dbCommand, "Status", DbType.String, pLogEntry.Status);
                db.AddInParameter(dbCommand, "StackTrace", DbType.String, pLogEntry.StackTrace);
                db.AddInParameter(dbCommand, "Params", DbType.String, pLogEntry.Params);
                db.AddInParameter(dbCommand, "TracerGuid", DbType.String, pLogEntry.TracerGuid.ToString());
                db.AddInParameter(dbCommand, "Categories", DbType.String, categories.ToString());
                db.AddInParameter(dbCommand, "ExtendedProperties", DbType.String, properties.ToString());
                db.AddInParameter(dbCommand, "LogId", DbType.Int32, pLogEntry.LogId);

                DataSet result = db.ExecuteDataSet(dbCommand);
                if (result != null && result.Tables != null && result.Tables.Count > 0)
                {
                    if (result.Tables[0].Columns.Count < 2)
                        logId = (long)result.Tables[0].Rows[0][0];
                }
            }
            catch (SqlException exc)
            {
                throw exc;
            }
            finally
            {
            }
            return logId;
        }

        public void Dispose() {  }
    }
}
