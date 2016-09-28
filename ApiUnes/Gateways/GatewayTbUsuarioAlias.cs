using System;
using System.Collections.Generic;
using System.Linq;
using ApiUnes.Models;
using System.Linq.Expressions;
using ApiUnes.Models.Object;
using ApiUnes.Models.Object.Bibliotecas;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace ApiUnes.Gateways.Dbo
{
    public class GatewayTbUsuarioAlias
    {
        //static painel_taxservices_dbContext _db = new painel_taxservices_dbContext();

        /// <summary>
        /// Auto Loader
        /// </summary>
        public GatewayTbUsuarioAlias()
        {
        }

        public static string SIGLA_QUERY = "";

        /// <summary>
        /// Enum CAMPOS
        /// </summary>
        public enum CAMPOS
        {
            UAL_ID_USUARIO_ALIAS = 100,
            USU_ID_USUARIO = 101,
            UAL_TX_ALIAS = 102,
            UAL_TX_SENHA = 103,
            UAL_NR_DIAS = 104,
            UAL_DT_SENHA = 105,
            UAL_BL_MUDAR = 106,
            UAL_BL_ATIVO = 107,
            UAL_NR_TENTATIVAS = 108,
            UAL_DT_TENTATIVAS = 109,
            UPA_ID_PERFIL_ALIAS = 110,
            PER_ID_PERFIL_GENERICO = 111,
            UAL_BL_GRATUIDADE = 112,
            UAL_DT_CRIACAO = 113,

        };

        /// <summary>
        /// Get TB_USUARIO_ALIAS/TB_USUARIO_ALIAS
        /// </summary>
        /// <param name="colecao"></param>
        /// <param name="campo"></param>
        /// <param name="orderby"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="queryString"></param>
        /// <returns></returns>
        private static IQueryable<TB_USUARIO_ALIAS> getQuery(ModelApiUnes _db, int colecao, int campo, int orderby, int pageSize, int pageNumber, Dictionary<string, string> queryString)
        {
            _db.Configuration.ProxyCreationEnabled = false;
            // DEFINE A QUERY PRINCIPAL 
            IQueryable<TB_USUARIO_ALIAS> entity = _db.TB_USUARIO_ALIAS.AsQueryable<TB_USUARIO_ALIAS>();

            #region WHERE - ADICIONA OS FILTROS A QUERY

            // ADICIONA OS FILTROS A QUERY
            foreach (var item in queryString)
            {
                int key = Convert.ToInt16(item.Key);
                CAMPOS filtroEnum = (CAMPOS)key;
                switch (filtroEnum)
                {


                    case CAMPOS.UAL_ID_USUARIO_ALIAS:
                        Int32 UAL_ID_USUARIO_ALIAS = Convert.ToInt32(item.Value);
                        entity = entity.Where(e => e.UAL_ID_USUARIO_ALIAS.Equals(UAL_ID_USUARIO_ALIAS)).AsQueryable<TB_USUARIO_ALIAS>();
                        break;
                    case CAMPOS.USU_ID_USUARIO:
                        Int32 USU_ID_USUARIO = Convert.ToInt32(item.Value);
                        entity = entity.Where(e => e.USU_ID_USUARIO.Equals(USU_ID_USUARIO)).AsQueryable<TB_USUARIO_ALIAS>();
                        break;
                    case CAMPOS.UAL_TX_ALIAS:
                        string UAL_TX_ALIAS = Convert.ToString(item.Value);
                        entity = entity.Where(e => e.UAL_TX_ALIAS.Equals(UAL_TX_ALIAS)).AsQueryable<TB_USUARIO_ALIAS>();
                        break;
                    case CAMPOS.UAL_TX_SENHA:
                        string UAL_TX_SENHA = Convert.ToString(item.Value);
                        entity = entity.Where(e => e.UAL_TX_SENHA.Equals(UAL_TX_SENHA)).AsQueryable<TB_USUARIO_ALIAS>();
                        break;
                    case CAMPOS.UAL_NR_DIAS:
                        Int32 UAL_NR_DIAS = Convert.ToInt32(item.Value);
                        entity = entity.Where(e => e.UAL_NR_DIAS.Equals(UAL_NR_DIAS)).AsQueryable<TB_USUARIO_ALIAS>();
                        break;
                    case CAMPOS.UAL_DT_SENHA:
                        DateTime UAL_DT_SENHA = Convert.ToDateTime(item.Value);
                        entity = entity.Where(e => e.UAL_DT_SENHA.Equals(UAL_DT_SENHA)).AsQueryable<TB_USUARIO_ALIAS>();
                        break;
                    case CAMPOS.UAL_BL_MUDAR:
                        Boolean UAL_BL_MUDAR = Convert.ToBoolean(item.Value);
                        entity = entity.Where(e => e.UAL_BL_MUDAR.Equals(UAL_BL_MUDAR)).AsQueryable<TB_USUARIO_ALIAS>();
                        break;
                    case CAMPOS.UAL_BL_ATIVO:
                        Boolean UAL_BL_ATIVO = Convert.ToBoolean(item.Value);
                        entity = entity.Where(e => e.UAL_BL_ATIVO.Equals(UAL_BL_ATIVO)).AsQueryable<TB_USUARIO_ALIAS>();
                        break;
                    case CAMPOS.UAL_NR_TENTATIVAS:
                        Int32 UAL_NR_TENTATIVAS = Convert.ToInt32(item.Value);
                        entity = entity.Where(e => e.UAL_NR_TENTATIVAS.Equals(UAL_NR_TENTATIVAS)).AsQueryable<TB_USUARIO_ALIAS>();
                        break;
                    case CAMPOS.UAL_DT_TENTATIVAS:
                        DateTime UAL_DT_TENTATIVAS = Convert.ToDateTime(item.Value);
                        entity = entity.Where(e => e.UAL_DT_TENTATIVAS.Equals(UAL_DT_TENTATIVAS)).AsQueryable<TB_USUARIO_ALIAS>();
                        break;
                    case CAMPOS.UPA_ID_PERFIL_ALIAS:
                        Int32 UPA_ID_PERFIL_ALIAS = Convert.ToInt32(item.Value);
                        entity = entity.Where(e => e.UPA_ID_PERFIL_ALIAS.Equals(UPA_ID_PERFIL_ALIAS)).AsQueryable<TB_USUARIO_ALIAS>();
                        break;
                    case CAMPOS.PER_ID_PERFIL_GENERICO:
                        Int32 PER_ID_PERFIL_GENERICO = Convert.ToInt32(item.Value);
                        entity = entity.Where(e => e.PER_ID_PERFIL_GENERICO.Equals(PER_ID_PERFIL_GENERICO)).AsQueryable<TB_USUARIO_ALIAS>();
                        break;
                    case CAMPOS.UAL_BL_GRATUIDADE:
                        Boolean UAL_BL_GRATUIDADE = Convert.ToBoolean(item.Value);
                        entity = entity.Where(e => e.UAL_BL_GRATUIDADE.Equals(UAL_BL_GRATUIDADE)).AsQueryable<TB_USUARIO_ALIAS>();
                        break;
                    case CAMPOS.UAL_DT_CRIACAO:
                        DateTime UAL_DT_CRIACAO = Convert.ToDateTime(item.Value);
                        entity = entity.Where(e => e.UAL_DT_CRIACAO.Equals(UAL_DT_CRIACAO)).AsQueryable<TB_USUARIO_ALIAS>();
                        break;

                }
            }
            #endregion

            #region ORDER BY - ADICIONA A ORDENAÇÃO A QUERY
            // ADICIONA A ORDENAÇÃO A QUERY
            CAMPOS filtro = (CAMPOS)campo;
            switch (filtro)
            {

                case CAMPOS.UAL_ID_USUARIO_ALIAS:
                    if (orderby == 0) entity = entity.OrderBy(e => e.UAL_ID_USUARIO_ALIAS).AsQueryable<TB_USUARIO_ALIAS>();
                    else entity = entity.OrderByDescending(e => e.UAL_ID_USUARIO_ALIAS).AsQueryable<TB_USUARIO_ALIAS>();
                    break;
                case CAMPOS.USU_ID_USUARIO:
                    if (orderby == 0) entity = entity.OrderBy(e => e.USU_ID_USUARIO).AsQueryable<TB_USUARIO_ALIAS>();
                    else entity = entity.OrderByDescending(e => e.USU_ID_USUARIO).AsQueryable<TB_USUARIO_ALIAS>();
                    break;
                case CAMPOS.UAL_TX_ALIAS:
                    if (orderby == 0) entity = entity.OrderBy(e => e.UAL_TX_ALIAS).AsQueryable<TB_USUARIO_ALIAS>();
                    else entity = entity.OrderByDescending(e => e.UAL_TX_ALIAS).AsQueryable<TB_USUARIO_ALIAS>();
                    break;
                case CAMPOS.UAL_TX_SENHA:
                    if (orderby == 0) entity = entity.OrderBy(e => e.UAL_TX_SENHA).AsQueryable<TB_USUARIO_ALIAS>();
                    else entity = entity.OrderByDescending(e => e.UAL_TX_SENHA).AsQueryable<TB_USUARIO_ALIAS>();
                    break;
                case CAMPOS.UAL_NR_DIAS:
                    if (orderby == 0) entity = entity.OrderBy(e => e.UAL_NR_DIAS).AsQueryable<TB_USUARIO_ALIAS>();
                    else entity = entity.OrderByDescending(e => e.UAL_NR_DIAS).AsQueryable<TB_USUARIO_ALIAS>();
                    break;
                case CAMPOS.UAL_DT_SENHA:
                    if (orderby == 0) entity = entity.OrderBy(e => e.UAL_DT_SENHA).AsQueryable<TB_USUARIO_ALIAS>();
                    else entity = entity.OrderByDescending(e => e.UAL_DT_SENHA).AsQueryable<TB_USUARIO_ALIAS>();
                    break;
                case CAMPOS.UAL_BL_MUDAR:
                    if (orderby == 0) entity = entity.OrderBy(e => e.UAL_BL_MUDAR).AsQueryable<TB_USUARIO_ALIAS>();
                    else entity = entity.OrderByDescending(e => e.UAL_BL_MUDAR).AsQueryable<TB_USUARIO_ALIAS>();
                    break;
                case CAMPOS.UAL_BL_ATIVO:
                    if (orderby == 0) entity = entity.OrderBy(e => e.UAL_BL_ATIVO).AsQueryable<TB_USUARIO_ALIAS>();
                    else entity = entity.OrderByDescending(e => e.UAL_BL_ATIVO).AsQueryable<TB_USUARIO_ALIAS>();
                    break;
                case CAMPOS.UAL_NR_TENTATIVAS:
                    if (orderby == 0) entity = entity.OrderBy(e => e.UAL_NR_TENTATIVAS).AsQueryable<TB_USUARIO_ALIAS>();
                    else entity = entity.OrderByDescending(e => e.UAL_NR_TENTATIVAS).AsQueryable<TB_USUARIO_ALIAS>();
                    break;
                case CAMPOS.UAL_DT_TENTATIVAS:
                    if (orderby == 0) entity = entity.OrderBy(e => e.UAL_DT_TENTATIVAS).AsQueryable<TB_USUARIO_ALIAS>();
                    else entity = entity.OrderByDescending(e => e.UAL_DT_TENTATIVAS).AsQueryable<TB_USUARIO_ALIAS>();
                    break;
                case CAMPOS.UPA_ID_PERFIL_ALIAS:
                    if (orderby == 0) entity = entity.OrderBy(e => e.UPA_ID_PERFIL_ALIAS).AsQueryable<TB_USUARIO_ALIAS>();
                    else entity = entity.OrderByDescending(e => e.UPA_ID_PERFIL_ALIAS).AsQueryable<TB_USUARIO_ALIAS>();
                    break;
                case CAMPOS.PER_ID_PERFIL_GENERICO:
                    if (orderby == 0) entity = entity.OrderBy(e => e.PER_ID_PERFIL_GENERICO).AsQueryable<TB_USUARIO_ALIAS>();
                    else entity = entity.OrderByDescending(e => e.PER_ID_PERFIL_GENERICO).AsQueryable<TB_USUARIO_ALIAS>();
                    break;
                case CAMPOS.UAL_BL_GRATUIDADE:
                    if (orderby == 0) entity = entity.OrderBy(e => e.UAL_BL_GRATUIDADE).AsQueryable<TB_USUARIO_ALIAS>();
                    else entity = entity.OrderByDescending(e => e.UAL_BL_GRATUIDADE).AsQueryable<TB_USUARIO_ALIAS>();
                    break;
                case CAMPOS.UAL_DT_CRIACAO:
                    if (orderby == 0) entity = entity.OrderBy(e => e.UAL_DT_CRIACAO).AsQueryable<TB_USUARIO_ALIAS>();
                    else entity = entity.OrderByDescending(e => e.UAL_DT_CRIACAO).AsQueryable<TB_USUARIO_ALIAS>();
                    break;

            }
            #endregion

            return entity;


        }



        /// <summary>
        /// Retorna TB_USUARIO_ALIAS/TB_USUARIO_ALIAS
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
                    List<dynamic> CollectionTB_USUARIO_ALIAS = new List<dynamic>();
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
                        CollectionTB_USUARIO_ALIAS = query.Select(e => new
                        {

                            UAL_ID_USUARIO_ALIAS = e.UAL_ID_USUARIO_ALIAS,
                            USU_ID_USUARIO = e.USU_ID_USUARIO,
                            UAL_TX_ALIAS = e.UAL_TX_ALIAS,
                            UAL_TX_SENHA = e.UAL_TX_SENHA,
                            UAL_NR_DIAS = e.UAL_NR_DIAS,
                            UAL_DT_SENHA = e.UAL_DT_SENHA,
                            UAL_BL_MUDAR = e.UAL_BL_MUDAR,
                            UAL_BL_ATIVO = e.UAL_BL_ATIVO,
                            UAL_NR_TENTATIVAS = e.UAL_NR_TENTATIVAS,
                            UAL_DT_TENTATIVAS = e.UAL_DT_TENTATIVAS,
                            UPA_ID_PERFIL_ALIAS = e.UPA_ID_PERFIL_ALIAS,
                            PER_ID_PERFIL_GENERICO = e.PER_ID_PERFIL_GENERICO,
                            UAL_BL_GRATUIDADE = e.UAL_BL_GRATUIDADE,
                            UAL_DT_CRIACAO = e.UAL_DT_CRIACAO,
                        }).ToList<dynamic>();
                    }
                    else if (colecao == 0)
                    {
                        CollectionTB_USUARIO_ALIAS = query.Select(e => new
                        {

                            UAL_ID_USUARIO_ALIAS = e.UAL_ID_USUARIO_ALIAS,
                            USU_ID_USUARIO = e.USU_ID_USUARIO,
                            UAL_TX_ALIAS = e.UAL_TX_ALIAS,
                            UAL_TX_SENHA = e.UAL_TX_SENHA,
                            UAL_NR_DIAS = e.UAL_NR_DIAS,
                            UAL_DT_SENHA = e.UAL_DT_SENHA,
                            UAL_BL_MUDAR = e.UAL_BL_MUDAR,
                            UAL_BL_ATIVO = e.UAL_BL_ATIVO,
                            UAL_NR_TENTATIVAS = e.UAL_NR_TENTATIVAS,
                            UAL_DT_TENTATIVAS = e.UAL_DT_TENTATIVAS,
                            UPA_ID_PERFIL_ALIAS = e.UPA_ID_PERFIL_ALIAS,
                            PER_ID_PERFIL_GENERICO = e.PER_ID_PERFIL_GENERICO,
                            UAL_BL_GRATUIDADE = e.UAL_BL_GRATUIDADE,
                            UAL_DT_CRIACAO = e.UAL_DT_CRIACAO,
                        }).ToList<dynamic>();
                    }

                    transaction.Commit();

                    retorno.Registros = CollectionTB_USUARIO_ALIAS;

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
        /// Adiciona nova TB_USUARIO_ALIAS
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static Int64 Add(string token, TB_USUARIO_ALIAS param, ModelApiUnes _dbContext = null)
        {
            ModelApiUnes _db;
            if (_dbContext == null) _db = new ModelApiUnes();
            else _db = _dbContext;

            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    _db.TB_USUARIO_ALIAS.Add(param);
                    _db.SaveChanges();
                    transaction.Commit();
                    return param.UAL_ID_USUARIO_ALIAS;
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
                        _db.Database.Connection.Close();
                        _db.Dispose();
                    }
                }
            }
        }


        /// <summary>
        /// Apaga uma TB_USUARIO_ALIAS
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static void Delete(string token, Int32 UAL_ID_USUARIO_ALIAS, ModelApiUnes _dbContext = null)
        {
            ModelApiUnes _db;
            if (_dbContext == null) _db = new ModelApiUnes();
            else _db = _dbContext;

            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    _db.TB_USUARIO_ALIAS.Remove(_db.TB_USUARIO_ALIAS.Where(e => e.UAL_ID_USUARIO_ALIAS.Equals(UAL_ID_USUARIO_ALIAS)).First());
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
                        _db.Database.Connection.Close();
                        _db.Dispose();
                    }
                }
            }
        }



        /// <summary>
        /// Altera TB_USUARIO_ALIAS
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static void Update(string token, TB_USUARIO_ALIAS param, ModelApiUnes _dbContext = null)
        {
            ModelApiUnes _db;
            if (_dbContext == null) _db = new ModelApiUnes();
            else _db = _dbContext;

            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    TB_USUARIO_ALIAS value = _db.TB_USUARIO_ALIAS
                                    .Where(e => e.UAL_ID_USUARIO_ALIAS.Equals(param.UAL_ID_USUARIO_ALIAS))
                                    .First<TB_USUARIO_ALIAS>();



                    if (param.UAL_ID_USUARIO_ALIAS != value.UAL_ID_USUARIO_ALIAS)
                        value.UAL_ID_USUARIO_ALIAS = param.UAL_ID_USUARIO_ALIAS;
                    if (param.USU_ID_USUARIO != value.USU_ID_USUARIO)
                        value.USU_ID_USUARIO = param.USU_ID_USUARIO;
                    if (param.UAL_TX_ALIAS != null && param.UAL_TX_ALIAS != value.UAL_TX_ALIAS)
                        value.UAL_TX_ALIAS = param.UAL_TX_ALIAS;
                    if (param.UAL_TX_SENHA != null && param.UAL_TX_SENHA != value.UAL_TX_SENHA)
                        value.UAL_TX_SENHA = param.UAL_TX_SENHA;
                    if (param.UAL_NR_DIAS != null && param.UAL_NR_DIAS != value.UAL_NR_DIAS)
                        value.UAL_NR_DIAS = param.UAL_NR_DIAS;
                    if (param.UAL_DT_SENHA != null && param.UAL_DT_SENHA != value.UAL_DT_SENHA)
                        value.UAL_DT_SENHA = param.UAL_DT_SENHA;
                    if (param.UAL_BL_MUDAR != value.UAL_BL_MUDAR)
                        value.UAL_BL_MUDAR = param.UAL_BL_MUDAR;
                    if (param.UAL_BL_ATIVO != value.UAL_BL_ATIVO)
                        value.UAL_BL_ATIVO = param.UAL_BL_ATIVO;
                    if (param.UAL_NR_TENTATIVAS != null && param.UAL_NR_TENTATIVAS != value.UAL_NR_TENTATIVAS)
                        value.UAL_NR_TENTATIVAS = param.UAL_NR_TENTATIVAS;
                    if (param.UAL_DT_TENTATIVAS != null && param.UAL_DT_TENTATIVAS != value.UAL_DT_TENTATIVAS)
                        value.UAL_DT_TENTATIVAS = param.UAL_DT_TENTATIVAS;
                    if (param.UPA_ID_PERFIL_ALIAS != null && param.UPA_ID_PERFIL_ALIAS != value.UPA_ID_PERFIL_ALIAS)
                        value.UPA_ID_PERFIL_ALIAS = param.UPA_ID_PERFIL_ALIAS;
                    if (param.PER_ID_PERFIL_GENERICO != null && param.PER_ID_PERFIL_GENERICO != value.PER_ID_PERFIL_GENERICO)
                        value.PER_ID_PERFIL_GENERICO = param.PER_ID_PERFIL_GENERICO;
                    if (param.UAL_BL_GRATUIDADE != null && param.UAL_BL_GRATUIDADE != value.UAL_BL_GRATUIDADE)
                        value.UAL_BL_GRATUIDADE = param.UAL_BL_GRATUIDADE;
                    if (param.UAL_DT_CRIACAO != null && param.UAL_DT_CRIACAO != value.UAL_DT_CRIACAO)
                        value.UAL_DT_CRIACAO = param.UAL_DT_CRIACAO;
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
                        _db.Database.Connection.Close();
                        _db.Dispose();
                    }
                }
            }
        }

        /// <summary>
        /// Autentica Usuário - TB_USUARIO_ALIAS
        /// </summary>
        /// <param name="senha"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
		public static Retorno Autenticate(String senha, String usuario)
        {
            try
            {
                var str = senha;
                var alg = SHA512.Create();
                byte[] byteArray = new byte[255];
                byteArray = alg.ComputeHash(Encoding.UTF8.GetBytes(str));
                var cript = BitConverter.ToString(byteArray).Replace("-", "");
                string senhaSHA512 = cript.Substring(64) + cript.Substring(0, 64);

                ModelApiUnes _db = new ModelApiUnes();
                int usuIdUsuario = (int)_db.TB_USUARIO.Where(u => u.USU_TX_USUARIO.Equals(usuario))
                                                     .Select(u => u.USU_ID_USUARIO).FirstOrDefault();

                TB_USUARIO_ALIAS ObjUsuario = _db.TB_USUARIO_ALIAS.Where(e => e.USU_ID_USUARIO.Equals(usuIdUsuario)
                                                                    && e.UAL_TX_ALIAS.Equals("admin")
                                                                    && e.UAL_TX_SENHA.Equals(senhaSHA512))
                                                              .Select(e => e).FirstOrDefault();
                if( ObjUsuario != null)
                    return GatewayTbUniversidadeTokenApi.NewToken(usuario + usuario.GetHashCode() + DateTime.Now + DateTime.Now.GetHashCode(), usuIdUsuario);
                else
                    return new Retorno();
            }
            catch (Exception e)
            {
                throw new Exception(e.InnerException == null ? e.Message : e.InnerException.InnerException == null ? e.InnerException.Message : e.InnerException.InnerException.Message);
            }
        }

        /// <summary>
        /// Verifica a Validade do Token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static Retorno ValidateToken(string token)
        {
            try
            {
                return GatewayTbUniversidadeTokenApi.Validade(token);
            }
            catch (Exception e)
            {
                throw new Exception(e.InnerException == null ? e.Message : e.InnerException.InnerException == null ? e.InnerException.Message : e.InnerException.InnerException.Message);
            }
        }


        public static Retorno ValidaCpfCnpjUsuario(string token, string usuario, string CpfCnpj)
        {

            ModelApiUnes _db = new ModelApiUnes();
            _db.Configuration.ProxyCreationEnabled = false;
            Retorno retorno = new Retorno();

            List<TB_USUARIO> usuUsuario = _db.TB_USUARIO.Where(u => u.USU_TX_USUARIO.Equals(usuario))
                                                 .Select(u => u).ToList<TB_USUARIO>();

            long cpfcnpj = Convert.ToInt64(CpfCnpj);
            List<TB_PESSOA> pesPessoa = _db.TB_PESSOA.Where(p => p.PES_NR_CPF_CNPJ == cpfcnpj)
                                                .Select(p => p).ToList<TB_PESSOA>();

            if ((usuUsuario.Count > 0) && (pesPessoa.Count > 0))
            {
                string dsSenha = new Random().Next(100000, 999999).ToString();
                var str = dsSenha;
                var alg = SHA512.Create();
                byte[] byteArray = new byte[255];
                byteArray = alg.ComputeHash(Encoding.UTF8.GetBytes(str));
                var cript = BitConverter.ToString(byteArray).Replace("-", "");
                string senhaSHA512 = cript.Substring(64) + cript.Substring(0, 64);

                long userId = usuUsuario[0].USU_ID_USUARIO;
                TB_USUARIO_ALIAS ObjUsuario = _db.TB_USUARIO_ALIAS
                                                 .Where(
                                                        e => e.USU_ID_USUARIO == userId
                                                        && e.UAL_TX_ALIAS.Equals("admin"))
                                                 .Select(e => e).FirstOrDefault();

                ObjUsuario.UAL_TX_SENHA = senhaSHA512;

                Update(token, ObjUsuario, _db);


                var texto = System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\App_Data\TemplateRecuperarSenha.txt");
                texto = texto.Replace("{ username }", usuario);
                texto = texto.Replace("{ XXXXXX }", dsSenha);

                Gateways.GatewayUtils.SendMail(texto, pesPessoa[0].PES_TX_EMAIL, "SERVELOJA - Recuperação de Senha");

                var list = new[] { new { Sucess = true } }.ToList<dynamic>();


                retorno.Registros = list;
            }
            
            return retorno;
        }


        public static Retorno ValidaCpfCnpj(string CpfCnpj)
        {
            ModelApiUnes _db = new ModelApiUnes();
            _db.Configuration.ProxyCreationEnabled = false;

            long cpfcnpj = Convert.ToInt64(CpfCnpj);
            List<dynamic> pesPessoa = _db.TB_PESSOA.Where(p => p.PES_NR_CPF_CNPJ == cpfcnpj)
                                                .Select(p => p).ToList<dynamic>();

            Retorno retorno = new Retorno();
            if (pesPessoa.Count > 0)
                retorno.Registros = pesPessoa;
            else
                retorno.Registros = new List<dynamic>();

            return retorno;
        }


        public static Retorno ValidaUsuario(string usuario)
        {
            ModelApiUnes _db = new ModelApiUnes();
            _db.Configuration.ProxyCreationEnabled = false;

            List<dynamic> usuUsuario = _db.TB_USUARIO.Where(u => u.USU_TX_USUARIO.Equals(usuario))
                                                 .Select(u => u).ToList<dynamic>();

            Retorno retorno = new Retorno();
            if (usuUsuario.Count > 0)
                retorno.Registros = usuUsuario;
            else
                retorno.Registros = new List<dynamic>();

            return retorno;
        }

    }
}