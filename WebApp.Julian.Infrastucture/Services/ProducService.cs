using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Julian.Application.DTO.Request;
using WebApp.Julian.Application.DTO.Response;
using WebApp.Julian.Application.Interface;
using WebApp.Julian.Domain.Entities;
using WebApp.Julian.Infrastucture.Context;

namespace WebApp.Julian.Infrastucture.Services
{
    public class ProducService : IProductService
    {
        private readonly WebAppJulianDbContext _context;

        public ProducService(WebAppJulianDbContext contextFactory)
        {
            _context = contextFactory;
        }

        public async Task AddAsync(ReqAddProductDTO req)
        {
            Product product = new Product()
            {
                Name = req.Name,
                Price = req.Price,
                Description = req.Description,
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ReqAddProductDTO req)
        {
            Product product = await _context.Products.
                Where(x => x.Id == req.id).FirstOrDefaultAsync();
            if (product == null)
            {
                throw new Exception("Product ID not found.");
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ReqAddProductDTO req)
        {

            Product? product = await _context.Products.
                Where(x => x.Id == req.id).FirstOrDefaultAsync();
            if(product == null)
            {
                throw new Exception("Product ID not found.");
            }
            product.Name = req.Name;
            product.Price = req.Price;
            product.Description = req.Description;

            await _context.SaveChangesAsync();
        }

        public async Task<List<ResProductDTO>> GetAllProduct()
        {
            List<Product> list = await _context.Products.ToListAsync();

            List<ResProductDTO> result = new List<ResProductDTO>();
            ResProductDTO resProductDTO;
            foreach (Product product in list)
            {
                resProductDTO = new ResProductDTO();
                resProductDTO.Name = product.Name;
                resProductDTO.Price = product.Price;
                resProductDTO.Description = product.Description;
                resProductDTO.id = product.Id;
                result.Add(resProductDTO);
            }
            return result;
        }
    }
}
