using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ApiUnes.Models;
using ApiUnes.Models.Object;

namespace ApiUnes.Negocios.Dbo
{
    public class GatewayTbUniversidadeVideos
    {

        /// <summary>
        /// Auto Loader
        /// </summary>
        public GatewayTbUniversidadeVideos()
        {
            
        }

        public static string SIGLA_QUERY = "";

        /// <summary>
        /// Enum CAMPOS
        /// </summary>
        public enum CAMPOS
        {
            UNV_ID_VIDEOS = 100,
            UNV_TX_TITULO = 101,
            UNV_TX_DESCRICAO = 102,
            UNV_NR_VIEW = 103,
            UNV_NR_LIKE = 104,
            UNV_DT_DATA = 105,
            UNT_ID_TAG = 106,
            UNV_TX_HASH = 107,

        };

        /// <summary>
        /// Get Tb_Universidade_Videos/Tb_Universidade_Videos
        /// </summary>
        /// <param name="colecao"></param>
        /// <param name="campo"></param>
        /// <param name="orderby"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="queryString"></param>
        /// <returns></returns>
        private static IQueryable<TB_UNIVERSIDADE_VIDEOS> getQuery(ModelApiUnes _db, int colecao, int campo, int orderby, int pageSize, int pageNumber, Dictionary<string, string> queryString)
        {
            _db.Configuration.ProxyCreationEnabled = false;

            // DEFINE A QUERY PRINCIPAL 
            var entity = _db.TB_UNIVERSIDADE_VIDEOS.AsQueryable<TB_UNIVERSIDADE_VIDEOS>();

            #region WHERE - ADICIONA OS FILTROS A QUERY

            // ADICIONA OS FILTROS A QUERY
            foreach (var item in queryString)
            {
                int key = Convert.ToInt16(item.Key);
                CAMPOS filtroEnum = (CAMPOS)key;
                switch (filtroEnum)
                {


                    case CAMPOS.UNV_ID_VIDEOS:
                        Int32 UNV_ID_VIDEOS = Convert.ToInt32(item.Value);
                        entity = entity.Where(e => e.UNV_ID_VIDEOS.Equals(UNV_ID_VIDEOS)).AsQueryable<TB_UNIVERSIDADE_VIDEOS>();
                        break;
                    case CAMPOS.UNV_TX_TITULO:
                        if (item.Value.Contains("%")) // LIKE
                        {
                            string UNV_TX_TITULO = Convert.ToString(item.Value).Replace("%","");
                            entity = entity.Where(e => e.UNV_TX_TITULO.Contains(UNV_TX_TITULO) || e.UNV_TX_DESCRICAO.Contains(UNV_TX_TITULO)).AsQueryable<TB_UNIVERSIDADE_VIDEOS>();
                        }
                        else
                        {
                            string UNV_TX_TITULO = Convert.ToString(item.Value);
                            entity = entity.Where(e => e.UNV_TX_TITULO.Equals(UNV_TX_TITULO)).AsQueryable<TB_UNIVERSIDADE_VIDEOS>();
                        }
                        break;
                    case CAMPOS.UNV_TX_DESCRICAO:
                        if (item.Value.Contains("%")) // LIKE
                        {
                            string UNV_TX_DESCRICAO = Convert.ToString(item.Value).Replace("%", "");
                            entity = entity.Where(e => e.UNV_TX_DESCRICAO.Contains(UNV_TX_DESCRICAO) || e.UNV_TX_TITULO.Contains(UNV_TX_DESCRICAO)).AsQueryable<TB_UNIVERSIDADE_VIDEOS>();
                        }
                        else
                        {
                            string UNV_TX_DESCRICAO = Convert.ToString(item.Value);
                            entity = entity.Where(e => e.UNV_TX_DESCRICAO.Equals(UNV_TX_DESCRICAO)).AsQueryable<TB_UNIVERSIDADE_VIDEOS>();
                        }
                        break;
                    case CAMPOS.UNV_NR_VIEW:
                        Int32 UNV_NR_VIEW = Convert.ToInt32(item.Value);
                        entity = entity.Where(e => e.UNV_NR_VIEW.Equals(UNV_NR_VIEW)).AsQueryable<TB_UNIVERSIDADE_VIDEOS>();
                        break;
                    case CAMPOS.UNV_NR_LIKE:
                        Int32 UNV_NR_LIKE = Convert.ToInt32(item.Value);
                        entity = entity.Where(e => e.UNV_NR_LIKE.Equals(UNV_NR_LIKE)).AsQueryable<TB_UNIVERSIDADE_VIDEOS>();
                        break;

                    /// PERSONALIZADO

                    case CAMPOS.UNV_DT_DATA:
                        if (item.Value.Contains("|")) // BETWEEN
                        {
                            string[] busca = item.Value.Split('|');
                            DateTime dtaIni = DateTime.ParseExact(busca[0] + " 00:00:00.000", "yyyyMMdd HH:mm:ss.fff", CultureInfo.InvariantCulture);
                            DateTime dtaFim = DateTime.ParseExact(busca[1] + " 23:59:00.000", "yyyyMMdd HH:mm:ss.fff", CultureInfo.InvariantCulture);
                            entity = entity.Where(e => e.UNV_DT_DATA > dtaIni && e.UNV_DT_DATA < dtaFim);
                        }
                        else if (item.Value.Contains(">")) // MAIOR IGUAL
                        {
                            string busca = item.Value.Replace(">", "");
                            DateTime dta = DateTime.ParseExact(busca + " 00:00:00.000", "yyyyMMdd HH:mm:ss.fff", CultureInfo.InvariantCulture);
                            entity = entity.Where(e => e.UNV_DT_DATA >= dta);
                        }
                        else if (item.Value.Contains("<")) // MENOR IGUAL
                        {
                            string busca = item.Value.Replace("<", "");
                            DateTime dta = DateTime.ParseExact(busca + " 23:59:00.000", "yyyyMMdd HH:mm:ss.fff", CultureInfo.InvariantCulture);
                            entity = entity.Where(e => e.UNV_DT_DATA <= dta);
                        }
                        break;

                    case CAMPOS.UNT_ID_TAG:
                        Int32 UNT_ID_TAG = Convert.ToInt32(item.Value);
                        entity = entity.Where(e => e.UNT_ID_TAG.Equals(UNT_ID_TAG)).AsQueryable<TB_UNIVERSIDADE_VIDEOS>();
                        break;
                    case CAMPOS.UNV_TX_HASH:
                        string UNV_TX_HASH = Convert.ToString(item.Value);
                        entity = entity.Where(e => e.UNV_TX_HASH.Equals(UNV_TX_HASH)).AsQueryable<TB_UNIVERSIDADE_VIDEOS>();
                        break;

                }
            }
            #endregion

            #region ORDER BY - ADICIONA A ORDENAÇÃO A QUERY
            // ADICIONA A ORDENAÇÃO A QUERY
            CAMPOS filtro = (CAMPOS)campo;
            switch (filtro)
            {

                case CAMPOS.UNV_ID_VIDEOS:
                    if (orderby == 0) entity = entity.OrderBy(e => e.UNV_ID_VIDEOS).AsQueryable<TB_UNIVERSIDADE_VIDEOS>();
                    else entity = entity.OrderByDescending(e => e.UNV_ID_VIDEOS).AsQueryable<TB_UNIVERSIDADE_VIDEOS>();
                    break;
                case CAMPOS.UNV_TX_TITULO:
                    if (orderby == 0) entity = entity.OrderBy(e => e.UNV_TX_TITULO).AsQueryable<TB_UNIVERSIDADE_VIDEOS>();
                    else entity = entity.OrderByDescending(e => e.UNV_TX_TITULO).AsQueryable<TB_UNIVERSIDADE_VIDEOS>();
                    break;
                case CAMPOS.UNV_TX_DESCRICAO:
                    if (orderby == 0) entity = entity.OrderBy(e => e.UNV_TX_DESCRICAO).AsQueryable<TB_UNIVERSIDADE_VIDEOS>();
                    else entity = entity.OrderByDescending(e => e.UNV_TX_DESCRICAO).AsQueryable<TB_UNIVERSIDADE_VIDEOS>();
                    break;
                case CAMPOS.UNV_NR_VIEW:
                    if (orderby == 0) entity = entity.OrderBy(e => e.UNV_NR_VIEW).AsQueryable<TB_UNIVERSIDADE_VIDEOS>();
                    else entity = entity.OrderByDescending(e => e.UNV_NR_VIEW).AsQueryable<TB_UNIVERSIDADE_VIDEOS>();
                    break;
                case CAMPOS.UNV_NR_LIKE:
                    if (orderby == 0) entity = entity.OrderBy(e => e.UNV_NR_LIKE).AsQueryable<TB_UNIVERSIDADE_VIDEOS>();
                    else entity = entity.OrderByDescending(e => e.UNV_NR_LIKE).AsQueryable<TB_UNIVERSIDADE_VIDEOS>();
                    break;
                case CAMPOS.UNV_DT_DATA:
                    if (orderby == 0) entity = entity.OrderBy(e => e.UNV_DT_DATA).AsQueryable<TB_UNIVERSIDADE_VIDEOS>();
                    else entity = entity.OrderByDescending(e => e.UNV_DT_DATA).AsQueryable<TB_UNIVERSIDADE_VIDEOS>();
                    break;
                case CAMPOS.UNT_ID_TAG:
                    if (orderby == 0) entity = entity.OrderBy(e => e.UNT_ID_TAG).AsQueryable<TB_UNIVERSIDADE_VIDEOS>();
                    else entity = entity.OrderByDescending(e => e.UNT_ID_TAG).AsQueryable<TB_UNIVERSIDADE_VIDEOS>();
                    break;
                case CAMPOS.UNV_TX_HASH:
                    if (orderby == 0) entity = entity.OrderBy(e => e.UNV_TX_HASH).AsQueryable<TB_UNIVERSIDADE_VIDEOS>();
                    else entity = entity.OrderByDescending(e => e.UNV_TX_HASH).AsQueryable<TB_UNIVERSIDADE_VIDEOS>();
                    break;

            }
            #endregion

            return entity;


        }



