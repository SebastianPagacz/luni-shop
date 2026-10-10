using MediatR;
using ProductModule.Domain.Abstractions;
using ProductModule.Domain.Models;

namespace ProductModule.Application.Entities.Products.Commands;

public class CreateProductHandler(
    IRepository<Product> repository, 
    IUnitOfWork unitOfWork
    ) : IRequestHandler<CreateProductCommand, Guid>
{
    public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var newProduct = Product.Create(request.Name, request.Description, request.Price, request.Stock);

        repository.AddItem(newProduct);
        await unitOfWork.CommitAsync(cancellationToken);

        return newProduct.Id;
    }
}