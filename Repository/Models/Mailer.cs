using System.Net;
using System.Net.Mail;

/// <summary>
/// 
//Brug af skolen SMTP
//Mailer mailer = new Mailer("vid233.vid.net.local", "hto@videndjurs.dk", "Henrik Obsen");

//Brug din egen gmail og Googles SMTP
//Mailer mailer = new Mailer("smtp.gmail.com", "email@gmail.com", "DitNavne", "password", 587);

//mailer.Send("Emne","Body teksten.","hto@djes.dk");
/// </summary>
public class Mailer
{
    private string _SMTP = "smtp.unoeuro.com";
    private string _fromEmail = "kontakt@lassewormark.com";
    private string _fromName = "Lasse Jørgensen";
    private string _fromUserName = "kontakt@lassewormark.com";
    private string _password = "KODE";
    private int _port = 587;


    public Mailer(string SMTP, string fromEmail, string fromName)
    {
        _SMTP = SMTP;
        _fromEmail = fromEmail;
        _fromName = fromName;
    }

    public Mailer(string SMTP, string fromEmail, string fromName, string fromUserName, string password, int port)
    {
        _SMTP = SMTP;
        _fromEmail = fromEmail;
        _fromName = fromName;
        _fromUserName = fromUserName;
        _password = password;
        _port = port;
    }

    public void Send(string Subject, string Text, string Receiver)
    {
        MailMessage mail = new MailMessage();

        mail.From = new MailAddress(_fromEmail, _fromName);

        mail.To.Add(Receiver);
        mail.Subject = Subject;
        mail.Body = Text;
        mail.IsBodyHtml = true;

        SmtpClient smtpCl = new SmtpClient(_SMTP, _port);

        if (_password != "")
        {
            smtpCl.EnableSsl = true;
            smtpCl.UseDefaultCredentials = false;
            smtpCl.Credentials = new NetworkCredential(_fromUserName, _password);
            smtpCl.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpCl.Port = _port;
        }

        smtpCl.Send(mail);

    }





}