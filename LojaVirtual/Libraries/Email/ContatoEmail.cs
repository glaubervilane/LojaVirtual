using LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries.Email
{
    public class ContatoEmail
    {
        public static void EnviarContatoPorEmail(Contato contato)
        {
            // Servidor de envio de mensagens
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("glauberfmarques@gmail.com", "");
            smtp.EnableSsl = true;

            string corpoMsg = string.Format("<h2>Contato - LojaVirtual</h2>" +
                "<b>Nome: </b> {0} <br/>" +
                "<b>E-mail: </b> {1} <br/>" +
                "<b>Texto: </b> {2} <br/>" +
                "<br /> E-mail enviado automaticamente do site LojaVirtual",
                contato.Nome,
                contato.Email,
                contato.Texto
                );

            //Mailmessage => construir a mensagem

            MailMessage mensagem = new MailMessage();
            mensagem.From = new MailAddress("glauberfmarques@gmail.com");
            mensagem.To.Add("glauberfmarques@gmail.com");
            mensagem.Subject = "Contato - LojaVirtual - E-Mail" + contato.Email;
            mensagem.Body = corpoMsg;
            mensagem.IsBodyHtml = true;

            //enviar mensagem via smtp
            smtp.Send(mensagem);
        }
    }
}
