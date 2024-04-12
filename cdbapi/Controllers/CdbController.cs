using cdbapi.Models;
using cdbapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace cdbapi.Controllers;

[ApiController]
[Route("app/[controller]")]
public class CdbController : ControllerBase
{

    private readonly ILogger<CdbController> _logger;
    private ICdbService _cdbService;
    private IImpostoService _impostoService;
    public CdbController(ILogger<CdbController> logger, ICdbService cdbService, IImpostoService impostoService)
    {
        _logger = logger;
        _cdbService = cdbService;
        _impostoService = impostoService;
    }


    [HttpPost(Name = "Simulador")]
    public ActionResult<Cdb> Simulador(Cdb request)
    {
        if (request == null)
        {
            return BadRequest("Dados de entrada inválidos.");
        }

        if (request.ValorInvestido <= 0 || request.PrazoEmMeses <= 1)
        {
            return BadRequest("Valor monetário positivo e duração em meses maior que 1 são necessários.");
        }
        Aliquotas alq = new Aliquotas();
        request.ValorBruto = _cdbService.CalcularValorBruto(request.ValorInvestido, request.PrazoEmMeses);
        request.ValorImposto = _impostoService.CalcularValorImposto(request.ValorBruto, request.PrazoEmMeses);
        request.ValorLiquido = _cdbService.CalcularValorLiquido(request.ValorBruto, request.ValorImposto);
        request.Aliquota = alq.ObterAliquota(request.PrazoEmMeses);
        return request;
    }
}
