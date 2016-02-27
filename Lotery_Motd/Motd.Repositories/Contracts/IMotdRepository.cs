
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Motd.Repositories.Contracts
{
    public interface IMotdRepository<T> where T : class
    {
        /// <summary>
        ///   Get the total objects count.
        /// </summary>
        int Count { get; }

        /// <summary>
        ///   Gets all objects from database of Type T
        /// </summary>
        IQueryable<T> All();

        /// <summary>
        ///   Gets object by primary key.
        /// </summary>
        /// <param name="id"> primary key </param>
        /// <returns> </returns>
        T GetById(object id);

        /// <summary>
        ///   Gets objects via optional filter, sort order, and includes
        /// </summary>
        /// <param name="filter"> </param>
        /// <param name="orderBy"> </param>
        /// <param name="includeProperties"> </param>
        /// <returns> </returns>
        IQueryable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");

        /// <summary>
        ///   Gets objects from database by filter.
        /// </summary>
        /// <param name="predicate"> Specified a filter </param>
        IQueryable<T> Filter(Expression<Func<T, bool>> predicate);

        /// <summary>
        ///   Gets objects from database with filting and paging.
        /// </summary>
        /// <param name="filter"> Specified a filter </param>
        /// <param name="total"> Returns the total records count of the filter. </param>
        /// <param name="index"> Specified the page index. </param>
        /// <param name="size"> Specified the page size </param>
        IQueryable<T> Filter(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50);

        /// <summary>
        ///   Gets the object(s) is exists in database by specified filter.
        /// </summary>
        /// <param name="predicate"> Specified the filter expression </param>
        bool Contains(Expression<Func<T, bool>> predicate);

        /// <summary>
        ///   Find object by keys.
        /// </summary>
        /// <param name="keys"> Specified the search keys. </param>
        T Find(params object[] keys);

        /// <summary>
        ///   Find object by specified expression.
        /// </summary>
        /// <param name="predicate"> </param>
        T Find(Expression<Func<T, bool>> predicate);

        /// <summary>
        ///   Create a new object to database.
        /// </summary>
        /// <param name="entity"> Specified a new object to create. </param>
        T Create(T entity);

        /// <summary>
        ///   Deletes the object by primary key
        /// </summary>
        /// <param name="id"> </param>
        void Delete(object id);

        /// <summary>
        ///   Delete the object from database.
        /// </summary>
        /// <param name="entity"> Specified a existing object to delete. </param>
        void Delete(T entity);

        /// <summary>
        ///   Delete objects from database by specified filter expression.
        /// </summary>
        /// <param name="predicate"> </param>
        void Delete(Expression<Func<T, bool>> predicate);

        /// <summary>
        ///   Update object changes and save to database.
        /// </summary>
        /// <param name="entity"> Specified the object to save. </param>
        void Update(T entity);

        #region AdditionalFunctions
        /// <summary>
        /// Executes a stored procedure or function that is defined in the data source and expressed in the conceptual model; 
        /// discards any results returned from the function; and returns the number of rows affected by the execution.
        /// </summary>
        /// <param name="functionName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        int ExecuteFunction(string functionName, params ObjectParameter[] parameters);

        /*
         * Executes an arbitrary command directly against the data source using the existing connection. The command is specified using the server's native query language, such as SQL. As with any API that accepts SQL it is important to parameterize any user input to protect against a SQL injection attack. 
         * You can include parameter place holders in the SQL query string and then supply parameter values as additional arguments. 
         * Any parameter values you supply will automatically be converted to a DbParameter. context.ExecuteStoreCommand("UPDATE dbo.Posts SET Rating = 5 WHERE Author = @p0", userSuppliedAuthor); Alternatively, you can also construct a DbParameter and supply it to SqlQuery. 
         * This allows you to use named parameters in the SQL query string. context.ExecuteStoreCommand("UPDATE dbo.Posts SET Rating = 5 WHERE Author = @author", new SqlParameter("@author", userSuppliedAuthor));
         */
        int ExecuteStoreCommand(string commandText, params Object[] parameters);

        /*
         * Executes a query directly against the data source and returns a sequence of typed results. The query is specified using the server's native query language, such as SQL. 
         * Results are not tracked by the context, use the overload that specifies an entity set name to track results. As with any API that accepts SQL it is important to parameterize any user input to protect against a SQL injection attack. 
         * You can include parameter place holders in the SQL query string and then supply parameter values as additional arguments. Any parameter values you supply will automatically be converted to a DbParameter. context.ExecuteStoreQuery&amp;lt;Post&amp;gt;("SELECT * FROM dbo.Posts WHERE Author = @p0", userSuppliedAuthor); 
         * Alternatively, you can also construct a DbParameter and supply it to SqlQuery. This allows you to use named parameters in the SQL query string. context.ExecuteStoreQuery&amp;lt;Post&amp;gt;("SELECT * FROM dbo.Posts WHERE Author = @author", new SqlParameter("@author", userSuppliedAuthor));
         */
        IQueryable<TElement> ExecuteStoreQuery<TElement>(
            string commandText,
            params Object[] parameters
            );

        /*
         * Creates a raw SQL query that will return elements of the given type. The type can be any type that has properties that match the names of the columns returned from the query, or can be a simple primitive type. The type does not have to be an entity type. 
         * The results of this query are never tracked by the context even if the type of object returned is an entity type. Use the SqlQuery(String, Object[]) method to return entities that are tracked by the context. As with any API that accepts SQL it is important to parameterize any user input to protect against a SQL injection attack. 
         * You can include parameter place holders in the SQL query string and then supply parameter values as additional arguments. Any parameter values you supply will automatically be converted to a DbParameter. context.Database.SqlQuery(typeof(Post), "SELECT * FROM dbo.Posts WHERE Author = @p0", userSuppliedAuthor); 
         * Alternatively, you can also construct a DbParameter and supply it to SqlQuery. This allows you to use named parameters in the SQL query string. context.Database.SqlQuery(typeof(Post), "SELECT * FROM dbo.Posts WHERE Author = @author", new SqlParameter("@author", userSuppliedAuthor));
         */
        IQueryable SqlQuery(
            Type elementType,
            string sql,
            params Object[] parameters
            );

        IQueryable<TElement> SqlQuery<TElement>(
            string sql,
            params Object[] parameters
            );

        /*
         * Executes the given DDL/DML command against the database. As with any API that accepts SQL it is important to parameterize any user input to protect against a SQL injection attack. You can include parameter place holders in the SQL query string and then supply parameter values as additional arguments. 
         * Any parameter values you supply will automatically be converted to a DbParameter. context.Database.ExecuteSqlCommand("UPDATE dbo.Posts SET Rating = 5 WHERE Author = @p0", userSuppliedAuthor); Alternatively, you can also construct a DbParameter and supply it to SqlQuery. 
         * This allows you to use named parameters in the SQL query string. context.Database.ExecuteSqlCommand("UPDATE dbo.Posts SET Rating = 5 WHERE Author = @author", new SqlParameter("@author", userSuppliedAuthor));
         */
        int ExecuteSqlCommand(
            string sql,
            params Object[] parameters
            );

        #endregion

        #region SaveChanges

        int SaveChanges();

        #endregion
    }
}
