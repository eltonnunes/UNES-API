using System;
using System.Collections.Generic;
using System.Linq;
using ApiUnes.Gateways.Dbo;
using ApiUnes.Models;
using ApiUnes.Models.Object;
using System.Web.Http;
using System.Net.Http;

namespace ApiUnes.Controllers
{
    public class TbUniversidadeTokenApiController : ApiController
    {

        // GET /Tb_Universidade_Token_Api/token/colecao/campo/orderBy/pageSize/pageNumber?CAMPO1=VALOR&CAMPO2=VALOR
        public Retorno Get(string token, int colecao = 0, int campo = 0, int orderBy = 0, int pageSize = 0, int pageNumber = 0)
        {
            // Abre nova conexão
            using (ModelApiUnes _db = new ModelApiUnes())
            {
                try
                {
                    Dictionary<string, string> queryString = Request.GetQueryNameValuePairs().ToDictionary(x => x.Key, x => x.Value);

                    if (Permissoes.Autenticado(token, _db))
                        return GatewayTbUniversidadeTokenApi.Get(token, colecao, campo, orderBy, pageSize, pageNumber, queryString, _db);
                    else
                        throw new Exception("Unauthorized");
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }

/*
        // POST /Tb_Universidade_Token_Api/token/
        [HttpPost("{token}/{Tb_Universidade_Token_Api}")]
        public HttpResponseMessage Post(string token, [FromBody]Tb_Universidade_Token_Api param)
        {
            // Abre nova conexão
            using (painel_taxservices_dbContext _db = new painel_taxservices_dbContext())
            {
                tbLogAcessoUsuario log = new tbLogAcessoUsuario();
                try
                {
                    log = Bibliotecas.LogAcaoUsuario.New(token, JsonConvert.SerializeObject(param), "Post", _db);

                    HttpResponseMessage retorno = new HttpResponseMessage();
                    if (Permissoes.Autenticado(token, _db))
                    {
                        Int32 dados = GatewayTbUniversidade_Token_Api.Add(token, param, _db);
                        log.codResposta = (int)HttpStatusCode.OK;
                        Bibliotecas.LogAcaoUsuario.Save(log, _db);
                        return Request.CreateResponse<Int32>(HttpStatusCode.OK, dados);
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


        // PUT /Tb_Universidade_Token_Api/token/
        [HttpPost("{token}/{Tb_Universidade_Token_Api}")]
        public HttpResponseMessage Put(string token, [FromBody]Tb_Universidade_Token_Api param)
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
                        GatewayTbUniversidade_Token_Api.Update(token, param, _db);
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


        // DELETE /Tb_Universidade_Token_Api/token/UTA_ID_TOKEN_API
        [HttpPost("{token}/{UTA_ID_TOKEN_API}")]
        public HttpResponseMessage Delete(string token, Int32 UTA_ID_TOKEN_API)
        {
            // Abre nova conexão
            using (painel_taxservices_dbContext _db = new painel_taxservices_dbContext())
            {
                tbLogAcessoUsuario log = new tbLogAcessoUsuario();
                try
                {
                    log = Bibliotecas.LogAcaoUsuario.New(token, JsonConvert.SerializeObject("UTA_ID_TOKEN_API : " + UTA_ID_TOKEN_API), "Delete", _db);

                    HttpResponseMessage retorno = new HttpResponseMessage();
                    if (Permissoes.Autenticado(token, _db))
                    {
                        GatewayTbUniversidade_Token_Api.Delete(token, UTA_ID_TOKEN_API, _db);
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