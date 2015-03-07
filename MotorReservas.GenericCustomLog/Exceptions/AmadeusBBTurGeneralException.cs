using System;

namespace GenericCustomLog.Exceptions
{
    public class AmadeusBBTurGeneralException : Exception
    {
        private string logId;

        public string LogId
        {
            get { return logId; }
            set { logId = value; }
        }
        private static string unFormattedMessage = "Message id: {1} - {0}";

        public AmadeusBBTurGeneralException(string message, string code, Exception innerException) :
            base(String.Format(unFormattedMessage, message, code), innerException)
        {
            
        }

    }
}
