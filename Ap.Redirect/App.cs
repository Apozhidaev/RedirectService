using Ap.Redirect.Configuration;
using NuGet.Modules;

namespace Ap.Redirect
{
    public class App
    {
        private IModule[] _modules;

        public void Start()
        {
            //var settings = new Settings
            //{
            //    Patterns = new []
            //    {
            //        new Pattern
            //        {
            //            Name = "domain",
            //            From = "https://reg\\.2domains\\.ru",
            //            To = "http://localhost:50009"
            //        }
            //    },
            //    Redirects = new[]
            //    {
            //        new RedirectRule
            //        {
            //            From = "http://localhost:50009/",
            //            To = "https://reg.2domains.ru/",
            //            Replaces = new[]
            //            {
            //                new ReplaceRule
            //                {
            //                    MediaType = "text/html",
            //                    Patterns = "domain"
            //                }
            //            }
            //        }
            //    }
            //};
            //XmlHelper.Serialize("settings.xml", settings);
            _modules = new IModule[]
            {
                new RedirectModule() 
            };
            foreach (var module in _modules)
            {
                module.Start();
            }
        }

        public void Stop()
        {
            foreach (var module in _modules)
            {
                module.Stop();
            }
        }
    }
}