using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArch.Domain.Entities;
using MediatR;

namespace CleanArch.Application.Products.Commands
{
    public class ProductRemoveCommand: IRequest<Product>
    {
        public int Id { get; set; }

        public ProductRemoveCommand(int Id)
        {
            this.Id = Id;
        }
    }
}