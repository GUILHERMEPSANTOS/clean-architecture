using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArch.Application.Products.Commands
{
    public class ProductUpdateCommand: ProductCommand
    {
        public int Id { get; set; }
    }
}