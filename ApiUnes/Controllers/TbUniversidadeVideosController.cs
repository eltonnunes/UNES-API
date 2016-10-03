using System;
using System.Collections.Generic;
using System.Linq;
using ApiUnes.Models;
using ApiUnes.Models.Object;
using ApiUnes.Negocios.Dbo;
using System.Web.Http;
using System.Net.Http;

namespace ApiUnes.Controllers.Dbo
{
    public class TbUniversidadeVideosController : ApiController
    {
        [HttpGet]
        [AcceptVerbs("GET")]
        // GET /TB_UNIVERSIDADE_VIDEOS/token/colecao/campo/orderBy/pageSize/pageNumber?CAMPO1=VALOR&CAMPO2=VALOR
        public Retorno Get(string token, int colecao = 0, int campo = 0, int orderBy = 0, int pageSize = 0, int pageNumber = 0)
        {
            // Abre nova conexão
            using (ServeLojaContext _db = new ServeLojaContext())
            {
                try
                {
                    Dictionary<string, string> queryString = Request.GetQueryNameValuePairs().ToDictionary(x => x.Key, x => x.Value);

                    if (Permissoes.Autenticado(token, _db))
                    {
                        return GatewayTbUniversidadeVideos.Get(token, colecao, campo, orderBy, pageSize, pageNumber, queryString);
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


        [HttpPost]
        [AcceptVerbs("POST")]
        // POST /TB_UNIVERSIDADE_VIDEOS/token/
        public Int64 Post(string token, [FromBody]TB_UNIVERSIDADE_VIDEOS param)
        {
            // Abre nova conexão
            using (ModelApiUnes _db = new ModelApiUnes())
            {
                try
                {
                    if (Permissoes.Autenticado(token, _db))
                    {
                        return GatewayTbUniversidadeVideos.Add(token, param, _db);
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


        //[HttpPut]
        //[AcceptVerbs("PUT")]
        // PUT /TB_UNIVERSIDADE_VIDEOS/token/
        /*public void Put(string token, [FromBody]TB_UNIVERSIDADE_VIDEOS param)
        {
            // Abre nova conexão
            using (ModelApiUnes _db = new ModelApiUnes())
            {
                try
                {
                    if (Permissoes.Autenticado(token, _db))
                    {
                        if (param.UNV_TX_HASH != null)
                        {
                            param.UNV_DT_DATA = null;
                            //param.UNV_NR_VIEW = null;
                            GatewayTbUniversidadeVideos.Update(token, param, _db);
                        }
                        else
                        {
                            Estatisticas values = new Estatisticas();
                            values.Idvideo = param.UNV_ID_VIDEOS;
                            values.Idusuario = Permissoes.GetIdUserFromToken(token);

                            GatewayTbUniversidadeVideos.Update(token, values);

                            TB_UNIVERSIDADE_ESTATISTICAS paramSt = new TB_UNIVERSIDADE_ESTATISTICAS();
                            paramSt.UNV_ID_VIDEOS = values.Idvideo;
                            paramSt.USU_ID_USUARIO = values.Idusuario;
                            paramSt.UNE_DT_DATAVIEW = DateTime.Now;

                            GatewayTbUniversidadeEstatisticas.Add(token, paramSt);
                        }
                    }
                    else
                        throw new Exception("Unauthorized");
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }*/



        [HttpPut]
        [AcceptVerbs("PUT")]
        // PUT /TB_UNIVERSIDADE_VIDEOS/token/
        public void Put(string token, TB_UNIVERSIDADE_VIDEOS param)
        {
            // Abre nova conexão
            using (ModelApiUnes _db = new ModelApiUnes())
            {
                try
                {
                    if (Permissoes.Autenticado(token, _db))
                    {
                        if (param.UNV_TX_HASH != null)
                        {
                            param.UNV_DT_DATA = null;
                            //param.UNV_NR_VIEW = null;
                            GatewayTbUniversidadeVideos.Update(token, param, _db);
                        }
                        else
                        {
                            Estatisticas values = new Estatisticas();
                            values.Idvideo = param.UNV_ID_VIDEOS;
                            values.Idusuario = Permissoes.GetIdUserFromToken(token);

                            GatewayTbUniversidadeVideos.Update(token, values);

                            TB_UNIVERSIDADE_ESTATISTICAS paramSt = new TB_UNIVERSIDADE_ESTATISTICAS();
                            paramSt.UNV_ID_VIDEOS = values.Idvideo;
                            paramSt.USU_ID_USUARIO = values.Idusuario;
                            paramSt.UNE_DT_DATAVIEW = DateTime.Now;

                            GatewayTbUniversidadeEstatisticas.Add(token, paramSt);
                        }
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

        [HttpDelete]
        [AcceptVerbs("DELETE")]
        // DELETE /TB_UNIVERSIDADE_VIDEOS/token/UNV_ID_VIDEOS
        public void Delete(string token, Int64 id)
        {
            // Abre nova conexão
            using (ModelApiUnes _db = new ModelApiUnes())
            {
                try
                {
                    if (Permissoes.Autenticado(token, _db))
                    {
                        GatewayTbUniversidadeVideos.Delete(token, id, _db);
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