using Assignment_form.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;
using Assignment_models;
using Assignment_form.APICALL;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Assignment_form.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRegisterRepository _RegisterRepository;


        
        public HomeController(ILogger<HomeController> logger, IRegisterRepository RegisterRepository)
        {
            _logger = logger;
            _RegisterRepository = RegisterRepository;
        }

        public async Task<IActionResult> Registration()
        {
            ViewData["Citys"] = await Cityddl();
            return View();
        }

        
        public async Task<List<SelectListItem>> Cityddl()
        {
            List<City> obj = await _RegisterRepository.CityGet();
            List<SelectListItem> ddl = new List<SelectListItem>();
            SelectListItem items1 = new SelectListItem();
            items1.Text = "---Select City---";
            items1.Value = "0";
            ddl.Add(items1);
            foreach (City cities in obj)
            {
                SelectListItem items = new SelectListItem();
                items.Text = cities.Country;
                items.Value = cities.Id.ToString();
                ddl.Add(items);
            }
            return ddl;
        }

        public async Task<IActionResult>Index(Alldetail obj)
        {
            var data = await _RegisterRepository.ListGet(obj);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Registration(Registration obj)
        {
            var data = await _RegisterRepository.Registration(obj);
            if (data != null)
            {


                var file = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Email_Image", "Registrationpage.html");
                String SendMailFrom = "navteshmaurya@gmail.com";
                String SendMailTo = obj.Email;
                String SendMailSubject = "Registration Successfully";
                // String SendMailBody = "<a href='http://localhost:5063/Home/Login'>Thanks for registration for us  [Please click here to login] </a>";
                String SendMailBody = System.IO.File.ReadAllText(file);
                try
                {
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com", 587);
                    SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                    MailMessage email = new MailMessage();
                    // START
                    email.From = new MailAddress(SendMailFrom);
                    email.To.Add(SendMailTo);
                    email.CC.Add(SendMailFrom);
                    email.Subject = SendMailSubject;
                    email.Body = SendMailBody;
                    email.IsBodyHtml = true;
                    //END
                    SmtpServer.Timeout = 10000;
                    SmtpServer.EnableSsl = true;
                    SmtpServer.UseDefaultCredentials = false;
                    SmtpServer.Credentials = new NetworkCredential(SendMailFrom, "lnpsvyibvqxnaspe");
                    SmtpServer.Send(email);

                    
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                return null;
            }

            return RedirectToAction("Index");
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
    }
}