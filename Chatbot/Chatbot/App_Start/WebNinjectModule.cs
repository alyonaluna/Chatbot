using Ninject.Modules;
using Chatbot.DataAccess;

namespace Chatbot.Web
{
    public class WebNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IFactRepository>().To<FactRepository>();
        }
    }
}