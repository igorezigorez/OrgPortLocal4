using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace OrgPort.DB.Initializers
{
    public class DropCreateIfModelChangesOrgPortDBInitializer<TContext> : OrgPortDBInitializer<TContext> where TContext:DbContext
    {
        public override void InitializeDatabase(TContext context)
        {
            if (context == null)
            {
                throw new Exception("OrgPort database context is null");
            }
            var replacedContext = ReplaceSqlCeConnection(context);
            bool databaseExists;
            using (new TransactionScope(TransactionScopeOption.Suppress))
            {
                databaseExists = replacedContext.Database.Exists();
            }

            if (databaseExists)
            {
                if (context.Database.CompatibleWithModel(throwIfNoMetadata: true))
                {
                    return;
                }
                replacedContext.Database.Delete();
            }
            else
            {
                context.Database.Create();
                this.Seed(context);
                context.SaveChanges();
            }
        }
    }
}
