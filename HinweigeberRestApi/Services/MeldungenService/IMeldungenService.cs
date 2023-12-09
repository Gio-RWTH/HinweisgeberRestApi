using HinweigeberRestApi.Areas.Massnahmen.Models;
using HinweigeberRestApi.Areas.Meldungen.Models;
using HinweigeberRestApi.Areas.WeitereInfos.Models;
using HinweigeberRestApi.SharedModels;

namespace HinweigeberRestApi.Services.MeldungenService
{
    public interface IMeldungenService
    {
		Task<ReturnResult<MeldungenReadDTO>> AddMeldung(MeldungenAddDTO model);
		Task<ReturnResult<MassnahmenReadDTO>> AddMassnahmeZuMeldung(MassnahmeAddDTO model);
		Task<ReturnResult<IEnumerable<MeldungenReadDTO>>> GetMeldungen();
		Task<ReturnResult<MeldungenReadDTO>> GetMeldungById(string code);
		Task<ReturnResult<WeitereInfosReadDTO>> AddWeitereInfoZuMassnahme(WeitereInfoAddDTO model);
	}
}
