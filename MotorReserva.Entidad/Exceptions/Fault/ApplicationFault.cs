
using System;
using System.Runtime.Serialization;
namespace MotorReservas.Entidad.Exceptions.Exceptions
{
    [DataContract]
    [Serializable]
    public class ApplicationFault
    {
        #region Campos

        private const string estadoExcepcion = "ER-N";

        private string estado;
        private string tipo;
        private string codigo;
        private string descripcion;
        private string inner;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor para excepciones de negocio (código especificado en throw)
        /// </summary>
        public ApplicationFault(string tipo, string codigo, string descripcion, string pInner, string pErrorConsecutiveId)
        {
            this.estado = estadoExcepcion;
            this.tipo = tipo;
            this.codigo = pErrorConsecutiveId;
            this.descripcion = descripcion + "^" + pErrorConsecutiveId;
            this.inner = pInner;
            this.ErrorConsecutiveId = pErrorConsecutiveId;
        }

        #endregion

        #region Propiedades

        [DataMember(IsRequired = true)]
        public string Estado
        {
            get
            {
                return estado;
            }
            set
            {
                estado = value;
            }
        }

        [DataMember(IsRequired = true)]
        public string Tipo
        {
            get
            {
                return tipo;
            }
            set
            {
                tipo = value;
            }
        }

        [DataMember(IsRequired = true)]
        public string Codigo
        {
            get
            {
                return codigo;
            }
            set
            {
                codigo = value;
            }
        }

        [DataMember(IsRequired = true)]
        public string Descripcion
        {
            get
            {
                return descripcion;
            }
            set
            {
                descripcion = value;
            }
        }
        [DataMember(IsRequired = true)]
        public string Inner
        {
            get
            {
                return inner;
            }
            set
            {
                inner = value;
            }
        }
        [DataMember(IsRequired = true)]
        public string ErrorConsecutiveId { get; set; }

        #endregion
    }
}
