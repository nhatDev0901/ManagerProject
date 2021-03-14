using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace ManagerProject.Helper
{
    public class SendMail
    {
        public static async void SendEmailWhenAddNewSubmittion(string submitterID, string submitterName,string department, string submitterEmail, string title, int countFile)
        {
            try
            {
                var body = ViewText.CONTENT_EMAIL_ADD_NEW_SUBMITTION;
                var fromEmail = "nguyw461@gmail.com";
                var username = ConfigurationManager.AppSettings["USER_NAME"].ToString();
                var password = ConfigurationManager.AppSettings["PASSWORD"].ToString();
                var toEmail = ConfigurationManager.AppSettings["TO_EMAIL"].ToString();

                var message = new MailMessage();
                message.To.Add(new MailAddress(toEmail));
                message.From = new MailAddress(fromEmail);
                message.Subject = "NEW CONTRIBUTION FROM STUDENT" + submitterName;
                message.Body = string.Format(body, submitterName, submitterID, submitterName, department, title, countFile);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    smtp.Host = ConfigurationManager.AppSettings["HOST"].ToString();
                    smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["PORT"].ToString());
                    smtp.Credentials = new NetworkCredential(username, password);
                    smtp.EnableSsl = true;

                    await smtp.SendMailAsync(message);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}