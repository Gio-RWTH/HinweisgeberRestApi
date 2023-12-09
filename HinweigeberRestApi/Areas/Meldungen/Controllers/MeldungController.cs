using HinweigeberRestApi.Areas.Massnahmen.Models;
using HinweigeberRestApi.Areas.Meldungen.Models;
using HinweigeberRestApi.Areas.WeitereInfos.Models;
using HinweigeberRestApi.Services.MeldungenService;
using Microsoft.AspNetCore.Mvc;

namespace HinweigeberRestApi.Areas.Meldungen.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class MeldungController : ControllerBase
	{
		private readonly IMeldungenService _meldungenService;
		public MeldungController(IMeldungenService meldungenService)
		{
			_meldungenService = meldungenService;
		}

		[HttpGet]
		public async Task<IActionResult> GetMeldungen()
		{
			var result = await _meldungenService.GetMeldungen();
			if (!result.IsSuccess)
				return BadRequest(result.ErrorMessage);
			return Ok(result.Result);
		}

		[HttpGet]
		public async Task<IActionResult> GetMeldungById(string code)
		{
			var result = await _meldungenService.GetMeldungById(code);
			if (!result.IsSuccess)
				return BadRequest(result.ErrorMessage);
			return Ok(result.Result);
		}

		[HttpPost]
		public async Task<IActionResult> AddMeldung([FromBody] MeldungenAddDTO model)
		{
			var result = await _meldungenService.AddMeldung(model);
			if (!result.IsSuccess)
				return BadRequest(result.ErrorMessage);
			return Ok(result.Result);
		}

		[HttpPost]
		public async Task<IActionResult> AddMassnahmeZuMeldung([FromBody] MassnahmeAddDTO model)
		{
			var result = await _meldungenService.AddMassnahmeZuMeldung(model);
			if (!result.IsSuccess)
				return BadRequest(result.ErrorMessage);
			return Ok(result.Result);
		}

		[HttpPost]
		public async Task<IActionResult> AddWeitereInfoZuMassnahme([FromBody] WeitereInfoAddDTO model)
		{
			var result = await _meldungenService.AddWeitereInfoZuMassnahme(model);
			if (!result.IsSuccess)
				return BadRequest(result.ErrorMessage);
			return Ok(result.Result);
		}

	}
}
