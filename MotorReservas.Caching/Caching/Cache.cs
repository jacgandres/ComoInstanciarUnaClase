using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;

namespace MotorReservas.Caching.Caching
{
    public enum TipoCache
    {
        Cache10Minutos,
        Cache1Hora,
        Cache4Horas,
        Cache1Dia,
        Cache1Semana
    }

    /// <summary>
    /// Clase encargada de manejar el cache de la aplicación
    /// </summary>
    public class Cache
    {
        private ICacheManager cache;

        /// <summary>
        /// Crea una instancia de 1 hora por defecto
        /// </summary>
        public Cache()
        {
            cache = CacheFactory.GetCacheManager("cache1hora");
        }

        /// <summary>
        /// Crear una instacia de la clase con el tiempo asignado
        /// </summary>
        /// <param name="tipo">Tipos: Cache10Minutos, Cache1hora, Cache4Horas</param>
        public Cache(TipoCache tipo)
        {
            switch (tipo)
            {
                case TipoCache.Cache10Minutos:
                    cache = CacheFactory.GetCacheManager("cache10minutos");
                    break;
                case TipoCache.Cache1Hora:
                    cache = CacheFactory.GetCacheManager("cache1hora");
                    break;
                case TipoCache.Cache4Horas:
                    cache = CacheFactory.GetCacheManager("cache4Horas");
                    break;
                default:
                    cache = CacheFactory.GetCacheManager("cache1hora");
                    break;
            }
        }

        /// <summary>
        /// Obtiene un objeto con un tipo de dato generico consultando en la base de datos
        /// </summary>
        /// <typeparam name="T">Tipo de dato del objeto</typeparam>
        /// <param name="Procedimiento">Nombre del Procedimiento Almacenado unido a la base de datos</param>
        /// <param name="Parametros">Parametros enviados al Procedimiento Almacenado</param>
        /// <returns>El objeto con tipo de dato definido por el usuario</returns>
        public T GetCache<T>(string Procedimiento, params object[] Parametros)
        {
            string key = CalculateKey(Procedimiento, Parametros);
            return (T)cache.GetData(key.ToString());
        }

        /// <summary>
        /// Almacena en cache la información del objeto con la llave Procedimiento + Parametros
        /// </summary>
        /// <typeparam name="T">Tipo de dato del objeto</typeparam>
        /// <param name="Data">objeto a almacenar</param>
        /// <param name="Procedimiento">Nombre del Procedimiento Almacenado unido a la base de datos</param>
        /// <param name="Parametros">Parametros enviados al Procedimiento Almacenado</param>
        public void SaveCache<T>(T Data, string Procedimiento, TipoCache pTipoCache, params object[] Parametros)
        {
            string key = CalculateKey(Procedimiento, Parametros);

            //cache.Add( key , Data );
            cache.Add(key, Data, CacheItemPriority.Normal, new CacheRefreshAction(), GetSlidingTime(pTipoCache));
        }


        /// <summary>
        /// Obtiene un objeto con un tipo de dato generico que se ha almacenado previamente
        /// </summary>
        /// <typeparam name="T">Tipo de dato del objeto</typeparam>
        /// <param name="pLlave">Llave con la cual se buscará en el cache</param>
        /// <returns>El objeto con tipo de dato definido por el usuario</returns>
        public T GetCache<T>(string pLlave)
        {
            return (T)cache.GetData(pLlave);
        }

        /// <summary>
        /// Almacena en cache la información de un objeto
        /// </summary>
        /// <param name="pLlave">Llave con la cual se almacenará en el cache</param>
        /// <param name="pObjeto">Objeto del tipo T a almacenar </param>
        public void SaveCache<T>(string pLlave, T pObjeto, TipoCache pTipoCache)
        {
            //cache.Add( pLlave , pObjeto );
            cache.Add(pLlave, pObjeto, CacheItemPriority.Normal, new CacheRefreshAction(), GetSlidingTime(pTipoCache));
        }

