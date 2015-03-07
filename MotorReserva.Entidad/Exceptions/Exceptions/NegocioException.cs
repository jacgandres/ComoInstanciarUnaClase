using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace MotorReservas.Entidad.Exceptions.Exceptions
{
    public class NegocioException : Exception
    {
        public string Messages { get; set; }
        public string CodigoError { get; set; }
        public NegocioException(params object[] pParams)
            : base(pParams[0] != null && (string.IsNullOrEmpty(pParams[0].ToString()) != false) ? pParams[0].ToString() : ((Exception)pParams[1]).Message, (Exception)pParams[1])
        {
            this.Messages = pParams[0] != null && (string.IsNullOrEmpty(pParams[0].ToString()) != false) ? ((Exception)pParams[1]).Message : pParams[0].ToString();

            this.CodigoError = string.Format("ERR{0}{1}{2}{3}-{4}", pParams[3], pParams[4], pParams[5], pParams[6], pParams[2]);

        }

        public NegocioException(string pMensaje, Exception pInnerException)
            : base(pMensaje, pInnerException)
        {
        }

        protected NegocioException(SerializationInfo pInfo, StreamingContext pContext)
            : base(pInfo, pContext)
        {
        }

        public NegocioException()
            : base()
        {
        }

        public NegocioException(string pError)
            : base(pError)
        {
            string[] param = pError.Split('*');

            if (param.Length > 0)
            {
                this.Messages = param[1];
                this.CodigoError = param[0];
            }
            else
                this.Messages = pError;
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
