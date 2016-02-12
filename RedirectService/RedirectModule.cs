using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using NuGet.Modules;
using NuGet.Modules.Redirect;
using RedirectService.Configuration;

namespace RedirectService
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
                Dictionary<Regex, string> queryRules = null;
                Dictionary<string, Dictionary<Regex, string>> contentRules = null;
                if (patterns != null)
                {
                    queryRules = redirectRule.Patterns?.Split(',').ToDictionary(
                        patternName => new Regex(patterns[patternName].Regex, RegexOptions.IgnoreCase),
                        patternName => patterns[patternName].Replacement);

                    contentRules = redirectRule.Replaces?.ToDictionary(
                        rule => rule.MediaType,
                        rule => rule.Patterns.Split(',').ToDictionary(
                            patternName => new Regex(patterns[patternName].Regex, RegexOptions.IgnoreCase),
                            patternName => patterns[patternName].Replacement));
                }
                var redirectSettings = new RedirectSettings
                {
                    Froms = redirectRule.From.Split(','),
                    To = redirectRule.To,
                    QueryRules = queryRules,
                    ContentRules = contentRules
                };
                _redirects.Add(new HttpRedirect(redirectSettings));
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