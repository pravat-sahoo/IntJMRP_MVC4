using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IJMRP.Models;
using System.Net.Mail;
using System.Net;
using System.Net.Mime;
using System.Threading;

namespace CSHRMS.ClassFile
{
    public class EmailSend
    {
        //HRMS_DATBASEEntities db = new HRMS_DATBASEEntities();
        public emailProperty Emailsetting(string Setting_ID)
        {
            emailProperty ob = new emailProperty();
            ob.E_Credentials_UserName="info@intjmrp.com";
            ob.E_Credentials_Password="intjmrp@123#";
                ob.E_Smtp_Client="intjmrp.com";
                ob.E_Port=25;
                    ob.E_EnableSsl=true;
                    ob.E_Timeout=100000;
                        ob.E_DeliveryMethod="SmtpDeliveryMethod.Network";
                        ob.E_UseDefaultCredentials=false;
                        ob.E_Delivery_Notification = "DeliveryNotificationOptions.OnFailure";
                           
                           
           return ob;
            
        }

        //public void SendEmailInBackgroundThread(MailMessage mailMessage)
        //{
        //    Thread bgThread = new Thread(new ParameterizedThreadStart(SendEmail));
        //    bgThread.IsBackground = true;
        //    bgThread.Start(mailMessage);
        //}

