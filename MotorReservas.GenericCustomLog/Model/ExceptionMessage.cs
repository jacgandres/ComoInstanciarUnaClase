
namespace GenericCustomLog.Model
{
    public class ExceptionMessage
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _mnemonic;

        public string Mnemonic
        {
            get { return _mnemonic; }
            set { _mnemonic = value; }
        }

        private string _subcategory;

        public string Subcategory
        {
            get { return _subcategory; }
            set { _subcategory = value; }
        }

        private string _message;

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }


        public ExceptionMessage()
        {
        }


    }
}
