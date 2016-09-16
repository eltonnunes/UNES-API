using System;
using System.Collections.Generic;
using System.Linq;
using ApiUnes.Models;
using ApiUnes.Models.Object;

namespace ApiUnes.Negocios.Dbo
{
		public class GatewayTbUniversidadeEstatisticas
    {

        /// <summary>
        /// Auto Loader
        /// </summary>
        public GatewayTbUniversidadeEstatisticas()
        {
            
        }

        public static string SIGLA_QUERY = "";

        /// <summary>
        /// Enum CAMPOS
        /// </summary>
        public enum CAMPOS
        {
                UNE_ID_ESTATISTICAS = 100,
                UNV_ID_VIDEOS = 101,
                USU_ID_USUARIO = 102,
                UNE_DT_DATAVIEW = 103,
       };

        /// <summary>
        /// Get Tb_Universidade_Estatisticas/Tb_Universidade_Estatisticas
        /// </summary>
        /// <param name="colecao"></param>
        /// <param name="campo"></param>
        /// <param name="orderby"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="queryString"></param>
        /// <returns></returns>
        private static IQueryable<TB_UNIVERSIDADE_ESTATISTICAS> getQuery(ModelApiUnes _db, int colecao, int campo, int orderby, int pageSize, int pageNumber, Dictionary<string, string> queryString)
        {
            _db.Configuration.ProxyCreationEnabled = false;

            // DEFINE A QUERY PRINCIPAL 
            var entity = _db.TB_UNIVERSIDADE_ESTATISTICAS.AsQueryable<TB_UNIVERSIDADE_ESTATISTICAS>();

            #region WHERE - ADICIONA OS FILTROS A QUERY

                // ADICIONA OS FILTROS A QUERY
                foreach (var item in queryString)
                {
                    int key = Convert.ToInt16(item.Key);
                    CAMPOS filtroEnum = (CAMPOS)key;
                    switch (filtroEnum)
                    {
				

								case CAMPOS.UNE_ID_ESTATISTICAS:
									Int32 UNE_ID_ESTATISTICAS = Convert.ToInt32(item.Value);
									entity = entity.Where(e => e.UNE_ID_ESTATISTICAS.Equals(UNE_ID_ESTATISTICAS)).AsQueryable<TB_UNIVERSIDADE_ESTATISTICAS>();
								break;
								case CAMPOS.UNV_ID_VIDEOS:
									Int32 UNV_ID_VIDEOS = Convert.ToInt32(item.Value);
									entity = entity.Where(e => e.UNV_ID_VIDEOS.Equals(UNV_ID_VIDEOS)).AsQueryable<TB_UNIVERSIDADE_ESTATISTICAS>();
								break;
								case CAMPOS.USU_ID_USUARIO:
									Int32 USU_ID_USUARIO = Convert.ToInt32(item.Value);
									entity = entity.Where(e => e.USU_ID_USUARIO.Equals(USU_ID_USUARIO)).AsQueryable<TB_UNIVERSIDADE_ESTATISTICAS>();
								break;
								case CAMPOS.UNE_DT_DATAVIEW:
									DateTime UNE_DT_DATAVIEW = Convert.ToDateTime(item.Value);
									entity = entity.Where(e => e.UNE_DT_DATAVIEW.Equals(UNE_DT_DATAVIEW)).AsQueryable<TB_UNIVERSIDADE_ESTATISTICAS>();
								break;

                    }
                }
            #endregion

            #region ORDER BY - ADICIONA A ORDENAÇÃO A QUERY
                // ADICIONA A ORDENAÇÃO A QUERY
                CAMPOS filtro = (CAMPOS)campo;
                switch (filtro)
                {

						case CAMPOS.UNE_ID_ESTATISTICAS: 
							if (orderby == 0)  entity = entity.OrderBy(e => e.UNE_ID_ESTATISTICAS).AsQueryable<TB_UNIVERSIDADE_ESTATISTICAS>();
							else entity = entity.OrderByDescending(e =>  e.UNE_ID_ESTATISTICAS).AsQueryable<TB_UNIVERSIDADE_ESTATISTICAS>();
						break;
						case CAMPOS.UNV_ID_VIDEOS: 
							if (orderby == 0)  entity = entity.OrderBy(e => e.UNV_ID_VIDEOS).AsQueryable<TB_UNIVERSIDADE_ESTATISTICAS>();
							else entity = entity.OrderByDescending(e =>  e.UNV_ID_VIDEOS).AsQueryable<TB_UNIVERSIDADE_ESTATISTICAS>();
						break;
						case CAMPOS.USU_ID_USUARIO: 
							if (orderby == 0)  entity = entity.OrderBy(e => e.USU_ID_USUARIO).AsQueryable<TB_UNIVERSIDADE_ESTATISTICAS>();
							else entity = entity.OrderByDescending(e =>  e.USU_ID_USUARIO).AsQueryable<TB_UNIVERSIDADE_ESTATISTICAS>();
						break;
						case CAMPOS.UNE_DT_DATAVIEW: 
							if (orderby == 0)  entity = entity.OrderBy(e => e.UNE_DT_DATAVIEW).AsQueryable<TB_UNIVERSIDADE_ESTATISTICAS>();
							else entity = entity.OrderByDescending(e =>  e.UNE_DT_DATAVIEW).AsQueryable<TB_UNIVERSIDADE_ESTATISTICAS>();
						break;

                }
            #endregion

            return entity;


        }



