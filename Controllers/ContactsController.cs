using Crito.Models;
using Crito.Services;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;

namespace Crito.Controllers
{
    public class ContactsController : SurfaceController
    {
        


        public ContactsController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider) : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
            

        }

        
        [HttpPost]
        public IActionResult Index( ContactForm contactForm)
        {      
            if (!ModelState.IsValid)
               return CurrentUmbracoPage();


            using var mail = new MailService("no-reply@crito.com", "smtp.crito.com", 587, "contact@crito.com", "PreTend123!"); //Instansiering för e-postmedd. (smtp = e-post server)

            mail.SendAsync(contactForm.Email, "A contact request was received.", "Your request was received and we will be in contact with you as soon as possible.").ConfigureAwait(false); //to sender
            mail.SendAsync("umbraco@crito.com", $"{contactForm.Name} sent a contact request.", contactForm.Message).ConfigureAwait(false); //to receiver/us

            return LocalRedirect(contactForm.RedirectUrl ?? "/");
            
          
        }


        
    }
}
