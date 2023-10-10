using DevProjectAPI.Infrastructure.DTO;
using DevProjectAPI.Infrastructure.Entities;
using DevProjectAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevProjectAPI.Controllers.Users.Products
{
    [Route("api/User/{pIdUser}")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productSevice;

        public ProductController(ProductService productSevice)
        {
            _productSevice = productSevice;
        }

        [HttpGet]
        [Route("GetProductList")]
        public async Task<IActionResult> GetProductListController(string pIdUser) 
        {
            ReturnDTO returnDTO = await _productSevice.GetProductByUserService(pIdUser);
            if (returnDTO.Success)
                return new OkObjectResult(returnDTO);

            return new NotFoundObjectResult(returnDTO);
        }

        [HttpPost]
        [Route("InsertProductByUser")]
        public async Task<IActionResult> InsertProductByUserController(string pIdUser, [FromBody] Product pProduct)
        {
            ReturnDTO returnDTO = await _productSevice.InsertProductByUser(pIdUser, pProduct);
            if (returnDTO.Success)
                return new OkObjectResult(returnDTO);

            return new NotFoundObjectResult(returnDTO);

        }

    }
}
