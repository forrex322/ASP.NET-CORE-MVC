using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using Dima.Services.EmailSender;

namespace Dima.Services.EmailSender
{
    public class MailKitEmailSender : IEmailSender
    {
        public async Task SendMessage(string emailTo, string messageBody, string subject)
        {
            MimeMessage emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Администрация сайта", "zonex1995@gmail.com"));
            emailMessage.To.Add(new MailboxAddress(emailTo));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("Plain")
            {
                Text = messageBody
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 587, false);
                await client.AuthenticateAsync("strongforex1995@gmail.com", "donatusponchik123");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }

    }
}
