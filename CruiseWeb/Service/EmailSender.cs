using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Security.Application;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
//Send email to all the registered users with attachment
namespace CruiseWeb.Service
{
   
    public class EmailSender
    {
        public void Send(String subject, String contents)
        {
            Execute(subject, contents).Wait();
        }

        // Please use your API KEY here.
        private const String API_KEY = "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";

        static async Task Execute(String subject, String contents)
        {
            var context = new IdentityDbContext();
            var users = context.Users.ToList();
            var tos = new List<EmailAddress>();
            foreach (var user in users)
            {
                if (user.Email != "admin@monash.edu")
                {
                    tos.Add(new EmailAddress(user.Email));
                }
            }         
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("noreply@cruiseonweb.com", "CruiseOnWeb");
            var plainTextContent = contents;
            /*//Helps prevent XSS attack using HTML
            var sanitizedContent = Sanitizer.GetSafeHtml(plainTextContent);
            var htmlContent = "<p>" + sanitizedContent + "</p>";       */
            var htmlContent = "<p>" + plainTextContent + "</p>";
            var showAllRecipients = false;
            var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, tos, subject, plainTextContent, htmlContent, showAllRecipients);
            const string Filename = "C:/Users/tisa9/source/repos/CruiseOnWeb/CruiseWeb/Content/Images/Discount.JPG";
            var bytes = File.ReadAllBytes(Filename);
            var file = Convert.ToBase64String(bytes);
            msg.AddAttachment("discount.jpg",file);
            var response = await client.SendEmailAsync(msg);
        }
    
    }
}