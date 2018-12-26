using System.Data.Entity;

namespace Chatbot.DataAccess
{
    public class KBContext : DbContext
    {
        public KBContext()
            : base("DbConnection")
        { }

        public DbSet<Fact> Facts { get; set; }
    }
}
