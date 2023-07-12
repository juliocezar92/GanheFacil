using GanheFacil.Service;
using Microsoft.AspNetCore.Mvc;

[Route("api/ganhefacil")]
[ApiController]
public class GanheFacilController : ControllerBase
{
    private readonly GanheFacilService _ganhefacilService;

    public GanheFacilController(GanheFacilService ganhefacilService)
    {
        _ganhefacilService = ganhefacilService;
    }

    [HttpPost("coletar-resultados")]
    public async Task<IActionResult> ColetarERegistrarResultados()
    {
        bool resultado = await _ganhefacilService.ColetarERegistrarResultados();

        if (resultado)
        {
            return Ok("Resultados coletados e registrados com sucesso.");
        }
        else
        {
            return StatusCode(500, "Ocorreu um erro ao coletar e registrar os resultados.");
        }
    }
}