        /// <summary>
        /// Retorna Tb_Universidade_Videos/Tb_Universidade_Videos
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
                    List<dynamic> CollectionTb_Universidade_Videos = new List<dynamic>();
                    Retorno retorno = new Retorno();

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
                        CollectionTb_Universidade_Videos = query.Select(e => new
                        {
                            UNV_ID_VIDEOS = e.UNV_ID_VIDEOS,
                            UNV_TX_TITULO = e.UNV_TX_TITULO,
                            UNV_TX_DESCRICAO = e.UNV_TX_DESCRICAO,
                            UNV_NR_VIEW = e.UNV_NR_VIEW,
                            UNV_NR_LIKE = e.UNV_NR_LIKE,
                            UNV_DT_DATA = e.UNV_DT_DATA,
                            UNT_ID_TAG = e.UNT_ID_TAG,
                            UNV_TX_HASH = e.UNV_TX_HASH,
                        }).ToList<dynamic>();
                    }
                    else if (colecao == 0)
                    {
                        CollectionTb_Universidade_Videos = query.Select(e => new
                        {

                            UNV_ID_VIDEOS = e.UNV_ID_VIDEOS,
                            UNV_TX_TITULO = e.UNV_TX_TITULO,
                            UNV_TX_DESCRICAO = e.UNV_TX_DESCRICAO,
                            UNV_NR_VIEW = e.UNV_NR_VIEW,
                            UNV_NR_LIKE = e.UNV_NR_LIKE,
                            UNV_DT_DATA = e.UNV_DT_DATA,
                            UNT_ID_TAG = e.UNT_ID_TAG,
                            UNV_TX_HASH = e.UNV_TX_HASH,
                            UNT_TAG = _db.TB_UNIVERSIDADE_TAG.Where(p => p.UNT_ID_TAG == e.UNT_ID_TAG).FirstOrDefault()
                        }).ToList<dynamic>();
                    }

