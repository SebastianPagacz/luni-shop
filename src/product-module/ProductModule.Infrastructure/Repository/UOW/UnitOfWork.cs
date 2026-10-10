using ProductModule.Domain.Abstractions;
using ProductModule.Infrastructure.Context;

namespace ProductModule.Infrastructure.Repository;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        await context.SaveChangesAsync(cancellationToken);
    }
}