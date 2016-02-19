using System;

namespace GenericCustomLog.Exceptions
{
    public class AviaturException : Exception
    {
        public string param1 { get; set; }
        public string param2 { get; set; }
        public string param3 { get; set; }
        public string param4 { get; set; }
        public string param5 { get; set; }
        public AviaturException() { }
        public AviaturException(params object[] parametros) 
        {
            param1 = "";
        }
    }
}
