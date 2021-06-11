using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSMachine_Utility
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public MailJetSettings _mailJetSettings { get; set; }

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Execute(email, subject, htmlMessage);
        }

        public async Task<MailjetResponse> Execute(string email, string subject, string body)
        {
            _mailJetSettings = _configuration.GetSection("MailJet").Get<MailJetSettings>();

            MailjetClient client = new MailjetClient(_mailJetSettings.ApiKey, _mailJetSettings.SecretKey);
            var request = new MailjetRequest { Resource = Send.Resource }
                 .Property(Send.FromEmail, "afram.hanna888@hotmail.com")
                 .Property(Send.FromName, "rami")
                 .Property(Send.Subject, subject)
                 .Property(Send.HtmlPart, body)
                 .Property(Send.Recipients, new JArray
                  {
                     new JObject
                  {
                     { "Email", email }
                      }
                      });

            return await client.PostAsync(request);
            //       MailjetClient client = new MailjetClient(Environment.GetEnvironmentVariable("6d10485b1e195046bb3179a842278839"), Environment.GetEnvironmentVariable("ab2bbb4bb8673f5972d2369bda453a70"))
            //       {
            //           Version = ApiVersion.V3_1,
            //       };
            //       MailjetRequest request = new MailjetRequest
            //       {
            //           Resource = Send.Resource,
            //       }
            //        .Property(Send.Messages, new JArray {
            //new JObject {
            // {
            //  "From",
            //  new JObject {
            //   {"Email", "ramsalo1980@gmail.com"},
            //   {"Name", "rami"}
            //  }
            // }, {
            //  "To",
            //  new JArray {
            //   new JObject {
            //    {
            //     "Email",
            //     "ramsalo1980@gmail.com"
            //    }, {
            //     "Name",
            //     "rami"
            //    }
            //   }
            //  }
            // }, {
            //  "Subject",
            //  "Greetings from Mailjet."
            // }, {
            //  "TextPart",
            //  "My first Mailjet email"
            // }, {
            //  "HTMLPart",
            //  "<h3>Dear passenger 1, welcome to <a href='https://www.mailjet.com/'>Mailjet</a>!</h3><br />May the delivery force be with you!"
            // }, {
            //  "CustomID",
            //  "AppGettingStartedTest"
            // }
            //}
            //        });
            //       MailjetResponse response = await client.PostAsync(request);
            //        MailjetRequest request = new MailjetRequest
            //        {
            //            Resource = Send.Resource,
            //        }
            //.Property(Send.Messages, new JArray {
            // new JObject {
            //  {
            //   "From",
            //   new JObject {
            //    {"Email", "marx3k@hotmail.com"},
            //    {"Name", "Rami"}
            //   }
            //  }, {
            //   "To",
            //   new JArray {
            //    new JObject {
            //     {
            //      "Email",
            //      email
            //     }, {
            //      "Name",
            //      "Rami"
            //     }
            //    }
            //   }
            //  }, {
            //   "Subject",
            //   subject
            //  }, {
            //   "HTMLPart",
            //   body
            //  }
            // }
            //});
            //        await client.PostAsync(request);

        }
    }
}
