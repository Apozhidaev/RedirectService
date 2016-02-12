namespace RedirectService
{
    public class App
    {
        private IModule[] _modules;

        public void Start()
        {
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