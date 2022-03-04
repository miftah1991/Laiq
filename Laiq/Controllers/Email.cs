using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace Laiq.Controllers
{
    public class Email
    {
        public void SendEmail(string from, string to, string subject, string message, string cc)
        {
            MailMessage mail = new MailMessage();
            var emailList = to.Split(',').ToList();
            foreach (var item in emailList)
            {
                mail.Bcc.Add(item);
            }

            if (cc != string.Empty)
            {
                mail.CC.Add(cc);
            }
            mail.From = new MailAddress(from);
            mail.Subject = subject;
            mail.Body = message;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "mail.dabs.af";
            smtp.Port = 25;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("hr@dabs.af", "x]TLkB3{+I&^SQ1");
            smtp.EnableSsl = false;
            smtp.Send(mail);

        }
        public void SendPaySlipEmail(string from, string to, string subject, string message, string cc)
        {
            MailMessage mail = new MailMessage();
            var emailList = to.Split(',').ToList();
            foreach (var item in emailList)
            {
                mail.To.Add(item);
            }
            if (cc != string.Empty)
            {
                mail.CC.Add(cc);
            }
            mail.From = new MailAddress(from);
            mail.Subject = subject;
            mail.Body = message;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "mail.dabs.af";
            smtp.Port = 25;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("hr@dabs.af", "x]TLkB3{+I&^SQ1");
            smtp.EnableSsl = false;
            smtp.Send(mail);

        }
        public void SendHREmail(string from, string to, string subject, string message)
        {
            MailMessage mail = new MailMessage();
            var emailList = to.Split(',').ToList();
            foreach (var item in emailList)
            {
                mail.To.Add(item);
            }

            mail.CC.Add("qudrat.k@dabs.af");
            mail.CC.Add("riaz.alokozay@dabs.af");
            mail.CC.Add("nagina.h@dabs.af");
            mail.CC.Add("zekrullah.r@dabs.af");
            mail.CC.Add("aligul.m@dabs.af");
            mail.CC.Add("fariba.s@dabs.af");
            mail.CC.Add("mursal.bahaduri@dabs.af");
            mail.Bcc.Add("miftah.a@dabs.af");
            mail.From = new MailAddress(from);
            mail.Subject = subject;
            mail.Body = message;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "mail.dabs.af";
            smtp.Port = 25;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("hr@dabs.af", "x]TLkB3{+I&^SQ1");
            smtp.EnableSsl = false;
            smtp.Send(mail);

        }

        public void SendEmail1(string from, string to, string subject, string message)
        {
            MailMessage mail = new MailMessage();
            var emailList = to.Split(',').ToList();
            foreach (var item in emailList)
            {
                mail.Bcc.Add(item);
            }
            mail.CC.Add("riaz.alokozay@dabs.af");
            mail.CC.Add("qudrat.k@dabs.af");
            mail.CC.Add("nagina.h@dabs.af");
            mail.CC.Add("zekrullah.r@dabs.af");
            mail.CC.Add("aligul.m@dabs.af");
            mail.CC.Add("fariba.s@dabs.af");
            mail.CC.Add("mursal.bahaduri@dabs.af");
            mail.Bcc.Add("miftah.a@dabs.af");
            mail.From = new MailAddress(from);
            mail.Subject = subject;
            mail.Body = message;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "mail.dabs.af";
            smtp.Port = 25;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("hr@dabs.af", "x]TLkB3{+I&^SQ1");
            smtp.EnableSsl = false;
            smtp.Send(mail);

        }

        public void SendAppHREmail(string from, string to, string subject, string message)
        {
            MailMessage mail = new MailMessage();
            var emailList = to.Split(',').ToList();
            foreach (var item in emailList)
            {
                mail.Bcc.Add(item);
            }

            mail.CC.Add("qudrat.k@dabs.af");
            mail.CC.Add("riaz.alokozay@dabs.af");
            mail.CC.Add("nagina.h@dabs.af");
            mail.CC.Add("zekrullah.r@dabs.af");
            mail.CC.Add("aligul.m@dabs.af");
            mail.CC.Add("fariba.s@dabs.af");
            mail.CC.Add("mursal.bahaduri@dabs.af");
            mail.Bcc.Add("miftah.a@dabs.af");
            mail.From = new MailAddress(from);
            mail.Subject = subject;
            mail.Body = message;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "mail.dabs.af";
            smtp.Port = 25;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("hr@dabs.af", "x]TLkB3{+I&^SQ1");
            smtp.EnableSsl = false;
            smtp.Send(mail);
        }
    }
}