using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using CleanArch.Application.Products.Commands;
using CleanArch.Application.Products.Queries;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using MediatR;

namespace CleanArch.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public ProductService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task Add(ProductDTO productDTO)
        {
            var productCommand = _mapper.Map<ProductCreateCommand>(productDTO);

            await _mediator.Send(productCommand);
        }

        public async Task<ProductDTO> GetById(int? id)
        {
            var productQuery = new GetProductByIdQuery(id.Value);

            if (productQuery == null)
                throw new ArgumentException("Entity could not be loaded");

            var productEntity = await _mediator.Send(productQuery);

            return _mapper.Map<ProductDTO>(productEntity);

        }

        // public async Task<ProductDTO> GetProductCategory(int? id)
        // {

        // }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {

            var productQuery = new GetProductsQuery();

            if (productQuery == null)
                throw new ArgumentException("Entity could not be loaded");

            var productsEntity = await _mediator.Send(productQuery);

            return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
        }

        public async Task Remove(int? id)
        {
            var productCommand = new ProductRemoveCommand(id.Value);

            await _mediator.Send(productCommand);
        }

        public async Task Update(ProductDTO productDTO)
        {
            var productCommand = _mapper.Map<ProductUpdateCommand>(productDTO);

            await _mediator.Send(productCommand);
        }
    }
}