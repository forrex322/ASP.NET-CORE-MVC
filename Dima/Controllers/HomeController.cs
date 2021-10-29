using Dima.Interfaces;
using Dima.Models;
using Dima.Models.Home;
using Dima.Services.EmailSender;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Dima.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(ILogger<HomeController> logger,
                              IEmailSender emailSender,
                              IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _emailSender = emailSender;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            //IndexVM vM = new IndexVM()
            //{
            //    MyFullName = "Dima"
            //};
            //return View(vM);

            var currentUrl = _httpContextAccessor.HttpContext.Request.GetEncodedUrl();
            string host = Dns.GetHostName();
            IPHostEntry ipE = Dns.GetHostEntry(host);
            IPAddress[] IpA = ipE.AddressList;
            for (int i = 0; i < IpA.Length; i++)
            {
                IpA.ToString();
            }
            IPAddress ip = Dns.GetHostByName(host).AddressList[0];

            _logger.LogInformation($"Url: {currentUrl}, Time: {DateTime.Now}, IP Address: {ip}");
            return View();

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> SendEmail([FromForm] EmailMessageVM vm)
        {
            await _emailSender.SendMessage(vm.EmailTo, vm.MessageBody, vm.Subject);
            return Json(new { success = true });
        }

        [HttpGet]
        public IActionResult SendEmail()
        {
            return View();
        }

    }
}
//TODO: add bootstrap 5 for template