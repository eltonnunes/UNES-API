using System;
using System.Collections.Generic;
using ApiUnes.Models;
using ApiUnes.Models.Object;
using System.Data;
using System.Linq;

namespace ApiUnes.Gateways.Dbo
{
    public class GatewayTbUniversidadeTag
    {
        //static ModelApiUnes _db = new ModelApiUnes();

        /// <summary>
        /// Auto Loader
        /// </summary>
        public GatewayTbUniversidadeTag()
        {
            
        }

        public static string SIGLA_QUERY = "";

        /// <summary>
        /// Enum CAMPOS
        /// </summary>
        public enum CAMPOS
        {
            UNT_ID_TAG = 100,
            UNT_TX_NOME = 101,

        };

        /// <summary>
        /// Get TB_UNIVERSIDADE_TAG/TB_UNIVERSIDADE_TAG
        /// </summary>
        /// <param name="colecao"></param>
        /// <param name="campo"></param>
        /// <param name="orderby"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="queryString"></param>
        /// <returns></returns>
        private static IQueryable<TB_UNIVERSIDADE_TAG> getQuery(ModelApiUnes _db, int colecao, int campo, int orderby, int pageSize, int pageNumber, Dictionary<string, string> queryString)
        {

            _db.Configuration.ProxyCreationEnabled = false;
            // DEFINE A QUERY PRINCIPAL 
            var entity = _db.TB_UNIVERSIDADE_TAG.AsQueryable<TB_UNIVERSIDADE_TAG>();// .AsQueryable<TB_UNIVERSIDADE_TAG>();

            #region WHERE - ADICIONA OS FILTROS A QUERY

            // ADICIONA OS FILTROS A QUERY
            foreach (var item in queryString)
            {
                int key = Convert.ToInt16(item.Key);
                CAMPOS filtroEnum = (CAMPOS)key;
                switch (filtroEnum)
                {


                    case CAMPOS.UNT_ID_TAG:
                        Int32 UNT_ID_TAG = Convert.ToInt32(item.Value);
                        entity = entity.Where(e => e.UNT_ID_TAG.Equals(UNT_ID_TAG)).AsQueryable<TB_UNIVERSIDADE_TAG>();
                        break;
                    case CAMPOS.UNT_TX_NOME:
                        string UNT_TX_NOME = Convert.ToString(item.Value);
                        entity = entity.Where(e => e.UNT_TX_NOME.Equals(UNT_TX_NOME)).AsQueryable<TB_UNIVERSIDADE_TAG>();
                        break;

                }
            }
            #endregion

            #region ORDER BY - ADICIONA A ORDENAÇÃO A QUERY
            // ADICIONA A ORDENAÇÃO A QUERY
            CAMPOS filtro = (CAMPOS)campo;
            switch (filtro)
            {

                case CAMPOS.UNT_ID_TAG:
                    if (orderby == 0) entity = entity.OrderBy(e => e.UNT_ID_TAG).AsQueryable<TB_UNIVERSIDADE_TAG>();
                    else entity = entity.OrderByDescending(e => e.UNT_ID_TAG).AsQueryable<TB_UNIVERSIDADE_TAG>();
                    break;
                case CAMPOS.UNT_TX_NOME:
                    if (orderby == 0) entity = entity.OrderBy(e => e.UNT_TX_NOME).AsQueryable<TB_UNIVERSIDADE_TAG>();
                    else entity = entity.OrderByDescending(e => e.UNT_TX_NOME).AsQueryable<TB_UNIVERSIDADE_TAG>();
                    break;

            }
            #endregion

            return entity;


        }


