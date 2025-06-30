using Application.DTOs;
using FluentResults;
using MediatR;

namespace Application.Features.Products.Commands
{
    public record CreateProductCommand(string Name, decimal Price, int CategoryId)
        : IRequest<Result<ProductDto>>;
}