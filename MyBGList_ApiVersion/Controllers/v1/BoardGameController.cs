using Comprehensive_Grasp_Api.DTO;
using Comprehensive_Grasp_Api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using MyBGList_ApiVersion.DTO.v2;

namespace Comprehensive_Grasp_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardGameController : ControllerBase
    {
        public BoardGameController()
        {
              
        }

        [HttpGet(Name = "get-board-game")]
        [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 60)]
        [Route("v{Version:apiVersion}/[controller]")]
        [ApiVersion("1.0")]
        public DTO.RestDTO<Card[]> Get()
        {
            return new DTO.RestDTO<Card[]>()
            {
                Data = new Card[]
                {
                    new Card()
                    {
                        Id = "1",
                        Name = "fgdhj",
                    }, 
                    new Card()
                    {
                        Id = "1",
                        Name = "fgdhj",
                    }, 
                    new Card()
                    {
                        Id = "1",
                        Name = "fgdhj",
                    },
                },
                Links = new List<DTO.LinkDTO>()
                {
                    new DTO.LinkDTO(Url.Action(null, "BoardGame", null, Request.Scheme)!, "self", "Get"),
                }
               
            };
           
        }
    }
}
