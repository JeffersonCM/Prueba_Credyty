using Credyty.Infraestructure.Interfaces;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Credyty.Infraestructure.Repositories
{
    public class CommonRepository<T> : ICommonRepository<T> where T : class
    {
        public async Task Delete(IDbTransaction transaction, T entity)
        {
            var comand = transaction.Connection.CreateCommand();
            string query = $"DELETE FROM {typeof(T).Name} WHERE ID = @ID";
            await Task.Run(() => transaction.Connection.QueryAsync(query, entity, transaction, null, comand.CommandType));
        }
        public async Task<T> Insert(IDbTransaction transaction, T entity)
        {
            if (entity != null)
            {
                var comand = transaction.Connection.CreateCommand();

                string queryPart1 = $"INSERT INTO {typeof(T).Name} (";
                string queryPart2 = ") VALUES (";
                string queryPart3 = string.Empty;

                PropertyInfo[] properties = typeof(T).GetProperties();
                foreach (PropertyInfo p in properties)
                {
                    if (p.Name != "ID")
                    {
                        queryPart1 += $" {p.Name},";
                        queryPart2 += $" @{ p.Name},";
                    }
                    else
                    {
                        queryPart3 = $"SELECT * FROM {typeof(T).Name} WHERE ID = (SELECT MAX(ID) from {typeof(T).Name})";
                    }
                }

                string query = $"{queryPart1.TrimEnd(',')} {queryPart2.TrimEnd(',')})";

                await Task.Run(() => transaction.Connection.QueryAsync<T>(query, entity, transaction, null, comand.CommandType));

                return (await Task.Run(() => transaction.Connection.QueryAsync<T>(queryPart3, null, transaction, null, comand.CommandType))).SingleOrDefault();
            }

            return entity;
        }
        public async Task<IEnumerable<T>> ListAll(IDbConnection connection)
        {
            var query = $"SELECT * FROM {typeof(T).Name}";
            return await Task.Run(() => connection.QueryAsync<T>(query));
        }
        public async Task<IEnumerable<T>> ListAll(IDbTransaction transaction)
        {
            var comand = transaction.Connection.CreateCommand();
            var query = $"SELECT * FROM {typeof(T).Name}";
            return await Task.Run(() => transaction.Connection.QueryAsync<T>(query, null, transaction, null, comand.CommandType));
        }
        public async Task<IEnumerable<T>> ListByWhere(IDbConnection connection, string where, object parameters)
        {
            var query = $"SELECT * FROM {typeof(T).Name} WHERE {where}";
            return await Task.Run(() => connection.QueryAsync<T>(query, parameters));
        }
        public async Task<IEnumerable<T>> ListByWhere(IDbTransaction transaction, string where, object parameters)
        {
            var comand = transaction.Connection.CreateCommand();
            var query = $"SELECT * FROM {typeof(T).Name} WHERE {where}";
            return await Task.Run(() => transaction.Connection.QueryAsync<T>(query, parameters, transaction, null, comand.CommandType));
        }
        public async Task Update(IDbTransaction transaction, T entity)
        {
            var comand = transaction.Connection.CreateCommand();
            string queryPart1 = $"UPDATE {typeof(T).Name} SET ";
            string queryPart2 = $" WHERE ID = @ID";

            PropertyInfo[] properties = typeof(T).GetProperties();
            foreach (PropertyInfo p in properties)
            {
                if (p.Name != "ID")
                {
                    queryPart1 += $" {p.Name} = @{p.Name},";
                }
            }

            string query = $"{queryPart1.TrimEnd(',')} {queryPart2}";

            await Task.Run(() => transaction.Connection.QueryAsync(query, entity, transaction, null, comand.CommandType));
        }
    }
}
