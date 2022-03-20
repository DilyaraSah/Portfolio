using Microsoft.AspNetCore.Mvc;
using Portfolio.Misc.Services.EmailServices;
using Portfolio.DataAccess.Context;
using MimeKit;

namespace PotfolioMain.Controllers;

public class ContactController : Controller
{
    private readonly IEmailServices _emailService;
    private readonly EmailConfiguration _emailConfig;
    private readonly ApplicationContext _context;


    public ContactController(IEmailServices emailService, EmailConfiguration emailConfig, ApplicationContext context)
    {
        _emailService = emailService;
        _emailConfig = emailConfig;
        _context = context;
    }

    // GET
    public IActionResult Contact()
    {
        return View();
    }
    
    // public IActionResult SendEmailDefault(Message messageToSend)
    // { 
    //     _emailService.SendEmail(messageToSend);
    //     return RedirectToAction("Contact");
    // }

    [HttpPost]
    public IActionResult Send(string nameContact, string emailContact, string subjectContact, string messageContact)
    {
        var message = new Message(new[] {_emailConfig.From}, $"Contact form: {subjectContact}",
            $"Name: {nameContact}\nEmail: {emailContact}\n\n{messageContact}");
        _emailService.SendEmail(message);
    
        return Ok("sent successfully");
        //return RedirectToAction("Contact");
    }

}