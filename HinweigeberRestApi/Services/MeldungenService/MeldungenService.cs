using AutoMapper;
using HinweigeberRestApi.Areas.Meldungen.Models;
using HinweigeberRestApi.Data;
using HinweigeberRestApi.Repository;
using HinweigeberRestApi.SharedModels;

namespace HinweigeberRestApi.Services.MeldungenService
{
    public class MeldungenService : IMeldungenService
    {
        private readonly IGenericRepository<Meldung> _repositoryContext;
        private readonly IGenericRepository<Massnahme> _repositoryMassnahmeContext;
		private readonly IMapper _mapper;
        public MeldungenService(IGenericRepository<Meldung> repositoryContext, IGenericRepository<Massnahme> repositoryMassnahmeContext, IMapper mapper)
        {
            _repositoryContext = repositoryContext;
			_repositoryMassnahmeContext = repositoryMassnahmeContext;
			_mapper = mapper;
        }

		public async Task<ReturnResult<MeldungenReadDTO>> AddMeldung(MeldungenAddDTO model)
		{
			var result = new ReturnResult<MeldungenReadDTO>();
			try
			{
				var meldung = _mapper.Map<Meldung>(model);
				var meldungModel = await _repositoryContext.Insert(meldung);
				result.Result = _mapper.Map<MeldungenReadDTO>(meldungModel); ;
			}
			catch (Exception ex)
			{
				result.IsSuccess = false;
				result.ErrorMessage = ex.Message;
			}
			return result;
		}

		//public async Task<OperationResult> DeleteMeldung(int id)
		//{
		//	var result = new OperationResult();
		//	try
		//	{

		//		await _repositoryContext.Delete(id);

		//	}
		//	catch (Exception ex)
		//	{
		//		result.IsSuccess = false;
		//		result.ErrorMessage = ex.Message;

		//	}
		//	return result;
		//}

	}
}
