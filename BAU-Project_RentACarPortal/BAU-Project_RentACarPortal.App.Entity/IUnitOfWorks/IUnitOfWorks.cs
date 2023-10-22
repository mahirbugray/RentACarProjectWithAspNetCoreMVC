using BAU_Project_RentACarPortal.App.Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAU_Project_RentACarPortal.App.Entity.IUnitOfWorks
{
	public interface IUnitOfWorks : IDisposable
	{
		IGenericRepository<T> GetRepository<T>() where T : class, new();
		void Commit();          //İçine SaveChanges() gelecek.
		Task CommitAsync();
	}
}
