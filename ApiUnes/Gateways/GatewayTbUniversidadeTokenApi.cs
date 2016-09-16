using System;
using System.Collections.Generic;
using System.Linq;
using ApiUnes.Models;
using ApiUnes.Models.Object;
using System.Data;
using ApiUnes.Models.Object.Bibliotecas;
using System.Globalization;

namespace ApiUnes.Gateways.Dbo
{
    public class GatewayTbUniversidadeTokenApi
    {
        //static ModelApiUnes _db = new ModelApiUnes();

        /// <summary>
        /// Auto Loader
        /// </summary>
        public GatewayTbUniversidadeTokenApi()
        {
            
        }

        public static string SIGLA_QUERY = "";

        /// <summary>
        /// Enum CAMPOS
        /// </summary>
        public enum CAMPOS
        {
            UTA_ID_TOKEN_API = 100,
            USU_ID_USUARIO = 101,
            UTA_DT_VALIDADE = 102,
            UTA_DT_GERACAO = 103,
            UTA_TX_TOKEN = 104,

        };

        /// <summary>
        /// Get TB_UNIVERSIDADE_TOKEN_API/TB_UNIVERSIDADE_TOKEN_API
        /// </summary>
        /// <param name="colecao"></param>
        /// <param name="campo"></param>
        /// <param name="orderby"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="queryString"></param>
        /// <returns></returns>
        private static IQueryable<TB_UNIVERSIDADE_TOKEN_API> getQuery(ModelApiUnes _db, int colecao, int campo, int orderby, int pageSize, int pageNumber, Dictionary<string, string> queryString)
        {
            _db.Configuration.ProxyCreationEnabled = false;

            // DEFINE A QUERY PRINCIPAL 
            var entity = _db.TB_UNIVERSIDADE_TOKEN_API.AsQueryable<TB_UNIVERSIDADE_TOKEN_API>();

            #region WHERE - ADICIONA OS FILTROS A QUERY

            // ADICIONA OS FILTROS A QUERY
            foreach (var item in queryString)
            {
                int key = Convert.ToInt16(item.Key);
                CAMPOS filtroEnum = (CAMPOS)key;
                switch (filtroEnum)
                {


                    case CAMPOS.UTA_ID_TOKEN_API:
                        Int32 UTA_ID_TOKEN_API = Convert.ToInt32(item.Value);
                        entity = entity.Where(e => e.UTA_ID_TOKEN_API.Equals(UTA_ID_TOKEN_API)).AsQueryable<TB_UNIVERSIDADE_TOKEN_API>();
                        break;
                    case CAMPOS.USU_ID_USUARIO:
                        Int32 USU_ID_USUARIO = Convert.ToInt32(item.Value);
                        entity = entity.Where(e => e.USU_ID_USUARIO.Equals(USU_ID_USUARIO)).AsQueryable<TB_UNIVERSIDADE_TOKEN_API>();
                        break;

                    /// PERSONALIZADO

                    case CAMPOS.UTA_DT_VALIDADE:
                        if (item.Value.Contains("|")) // BETWEEN
                        {
                            string[] busca = item.Value.Split('|');
                            DateTime dtaIni = DateTime.ParseExact(busca[0] + " 00:00:00.000", "yyyyMMdd HH:mm:ss.fff", CultureInfo.InvariantCulture);
                            DateTime dtaFim = DateTime.ParseExact(busca[1] + " 23:59:00.000", "yyyyMMdd HH:mm:ss.fff", CultureInfo.InvariantCulture);
                            entity = entity.Where(e => e.UTA_DT_VALIDADE > dtaIni && e.UTA_DT_VALIDADE < dtaFim);
                        }
                        else if (item.Value.Contains(">")) // MAIOR IGUAL
                        {
                            string busca = item.Value.Replace(">", "");
                            DateTime dta = DateTime.ParseExact(busca + " 00:00:00.000", "yyyyMMdd HH:mm:ss.fff", CultureInfo.InvariantCulture);
                            entity = entity.Where(e => e.UTA_DT_VALIDADE >= dta);
                        }
                        else if (item.Value.Contains("<")) // MENOR IGUAL
                        {
                            string busca = item.Value.Replace("<", "");
                            DateTime dta = DateTime.ParseExact(busca + " 23:59:00.000", "yyyyMMdd HH:mm:ss.fff", CultureInfo.InvariantCulture);
                            entity = entity.Where(e => e.UTA_DT_VALIDADE <= dta);
                        }
                        else if (item.Value.Length == 4) // ANO IGUAL
                        {
                            string busca = item.Value + "0101";
                            DateTime dtaIni = DateTime.ParseExact(busca + " 00:00:00.000", "yyyyMMdd HH:mm:ss.fff", CultureInfo.InvariantCulture);
                            entity = entity.Where(e => e.UTA_DT_VALIDADE.Year == dtaIni.Year);
                        }
                        else if (item.Value.Length == 6) // ANO E MÊS IGUAL
                        {
                            string busca = item.Value + "01";
                            DateTime dtaIni = DateTime.ParseExact(busca + " 00:00:00.000", "yyyyMMdd HH:mm:ss.fff", CultureInfo.InvariantCulture);
                            entity = entity.Where(e => e.UTA_DT_VALIDADE.Year == dtaIni.Year && e.UTA_DT_VALIDADE.Month == dtaIni.Month);
                        }
                        else // IGUAL : ANO, MÊS E DIA IGUAL
                        {
                            string busca = item.Value;
                            DateTime dtaIni = DateTime.ParseExact(busca + " 00:00:00.000", "yyyyMMdd HH:mm:ss.fff", CultureInfo.InvariantCulture);
                            entity = entity.Where(e => e.UTA_DT_VALIDADE.Year == dtaIni.Year && e.UTA_DT_VALIDADE.Month == dtaIni.Month && e.UTA_DT_VALIDADE.Day == dtaIni.Day);
                        }
                        break;

                    case CAMPOS.UTA_DT_GERACAO:
                        DateTime UTA_DT_GERACAO = Convert.ToDateTime(item.Value);
                        entity = entity.Where(e => e.UTA_DT_GERACAO.Equals(UTA_DT_GERACAO)).AsQueryable<TB_UNIVERSIDADE_TOKEN_API>();
                        break;
                    case CAMPOS.UTA_TX_TOKEN:
                        string UTA_TX_TOKEN = Convert.ToString(item.Value);
                        entity = entity.Where(e => e.UTA_TX_TOKEN.Equals(UTA_TX_TOKEN)).AsQueryable<TB_UNIVERSIDADE_TOKEN_API>();
                        break;

                }
            }
            #endregion

            #region ORDER BY - ADICIONA A ORDENAÇÃO A QUERY
            // ADICIONA A ORDENAÇÃO A QUERY
            CAMPOS filtro = (CAMPOS)campo;
            switch (filtro)
            {

                case CAMPOS.UTA_ID_TOKEN_API:
                    if (orderby == 0) entity = entity.OrderBy(e => e.UTA_ID_TOKEN_API).AsQueryable<TB_UNIVERSIDADE_TOKEN_API>();
                    else entity = entity.OrderByDescending(e => e.UTA_ID_TOKEN_API).AsQueryable<TB_UNIVERSIDADE_TOKEN_API>();
                    break;
                case CAMPOS.USU_ID_USUARIO:
                    if (orderby == 0) entity = entity.OrderBy(e => e.USU_ID_USUARIO).AsQueryable<TB_UNIVERSIDADE_TOKEN_API>();
                    else entity = entity.OrderByDescending(e => e.USU_ID_USUARIO).AsQueryable<TB_UNIVERSIDADE_TOKEN_API>();
                    break;
                case CAMPOS.UTA_DT_VALIDADE:
                    if (orderby == 0) entity = entity.OrderBy(e => e.UTA_DT_VALIDADE).AsQueryable<TB_UNIVERSIDADE_TOKEN_API>();
                    else entity = entity.OrderByDescending(e => e.UTA_DT_VALIDADE).AsQueryable<TB_UNIVERSIDADE_TOKEN_API>();
                    break;
                case CAMPOS.UTA_DT_GERACAO:
                    if (orderby == 0) entity = entity.OrderBy(e => e.UTA_DT_GERACAO).AsQueryable<TB_UNIVERSIDADE_TOKEN_API>();
                    else entity = entity.OrderByDescending(e => e.UTA_DT_GERACAO).AsQueryable<TB_UNIVERSIDADE_TOKEN_API>();
                    break;
                case CAMPOS.UTA_TX_TOKEN:
                    if (orderby == 0) entity = entity.OrderBy(e => e.UTA_TX_TOKEN).AsQueryable<TB_UNIVERSIDADE_TOKEN_API>();
                    else entity = entity.OrderByDescending(e => e.UTA_TX_TOKEN).AsQueryable<TB_UNIVERSIDADE_TOKEN_API>();
                    break;

            }
            #endregion

            return entity;


        }


