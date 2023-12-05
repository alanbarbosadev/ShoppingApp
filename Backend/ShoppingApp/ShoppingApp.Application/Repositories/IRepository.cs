using ShoppingApp.Application.Specifications;
using ShoppingApp.Domain.Entities;

namespace ShoppingApp.Application.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<IReadOnlyList<T>> GetAllWithSpecificationAsync(ISpecification<T> specification);
        Task<T> GetByIdWithSpecificationAsync(ISpecification<T> specification);
        Task<int> CountAsync(ISpecification<T> specification);
    }
}
