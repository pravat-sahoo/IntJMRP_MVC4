using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace IJMRP.classfile
{
    public class ClassEmail
    {
        public void Mail(string to, string subject, string body, HttpPostedFileBase fileUploader)
        {
            MailMessage mail = new MailMessage();
            string toadd = to.ToLower();
            mail.Subject = subject;
            mail.Body = body;


            if (fileUploader != null)
            {
                string fileName = Path.GetFileName(fileUploader.FileName);
                mail.Attachments.Add(new Attachment(fileUploader.InputStream, fileName));
            }
            mail.IsBodyHtml = false;

            using (SmtpClient smtp = new SmtpClient())
            {
                mail.From = new MailAddress("notification@ionxindia.com");

                mail.To.Add(toadd);
                smtp.EnableSsl = false;
                NetworkCredential networkCredential = new NetworkCredential("notification@ionxindia.com", "Askme@123");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = networkCredential;
                smtp.Port = 25;
                smtp.Host = "ionxindia.com";
                try
                {
                    smtp.Send(mail);
                }
                catch
                {

                }


            }
        }

    }
}