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
    public class SubscribeController : SurfaceController
    {
        private readonly SubscriberService _subscriberService;

        public SubscribeController(
            IUmbracoContextAccessor umbracoContextAccessor,
            IUmbracoDatabaseFactory databaseFactory,
            ServiceContext services,
            AppCaches appCaches,
            IProfilingLogger profilingLogger,
            IPublishedUrlProvider publishedUrlProvider,
            SubscriberService subscriberService)
            : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
            _subscriberService = subscriberService;
        }

        [HttpPost]
        public IActionResult Index(SubscribeModel subscribeModel)
        {
            if (!ModelState.IsValid)
            {
                // Om modellen inte är giltig, returnera till startsidan
                return RedirectToCurrentUmbracoPage();
            }

            // sparar prenumerationen i databasen
            _subscriberService.AddSubscriberAsync(subscribeModel).ConfigureAwait(false);

            //omdirigerar användaren till startsidan
            return RedirectToCurrentUmbracoPage();
        }
    }
}
