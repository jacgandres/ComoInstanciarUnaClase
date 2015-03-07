using System;
using System.Runtime.Serialization;
using System.Security.Permissions;
using MotorReserva.Entidad;


namespace MotorReservas.Entidad.Exceptions.Exceptions
{
    [Serializable]
    public class ServiceException : Exception
    {
        private CODIGO_EXCEPCION_COMUNICACION _codigo;
        public string Messages { get; set; }
        public string CodigoError { get; set; }
        public string CodigoBase
        {
            get
            {
                return Enum.Format(typeof(CODIGO_EXCEPCION_COMUNICACION), _codigo, "D");
            }
        }

        public CODIGO_EXCEPCION_COMUNICACION Codigo
        {
            get
            {
                return _codigo;
            }
        }

        public ServiceException(params object[] pParams)
            : base(pParams[0] != null && (string.IsNullOrEmpty(pParams[0].ToString()) != false) ? pParams[0].ToString() : ((Exception)pParams[1]).Message, (Exception)pParams[1])
        {
            this.Messages = pParams[0] != null && (string.IsNullOrEmpty(pParams[0].ToString()) != false) ? ((Exception)pParams[1]).Message : pParams[0].ToString();

            this.CodigoError = string.Format("ERR{0}{1}{2}{3}-{4}", pParams[3], pParams[4], pParams[5], pParams[6], pParams[2]);
             
        }

        public ServiceException(string pMensaje, CODIGO_EXCEPCION_COMUNICACION pCodigo)
            : base(pMensaje)
        {
            _codigo = pCodigo;
        }

        public ServiceException(string pMensaje, CODIGO_EXCEPCION_COMUNICACION pCodigo, Exception pInnerException)
            : base(pMensaje, pInnerException)
        {
            _codigo = pCodigo;
        }

        public ServiceException(string pMensaje, Exception pInnerException)
            : base(pMensaje, pInnerException)
        {
        }

        protected ServiceException(SerializationInfo pInfo, StreamingContext pContext)
            : base(pInfo, pContext)
        {
        }

        public ServiceException()
            : base()
        {
        }

        public ServiceException(string pMensaje)
            : base(pMensaje)
        {
            this.Messages = pMensaje;
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
