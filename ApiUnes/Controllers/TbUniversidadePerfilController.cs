using System;
using System.Collections.Generic;
using System.Linq;
using ApiUnes.Gateways.Dbo;
using ApiUnes.Models;
using ApiUnes.Models.Object;
using System.Web.Http;
using System.Net.Http;
using ApiUnes.Negocios.Dbo;

namespace ApiUnes.Controllers.Dbo
{
    public class TbUniversidadePerfilController : ApiController
    {

        // GET /TbUniversidadePerfil/token/colecao/campo/orderBy/pageSize/pageNumber?CAMPO1=VALOR&CAMPO2=VALOR
        public Retorno Get(string token, int colecao = 0, int campo = 0, int orderBy = 0, int pageSize = 0, int pageNumber = 0)
        {
            // Abre nova conexão
            try
            {
                ModelApiUnes _db = new ModelApiUnes();
                Dictionary<string, string> queryString = Request.GetQueryNameValuePairs().ToDictionary(x => x.Key, x => x.Value);


                if (Permissoes.Autenticado(token, _db))
                {
                    return GatewayTbUniversidadePerfil.Get(token, colecao, campo, orderBy, pageSize, pageNumber, queryString, _db);
                }
                else
                    return new Retorno() { Token = false }; //throw new Exception("Unauthorized");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        // POST /TbUniversidadePerfil/token/
        [HttpPost]
        [AcceptVerbs("POST")]
        public long Post(string token, [FromBody]TB_UNIVERSIDADE_PERFIL param)
        {
            // Abre nova conexão
            using (ModelApiUnes _db = new ModelApiUnes())
            {
                try
                {
                    if (Permissoes.Autenticado(token, _db))
                    {
                        return GatewayTbUniversidadePerfil.Add(token, param, _db);
                    }
                    else
                        return 0; //throw new Exception("Unauthorized");
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }


        // PUT /TbUniversidadePerfil/token/
        [HttpPut]
        [AcceptVerbs("PUT")]
        public void Put(string token, [FromBody]TB_UNIVERSIDADE_PERFIL param)
        {
            // Abre nova conexão
            using (ModelApiUnes _db = new ModelApiUnes())
            {
                try
                {
                    if (Permissoes.Autenticado(token, _db))
                    {
                        GatewayTbUniversidadePerfil.Update(token, param, _db);
                    }
                    //else
                    //    return new Retorno() { Token = false }; //throw new Exception("Unauthorized");
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }


        // DELETE /TbUniversidadePerfil/token/UNP_ID_PERFIL
        [HttpDelete]
        [AcceptVerbs("DELETE")]
        public void Delete(string token, Int32 UNP_ID_PERFIL)
        {
            // Abre nova conexão
            using (ModelApiUnes _db = new ModelApiUnes())
            {
                try
                {
                    if (Permissoes.Autenticado(token, _db))
                    {
                        GatewayTbUniversidadePerfil.Delete(token, UNP_ID_PERFIL, _db);
                    }
                    //else
                    //    return new Retorno() { Token = false }; //throw new Exception("Unauthorized");
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }
    }
}
