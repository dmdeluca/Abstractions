using Microsoft.EntityFrameworkCore;

namespace Abstractions.Contracts;

/// <summary>
/// A wrapper for any <typeparamref name="TContext"/> instance that makes it easy to mock operations executed on it. Solves the problem of not being able to mock EF Queryable extensions.
/// </summary>
/// <typeparam name="TContext">The type of <see cref="DbContext"/></typeparam>
public interface IDbContextWrapper<TContext> where TContext : DbContext
{
    /// <summary>
    /// Executes a function on the DbContext, returning some result. Use this method to wrap data context operations that involve difficult-to-mock elements like asynchronous IQueryable extensions.
    /// </summary>
    /// <typeparam name="TResult">The return type of the function</typeparam>
    /// <typeparam name="TContext">The target DbContext type</typeparam>
    /// <param name="function">A function to execute on the TContext</param>
    /// <returns>The result of the function applied to the TContext instance</returns>
    TResult Execute<TResult>(Func<TContext, TResult> function);
}
