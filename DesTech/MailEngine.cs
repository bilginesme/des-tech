using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;

namespace DesTech
{
    public class MailEngine
    {
        public static void Send(string strSubjectAnnex, string strBody,  List<string> addresses)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient()
                {
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("besme@esme.org", "D@phne(285]lj")
                };
                MailMessage mail = new MailMessage();

                foreach (string str in addresses)
                    mail.To.Add(new MailAddress(str));
                mail.From = new MailAddress("besme@destech.net", "Bilgin Esme");
                mail.Subject = "DesTech Web  - " + strSubjectAnnex;
                mail.Body = strBody;
                mail.IsBodyHtml = false;

                smtpClient.Send(mail);
            }
            catch (SmtpException smtpException)
            {

            }
            catch (ArgumentNullException e)
            {

            }
            catch (InvalidOperationException e)
            {

            }
            catch(Exception e)
            {

            }
            
        }
        public static void Send(string strBody, string strSubjectAnnex, string address)
        {
            List<string> addresses = new List<string> { address };
            Send(strBody, strSubjectAnnex, addresses);
        }
        public static void SendContactUsMessage(string strSubject, string strBody)
        {
            string strTo = "besme@destech.net";

            List<string> addresses = new List<string> { strTo };
            Send(strSubject, strBody, addresses);
        }
    }
}