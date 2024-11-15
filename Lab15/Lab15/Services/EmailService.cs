using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;
using System.Net;
using System.Net.Mail;

public class EmailService {
    public void SendEmail(string subject, string text)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse("willis.wiza18@ethereal.email"));
        email.To.Add(MailboxAddress.Parse("willis.wiza18@ethereal.email"));
        //email.Subject = "Test Email";
        //email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = "Hi Mark" };
        email.Subject = subject;
        email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = text };

        using var smtp = new MailKit.Net.Smtp.SmtpClient();
        smtp.Connect("smtp.ethereal.email", 587, MailKit.Security.SecureSocketOptions.StartTls);
        smtp.Authenticate("willis.wiza18@ethereal.email", "J4Bvk1dhrqNChegfe9");
        smtp.Send(email);
        smtp.Disconnect(true);
    }
}
