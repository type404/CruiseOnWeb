using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CruiseWeb.Service
{

    public class EmailSender
    {
        // Please use your API KEY here.
        private const String API_KEY = "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";

        
        public void Send(String toEmail, String subject, String contents)
        {

            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("noreply@cruiseonweb.com", "CruiseOnWeb");
            var to = new EmailAddress(toEmail, "");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            const string Filename = "C:/Users/tisa9/source/repos/CruiseOnWeb/CruiseWeb/Content/Images/Discount.JPG";
            var bytes = File.ReadAllBytes(Filename);
            var file = Convert.ToBase64String(bytes);
            msg.AddAttachment("discount.jpg",file);
            var response = client.SendEmailAsync(msg);
        }

        

    }
}