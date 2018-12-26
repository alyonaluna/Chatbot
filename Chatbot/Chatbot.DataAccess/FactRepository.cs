using System;
using System.Linq;

namespace Chatbot.DataAccess
{
    public class FactRepository : IFactRepository
    {
        /// <inheritdoc />
        public void Add(Fact fact)
        {
            using (var db = new KBContext())
            {
                fact.Id = Guid.NewGuid();
                db.Facts.Add(fact);
                db.SaveChanges();
            }
        }

        /// <inheritdoc />
        public Fact Get(string question)
        {
            using (var db = new KBContext())
            {
                return db.Facts.FirstOrDefault(x => x.Question == question);
            }
        }
    }
}
