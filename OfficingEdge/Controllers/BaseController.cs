using CollectCoModels.Response;
using Microsoft.AspNetCore.Mvc;
using OfficeModels.Responses;
using OfficeServices.Log;
using System.Net;

namespace CollectCoRepositry.Controllers
{
    public class BaseController : ControllerBase
    {
        private ResponseDto responseDto;
        public BaseController()
        {
            responseDto = new();
        }

        protected ActionResult<ResponseDto> GetResponse(Response response)
        {
            if (response.StatusCode == HttpStatusCode.OK)
            {
                responseDto.Result = response;
                responseDto.DisplayMessage = response.Message;
                
				return StatusCode((int)response.StatusCode, responseDto);
            }
            else if (response.StatusCode != HttpStatusCode.OK)
            {
                responseDto.IsSuccess = false;
                responseDto.ErrorMEssages = response.ErrorMessages;
                
                 
			
                return StatusCode((int)response.StatusCode, responseDto);
            }

            return responseDto;
        }
       
    }
}
