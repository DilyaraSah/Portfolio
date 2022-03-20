using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Extensions.Logging;
//using PotfolioMain;

namespace Portfolio.Misc.Services.EmailServices;

public class EmailServices : IEmailServices
{
    private readonly EmailConfiguration _emailConfig;

    private readonly ILogger<EmailServices> _logger;
    public EmailServices(ILogger<EmailServices> logger, EmailConfiguration emailConfig)
    {
        _emailConfig = emailConfig;
        _logger = logger;
    }

    public void SendEmail(Message messageBody)
    {
        var message = CreateEmailMessage(messageBody.ToString());
        try
        {
            using (SmtpClient client = new SmtpClient())
            {
                client.Connect("smtp.mail.ru", 465, true);
                client.Authenticate("sakhibgareeva-first@mail.ru", "3sFSX94K0WPur2xvUidr");
                client.Send(message);
                
                client.Disconnect(true);
                _logger.LogInformation("message sent successfully");
            }
        }
        catch (Exception e)
        {
            _logger.LogError(e.GetBaseException().Message);
        }
    }
    

    public MimeMessage CreateEmailMessage(string mesBody)
    {
        MimeMessage message = new MimeMessage();
        message.From.Add(new MailboxAddress("Sender","sakhibgareeva-first@mail.ru"));
        message.To.Add(new MailboxAddress("dilya", "sakhibgareeva-second@mail.ru"));
        message.Subject = "new message using mailkil";
        message.Body = new BodyBuilder() {HtmlBody = $"<div style=\"color: green;\">{mesBody}</div>"}.ToMessageBody();
        return message;
    }
    
    // private readonly EmailConfiguration _emailConfig;
    //
    // public EmailServices(EmailConfiguration emailConfig)
    // {
    //     _emailConfig = emailConfig;
    // }
    // public void SendEmail(Message message)
    // {
    //     var emailMessage = CreateEmailMessage(message);
    //     Send(emailMessage);
    // }
    //
    // private MimeMessage CreateEmailMessage(Message message)
    // {
    //     var emailMessage = new MimeMessage();
    //     emailMessage.From.Add(new MailboxAddress("Sender",_emailConfig.From));
    //     emailMessage.To.AddRange(message.To);
    //     emailMessage.Subject = message.Subject;
    //     emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) {Text = message.Content};
    //     
    //     return emailMessage;
    // }
    // private void Send(MimeMessage mailMessage)
    // {
    //     using (var client = new SmtpClient())  
    //     {
    //         try
    //         {
    //             client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
    //             //client.AuthenticationMechanisms.Remove("XOAUTH2");
    //             client.Authenticate(_emailConfig.UserName, _emailConfig.Password);
    //             client.Send(mailMessage);
    //             client.Disconnect(true);
    //         }
    //         catch
    //         {
    //             //log an error message or throw an exception or both.
    //             throw;
    //         }
    //     }
    // }
}