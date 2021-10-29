using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dima.Services.EmailSender
{
    public interface IEmailSender
    {
        Task SendMessage(string emailTo, string messageBody, string subject);
    }
}
