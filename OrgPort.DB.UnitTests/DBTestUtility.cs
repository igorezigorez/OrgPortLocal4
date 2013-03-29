using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using OrgPort.DB.Initializers;

namespace OrgPort.DB.UnitTests
{
    internal class DBTestUtility : OrgPortDBInitializer<OrgPortDBContext>
    {
        public static void DropCreateOrgPortDatabase()
        {
            OrgPortDBContext context = GetDatabaseContext();
            DropAndCreateDatabase(context);
            context.SaveChanges();
        }

        public static void DropCreateAndSeedOrgPortDatabase()
        {
            OrgPortDBContext context = GetDatabaseContext();
            DropAndCreateDatabase(context);
            SeedDatabase(context);

            context.SaveChanges();
        }

        private static OrgPortDBContext GetDatabaseContext()
        {
            // This uses the configuration values in the app.config which point to a TestData.sdf file.
            Database.DefaultConnectionFactory = new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0");

            return new OrgPortDBContext();
        }

        private static void DropAndCreateDatabase(OrgPortDBContext context)
        {
            var replacedContext = ReplaceSqlCeConnection(context);

            if (replacedContext.Database.Exists())
            {
                replacedContext.Database.Delete();
            }
            context.Database.Create();
        }

        private static void SeedDatabase(OrgPortDBContext context)
        {
            ISeedDatabase seeder = context as ISeedDatabase;
            if (seeder != null)
            {
                seeder.Seed();
            }
        }

        public override void InitializeDatabase(OrgPortDBContext context)
        {
            throw new NotImplementedException();
        }
    }
}
