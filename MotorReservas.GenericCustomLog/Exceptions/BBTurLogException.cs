using System;

namespace GenericCustomLog.Exceptions
{
    public class BBTurLogException : AmadeusBBTurGeneralException
    {
        private string mnemonic;
        private int layer;

        public BBTurLogException(string message, Exception innerException, string logId, int layer, string mnemonic)
            : base(message, layer + mnemonic + logId.PadLeft(7, '0'), innerException)
        {
            this.LogId = logId;
            this.layer = layer;
            this.mnemonic = mnemonic;
        }
        public BBTurLogException(string message, Exception innerException, string logId)
            : base(message, logId.PadLeft(7, '0'), innerException)
        {
            this.LogId = logId;
        }

        public override string ToString()
        {
            return layer + mnemonic + this.LogId.PadLeft(7, '0') + " - " + this.Message;
        }
    }
}
