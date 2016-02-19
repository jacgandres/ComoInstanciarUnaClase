using System.Collections;

namespace GenericCustomLog.BusinessLogic
{
    public sealed class ExceptionMessageDictionary
    {
        static readonly ExceptionMessageDictionary instance = new ExceptionMessageDictionary();
        private IDictionary exceptionMessageHash = new Hashtable();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static ExceptionMessageDictionary()
        {
            LogFacade logFacade = new LogFacade();
            //exceptionMessageHash = logFacade.getAllLogMessages();
        }

        ExceptionMessageDictionary()
        {
            ICustomLog logFacade = new LogFacade();
            this.exceptionMessageHash = logFacade.getAllLogMessages();
        }

        public static ExceptionMessageDictionary Instance
        {
            get
            {
                if (instance.exceptionMessageHash.Count == 0)
                {
                    ICustomLog logFacade = new LogFacade();
                    instance.exceptionMessageHash = logFacade.getAllLogMessages();
                }
                return instance;
            }
        }

        public string getExceptionMessage(string mnemonic, string subcategory)
        {
            return exceptionMessageHash[mnemonic + "-" + subcategory].ToString();
        }
    }
}
