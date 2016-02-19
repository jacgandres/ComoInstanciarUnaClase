using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorReserva.Entidad
{
    [Serializable]
    public enum ENUMERACION_MODULOS : int
    {
        Administrativo = 1,
        Inventario = 2,
        Reservas = 3,
        Clientes
    }

    [Serializable]
    public enum TIPO_LOG
    {
        AUD,
        ERR
    }

    [Serializable]
    public enum NOMBRE_COMPONENTES
    {
        IntegradorNegocio,
        IntegradorWeb,
        Caching,
        Logging,
        Manejador_Excepciones,
        Cotizaciones,
        Perfil_Pasajero,
        Cliente,
        Revisados,
        Solicitud,
        Control_Calidad_2,
        Seguridad,
        Call_Center,
        Emision,
        Presentacion,
        Consultas_Generales,
        Usuario,
        MultiIdioma
    }

    [Serializable]
    public enum CODIGO_AUDITORIA_CAMBIO_INFORMACION : int
    {
        Insercion = 1001,
        Actualizacion = 1002,
        Eliminacion = 1003,
        Consulta = 1004
    }
    [Serializable]
    public enum CODIGO_AUDITORIA_TIEMPO_TIPO_PROCESO : int
    {
        Pos_Bolivar = 2001,
        ESB = 2002,
        MPT = 2003,
        Presentacion = 2005
    }

    [Serializable]
    public enum CODIGO_EXCEPCION_NEGOCIO : int
    {
        Codigo_Datos_Incompletos = 1100,
        Codigo_Indeterminado = 1000
    }
    [Serializable]
    public enum CODIGO_EXCEPCION_COMUNICACION : int
    {
        Codigo_Indeterminado = 2000,
        Codigo_Tiempo_Espera = 2100,
        Codigo_Interno_Servicio = 2200,
        Codigo_Formato_Soap = 2300
    }
    [Serializable]
    public enum CODIGO_EXCEPCION_PRESENTACION : int
    {
        Codigo_Indeterminado = 3000,
    }
    [Serializable]
    public enum CODIGO_EXCEPCION_INDETERMINADO : int
    {
        Codigo_Indeterminado = 2000,
        Codigo_Null_Reference = 2100,
        Codigo_Fuera_Limite_Lista = 2200,
        Codigo_Error_Archivo_MultiIdioma = 2300
    }

    [Serializable]
    public enum DATA_SOURCE_LIST : int
    {
        AmadeuscodeList = 1,
        GeneralList = 2
    }

    
}