        /// <summary>
        /// Retorna TB_UNIVERSIDADE_TOKEN_API/TB_UNIVERSIDADE_TOKEN_API
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
                    string outValue = null;
                    if (queryString.TryGetValue("" + (int)CAMPOS.UTA_TX_TOKEN, out outValue))
                        queryString["" + (int)CAMPOS.UTA_TX_TOKEN] = token;
                    else
                        queryString.Add("" + (int)CAMPOS.UTA_TX_TOKEN, token);


                    //DECLARAÇÕES
                    List<dynamic> CollectionTB_UNIVERSIDADE_TOKEN_API = new List<dynamic>();
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
                        CollectionTB_UNIVERSIDADE_TOKEN_API = query.Select(e => new
                        {

                            UTA_ID_TOKEN_API = e.UTA_ID_TOKEN_API,
                            USU_ID_USUARIO = e.USU_ID_USUARIO,
                            UTA_DT_VALIDADE = e.UTA_DT_VALIDADE,
                            UTA_DT_GERACAO = e.UTA_DT_GERACAO,
                            UTA_TX_TOKEN = e.UTA_TX_TOKEN,
                        }).ToList<dynamic>();
                    }
                    else if (colecao == 0)
                    {
                        CollectionTB_UNIVERSIDADE_TOKEN_API = query.Select(e => new
                        {

                            UTA_ID_TOKEN_API = e.UTA_ID_TOKEN_API,
                            USU_ID_USUARIO = e.USU_ID_USUARIO,
                            UTA_DT_VALIDADE = e.UTA_DT_VALIDADE,
                            UTA_DT_GERACAO = e.UTA_DT_GERACAO,
                            UTA_TX_TOKEN = e.UTA_TX_TOKEN,
                        }).ToList<dynamic>();
                    }
                    else if (colecao == 2) // VALIDAÇÃO
                    {
                        CollectionTB_UNIVERSIDADE_TOKEN_API = query.Select(e => new
                        {

                            UTA_ID_TOKEN_API = e.UTA_ID_TOKEN_API,
                            USU_ID_USUARIO = e.USU_ID_USUARIO,
                            UTA_DT_VALIDADE = e.UTA_DT_VALIDADE,
                            UTA_DT_GERACAO = e.UTA_DT_GERACAO,
                            UTA_TX_TOKEN = e.UTA_TX_TOKEN,
                            PES_PESSOA = _db.TB_PESSOA.Where(
                                                                p => p.PES_ID_PESSOA == (
                                                                                            _db.TB_USUARIO
                                                                                                         .Where(u => u.USU_ID_USUARIO == e.USU_ID_USUARIO)
                                                                                                         .Select(u => u.PES_ID_PESSOA).FirstOrDefault()
                                                                                        )
                                                            ).FirstOrDefault()
                        }).ToList<dynamic>();
                    }

