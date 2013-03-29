using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace OrgPort.DB.Initializers
{
    public class DropCreateAlwaysOrgPortDBInitializer<TContext> : OrgPortDBInitializer<TContext> where TContext:DbContext
    {
        public override void InitializeDatabase(TContext context)
        {
            if (context == null)
            {
                throw new Exception("OrgPort database context is null");
            }
            var replacedContext = ReplaceSqlCeConnection(context);

            if (replacedContext.Database.Exists())
            {
                replacedContext.Database.Delete();
            }

            context.Database.Create();
            this.Seed(context);
            context.SaveChanges();
        }
    }
}
