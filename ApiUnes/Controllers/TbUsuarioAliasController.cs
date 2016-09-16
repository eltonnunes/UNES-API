using System;
using System.Collections.Generic;
using ApiUnes.Models;
using ApiUnes.Gateways.Dbo;
using ApiUnes.Models.Object;
using System.Linq;
using System.Web.Http;
using System.Net.Http;

namespace api.Controllers.Dbo
{
    public class TbUsuarioAliasController : ApiController
    {

        // GET /TbUsuarioAlias/token/colecao/campo/orderBy/pageSize/pageNumber?CAMPO1=VALOR&CAMPO2=VALOR
        public Retorno Get(string token, int colecao = 0, int campo = 0, int orderBy = 0, int pageSize = 0, int pageNumber = 0)
        {
            // Abre nova conexão
            using (ModelApiUnes _db = new ModelApiUnes())
            {
                try
                {
                    Dictionary<string, string> queryString = Request.GetQueryNameValuePairs().ToDictionary(x => x.Key, x => x.Value);
                    if (Permissoes.Autenticado(token, _db))
                    {
                        return GatewayTbUsuarioAlias.Get(token, colecao, campo, orderBy, pageSize, pageNumber, queryString, _db);
                    }
                    else
                        throw new Exception("Unauthorized");
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }


        // POST /TbUsuarioAlias/token/
        public Retorno Post([FromBody]Login login)
        {
            // Abre nova conexão
            ModelApiUnes _db = new ModelApiUnes();
            try
            {
                //Login login = (Login)formObj;
                //if (Permissoes.Autenticado(token, _db))
                //{
                return GatewayTbUsuarioAlias.Autenticate(login.Senha, login.Usuario);
                // }
                //else
                //{
                ///return Request.CreateResponse(HttpStatusCode.Unauthorized);
                //}
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        /*// PUT /TbUsuarioAlias/token/
        [HttpPut("{token}/{TbUsuarioAlias}")]
        public HttpResponseMessage Put(string token, [FromBody]TbUsuarioAlias param)
        {
            // Abre nova conexão
            using (painel_taxservices_dbContext _db = new painel_taxservices_dbContext())
            {
                tbLogAcessoUsuario log = new tbLogAcessoUsuario();
                try
                {
                    log = Bibliotecas.LogAcaoUsuario.New(token, JsonConvert.SerializeObject(param), "Put", _db);

                    HttpResponseMessage retorno = new HttpResponseMessage();
                    if (Permissoes.Autenticado(token, _db))
                    {
                        GatewayTBUSUARIO_ALIAS.Update(token, param, _db);
                        log.codResposta = (int)HttpStatusCode.OK;
                        Bibliotecas.LogAcaoUsuario.Save(log, _db);
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                    {
                        log.codResposta = (int)HttpStatusCode.Unauthorized;
                        Bibliotecas.LogAcaoUsuario.Save(log, _db);
                        return Request.CreateResponse(HttpStatusCode.Unauthorized);
                    }
                }
                catch (Exception e)
                {
                    log.codResposta = (int)HttpStatusCode.InternalServerError;
                    log.msgErro = e.Message;
                    Bibliotecas.LogAcaoUsuario.Save(log);//, _db);
                    throw new HttpResponseException(HttpStatusCode.InternalServerError);
                }
            }
        }


        // DELETE /TbUsuarioAlias/token/UAL_ID_USUARIO_ALIAS
        [HttpDelete("{token}/{UAL_ID_USUARIO_ALIAS}")]
        public HttpResponseMessage Delete(string token, Int32 UAL_ID_USUARIO_ALIAS)
        {
            // Abre nova conexão
            using (painel_taxservices_dbContext _db = new painel_taxservices_dbContext())
            {
                tbLogAcessoUsuario log = new tbLogAcessoUsuario();
                try
                {
                    log = Bibliotecas.LogAcaoUsuario.New(token, JsonConvert.SerializeObject("UAL_ID_USUARIO_ALIAS : " + UAL_ID_USUARIO_ALIAS), "Delete", _db);

                    HttpResponseMessage retorno = new HttpResponseMessage();
                    if (Permissoes.Autenticado(token, _db))
                    {
                        GatewayTBUSUARIO_ALIAS.Delete(token, UAL_ID_USUARIO_ALIAS, _db);
                        log.codResposta = (int)HttpStatusCode.OK;
                        Bibliotecas.LogAcaoUsuario.Save(log, _db);
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                    {
                        log.codResposta = (int)HttpStatusCode.Unauthorized;
                        Bibliotecas.LogAcaoUsuario.Save(log, _db);
                        return Request.CreateResponse(HttpStatusCode.Unauthorized);
                    }
                }
                catch (Exception e)
                {
                    log.codResposta = (int)HttpStatusCode.InternalServerError;
                    log.msgErro = e.Message;
                    Bibliotecas.LogAcaoUsuario.Save(log);//, _db);
                    throw new HttpResponseException(HttpStatusCode.InternalServerError);
                }
            }
        }*/
    }
}
