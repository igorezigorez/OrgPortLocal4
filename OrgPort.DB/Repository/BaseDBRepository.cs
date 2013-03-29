using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgPort.DB.Repository
{
    public class BaseDBRepository
    {
        protected IUnitOfWork UnitOfWork { get; set; }

        protected OrgPortDBContext Context
        {
            get { return (OrgPortDBContext)UnitOfWork; }
        }

        public BaseDBRepository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("UnitOfWork is null!");
            }
            UnitOfWork = unitOfWork;
        }

        public virtual DbSet<TEntity> GetDbSet<TEntity>() where TEntity : class
        {
            return this.Context.Set<TEntity>();
        }

        protected virtual void SetEntityState(object entity, EntityState entityState)
        {
            this.Context.Entry(entity).State = entityState;
        }
    }
}