        private static string CalculateKey(string Metodo, params object[] Parametros)
        {
            StringBuilder key = new StringBuilder();
            key.Append(Metodo);
            int columna = 0;
            foreach (object str in Parametros)
            {
                if (str != null)
                {
                    string temp = String.Format("col{0}={1}", columna.ToString(), (str != null) ? str.ToString() : "#");
                    key.Append(temp);
                    columna++;
                }
            }

            return key.ToString();
        }

        public bool ResultExist(string Procedimiento, params object[] Parametros)
        {
            string key = CalculateKey(Procedimiento, Parametros);
            return cache.Contains(key.ToString());
        }

        public void FlushCache()
        {
            cache.Flush();
        }

        public void RemoveCacheByKey(List<string> pKeys)
        {
            foreach (string key in pKeys)
            {
                cache.Remove(key);
            }
        }

        /// <summary>
        /// Obtiene el slidingtime deacuerdo al tipo de cache definido en la enumeración por default es 1 hora
        /// </summary>
        /// <param name="pTipoCache"></param>
        /// <returns></returns>
        private static SlidingTime GetSlidingTime(TipoCache pTipoCache)
        {
            SlidingTime slidingTime = new SlidingTime(TimeSpan.FromHours(1));

            switch (pTipoCache)
            {
                case TipoCache.Cache10Minutos:
                    slidingTime = new SlidingTime(TimeSpan.FromMinutes(10));
                    break;
                case TipoCache.Cache1Hora:
                    slidingTime = new SlidingTime(TimeSpan.FromHours(1));
                    break;
                case TipoCache.Cache4Horas:
                    slidingTime = new SlidingTime(TimeSpan.FromHours(4));
                    break;
                case TipoCache.Cache1Dia:
                    slidingTime = new SlidingTime(TimeSpan.FromDays(1));
                    break;
                case TipoCache.Cache1Semana:
                    slidingTime = new SlidingTime(TimeSpan.FromDays(7));
                    break;
                default:
                    slidingTime = new SlidingTime(TimeSpan.FromHours(1));
                    break;
            }
            return slidingTime;
        }

        /// <summary>
        /// Creacion de la llave del Sistema
        /// </summary>
        /// <typeparam name="T">Tipo de entidad</typeparam>
        /// <param name="pObjeto">Objeto q representa la entidad</param>
        /// <param name="pFecha">Fecha de consulta</param>
        /// <param name="pMetodoLlamado">Metodo de donde se hace el llamado</param>
        /// <returns></returns>
        public string GetKey<T>(T pObjeto, string pClase, string pMetodoLlamado)
        {
            StringBuilder sb = new StringBuilder();
            string objInfo = "Nombre:{0} - Valor:{1}";
            if (pObjeto.GetType().Name.Equals("String") == false)
            {
                if (pObjeto.GetType().Namespace.Equals("System.Collections.Generic") == true)
                {
                    throw new ApplicationException(string.Format("Imposible serializar la lista, Clase:{0}. Metodo:{1}", pClase, pMetodoLlamado));
                }
                else
                {
                    if (pObjeto.GetType().GetFields().Length > 0)
                    {
                        foreach (FieldInfo info in pObjeto.GetType().GetFields())
                        {
                            object value = info.GetValue(pObjeto);
                            if (((info.FieldType).UnderlyingSystemType).FullName.Contains("[]") == false)
                            {
                                sb.AppendLine(string.Format(objInfo, info.Name, (value == null) ? "NULL" : value.ToString()));
                            }
                            else
                            {
                                if (value != null)
                                {
                                    foreach (object obj in (object[])value)
                                    {
                                        string valueTmp = GetKey<object>(obj, pClase, pMetodoLlamado);
                                        sb.AppendLine(valueTmp);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (PropertyInfo info in pObjeto.GetType().GetProperties())
                        {
                            if (info.CanRead == true)
                            {
                                object value = info.GetValue(pObjeto, null);
                                sb.AppendLine(string.Format(objInfo, info.Name, (value == null) ? "NULL" : value.ToString()));
                            }
                        }
                    }
                }
            }
            else
            {
                sb.AppendLine(pObjeto.ToString());
            }
            string llave = sb.ToString() + "\n" + pClase + "\n" + pMetodoLlamado;
            return llave;
        }

    }
}
