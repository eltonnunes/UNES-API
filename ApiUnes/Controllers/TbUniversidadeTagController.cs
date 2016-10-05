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
    public class TbUniversidadeTagController : ApiController
    {

        // GET /TB_UNIVERSIDADE_TAG/token/colecao/campo/orderBy/pageSize/pageNumber?CAMPO1=VALOR&CAMPO2=VALOR
        public Retorno Get(string token, int colecao = 0, int campo = 0, int orderBy = 0, int pageSize = 0, int pageNumber = 0)
        {
            try
            {
                ModelApiUnes _db = new ModelApiUnes();
                Dictionary<string, string> queryString = Request.GetQueryNameValuePairs().ToDictionary(x => x.Key, x => x.Value);

                Retorno dados = GatewayTbUniversidadeTag.Get(token, colecao, campo, orderBy, pageSize, pageNumber, queryString, _db);
                return dados;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        // POST /TB_UNIVERSIDADE_TAG/token/
        [HttpPost]
        public Int64 Post(string token, [FromBody]TB_UNIVERSIDADE_TAG param)
        {
            // Abre nova conexão
            using (ModelApiUnes _db = new ModelApiUnes())
            {
                try
                {
                    if (Permissoes.Autenticado(token, _db))
                    {
                        Int64 dados = GatewayTbUniversidadeTag.Add(token, param, _db);
                        return dados;
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


        // PUT /TB_UNIVERSIDADE_TAG/token/
        [HttpPost]
        public void Put(string token, [FromBody]TB_UNIVERSIDADE_TAG param)
        {
            // Abre nova conexão
            using (ModelApiUnes _db = new ModelApiUnes())
            {
                try
                {
                    if (Permissoes.Autenticado(token, _db))
                    {
                        GatewayTbUniversidadeTag.Update(token, param, _db);
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


        // DELETE /TB_UNIVERSIDADE_TAG/token/
        [HttpPost]
        public void Delete(string token, Int64 id)
        {
            // Abre nova conexão
            using (ModelApiUnes _db = new ModelApiUnes())
            {
                try
                {
                    if (Permissoes.Autenticado(token, _db))
                    {
                        GatewayTbUniversidadeTag.Delete(token, id, _db);
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
    }
}