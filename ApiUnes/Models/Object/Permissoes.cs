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
                //Boolean result = Permissoes.GetAdminPermissionFromToken(token);
                //if (!result)
                //    return result;

                DateTime dt = DateTime.Now;
                var verify = _db.TB_UNIVERSIDADE_TOKEN_API
                                .Where(v => v.UTA_TX_TOKEN.Equals(token)
                                            && v.UTA_DT_VALIDADE > dt
                                        )
                                .Select(v => v).ToList();

                if (verify.Count != 0)
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
                Retorno retorno = new Retorno();
                long result = Permissoes.GetPerfilPermissionFromToken(token);
                if (result > 0 && result != 6)
                    retorno.Token = true;
                else
                    retorno.Token = false;

                var verify = _db.TB_UNIVERSIDADE_TOKEN_API
                                .Where(v => v.UTA_TX_TOKEN
                                .Equals(token))
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
                    Retorno retorno = new Retorno();
                    long result = Permissoes.GetPerfilPermissionFromToken(token);
                    if (result > 0 && result != 6)
                        retorno.Token = true;
                    else
                        retorno.Token = false;

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

        /// <summary>
        /// Retorna o id do perfil do token
        /// </summary>
        /// <param name="token"></param>
        /// <param name="_dbContext"></param>
        /// <returns></returns>
        public static long GetPerfilPermissionFromToken(string token, ModelApiUnes _dbContext = null) {

            ModelApiUnes _db;
            if (_dbContext == null) _db = new ModelApiUnes();
            else _db = _dbContext;
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {


                    string USU_TX_USUARIO = _db.TB_UNIVERSIDADE_TOKEN_API
                                            .Where(v => v.UTA_TX_TOKEN.Equals(token))
                                            .Select(v => v.TB_USUARIO.USU_TX_USUARIO)
                                            .FirstOrDefault();

                    long idPerfil = _db.TB_PERFIL_USUARIO.Where(p => p.PEU_TX_USERNAME == USU_TX_USUARIO)
                                         .Select( 
                                                    p => (p.PER_ID_PERFIL == 1) ? 1 : 
                                                            (p.PER_ID_PERFIL == 9 || p.PER_ID_PERFIL == 12 || p.PER_ID_PERFIL == 37) ? 2 :
                                                                (p.PER_ID_PERFIL == 5) ? 3 :
                                                                    (p.PER_ID_PERFIL == 3 || p.PER_ID_PERFIL == 4 || p.PER_ID_PERFIL == 6 || p.PER_ID_PERFIL == 7 || p.PER_ID_PERFIL == 8
                                                                     || p.PER_ID_PERFIL == 10 || p.PER_ID_PERFIL == 15 || p.PER_ID_PERFIL == 22 || p.PER_ID_PERFIL == 27 || p.PER_ID_PERFIL == 28 || p.PER_ID_PERFIL == 29
                                                                     || p.PER_ID_PERFIL == 33 || p.PER_ID_PERFIL == 34 || p.PER_ID_PERFIL == 35 || p.PER_ID_PERFIL == 36
                                                                     || p.PER_ID_PERFIL == 38 || p.PER_ID_PERFIL == 40 || p.PER_ID_PERFIL == 41) ? 4 :
                                                                         (p.PER_ID_PERFIL == 2 || p.PER_ID_PERFIL == 13 || p.PER_ID_PERFIL == 21 || p.PER_ID_PERFIL == 23 || p.PER_ID_PERFIL == 24
                                                                         || p.PER_ID_PERFIL == 25 || p.PER_ID_PERFIL == 26 || p.PER_ID_PERFIL == 32 || p.PER_ID_PERFIL == 39) ? 5 : 6
                                                 ).First();

                    Retorno retorno = new Retorno();
                    /*Boolean result = Permissoes.GetAdminPermissionFromToken(token);
                    retorno.Token = result;
                    if (!result)
                        return 0;*/

                    return idPerfil > 0 ? idPerfil : 0;


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


        /// <summary>
        /// Retorna true ou false
        /// </summary>
        /// <param name="token"></param>
        /// <param name="_dbContext"></param>
        /// <returns></returns>
        public static bool GetAdminPermissionFromToken(string token, ModelApiUnes _dbContext = null)
        {

            ModelApiUnes _db;
            if (_dbContext == null) _db = new ModelApiUnes();
            else _db = _dbContext;
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    string USU_TX_USUARIO = _db.TB_UNIVERSIDADE_TOKEN_API
                                            .Where(v => v.UTA_TX_TOKEN.Equals(token))
                                            .Select(v => v.TB_USUARIO.USU_TX_USUARIO)
                                            .FirstOrDefault();

                    long idPerfil = _db.TB_PERFIL_USUARIO.Where(p => p.PEU_TX_USERNAME == USU_TX_USUARIO)
                                         .Select(
                                                    p => (p.PER_ID_PERFIL == 1) ? 1 :
                                                            (p.PER_ID_PERFIL == 9 || p.PER_ID_PERFIL == 12 || p.PER_ID_PERFIL == 37) ? 2 :
                                                                (p.PER_ID_PERFIL == 5) ? 3 :
                                                                    (p.PER_ID_PERFIL == 3 || p.PER_ID_PERFIL == 4 || p.PER_ID_PERFIL == 6 || p.PER_ID_PERFIL == 7 || p.PER_ID_PERFIL == 8
                                                                     || p.PER_ID_PERFIL == 10 || p.PER_ID_PERFIL == 15 || p.PER_ID_PERFIL == 22 || p.PER_ID_PERFIL == 27 || p.PER_ID_PERFIL == 28 || p.PER_ID_PERFIL == 29
                                                                     || p.PER_ID_PERFIL == 33 || p.PER_ID_PERFIL == 34 || p.PER_ID_PERFIL == 35 || p.PER_ID_PERFIL == 36
                                                                     || p.PER_ID_PERFIL == 38 || p.PER_ID_PERFIL == 40 || p.PER_ID_PERFIL == 41) ? 4 :
                                                                         (p.PER_ID_PERFIL == 2 || p.PER_ID_PERFIL == 13 || p.PER_ID_PERFIL == 21 || p.PER_ID_PERFIL == 23 || p.PER_ID_PERFIL == 24
                                                                         || p.PER_ID_PERFIL == 25 || p.PER_ID_PERFIL == 26 || p.PER_ID_PERFIL == 32 || p.PER_ID_PERFIL == 39) ? 5 : 6
                                                 ).First();

                    return idPerfil == 1 ? true : false;


                }
                catch
                {
                    return false;
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



        /// <summary>
        /// Retorna true ou false
        /// </summary>
        /// <param name="token"></param>
        /// <param name="_dbContext"></param>
        /// <returns></returns>
        public static bool GetAdminPermissionFromUser(string USU_TX_USUARIO, ModelApiUnes _dbContext = null)
        {

            ModelApiUnes _db;
            if (_dbContext == null) _db = new ModelApiUnes();
            else _db = _dbContext;
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    long idPerfil = _db.TB_PERFIL_USUARIO.Where(p => p.PEU_TX_USERNAME == USU_TX_USUARIO)
                                         .Select(
                                                    p => (p.PER_ID_PERFIL == 1) ? 1 :
                                                            (p.PER_ID_PERFIL == 8 || p.PER_ID_PERFIL == 9 || p.PER_ID_PERFIL == 12 || p.PER_ID_PERFIL == 37) ? 2 :
                                                                (p.PER_ID_PERFIL == 5) ? 3 :
                                                                    (p.PER_ID_PERFIL == 3 || p.PER_ID_PERFIL == 4 || p.PER_ID_PERFIL == 6 || p.PER_ID_PERFIL == 7
                                                                     || p.PER_ID_PERFIL == 10 || p.PER_ID_PERFIL == 15 || p.PER_ID_PERFIL == 22 || p.PER_ID_PERFIL == 27 || p.PER_ID_PERFIL == 28 || p.PER_ID_PERFIL == 29
                                                                     || p.PER_ID_PERFIL == 33 || p.PER_ID_PERFIL == 34 || p.PER_ID_PERFIL == 35 || p.PER_ID_PERFIL == 36
                                                                     || p.PER_ID_PERFIL == 38 || p.PER_ID_PERFIL == 40 || p.PER_ID_PERFIL == 41) ? 4 :
                                                                         (p.PER_ID_PERFIL == 2 || p.PER_ID_PERFIL == 13 || p.PER_ID_PERFIL == 21 || p.PER_ID_PERFIL == 23 || p.PER_ID_PERFIL == 24
                                                                         || p.PER_ID_PERFIL == 25 || p.PER_ID_PERFIL == 26 || p.PER_ID_PERFIL == 32 || p.PER_ID_PERFIL == 39) ? 5 : 6
                                                 ).First();

                    return idPerfil != 6 ? true : false;


                }
                catch
                {
                    return false;
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