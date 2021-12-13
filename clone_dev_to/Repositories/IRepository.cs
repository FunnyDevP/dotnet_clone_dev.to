namespace clone_dev_to.Repositories;

public interface IRepository<TEntity>
{
    List<TEntity> GetAll();
}