                    retorno.Registros = CollectionTB_UNIVERSIDADE_TOKEN_API;
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
        /// Adiciona nova TB_UNIVERSIDADE_TOKEN_API
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static Int64 Add(string token, TB_UNIVERSIDADE_TOKEN_API param, ModelApiUnes _dbContext = null)
        {
            ModelApiUnes _db;
            if (_dbContext == null) _db = new ModelApiUnes();
            else _db = _dbContext;

            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    _db.TB_UNIVERSIDADE_TOKEN_API.Add(param);
                    _db.SaveChanges();
                    transaction.Commit();
                    return param.UTA_ID_TOKEN_API;
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
        /// Apaga uma TB_UNIVERSIDADE_TOKEN_API
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static void Delete(string token, Int32 UTA_ID_TOKEN_API, ModelApiUnes _dbContext = null)
        {

            ModelApiUnes _db;
            if (_dbContext == null) _db = new ModelApiUnes();
            else _db = _dbContext;

            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    _db.TB_UNIVERSIDADE_TOKEN_API.Remove(_db.TB_UNIVERSIDADE_TOKEN_API.Where(e => e.UTA_ID_TOKEN_API.Equals(UTA_ID_TOKEN_API)).First());
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
        /// Altera TB_UNIVERSIDADE_TOKEN_API
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static void Update(string token, TB_UNIVERSIDADE_TOKEN_API param, ModelApiUnes _dbContext = null)
        {
            ModelApiUnes _db;
            if (_dbContext == null) _db = new ModelApiUnes();
            else _db = _dbContext;

            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    TB_UNIVERSIDADE_TOKEN_API value = _db.TB_UNIVERSIDADE_TOKEN_API
                                    .Where(e => e.UTA_ID_TOKEN_API.Equals(param.UTA_ID_TOKEN_API))
                                    .First<TB_UNIVERSIDADE_TOKEN_API>();



                    if (param.UTA_ID_TOKEN_API != value.UTA_ID_TOKEN_API)
                        value.UTA_ID_TOKEN_API = param.UTA_ID_TOKEN_API;
                    if (param.USU_ID_USUARIO != value.USU_ID_USUARIO)
                        value.USU_ID_USUARIO = param.USU_ID_USUARIO;
                    if (param.UTA_DT_VALIDADE != null && param.UTA_DT_VALIDADE != value.UTA_DT_VALIDADE)
                        value.UTA_DT_VALIDADE = param.UTA_DT_VALIDADE;
                    if (param.UTA_DT_GERACAO != null && param.UTA_DT_GERACAO != value.UTA_DT_GERACAO)
                        value.UTA_DT_GERACAO = param.UTA_DT_GERACAO;
                    if (param.UTA_TX_TOKEN != null && param.UTA_TX_TOKEN != value.UTA_TX_TOKEN)
                        value.UTA_TX_TOKEN = param.UTA_TX_TOKEN;
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
        /// Autentica e Gera novo Token
        /// </summary>
        /// <param name="preToken"></param>
        /// <param name="usuIdUsuario"></param>
        /// <returns></returns>
        public static Retorno NewToken(string preToken, int usuIdUsuario)
        {
            try
            {
                ModelApiUnes _db = new ModelApiUnes();
                string token = Token.GetUniqueKey(preToken);
                TB_UNIVERSIDADE_TOKEN_API tokenApi = new TB_UNIVERSIDADE_TOKEN_API();
                tokenApi.USU_ID_USUARIO = usuIdUsuario;
                tokenApi.UTA_DT_GERACAO = DateTime.Now;
                // Adiciona um dia de Validade para o Token
                tokenApi.UTA_DT_VALIDADE = DateTime.Now.AddDays(1);
                tokenApi.UTA_TX_TOKEN = token;
                Int64 idToken = Add("", tokenApi, _db);

                Dictionary<string, string> queryString = new Dictionary<string, string>();
                queryString.Add("100", idToken.ToString());
                Retorno dados = Get(token, 2, 100, 0, 0, 0, queryString, _db);

                return (dados.Registros.Count > 0) ? dados : new Retorno();
            }
            catch (Exception e)
            {
                throw new Exception(e.InnerException == null ? e.Message : e.InnerException.InnerException == null ? e.InnerException.Message : e.InnerException.InnerException.Message);
            }
        }

        /// <summary>
        /// Verifica a validade do Token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static Retorno Validade(string token)
        {
            try
            {
                ModelApiUnes _db = new ModelApiUnes();
                Dictionary<string, string> queryString = new Dictionary<string, string>();
                queryString.Add("104", token);
                queryString.Add("102", DateTime.Now.ToString("yyyyMMdd") + "<");
                Retorno dados = Get("", 0, 104, 0, 0, 0, queryString, _db);

                if (dados.Registros.Count > 0)
                {
                    TB_UNIVERSIDADE_TOKEN_API param = (TB_UNIVERSIDADE_TOKEN_API)dados.Registros[0];
                    param.UTA_DT_VALIDADE = DateTime.Now.AddDays(1);
                    _db = new ModelApiUnes();
                    Update(token, param, _db);
                }

                return (dados.Registros.Count > 0) ? dados : new Retorno();
            }
            catch (Exception e)
            {
                throw new Exception(e.InnerException == null ? e.Message : e.InnerException.InnerException == null ? e.InnerException.Message : e.InnerException.InnerException.Message);
            }
        }

    }
}
