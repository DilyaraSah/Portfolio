using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Extensions.Logging;
//using PotfolioMain;

namespace Portfolio.Misc.Services.EmailServices;

public class EmailServices : IEmailServices
{
    private EmailConfiguration _emailConfig;
    private readonly ILogger<EmailServices> _logger;

    public EmailServices(ILogger<EmailServices> logger, EmailConfiguration emailConfig)
    {
        _emailConfig = emailConfig;
        _logger = logger;
    }

    public void SendEmail(string mesBody, string mesHeader, string mesReciever)
    {
        var message = new Message(mesHeader, mesBody, mesReciever, _emailConfig);
        using (MailKit.Net.Smtp.SmtpClient client = new MailKit.Net.Smtp.SmtpClient())
        {
            try
            {
                client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(_emailConfig.UserName, _emailConfig.Password);
                client.Send(message.MimeMessage);
                client.Disconnect(true);
                _logger.LogInformation("successfully sent");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }
    }
}