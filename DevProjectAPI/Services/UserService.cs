using DevProjectAPI.Infrastructure.DTO;
using DevProjectAPI.Infrastructure.Entities;
using DevProjectAPI.Infrastructure.Helpers;
using DevProjectAPI.Infrastructure.Repositories;

namespace DevProjectAPI.Services
{
    public class UserService
    {
        #region Constructor
        UserRepository _userRepository;
        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        #endregion

        public async Task<ReturnDTO> GetUserService(string pIdUser)
        {
            ReturnDTO returnDTO = new ReturnDTO
            {
                Success = false,
                Message = "",
                ResultObject = null
            };

            try
            {
                returnDTO.ResultObject = await _userRepository.GetUserByIdAsync(pIdUser);
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

        public async Task<ReturnDTO> InsertUserService(User pUser)
        {
            ReturnDTO returnDTO = new ReturnDTO
            {
                Success = false,
                Message = "",
                ResultObject = null
            };
            try
            {
                await _userRepository.CreateUser(pUser);
                returnDTO.Success = true;
                returnDTO.Message = "OK";
                returnDTO.ResultObject = pUser;

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


    }
}
