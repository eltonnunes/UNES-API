using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace ApiUnes.Models.Object
{
    public class Permissoes
    {
        /// <summary>
        /// Retorna true se o token informado é válido
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static bool Autenticado(string token, ServeLojaContext _dbContext = null)
        {
            ServeLojaContext _db;
            if (_dbContext == null) _db = new ServeLojaContext();
            else _db = _dbContext;
            //using (var transaction = _db.Database.BeginTransaction())
            //{
            try
            {


                var verify = _db.TB_UNIVERSIDADE_TOKEN_API
                                //.Where(v => v.UTA_TX_TOKEN
                                //.Equals(token))
                                .Select(v => v).ToList();
                //.FirstOrDefault();



                if (verify != null)
                    return true;

                return false;
            }
            catch (Exception e)
            {
                if (e is DbEntityValidationException)
                {
                    string erro = MensagemErro.getMensagemErro((DbEntityValidationException)e);
                    throw new Exception(erro.Equals("") ? "Falha ao consultar pdvs" : erro);
                }
                throw new Exception(e.InnerException == null ? e.Message : e.InnerException.InnerException == null ? e.InnerException.Message : e.InnerException.InnerException.Message);

                //return false;
            }
            finally
            {
                if (_dbContext == null)
                {
                    //transaction.Dispose();
                    _db.Database.Connection.Close();
                    _db.Dispose();
                }
            }
            //}
        }


        /// <summary>
        /// Retorna true se o token informado é válido
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static bool Autenticado(string token, ModelApiUnes _dbContext = null)
        {
            ModelApiUnes _db;
            if (_dbContext == null) _db = new ModelApiUnes();
            else _db = _dbContext;
            //using (var transaction = _db.Database.BeginTransaction())
            //{
            try
            {


                var verify = _db.TB_UNIVERSIDADE_TOKEN_API
                                //.Where(v => v.UTA_TX_TOKEN
                                //.Equals(token))
                                .Select(v => v).ToList();
                //.FirstOrDefault();



                if (verify != null)
                    return true;

                return false;
            }
            catch (Exception e)
            {
                if (e is DbEntityValidationException)
                {
                    string erro = MensagemErro.getMensagemErro((DbEntityValidationException)e);
                    throw new Exception(erro.Equals("") ? "Falha ao consultar pdvs" : erro);
                }
                throw new Exception(e.InnerException == null ? e.Message : e.InnerException.InnerException == null ? e.InnerException.Message : e.InnerException.InnerException.Message);

                //return false;
            }
            finally
            {
                if (_dbContext == null)
                {
                    //transaction.Dispose();
                    _db.Database.Connection.Close();
                    _db.Dispose();
                }
            }
            //}
        }


        /// <summary>
        /// Retorna true se o token informado é válido
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static Int64 GetIdUserFromToken(string token, ModelApiUnes _dbContext = null)
        {
            ModelApiUnes _db;
            if (_dbContext == null) _db = new ModelApiUnes();
            else _db = _dbContext;
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    var verify = _db.TB_UNIVERSIDADE_TOKEN_API
                                    .Where(v => v.UTA_TX_TOKEN
                                    .Equals(token))
                                    .Select(v => v)
                                    .FirstOrDefault();

                    if (verify != null)
                        return verify.USU_ID_USUARIO;

                    return 0;
                }
                catch
                {
                    return 0;
                }
                finally
                {
                    if (_dbContext == null)
                    {
                        transaction.Dispose();
                        _db.Database.Connection.Close();
                        _db.Dispose();
                    }
                }
            }
        }
    }
}