        /// <summary>
        /// Retorna TB_UNIVERSIDADE_TAG/TB_UNIVERSIDADE_TAG
        /// </summary>
        /// <returns></returns>
        public static Retorno Get(string token, int colecao = 0, int campo = 0, int orderBy = 0, int pageSize = 0, int pageNumber = 0, Dictionary<string, string> queryString = null, ModelApiUnes _dbContext = null)
        {
            ModelApiUnes _db;
            if (_dbContext == null) _db = new ModelApiUnes();
            else _db = _dbContext;

            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    //DECLARAÇÕES
                    List<dynamic> CollectionTB_UNIVERSIDADE_TAG = new List<dynamic>();
                    Retorno retorno = new Retorno();

                    // GET QUERY
                    var query = getQuery(_db, colecao, campo, orderBy, pageSize, pageNumber, queryString);


                    // TOTAL DE REGISTROS
                    retorno.TotalDeRegistros = _db.TB_UNIVERSIDADE_TAG.Count();


                    // PAGINAÇÃO
                    int skipRows = (pageNumber - 1) * pageSize;
                    if (retorno.TotalDeRegistros > pageSize && pageNumber > 0 && pageSize > 0)
                        query = query.Skip(skipRows).Take(pageSize);
                    else
                        pageNumber = 1;

                    retorno.PaginaAtual = pageNumber;
                    retorno.ItensPorPagina = pageSize;

                    // COLEÇÃO DE RETORNO
                    if (colecao == 1)
                    {
                        CollectionTB_UNIVERSIDADE_TAG = query.Select(e => new
                        {

                            UntIdTag = e.UNT_ID_TAG,
                            UntTxNome = e.UNT_TX_NOME,
                        }).ToList<dynamic>();
                    }
                    else if (colecao == 0)
                    {
                        CollectionTB_UNIVERSIDADE_TAG = query.Select(e => new
                        {

                            UntIdTag = e.UNT_ID_TAG,
                            UntTxNome = e.UNT_TX_NOME,
                        }).ToList<dynamic>();
                    }

                    retorno.Registros = CollectionTB_UNIVERSIDADE_TAG;

                    return retorno;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new Exception(e.InnerException == null ? e.Message : e.InnerException.InnerException == null ? e.InnerException.Message : e.InnerException.InnerException.Message);
                }
                finally
                {
                    if (_dbContext == null)
                    {
                        // Fecha conexão
                        transaction.Dispose();
                        _db.Database.Connection.Close();
                        _db.Dispose();
                    }
                }
            }
        }



        /// <summary>
        /// Adiciona nova TB_UNIVERSIDADE_TAG
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static Int64 Add(string token, TB_UNIVERSIDADE_TAG param, ModelApiUnes _dbContext = null)
        {
            ModelApiUnes _db;
            if (_dbContext == null) _db = new ModelApiUnes();
            else _db = _dbContext;
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    _db.TB_UNIVERSIDADE_TAG.Add(param);
                    _db.SaveChanges();
                    transaction.Commit();
                    return param.UNT_ID_TAG;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new Exception(e.InnerException == null ? e.Message : e.InnerException.InnerException == null ? e.InnerException.Message : e.InnerException.InnerException.Message);
                }
                finally
                {
                    if (_dbContext == null)
                    {
                        // Fecha conexão
                        transaction.Dispose();
                        _db.Database.Connection.Close();
                        _db.Dispose();
                    }
                }
            }
        }


        /// <summary>
        /// Apaga uma TB_UNIVERSIDADE_TAG
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static void Delete(string token, Int32 UntIdTag, ModelApiUnes _dbContext = null)
        {
            ModelApiUnes _db;
            if (_dbContext == null) _db = new ModelApiUnes();
            else _db = _dbContext;
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    _db.TB_UNIVERSIDADE_TAG.Remove(_db.TB_UNIVERSIDADE_TAG.Where(e => e.UNT_ID_TAG.Equals(UntIdTag)).First());
                    _db.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new Exception(e.InnerException == null ? e.Message : e.InnerException.InnerException == null ? e.InnerException.Message : e.InnerException.InnerException.Message);
                }
                finally
                {
                    if (_dbContext == null)
                    {
                        // Fecha conexão
                        transaction.Dispose();
                        _db.Database.Connection.Close();
                        _db.Dispose();
                    }
                }
            }
        }



        /// <summary>
        /// Altera TB_UNIVERSIDADE_TAG
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static void Update(string token, TB_UNIVERSIDADE_TAG param, ModelApiUnes _dbContext = null)
        {
            ModelApiUnes _db;
            if (_dbContext == null) _db = new ModelApiUnes();
            else _db = _dbContext;
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    TB_UNIVERSIDADE_TAG value = _db.TB_UNIVERSIDADE_TAG
                                    .Where(e => e.UNT_ID_TAG.Equals(param.UNT_ID_TAG))
                                    .First<TB_UNIVERSIDADE_TAG>();



                    if (param.UNT_ID_TAG != value.UNT_ID_TAG)
                        value.UNT_ID_TAG = param.UNT_ID_TAG;
                    if (param.UNT_TX_NOME != null && param.UNT_TX_NOME != value.UNT_TX_NOME)
                        value.UNT_TX_NOME = param.UNT_TX_NOME;
                    _db.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new Exception(e.InnerException == null ? e.Message : e.InnerException.InnerException == null ? e.InnerException.Message : e.InnerException.InnerException.Message);
                }
                finally
                {
                    if (_dbContext == null)
                    {
                        // Fecha conexão
                        transaction.Dispose();
                        _db.Database.Connection.Close();
                        _db.Dispose();
                    }
                }
            }
        }

    }
}