        /// <summary>
        /// Retorna Tb_Universidade_Estatisticas/Tb_Universidade_Estatisticas
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
							List<dynamic> CollectionTb_Universidade_Estatisticas = new List<dynamic>();
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
									CollectionTb_Universidade_Estatisticas = query.Select(e => new
									{
	
 
 
 

						UNE_ID_ESTATISTICAS = e.UNE_ID_ESTATISTICAS,
						UNV_ID_VIDEOS = e.UNV_ID_VIDEOS,
						USU_ID_USUARIO = e.USU_ID_USUARIO,
						UNE_DT_DATAVIEW = e.UNE_DT_DATAVIEW,
									}).ToList<dynamic>();
							}
							else if (colecao == 0)
							{
									CollectionTb_Universidade_Estatisticas = query.Select(e => new
									{
	
						UNE_ID_ESTATISTICAS = e.UNE_ID_ESTATISTICAS,
						UNV_ID_VIDEOS = e.UNV_ID_VIDEOS,
						USU_ID_USUARIO = e.USU_ID_USUARIO,
						UNE_DT_DATAVIEW = e.UNE_DT_DATAVIEW,
									}).ToList<dynamic>();
							}

							retorno.Registros = CollectionTb_Universidade_Estatisticas;
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
        /// Adiciona nova Tb_Universidade_Estatisticas
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static Int64 Add(string token, TB_UNIVERSIDADE_ESTATISTICAS param, ModelApiUnes _dbContext = null)
        {
						ModelApiUnes _db;
            if (_dbContext == null) _db = new ModelApiUnes();
            else _db = _dbContext;
            using (var transaction = _db.Database.BeginTransaction())
            {
				try
				{
					_db.TB_UNIVERSIDADE_ESTATISTICAS.Add(param);
					_db.SaveChanges();
					transaction.Commit();
					return param.UNE_ID_ESTATISTICAS;
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
        /// Apaga uma Tb_Universidade_Estatisticas
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static void Delete(string token, Int32 UNE_ID_ESTATISTICAS, ModelApiUnes _dbContext = null)
        {
						ModelApiUnes _db;
            if (_dbContext == null) _db = new ModelApiUnes();
            else _db = _dbContext;
            using (var transaction = _db.Database.BeginTransaction())
            {
				try
				{
					_db.TB_UNIVERSIDADE_ESTATISTICAS.Remove(_db.TB_UNIVERSIDADE_ESTATISTICAS.Where(e => e.UNE_ID_ESTATISTICAS.Equals(UNE_ID_ESTATISTICAS)).First());
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
        /// Altera TB_UNIVERSIDADE_ESTATISTICAS
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static void Update(string token, TB_UNIVERSIDADE_ESTATISTICAS param, ModelApiUnes _dbContext = null)
        {
						ModelApiUnes _db;
            if (_dbContext == null) _db = new ModelApiUnes();
            else _db = _dbContext;
            using (var transaction = _db.Database.BeginTransaction())
            {
						try
						{
							TB_UNIVERSIDADE_ESTATISTICAS value = _db.TB_UNIVERSIDADE_ESTATISTICAS
											.Where(e => e.UNE_ID_ESTATISTICAS.Equals(param.UNE_ID_ESTATISTICAS))
											.First<TB_UNIVERSIDADE_ESTATISTICAS>();

							

									if (param.UNE_ID_ESTATISTICAS != value.UNE_ID_ESTATISTICAS)
						value.UNE_ID_ESTATISTICAS = param.UNE_ID_ESTATISTICAS;
									if (param.UNV_ID_VIDEOS != value.UNV_ID_VIDEOS)
						value.UNV_ID_VIDEOS = param.UNV_ID_VIDEOS;
									if (param.USU_ID_USUARIO != value.USU_ID_USUARIO)
						value.USU_ID_USUARIO = param.USU_ID_USUARIO;
									if (param.UNE_DT_DATAVIEW != null && param.UNE_DT_DATAVIEW != value.UNE_DT_DATAVIEW)
						value.UNE_DT_DATAVIEW = param.UNE_DT_DATAVIEW;
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