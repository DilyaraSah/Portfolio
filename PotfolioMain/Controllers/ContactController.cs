using Microsoft.AspNetCore.Mvc;
using Portfolio.Misc.Services.EmailServices;
using Portfolio.DataAccess;
using Portfolio.Entity;
using MimeKit;

namespace PotfolioMain.Controllers;

public class ContactController : Controller
{
    private readonly ILogger<ContactController> _logger;
    private readonly EmailServices _emailService;
    private readonly EmailConfiguration _emailConfig;


    public ContactController(ILogger<ContactController> logger, EmailServices emailService, EmailConfiguration emailConfig, ApplicationContext context)
    {
        _logger = logger;
        _emailService = emailService;
        _emailConfig = emailConfig;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpGet]
    public IActionResult Send()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Send(Request requestModel)
    {
        if (ModelState.IsValid)
            {
                _emailService.SendEmail(requestModel.Message, requestModel.Subject, requestModel.Email);
                return View("success");
            }
        return View("Index");
    }

}