        public void single_Recipent_Email(string EMAILSETTING_ID, string To, string SUBJECT, string MSG, string CC)
        {
            try
            {
                EmailSend obemailSetting = new EmailSend();
                emailProperty obEmailprop = new emailProperty();
                obEmailprop = obemailSetting.Emailsetting(EMAILSETTING_ID);
                //send mail

                SmtpClient client = new SmtpClient(obEmailprop.E_Smtp_Client);
                // bcc = "cs@cosmicstrands.com";
                client.Port = obEmailprop.E_Port;
                client.EnableSsl = obEmailprop.E_EnableSsl;
                client.Timeout = obEmailprop.E_Timeout;
               
                switch (obEmailprop.E_DeliveryMethod)
                {
                    case "SmtpDeliveryMethod.Network":
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        break;
                    case "SmtpDeliveryMethod.SpecifiedPickupDirectory":
                        client.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                        break;
                    case "SmtpDeliveryMethod.PickupDirectoryFromIis":
                        client.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;
                        break;
                    default:
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        break;
                }

                client.UseDefaultCredentials = obEmailprop.E_UseDefaultCredentials;
                client.Credentials = new NetworkCredential(obEmailprop.E_Credentials_UserName, obEmailprop.E_Credentials_Password);
                //smtp.SendCompleted += new SendCompletedEventHandler(smtp_SendCompleted);
                MailMessage msg = new MailMessage();

                msg.To.Add(To);

                if (!string.IsNullOrEmpty(CC) || !string.IsNullOrWhiteSpace(CC))
                    msg.CC.Add(CC);
                //msg.Bcc.Add(BCC);
                msg.From = new MailAddress(obEmailprop.E_Credentials_UserName);

                msg.Subject = SUBJECT;
                msg.Body = MSG;
                
                msg.IsBodyHtml = true;
                client.Send(msg);

                switch (obEmailprop.E_Delivery_Notification)
                {
                    case "DeliveryNotificationOptions.Delay":
                        msg.DeliveryNotificationOptions = DeliveryNotificationOptions.Delay;
                        break;
                    case "DeliveryNotificationOptions.Never":
                        msg.DeliveryNotificationOptions = DeliveryNotificationOptions.Never;
                        break;
                    case "DeliveryNotificationOptions.None":
                        msg.DeliveryNotificationOptions = DeliveryNotificationOptions.None;
                        break;
                    case "DeliveryNotificationOptions.OnFailure":
                        msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                        break;
                    case "DeliveryNotificationOptions.Success":
                        msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
                        break;
                  
                    default:
                        msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
                        break;
                }
                
                //return "SUCCESS";
            }
            catch (Exception ex)
            {
            //{
            //    //lg.WriteLog(ex.Message.ToString(), ex.ToString(), username, Convert.ToString(HttpContext.Current.Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name);
            //    return ex.Message;
            }      
        }

//        public void All_Recipients_Email(string EMAILSETTING_ID, string To, string SUBJECT, string MSG, string CC)
//        {
//            try
//            {
//                EmailSend obemailSetting = new EmailSend();
//                emailProperty obEmailprop = new emailProperty();
//                obEmailprop = obemailSetting.Emailsetting(EMAILSETTING_ID);
//                //send mail

//                SmtpClient client = new SmtpClient(obEmailprop.E_Smtp_Client);
//                // bcc = "cs@cosmicstrands.com";
//                client.Port = obEmailprop.E_Port;
//                client.EnableSsl = obEmailprop.E_EnableSsl;
//                client.Timeout = obEmailprop.E_Timeout;

//                switch (obEmailprop.E_DeliveryMethod)
//                {
//                    case "SmtpDeliveryMethod.Network":
//                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
//                        break;
//                    case "SmtpDeliveryMethod.SpecifiedPickupDirectory":
//                        client.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
//                        break;
//                    case "SmtpDeliveryMethod.PickupDirectoryFromIis":
//                        client.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;
//                        break;
//                    default:
//                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
//                        break;
//                }

//                client.UseDefaultCredentials = obEmailprop.E_UseDefaultCredentials;
//                client.Credentials = new NetworkCredential(obEmailprop.E_Credentials_UserName, obEmailprop.E_Credentials_Password);
//                //smtp.SendCompleted += new SendCompletedEventHandler(smtp_SendCompleted);
//                MailMessage msg = new MailMessage();

//                msg.To.Add(To);

//                var emailids = db.tblUserLogins.Where(m => m.U_STATUS == "ACTIVE").ToList();
//                if (emailids != null)
//                {
//                    foreach (var address in emailids)
//                    {
//                        if (address.U_EMAIL_ADDRESS.Trim(' ') != "")
//                        {
//                            msg.CC.Add(address.U_EMAIL_ADDRESS.Trim(' '));
//                        }
//                    }
//                }
//                AlternateView HTMLEmail = AlternateView.CreateAlternateViewFromString(MSG,
//                       null, "text/html");
//                msg.AlternateViews.Add(HTMLEmail);
//                //if (!string.IsNullOrEmpty(CC) || !string.IsNullOrWhiteSpace(CC))
//                //    msg.CC.Add(CC);
//                //msg.Bcc.Add(BCC);
//                msg.From = new MailAddress(obEmailprop.E_Credentials_UserName);

//                msg.Subject = SUBJECT;
//                msg.Body = MSG;
//                client.Send(msg);

//                switch (obEmailprop.E_Delivery_Notification)
//                {
//                    case "DeliveryNotificationOptions.Delay":
//                        msg.DeliveryNotificationOptions = DeliveryNotificationOptions.Delay;
//                        break;
//                    case "DeliveryNotificationOptions.Never":
//                        msg.DeliveryNotificationOptions = DeliveryNotificationOptions.Never;
//                        break;
//                    case "DeliveryNotificationOptions.None":
//                        msg.DeliveryNotificationOptions = DeliveryNotificationOptions.None;
//                        break;
//                    case "DeliveryNotificationOptions.OnFailure":
//                        msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
//                        break;
//                    case "DeliveryNotificationOptions.Success":
//                        msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
//                        break;

//                    default:
//                        msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
//                        break;
//                }

//                //return "SUCCESS";
//            }
//            catch (Exception ex)
//            {
//                //{
//                //    //lg.WriteLog(ex.Message.ToString(), ex.ToString(), username, Convert.ToString(HttpContext.Current.Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name);
//                //    return ex.Message;
//            } 
//        }

//        public void Welcome_Email(string EMAILSETTING_ID,string To, string username,string designation, string e_image)
//        {
//            try
//            {
//                EmailSend obemailSetting = new EmailSend();
//                emailProperty obEmailprop = new emailProperty();
//                obEmailprop = obemailSetting.Emailsetting(EMAILSETTING_ID);
//                //send mail

//                SmtpClient client = new SmtpClient(obEmailprop.E_Smtp_Client);
//                // bcc = "cs@cosmicstrands.com";
//                client.Port = obEmailprop.E_Port;
//                client.EnableSsl = obEmailprop.E_EnableSsl;
//                client.Timeout = obEmailprop.E_Timeout;

//                switch (obEmailprop.E_DeliveryMethod)
//                {
//                    case "SmtpDeliveryMethod.Network":
//                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
//                        break;
//                    case "SmtpDeliveryMethod.SpecifiedPickupDirectory":
//                        client.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
//                        break;
//                    case "SmtpDeliveryMethod.PickupDirectoryFromIis":
//                        client.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;
//                        break;
//                    default:
//                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
//                        break;
//                }

//                client.UseDefaultCredentials = obEmailprop.E_UseDefaultCredentials;
//                client.Credentials = new NetworkCredential(obEmailprop.E_Credentials_UserName, obEmailprop.E_Credentials_Password);
//                //smtp.SendCompleted += new SendCompletedEventHandler(smtp_SendCompleted);
//                MailMessage msg = new MailMessage();

//                msg.To.Add(To);

//                var emailids = db.tblUserLogins.Where(m=>m.U_STATUS=="ACTIVE").ToList();
//                if (emailids!=null)
//                {
//                    foreach (var address in emailids)
//                    {
//                        if (address.U_EMAIL_ADDRESS.Trim(' ') != "")
//                        {
//                            msg.CC.Add(address.U_EMAIL_ADDRESS.Trim(' '));
//                        }
//                    }
//                }

//                string msg_start = "<center>Hi  Friends,<br/> I am pleased to introduce " + username + " who has joined Cosmic Strands as " + designation+"</center><br/><br/>";
//                string msg_end = "<br/> <br/><center> Please join me in extending a warm welcome to " + username + " and wishing " + username + " success in the new opportunities and challenges ahead.<br/><br/>" + username + " can be reached at : <br/>" + To+"</center>";
               
//                 string EMailBody = msg_start + @"  <br />
//            <center><img src=""cid:InlineImageID"" /></center><br />" +msg_end;
               
//                AlternateView HTMLEmail = AlternateView.CreateAlternateViewFromString(EMailBody,
//                        null, "text/html");
//                AlternateView PlainTextEmail = AlternateView.CreateAlternateViewFromString(EMailBody, null, "text/plain");

//                 LinkedResource MyImage = new LinkedResource(e_image);
//                MyImage.ContentId = "InlineImageID";

//               HTMLEmail.LinkedResources.Add(MyImage);

//                msg.AlternateViews.Add(HTMLEmail);
//                msg.AlternateViews.Add(PlainTextEmail);


//                //if (!string.IsNullOrEmpty(CC) || !string.IsNullOrWhiteSpace(CC))
//                //    msg.CC.Add(CC);
//                //msg.Bcc.Add(BCC);
//                msg.From = new MailAddress(obEmailprop.E_Credentials_UserName);
//                string SUBJECT = "Welcome to Cosmic Strands!!!!!";

//                msg.Subject = SUBJECT;
//                //msg.Body = msg_value;



//                client.Send(msg);

//                switch (obEmailprop.E_Delivery_Notification)
//                {
//                    case "DeliveryNotificationOptions.Delay":
//                        msg.DeliveryNotificationOptions = DeliveryNotificationOptions.Delay;
//                        break;
//                    case "DeliveryNotificationOptions.Never":
//                        msg.DeliveryNotificationOptions = DeliveryNotificationOptions.Never;
//                        break;
//                    case "DeliveryNotificationOptions.None":
//                        msg.DeliveryNotificationOptions = DeliveryNotificationOptions.None;
//                        break;
//                    case "DeliveryNotificationOptions.OnFailure":
//                        msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
//                        break;
//                    case "DeliveryNotificationOptions.Success":
//                        msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
//                        break;

//                    default:
//                        msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
//                        break;
//                }

//                //return "SUCCESS";
//            }
//            catch (Exception ex)
//            {
//                //{
//                //    //lg.WriteLog(ex.Message.ToString(), ex.ToString(), username, Convert.ToString(HttpContext.Current.Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name);
//                //    return ex.Message;
//            }
//        }

    }


    public class emailProperty
    {
        public string E_Credentials_UserName { get; set; }
        public string E_Credentials_Password { get; set; }
        public string E_Smtp_Client { get; set; }
        public int E_Port { get; set; }
        public Boolean E_EnableSsl { get; set; }
          public int E_Timeout { get; set; }
          public string E_DeliveryMethod { get; set; }
          public Boolean E_UseDefaultCredentials { get; set; }
          public string E_Delivery_Notification { get; set;}
         
    }



}