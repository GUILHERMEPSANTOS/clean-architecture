using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArch.Application.DTOs;

namespace CleanArch.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts(); 
        Task<ProductDTO> GetById(int? id);
        // Task<ProductDTO> GetProductCategory(int? id);
        Task Add(ProductDTO productDTO);
        Task<ProductDTO> Update(ProductDTO productDTO);
        Task<ProductDTO> Remove(int? id);
    }
}