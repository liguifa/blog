using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Common
{
    public class SendEmailOperation
    {
        public static bool SendEmail(string email, string message)
        {
            string sendAdress = "1048229044@qq.com";
            string sendEmailPwd = "19930508liguifal";
            string EmailSmtp = "smtp.qq.com";
            string EmailText = message;
            string EmailTitle = "有人登陆!";


            MailMessage myMail = new MailMessage();
            try
            {
                myMail.From = new MailAddress(sendAdress);
                myMail.To.Add(new MailAddress(email));
                myMail.Subject = EmailTitle;
                myMail.SubjectEncoding = Encoding.UTF8;
                myMail.Body = EmailText;
                myMail.BodyEncoding = Encoding.UTF8;
                myMail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = EmailSmtp;
                smtp.Port = 465; //Gmail的smtp端口
                smtp.Credentials = new NetworkCredential(sendAdress, sendEmailPwd);
                smtp.EnableSsl = true; //Gmail要求SSL连接
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network; //Gmail的发送方式是通过网络的方式，需要指定
                smtp.Send(myMail);
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}