using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Julian.Application.DTO.Request;
using WebApp.Julian.Application.DTO.Response;
using WebApp.Julian.Domain.Entities;

namespace WebApp.Julian.Application.Interface
{
    public interface IProductService
    {
        Task AddAsync(ReqAddProductDTO req);
        Task UpdateAsync(ReqAddProductDTO req);
        Task DeleteAsync(ReqAddProductDTO req);
        Task<List<ResProductDTO>> GetAllProduct();
    }
}
