using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
//using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Netflix.Common
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly SqlConnection connection;

        public GenericRepository(string connection)
        {
            this.connection = new SqlConnection(Helpers.getConnStr());
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> Query(string Sql)
        {
            using (var conn = this.connection)
            {
                return conn.Query<TEntity>(Sql);
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            IEnumerable<TEntity> res = connection.GetAll<TEntity>();
            return res;
        }

        public virtual TEntity Get(long id)
        {
            TEntity res = connection.Get<TEntity>(id);
            return res;
        }

        public void Add(TEntity obj)
        {
            connection.Insert(obj);
        }

        public void Update(TEntity obj)
        {
            connection.Update<TEntity>(obj);
        }

        public void Delete(TEntity obj)
        {
            connection.Delete(obj);
        }

        public List<TEntity> Find(TEntity entity)
        {
            if (entity == null) return null;
            try
            {
                Type t1 = entity.GetType();
                PropertyInfo[] fields = t1.GetProperties(BindingFlags.Instance | BindingFlags.Public);

                string tableName = t1.GetCustomAttribute<Dapper.Contrib.Extensions.TableAttribute>().Name;

                string where = "where 1=1 ";
                foreach (var field in fields)
                {
                    var type = field.PropertyType.FullName;
                    var value = field.GetValue(entity, null);

                    //Null olabilenlerde nulldan farklı değerleri , Null olamayanlarda 0 dan farklı değerleri 
                    if (type.Contains("Int") || type.Contains("Decimal") || type.Contains("long") || type.Contains("Byte"))
                        if ((type.Contains("Nullable") && value != null) || (!type.Contains("Nullable") && Convert.ToInt32(value) != 0))
                            where += string.Format(" and {0} = {1} ", field.Name, value);

                    if (type.Contains("String"))
                        if (value != null && !string.IsNullOrEmpty((string)value))
                            where += string.Format(" and {0} = '{1}' ", field.Name, value);

                    //if (type.Contains("Boolean"))
                    //    if ((type.Contains("Nullable") && value != null)
                    //    if (value != null)
                    //        if (Convert.ToBoolean(value))
                    //            where += string.Format(" and {0} = 1 ", field.Name);
                    //        else
                    //            where += string.Format(" and {0} = 0 ", field.Name);
                }

                string sql = string.Format("select * from {0} {1}", tableName, where);

                using (var conn = this.connection)
                {
                    List<TEntity> res = Query(sql).AsList();
                    return res;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("GenericRepository.Find method Hata : " + ex.Message);
            }
        }
    }
}
