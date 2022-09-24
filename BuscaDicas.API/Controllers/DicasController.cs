using BuscaDicas.Modelo;
using BuscaDicasNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuscaDicas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DicasController : ControllerBase
    {

        private readonly Idicas _dicas;

        public DicasController(Idicas dicas)
        {
            _dicas = dicas;
        }

        [HttpPost]
        public async Task IncluirDica(DicasModel dicasModel)
        {
           await _dicas.IncluirDicas(dicasModel);
        }


    }
}
