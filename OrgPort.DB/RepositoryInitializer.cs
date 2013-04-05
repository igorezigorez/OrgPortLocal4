using OrgPort.Data;
using OrgPort.DB.Initializers;
using OrgPort.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMatrix.WebData;

namespace OrgPort.DB
{
    class RepositoryInitializer:IRepositoryInitializer
    {
        IUnitOfWork unitOfWork;

        public RepositoryInitializer(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new Exception("Unity of work is null");
            }
            this.unitOfWork = unitOfWork;
            Database.DefaultConnectionFactory = new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0");

            Database.SetInitializer(new DropCreateAlwaysOrgPortDBInitializer<OrgPortDBContext>());
            
            //Database.SetInitializer(new DropCreateIfModelChangesOrgPortDBInitializer<OrgPortDBContext>());
        }


        public OrgPortDBContext Context
        {
            get { return (OrgPortDBContext)this.unitOfWork; }
        }

        public void Initialize()
        {
            this.Context.Set<Tag>().ToList().Count();
            //WebSecurity.InitializeDatabaseConnection(this.Context.Database.Connection.ConnectionString.Trim().Trim(';'), "User", "Id", "UserName", false);
            //WebSecurity.InitializeDatabaseConnection("DefaultConnection", "EdxUserProfile", "UserId", "UserName", autoCreateTables: true);
        }
    }
}
