using GameTracker.Interfaces;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace GameTracker.Infrastructure
{
    public class DEBUG_EmailSender : GameTracker.Interfaces.IEmailSender
    {
        public void SendEmail(string to, string subject, string body)
        {
            File.AppendAllText("email_log.txt", $"To: {to}\nSubject: {subject}\nBody: {body}\n\n\n\n\n\n\n\n\n\n\n");
            Console.WriteLine($"\n\n\nDEBUG Email Sent to {to} with subject '{subject}' and body:\n{body}\n\n\n");
        }
    }
}
