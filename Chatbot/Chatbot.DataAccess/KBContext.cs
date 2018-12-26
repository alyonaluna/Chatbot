using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
