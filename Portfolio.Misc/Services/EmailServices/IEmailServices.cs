namespace Portfolio.Misc.Services.EmailServices;

public interface IEmailServices
{
    void SendEmail(string mesBody, string mesHeader, string mesReciever);
}