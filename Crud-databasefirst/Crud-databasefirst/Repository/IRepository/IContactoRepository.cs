namespace Crud_databasefirst.Repository.IRepository
{
    public interface IContactoRepository<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<bool>Delete(int id);
    }
}
