using AutoMapper;
using FluentResults;
using MediatR;
using Application.Features.Products.Commands;
using Application.DTOs;
using Infrastructure.Data;
using Domain.Entities;

namespace Application.Features.Products.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, Result<ProductDto>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateProductHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<ProductDto>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.FindAsync(request.CategoryId);
            if (category == null)
                return Result.Fail("Category not found");

            var product = new Product()
            {
                Name = request.Name,
                Price = request.Price,
                CategoryId = request.CategoryId
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync(cancellationToken);

            var dto = _mapper.Map<ProductDto>(product);
            return Result.Ok(dto);
        }
    }
}