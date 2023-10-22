using BAU_Project_RentACarPortal.App.DataAccess.Contexts;
using BAU_Project_RentACarPortal.App.DataAccess.Repositories;
using BAU_Project_RentACarPortal.App.Entity.Interfaces;
using BAU_Project_RentACarPortal.App.Entity.IUnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAU_Project_RentACarPortal.App.DataAccess.UnitOfWorks
{
	public class UnitOfWork : IUnitOfWorks
	{
		private readonly RentalDbContext _context;
		private bool disposed = false;

		public UnitOfWork(RentalDbContext context)
		{
			_context = context;
		}

		public IGenericRepository<T> GetRepository<T>() where T : class, new()
		{
			return new GenericRepository<T>(_context);
		}
		public void Commit()
		{
			_context.SaveChanges();
		}

		public async Task CommitAsync()
		{
			await _context.SaveChangesAsync();
		}

		public virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					_context.Dispose();
				}
			}
			this.disposed = true;
		}
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
