using ApiUnes.Gateways;
using ApiUnes.Models;
using ApiUnes.Models.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;

namespace ApiUnes.Controllers
{
    public class UtilController : ApiController
    {
        // GET: api/Util
        public IEnumerable<string> Get()
        {
            string html = @"<style>
	/* Show More Pattern CSS */
	@media only screen and (max-width: 599px) {
	    table[class='pattern'] .story p {
	        max-height: 98px;
            margin-bottom: 14px;
            overflow: hidden;

	    }
        table[class='pattern'] #story1:target p,
        table[class='pattern'] #story2:target p,
        table[class='pattern'] #story3:target p {
            max-height: 999px;
        }
        table[class='pattern'] .readmore {
            position: relative;
            display: inline-block !important;
            width: auto !important;
            height: auto !important;
            max-width: inherit !important;
            max-height: inherit !important;
            overflow: visible !important;
            float: none !important;
            font-size: 12px !important;
            font-weight: bold;
            color: #999 !important;
            text-decoration: none;
            text-transform: uppercase;
        }
        table[class='pattern'] .readmore:after {
            content: '';
            position: absolute;
            top: 3px;
            right: -20px;
            display: block;
            border-left: 6px solid transparent;
            border-right: 6px solid transparent;
            border-top: 6px solid #999;
        }
	}
    @media only screen and (max-width: 500px) {
        table[class='pattern'] .story p {
            max-height: 80px;
        }
    }
    @media only screen and (max-width: 400px) {
        table[class='pattern'] .story p {
            max-height: 50px;
        }
    }
</style>

<table cellpadding='0' cellspacing='0' class='pattern'>

    <tr>
        <td class='story' id='story1' width='600' align='center' valign='top' style='background-color: darkslategray; border-bottom: 1px dotted #999; font-family: arial,sans-serif; font-size: 14px; color: #333; padding: 16px;'>
        	<img src='https://www.serveloja.com.br/site/wp-content/uploads/2016/01/logoservelojabranco.png' alt='' style='width: 16.938em; height: 5.625em; display: block; border: 0; margin: auto;' />
        </td>
    </tr>
    <tr>
        <td class='story' id='story1' width='600' align='left' valign='top' style='border-bottom: 1px dotted #999; font-family: arial,sans-serif; font-size: 14px; color: #333; padding: 0 0 16px 0;'>
          <br /><br />
          <h3 style = 'margin: auto; width: 215px;' > Recuperação de senha</h3>
            <p>

              Esta mensagem é uma resposta à sua solicitação de recuperação da senha da sua conta.
              <br /><br />
              Seu login é: 6424<br />
              Sua senha é: XXXXXX<br />
              <br /><br />
              Atenção!<br />
              Após logar no sistema, altere a sua senha.<br />
              Para acessar o nosso sistema utilize o link: http://www.serveloja.com.br/sistema<br />
              Se ocorrer um problema ao clicar no link acima, tente copiar e colar o link inteiro em um navegador.
            </p>

        </td>
    </tr>
    <tr>
        <td class='story' id='story2' width='600' align='left' valign='top' style='border-bottom: 1px dotted #999; font-family: arial,sans-serif; font-size: 14px; color: #333; padding: 16px 0;'>
            <p>
                ** Esta é uma mensagem automática -- não responda a essa mensagem, pois você não receberá resposta. **
            </p>
        </td>
    </tr>
    <tr>
        <td class='story' id='story3' width='600' align='center' valign='top' style='font-family: arial,sans-serif; font-size: 14px; color: #333; padding: 16px 0 0 0;'>
            Obrigado.
Serveloja - Soluções Empresariais
http://www.serveloja.com.br/
        </td>
    </tr>
</table>
"; 

            string subject = "Email Subject";
            string body = html;
            string FromMail = "suporte@serveloja.com.br";
            string emailTo = "elton@serveloja.com.br";
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("mail.serveloja.com.br");
            mail.From = new MailAddress(FromMail);
            mail.To.Add(emailTo);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            SmtpServer.Port = 25;
            SmtpServer.Credentials = new System.Net.NetworkCredential("suporte@serveloja.com.br", "your password");
            SmtpServer.EnableSsl = false;
            SmtpServer.Send(mail);

            return new string[] { "value1", "value2" };
        }


        // GET /TbUsuarioAlias/token/colecao/campo/orderBy/pageSize/pageNumber?CAMPO1=VALOR&CAMPO2=VALOR
        public Retorno Get(string token, int colecao = 0, int campo = 0, int orderBy = 0, int pageSize = 0, int pageNumber = 0)
        {
            // Abre nova conexão
            using (ModelApiUnes _db = new ModelApiUnes())
            {
                try
                {
                    Dictionary<string, string> queryString = Request.GetQueryNameValuePairs().ToDictionary(x => x.Key, x => x.Value);
                    //if (Permissoes.Autenticado(token, _db))
                    //{
                        return GatewayUtils.Get(token, colecao, campo, orderBy, pageSize, pageNumber, queryString, _db);
                   // }
                    //else
                    //    return new Retorno() { Token = false }; //throw new Exception("Unauthorized");
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }


        // GET: api/Util/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Util
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Util/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Util/5
        public void Delete(int id)
        {
        }
    }
}
