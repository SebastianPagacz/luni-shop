using MediatR;
using ProductModule.Domain.ValueObjects;

namespace ProductModule.Application.Entities.Products.Commands;

public record CreateProductCommand(
    string Name, 
    string? Description, 
    Money Price, 
    int Stock
    ) : IRequest<Guid>;