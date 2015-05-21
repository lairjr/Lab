using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;

namespace appProfiles.App_Folders.Classes
{
    public class cMail
    {
        cMailData sender;
        cMailData receiver;
        string message, subject;

        public cMailData Sender
        {
            get { return sender; }
            set { sender = value; }
        }

        public cMailData Receiver
        {
            get { return receiver; }
            set { receiver = value; }
        }

        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public Boolean send()
        {
            MailMessage _msg = new MailMessage();
            _msg.From = new MailAddress(sender.Email, sender.Name);
            _msg.To.Add(new MailAddress(receiver.Email, receiver.Name));
            _msg.Subject = subject;
            _msg.Body = message;
            _msg.IsBodyHtml = true;
            _msg.Priority = MailPriority.Normal;

            SmtpClient _smpt = new SmtpClient("smtp.gmail.com", 587);
            _smpt.EnableSsl = true;
            _smpt.Credentials = new System.Net.NetworkCredential("lairjr.mail@gmail.com", "sis12345");
            try
            {
                _smpt.Send(_msg);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}