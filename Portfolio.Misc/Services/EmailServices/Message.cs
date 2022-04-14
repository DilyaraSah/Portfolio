using MimeKit;

namespace Portfolio.Misc.Services.EmailServices;

public class Message
{
    public MimeMessage MimeMessage { get; set; }
    public EmailConfiguration Configuration;

    public Message(string header, string content, string reciever, EmailConfiguration emailConfiguration)
    {
        Configuration = emailConfiguration;
        MimeMessage = CreateMessage(header, CreateBody(content));
        MimeMessage.To.Add(new MailboxAddress($"{reciever}", $"{reciever}"));
    }

    public MimeMessage CreateMessage(string header, MimeEntity bobyEntity)
    {
        MimeMessage message = new MimeMessage();
        message.From.Add(new MailboxAddress(Configuration.UserName, Configuration.From));
        message.Subject = header;
        message.Body = bobyEntity;
        return message;
    }
    
    public MimeEntity CreateBody(string bodyText)
        => new BodyBuilder() {TextBody = $"{bodyText}"}.ToMessageBody();
}