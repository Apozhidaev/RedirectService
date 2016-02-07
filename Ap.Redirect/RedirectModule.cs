using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Ap.Redirect.Configuration;
using NuGet.Modules;
using NuGet.Modules.Redirect;

namespace Ap.Redirect
{
    public class RedirectModule : IModule
    {
        private readonly List<HttpRedirect> _redirects = new List<HttpRedirect>();

        public void Start()
        {
            var settings = XmlHelper.Deserialize<Settings>("settings.xml");
            var patterns = settings.Patterns?.ToDictionary(p => p.Name);
            foreach (var redirectRule in settings.Redirects)
            {
                Dictionary<string, Dictionary<Regex, string>> rules = null;
                if (patterns != null)
                {
                    rules = redirectRule.Replaces?.ToDictionary(
                    rule => rule.MediaType,
                    rule => rule.Patterns.Split(',').ToDictionary(
                        patternName => new Regex(patterns[patternName].From),
                        patternName => patterns[patternName].To));
                }
                _redirects.Add(new HttpRedirect(redirectRule.From.Split(','), redirectRule.To, rules));
            }
            foreach (var httpRedirect in _redirects)
            {
                httpRedirect.Start();
            }
        }

        public void Stop()
        {
            foreach (var httpRedirect in _redirects)
            {
                httpRedirect.Stop();
            }
            _redirects.Clear();
        }
    }
}