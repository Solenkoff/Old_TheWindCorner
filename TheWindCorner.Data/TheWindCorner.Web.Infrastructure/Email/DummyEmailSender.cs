namespace TheWindCorner.Web.Infrastructure.Email
{
    using Microsoft.AspNetCore.Identity.UI.Services;

    public class DummyEmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            Console.WriteLine($"[Email to {email}] {subject}: {htmlMessage}");
            return Task.CompletedTask;
        }
    }
  
}
