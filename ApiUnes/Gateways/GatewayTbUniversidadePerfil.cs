using System;
using System.Collections.Generic;
using System.Linq;
using ApiUnes.Models;
using ApiUnes.Models.Object;

namespace ApiUnes.Negocios.Dbo
{
    public class GatewayTbUniversidadePerfil
    {

        /// <summary>
        /// Auto Loader
        /// </summary>
        public GatewayTbUniversidadePerfil()
        {
        }

        public static string SIGLA_QUERY = "";

        /// <summary>
        /// Enum CAMPOS
        /// </summary>
        public enum CAMPOS
        {
            UNP_ID_PERFIL = 100,
            UNP_TX_NOME = 101,

        };

        /// <summary>
        /// Get TB_UNIVERSIDADE_PERFIL/TB_UNIVERSIDADE_PERFIL
        /// </summary>
        /// <param name="colecao"></param>
        /// <param name="campo"></param>
        /// <param name="orderby"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="queryString"></param>
        /// <returns></returns>
        private static IQueryable<TB_UNIVERSIDADE_PERFIL> getQuery(ModelApiUnes _db, int colecao, int campo, int orderby, int pageSize, int pageNumber, Dictionary<string, string> queryString)
        {
            // DEFINE A QUERY PRINCIPAL 
            var entity = _db.TB_UNIVERSIDADE_PERFIL.AsQueryable<TB_UNIVERSIDADE_PERFIL>();

            #region WHERE - ADICIONA OS FILTROS A QUERY

            // ADICIONA OS FILTROS A QUERY
            foreach (var item in queryString)
            {
                int key = Convert.ToInt16(item.Key);
                CAMPOS filtroEnum = (CAMPOS)key;
                switch (filtroEnum)
                {


                    case CAMPOS.UNP_ID_PERFIL:
                        Int32 UNP_ID_PERFIL = Convert.ToInt32(item.Value);
                        entity = entity.Where(e => e.UNP_ID_PERFIL.Equals(UNP_ID_PERFIL)).AsQueryable<TB_UNIVERSIDADE_PERFIL>();
                        break;
                    case CAMPOS.UNP_TX_NOME:
                        string UNP_TX_NOME = Convert.ToString(item.Value);
                        entity = entity.Where(e => e.UNP_TX_NOME.Equals(UNP_TX_NOME)).AsQueryable<TB_UNIVERSIDADE_PERFIL>();
                        break;

                }
            }
            #endregion

            #region ORDER BY - ADICIONA A ORDENAÇÃO A QUERY
            // ADICIONA A ORDENAÇÃO A QUERY
            CAMPOS filtro = (CAMPOS)campo;
            switch (filtro)
            {

                case CAMPOS.UNP_ID_PERFIL:
                    if (orderby == 0) entity = entity.OrderBy(e => e.UNP_ID_PERFIL).AsQueryable<TB_UNIVERSIDADE_PERFIL>();
                    else entity = entity.OrderByDescending(e => e.UNP_ID_PERFIL).AsQueryable<TB_UNIVERSIDADE_PERFIL>();
                    break;
                case CAMPOS.UNP_TX_NOME:
                    if (orderby == 0) entity = entity.OrderBy(e => e.UNP_TX_NOME).AsQueryable<TB_UNIVERSIDADE_PERFIL>();
                    else entity = entity.OrderByDescending(e => e.UNP_TX_NOME).AsQueryable<TB_UNIVERSIDADE_PERFIL>();
                    break;

            }
            #endregion

            return entity;


        }



        /// <summary>
        /// Retorna TB_UNIVERSIDADE_PERFIL/TB_UNIVERSIDADE_PERFIL
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
                    List<dynamic> CollectionTB_UNIVERSIDADE_PERFIL = new List<dynamic>();
                    Retorno retorno = new Retorno();

                    long result = Permissoes.GetPerfilPermissionFromToken(token);
                    if (result > 0 && result != 6)
                        retorno.Token = true;
                    else
                        retorno.Token = false;

                    // GET QUERY
                    var query = getQuery(_db, colecao, campo, orderBy, pageSize, pageNumber, queryString);


                    // TOTAL DE REGISTROS
                    retorno.TotalDeRegistros = query.Count();


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
                        CollectionTB_UNIVERSIDADE_PERFIL = query.Select(e => new
                        {


                            UNP_ID_PERFIL = e.UNP_ID_PERFIL,
                            UNP_TX_NOME = e.UNP_TX_NOME,

                        }).ToList<dynamic>();
                    }
                    else if (colecao == 0)
                    {
                        CollectionTB_UNIVERSIDADE_PERFIL = query.Select(e => new
                        {


                            UNP_ID_PERFIL = e.UNP_ID_PERFIL,
                            UNP_TX_NOME = e.UNP_TX_NOME,

                        }).ToList<dynamic>();
                    }

                    retorno.Registros = CollectionTB_UNIVERSIDADE_PERFIL;
                    return retorno;
                }
                catch (Exception e)
                {
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
        /// Adiciona nova TB_UNIVERSIDADE_PERFIL
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static long Add(string token, TB_UNIVERSIDADE_PERFIL param, ModelApiUnes _dbContext = null)
        {
            ModelApiUnes _db;
            if (_dbContext == null) _db = new ModelApiUnes();
            else _db = _dbContext;
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    _db.TB_UNIVERSIDADE_PERFIL.Add(param);
                    _db.SaveChanges();
                    transaction.Commit();
                    return param.UNP_ID_PERFIL;
                }
                catch (Exception e)
                {
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
        /// Apaga uma TB_UNIVERSIDADE_PERFIL
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static void Delete(string token, Int32 UNP_ID_PERFIL, ModelApiUnes _dbContext = null)
        {
            ModelApiUnes _db;
            if (_dbContext == null) _db = new ModelApiUnes();
            else _db = _dbContext;
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    _db.TB_UNIVERSIDADE_PERFIL.Remove(_db.TB_UNIVERSIDADE_PERFIL.Where(e => e.UNP_ID_PERFIL.Equals(UNP_ID_PERFIL)).First());
                    _db.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception e)
                {
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
        /// Altera TB_UNIVERSIDADE_PERFIL
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static void Update(string token, TB_UNIVERSIDADE_PERFIL param, ModelApiUnes _dbContext = null)
        {
            ModelApiUnes _db;
            if (_dbContext == null) _db = new ModelApiUnes();
            else _db = _dbContext;
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    TB_UNIVERSIDADE_PERFIL value = _db.TB_UNIVERSIDADE_PERFIL
                                    .Where(e => e.UNP_ID_PERFIL.Equals(param.UNP_ID_PERFIL))
                                    .First<TB_UNIVERSIDADE_PERFIL>();


                    if (param.UNP_ID_PERFIL != value.UNP_ID_PERFIL)
                        value.UNP_ID_PERFIL = param.UNP_ID_PERFIL;
                    if (param.UNP_TX_NOME != null && param.UNP_TX_NOME != value.UNP_TX_NOME)
                        value.UNP_TX_NOME = param.UNP_TX_NOME;

                    _db.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception e)
                {
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
