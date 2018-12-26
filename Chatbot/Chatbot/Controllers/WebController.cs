using Chatbot.DataAccess;
using Ninject;
using System.Web.Http;

namespace Chatbot.Controllers
{
    public class WebController : ApiController
    {
        private readonly IFactRepository _factRepository;

        public WebController()
        {
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<IFactRepository>().To<FactRepository>();
            _factRepository = ninjectKernel.Get<FactRepository>();
        }

        public string GetAnswer(string question)
        {
            var fact = _factRepository.Get(question);
            return fact == null ? "" : fact.Answer;
        }

        [HttpPost]
        public void CreateFact(Fact fact)
        {
            _factRepository.Add(fact);
        }
    }
}