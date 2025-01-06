using Dapper;
using UsingHybridOrm.DataAccess.Abstract.Base;
using UsingHybridOrm.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace UsingHybridOrm.DataAccess.Concrete.Dapper
{
    public class DapperBaseRepository<TEntity> :
          IRepository<TEntity>
          where TEntity : BaseEntity
    {
        private readonly IDbConnection _connection;

        protected DapperBaseRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<TEntity> GetAll()
        {
            var query = $"SELECT * FROM {typeof(TEntity).Name}s";
            return _connection.Query<TEntity>(query);
        }

        public TEntity GetById(int id)
        {
            var query = $"SELECT * FROM {typeof(TEntity).Name}s WHERE ID = @ID";
            return _connection.QuerySingleOrDefault<TEntity>(query, new { ID = id });
        }

        public void Add(TEntity entity)
        {
            var query = $"INSERT INTO {typeof(TEntity).Name}s (...) VALUES (...);";
            _connection.Execute(query, entity);
        }

        public void Update(TEntity entity)
        {
            var query = $"UPDATE {typeof(TEntity).Name}s SET (...) WHERE ID = @ID;";
            _connection.Execute(query, entity);
        }

        public void Delete(int id)
        {
            var query = $"DELETE FROM {typeof(TEntity).Name}s WHERE ID = @ID;";
            _connection.Execute(query, new { ID = id });
        }
    }
}