                    retorno.Registros = CollectionTb_Universidade_Videos;
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
        /// Adiciona nova Tb_Universidade_Videos
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static Int64 Add(string token, TB_UNIVERSIDADE_VIDEOS param, ModelApiUnes _dbContext = null)
        {
            ModelApiUnes _db;
            if (_dbContext == null) _db = new ModelApiUnes();
            else _db = _dbContext;
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    param.UNV_ID_VIDEOS = 0;
                    _db.TB_UNIVERSIDADE_VIDEOS.Add(param);
                    _db.SaveChanges();
                    transaction.Commit();
                    return param.UNV_ID_VIDEOS;
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
        /// Apaga uma Tb_Universidade_Videos
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static void Delete(string token, Int64 UNV_ID_VIDEOS, ModelApiUnes _dbContext = null)
        {
            ModelApiUnes _db;
            if (_dbContext == null) _db = new ModelApiUnes();
            else _db = _dbContext;
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    _db.TB_UNIVERSIDADE_VIDEOS.Remove(_db.TB_UNIVERSIDADE_VIDEOS.Where(e => e.UNV_ID_VIDEOS.Equals(UNV_ID_VIDEOS)).First());
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
        /// Altera TB_UNIVERSIDADE_VIDEOS
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static void Update(string token, TB_UNIVERSIDADE_VIDEOS param, ModelApiUnes _dbContext = null)
        {
            ModelApiUnes _db;
            if (_dbContext == null) _db = new ModelApiUnes();
            else _db = _dbContext;
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    TB_UNIVERSIDADE_VIDEOS value = _db.TB_UNIVERSIDADE_VIDEOS
                                    .Where(e => e.UNV_ID_VIDEOS.Equals(param.UNV_ID_VIDEOS))
                                    .First<TB_UNIVERSIDADE_VIDEOS>();



                    /*if (param.UNV_ID_VIDEOS != value.UNV_ID_VIDEOS)
                        value.UNV_ID_VIDEOS = param.UNV_ID_VIDEOS;*/
                    if (param.UNV_TX_TITULO != null && param.UNV_TX_TITULO != value.UNV_TX_TITULO)
                        value.UNV_TX_TITULO = param.UNV_TX_TITULO;
                    if (param.UNV_TX_DESCRICAO != null && param.UNV_TX_DESCRICAO != value.UNV_TX_DESCRICAO)
                        value.UNV_TX_DESCRICAO = param.UNV_TX_DESCRICAO;
                    /*if (param.UNV_NR_VIEW != null && param.UNV_NR_VIEW != value.UNV_NR_VIEW)
                        value.UNV_NR_VIEW = param.UNV_NR_VIEW;
                    if (param.UNV_NR_LIKE != null && param.UNV_NR_LIKE != value.UNV_NR_LIKE)
                        value.UNV_NR_LIKE = param.UNV_NR_LIKE;
                    if (param.UNV_DT_DATA != null && param.UNV_DT_DATA != value.UNV_DT_DATA)
                        value.UNV_DT_DATA = param.UNV_DT_DATA;*/
                    if (param.UNT_ID_TAG != value.UNT_ID_TAG)
                        value.UNT_ID_TAG = param.UNT_ID_TAG;
                    /*if (param.UNV_TX_HASH != null && param.UNV_TX_HASH != value.UNV_TX_HASH)
                        value.UNV_TX_HASH = param.UNV_TX_HASH;*/
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
        /// Altera TB_UNIVERSIDADE_VIDEOS - Atualizar Statisticas de Visualização
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static void Update(string token, Estatisticas param, ModelApiUnes _dbContext = null)
        {
            ModelApiUnes _db;
            if (_dbContext == null) _db = new ModelApiUnes();
            else _db = _dbContext;
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    TB_UNIVERSIDADE_VIDEOS value = _db.TB_UNIVERSIDADE_VIDEOS
                                    .Where(e => e.UNV_ID_VIDEOS.Equals(param.Idvideo))
                                    .First<TB_UNIVERSIDADE_VIDEOS>();

                    if (param.Idvideo != 0 && param.Idusuario != 0)
                        value.UNV_NR_VIEW = value.UNV_NR_VIEW + 1;

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