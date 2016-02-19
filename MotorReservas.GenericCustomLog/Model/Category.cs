
namespace GenericCustomLog.Model
{
    public class Category
    {
        private int _categoryid;
        private string _categoryname;

        public int Categoryid
        {
            get { return _categoryid; }
            set { _categoryid = value; }
        }
        
        public string Categoryname
        {
            get { return _categoryname; }
            set { _categoryname = value; }
        }
    }
}