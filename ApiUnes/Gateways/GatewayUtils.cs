using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApiUnes.Models;
using ApiUnes.Models.Object;
using System.Net.Mail;

namespace ApiUnes.Gateways
{
    public class GatewayUtils
    {
        public static void RecuperarSenha() {

        }

        /// <summary>
        /// Enum CAMPOS
        /// </summary>
        public enum CAMPOS
        {
            USUARIO = 100,
            CPF = 101,
            CNPJ = 102,

        };


        /// <summary>
        /// Retorna Utils
        /// </summary>
        /// <returns></returns>
        public static Retorno Get(string token, int colecao = 0, int campo = 0, int orderBy = 0, int pageSize = 0, int pageNumber = 0, Dictionary<string, string> queryString = null, ModelApiUnes _dbContext = null)
        {
            Retorno retorno = new Retorno();
            string CODIGO = null;
            string CNPJCPF = null;
            string CPF = null;
            string CNPJ = null;

            // ADICIONA OS FILTROS A QUERY
            foreach (var item in queryString)
            {
                int key = Convert.ToInt16(item.Key);
                CAMPOS filtroEnum = (CAMPOS)key;
                switch (filtroEnum)
                {
                    case CAMPOS.USUARIO:
                        CODIGO = item.Value;
                    break;

                    case CAMPOS.CPF:
                        CPF = item.Value;
                    break;

                    case CAMPOS.CNPJ:
                        CNPJ = item.Value;
                    break;
                }
            }

            if (!string.IsNullOrEmpty(CPF))
                CNPJCPF = CPF;
            if (!string.IsNullOrEmpty(CNPJ))
                CNPJCPF = CNPJ;

            if((!string.IsNullOrEmpty(CNPJCPF)) && (!string.IsNullOrEmpty(CODIGO)))
                retorno = Gateways.Dbo.GatewayTbUsuarioAlias.ValidaCpfCnpjUsuario(token, CODIGO, CNPJCPF);
            if ((!string.IsNullOrEmpty(CNPJCPF)) && (string.IsNullOrEmpty(CODIGO)))
                retorno = Gateways.Dbo.GatewayTbUsuarioAlias.ValidaCpfCnpj(CNPJCPF);
            if ((string.IsNullOrEmpty(CNPJCPF)) && (!string.IsNullOrEmpty(CODIGO)))
                retorno = Gateways.Dbo.GatewayTbUsuarioAlias.ValidaUsuario(CODIGO);

            return retorno;
        }


        public static void SendMail(string html, string mailto, string subject)
        {
            try
            {
                string body = html;
                string FromMail = "suporte@serveloja.com.br";
                string emailTo = mailto;
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("mail.serveloja.com.br");
                mail.From = new MailAddress(FromMail);
                mail.To.Add(emailTo);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("suporte@serveloja.com.br", "#123456");
                SmtpServer.EnableSsl = false;
                SmtpServer.Send(mail);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}