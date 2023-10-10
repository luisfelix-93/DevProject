using DevProjectAPI.Infrastructure.DTO;
using DevProjectAPI.Infrastructure.Entities;
using DevProjectAPI.Infrastructure.Repositories;
using System.IO;

namespace DevProjectAPI.Services
{
    public class ProductService
    {
        #region Constructor
        private ProductRepository _productRepository;
        private UserRepository _userRepository;
        public ProductService(ProductRepository productRepository, UserRepository userRepository)
        {
            _productRepository = productRepository;
            _userRepository = userRepository;
        }
        #endregion
        #region Methods
        public async Task<ReturnDTO> GetProductByUserService(string pIdUser)
        {
            ReturnDTO returnDTO = new ReturnDTO
            {
                Success = false,
                Message = "",
                ResultObject = null
            };

            try
            {
                returnDTO.ResultObject = await _productRepository.GetProductListByIdUser(pIdUser);
                if (returnDTO.ResultObject != null)
                {
                    returnDTO.Success = true;
                    returnDTO.Message = "OK";
                }

                return returnDTO;
            }
            catch (Exception ex)
            {
                returnDTO.Success = false;
                returnDTO.Message = ex.Message;
                returnDTO.ResultObject = null;

                return returnDTO;
            }
        }
        public async Task<ReturnDTO> InsertProductByUser(string pIdUser, Product pProduct)
        {
            User user = new User();
            ReturnDTO returnDTO = new ReturnDTO
            {
                Success = false,
                Message = "",
                ResultObject = null
            };
            try
            {
                Product product = new Product
                {
                    idUser = pIdUser,
                    IdProduct = pProduct.IdProduct,
                    ProductDescription = pProduct.ProductDescription,
                    ProductName = pProduct.ProductName,
                    ProductPrice = pProduct.ProductPrice,
                    PriceType = pProduct.PriceType,
                };

                user = await _userRepository.GetUserByIdAsync(pIdUser);
                if(user == null)
                {
                    returnDTO.Success = false;
                    returnDTO.Message = "User not found";
                    returnDTO.ResultObject = null;
                }
                else
                {
                    await _productRepository.InsertProduct(product);
                    returnDTO.Success = true;
                    returnDTO.Message = "OK";
                    returnDTO.ResultObject = pProduct;
                }

                return returnDTO;
            }
            catch (Exception ex)
            {
                returnDTO.Success = false;
                returnDTO.Message = ex.Message;
                returnDTO.ResultObject = null;

                return returnDTO;
            }
        }
        #endregion
    }
}
