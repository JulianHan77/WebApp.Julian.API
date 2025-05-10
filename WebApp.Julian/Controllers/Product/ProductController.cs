using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApp.Julian.Application.DTO.Request;
using WebApp.Julian.Application.DTO.Response;
using WebApp.Julian.Application.Interface;
using WebApp.Julian.Domain.Entities;

namespace WebApp.Julian.API.Controllers.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService iProduct;

        public ProductController(
            IProductService iProduct)
        {
            this.iProduct = iProduct;
        }

        [Route("AddProduct")]
        [HttpPost]
        public async Task<ActionResult> Add(ReqAddProductDTO req)
        {
            await iProduct.AddAsync(req);
            return Ok();
        }

        [Route("DeleteProduct")]
        [HttpPost]
        public async Task<ActionResult> Delete(ReqAddProductDTO req)
        {
            await iProduct.DeleteAsync(req);
            return Ok();
        }

        [Route("UpdateProduct")]
        [HttpPost]
        public async Task<ActionResult> Update(ReqAddProductDTO req)
        {
            await iProduct.UpdateAsync(req);
            return Ok();
        }

        [Route("GetAllProduct")]
        [HttpGet]
        public async Task<ActionResult> GetAllProduct()
        {
            List<ResProductDTO> data = await iProduct.GetAllProduct();
            return Ok(data);
        }

    }
}
