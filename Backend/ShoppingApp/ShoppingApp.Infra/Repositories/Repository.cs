using Microsoft.EntityFrameworkCore;
using ShoppingApp.Application.Repositories;
using ShoppingApp.Application.Specifications;
using ShoppingApp.Domain.Entities;
using ShoppingApp.Infra.DataContext;
using ShoppingApp.Infra.Specifications;

namespace ShoppingApp.Infra.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly DbSet<T> _dbSet;

        public Repository(ShoppingAppContext context)
        {
            _dbSet = context.Set<T>();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IReadOnlyList<T>> GetAllWithSpecificationAsync(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).ToListAsync();
        }

        public async Task<T> GetByIdWithSpecificationAsync(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync();
        }

        public async Task<int> CountAsync(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).CountAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> specification)
        {
            return SpecificationEvaluator<T>.GetQuery(_dbSet.AsQueryable(), specification);
        } 
    }
}
