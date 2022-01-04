using Microsoft.EntityFrameworkCore;
using DataLayerAbstractions.Contracts;

namespace DataLayerAbstractions;

public class DbContextWrapper<TContext> : IDbContextWrapper<TContext> where TContext : DbContext
{
    /// <summary>
    /// An instance of the TContext on which wrapped operations will be executed.
    /// </summary>
    private readonly TContext dbContext;

    public DbContextWrapper(TContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public TResult Execute<TResult>(Func<TContext, TResult> function)
    {
        if (function is null)
            throw new ArgumentNullException(nameof(function));

        return function(dbContext);
    }
}
