using AutoMapper;
using HinweigeberRestApi.Areas.Massnahmen.Models;
using HinweigeberRestApi.Areas.Meldungen.Models;
using HinweigeberRestApi.Areas.WeitereInfos.Models;
using HinweigeberRestApi.Data;
using HinweigeberRestApi.Repository;
using HinweigeberRestApi.SharedModels;
using HinweigeberRestApi.SharedModels.RequestsParameter.Paging;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace HinweigeberRestApi.Services.MeldungenService
{
    public class MeldungenService : IMeldungenService
    {
        private readonly IGenericRepository<Meldung> _repositoryContext;
        private readonly IGenericRepository<Massnahme> _repositoryMassnahmeContext;
        private readonly IGenericRepository<Weitereinfo> _repositoryWeitereInfoContext;
		private readonly IMapper _mapper;
        public MeldungenService(IGenericRepository<Meldung> repositoryContext, IGenericRepository<Massnahme> repositoryMassnahmeContext,
			IGenericRepository<Weitereinfo> repositoryWeitereInfoContext, IMapper mapper)
        {
            _repositoryContext = repositoryContext;
			_repositoryMassnahmeContext = repositoryMassnahmeContext;
			_repositoryWeitereInfoContext = repositoryWeitereInfoContext;
			_mapper = mapper;
        }

		public async Task<ReturnResult<MeldungenReadDTO>> AddMeldung(MeldungenAddDTO model)
		{
			var result = new ReturnResult<MeldungenReadDTO>();
			try
			{
				var meldung = _mapper.Map<Meldung>(model);
				meldung.CreateDate = DateTime.Now;

				var tmpCode = GenerateRandomDigits();
				var tmpMeldung = await _repositoryContext.Get(x => x.Code == tmpCode);


				while (tmpMeldung != null)
				{
					tmpCode = GenerateRandomDigits();
					tmpMeldung = await _repositoryContext.Get(x => x.Code == tmpCode);
				}

				meldung.Code = tmpCode;
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

		public async Task<OperationResult> UpdateMeldung(MeldungUpdateDTO model)
		{

			var result = new OperationResult();
			try
			{
				var meldung = await _repositoryContext.Get(p => p.Id == model.Id);
				if (meldung != null)
				{
					meldung.Beschreibung = model.Beschreibung;
					meldung.isFinished = model.isFinished;
					//var meldung = _mapper.Map<Meldung>(model);
					await _repositoryContext.Update(meldung);
				}
			}
			catch (Exception ex)
			{
				result.IsSuccess = false;
				result.ErrorMessage = ex.Message;
			}
			return result;
		}

		public async Task<ReturnResult<MassnahmenReadDTO>> AddMassnahmeZuMeldung(MassnahmeAddDTO model)
		{
			var result = new ReturnResult<MassnahmenReadDTO>();
			try
			{
				var meldung = await _repositoryContext.Get(x => x.Code == model.Code);
				var massnahme = _mapper.Map<Massnahme>(model);
				massnahme.Code = model.Code;
				massnahme.CreateDate = DateTime.Now;

				meldung.Massnahmen.Add(massnahme);
				await _repositoryContext.Update(meldung);

				var tmpMassnahme = await _repositoryMassnahmeContext.GetAll(x => x.Code == model.Code);

				if (tmpMassnahme.OrderByDescending(p => p.CreateDate).FirstOrDefault() != null)
				{
					result.Result = _mapper.Map<MassnahmenReadDTO>(tmpMassnahme.OrderByDescending(p => p.CreateDate).FirstOrDefault());
				}
			}
			catch (Exception ex)
			{
				result.IsSuccess = false;
				result.ErrorMessage = ex.Message;
			}
			return result;
		}

		public async Task<ReturnResult<WeitereInfosReadDTO>> AddWeitereInfoZuMassnahme(WeitereInfoAddDTO model)
		{
			var result = new ReturnResult<WeitereInfosReadDTO>();
			try
			{
				var massnahme = await _repositoryMassnahmeContext.Get(x => x.Id == model.MassnahmeId);
				if (massnahme.WeitereInfo == null)
				{
					var weitereInfo = _mapper.Map<Weitereinfo>(model);
					massnahme.WeitereInfo = weitereInfo;
					massnahme.WeitereInfo.CreateDate = DateTime.Now;

					await _repositoryMassnahmeContext.Update(massnahme);

					var tmpWeitereInfo = await _repositoryWeitereInfoContext.GetAll(x => x.Code == model.Code);

					if (tmpWeitereInfo.OrderByDescending(p => p.CreateDate).FirstOrDefault() != null)
					{
						result.Result = _mapper.Map<WeitereInfosReadDTO>(tmpWeitereInfo.OrderByDescending(p => p.CreateDate).FirstOrDefault());
					}
				}
				else
				{
					result.ErrorMessage = "Info zu dieser Nachicht ist schon vorhanden ";
				}
			}
			catch (Exception ex)
			{
				result.IsSuccess = false;
				result.ErrorMessage = ex.Message;
			}
			return result;
		}

		public async Task<OperationResult> UpdateWeitereInfo(WeitereInfoUpdateDTO model)
		{

			var result = new OperationResult();
			try
			{


				var weitereinfo = await _repositoryWeitereInfoContext.Get(p => p.Id == model.Id);
				if (weitereinfo != null)
				{
					weitereinfo.Beschreibung = model.Beschreibung;
					//var weitereinfo = _mapper.Map<Weitereinfo>(model);
					await _repositoryWeitereInfoContext.Update(weitereinfo);
				}

			}
			catch (Exception ex)
			{
				result.IsSuccess = false;
				result.ErrorMessage = ex.Message;
			}
			return result;
		}

		private string GenerateRandomDigits()
		{
			// Initialize a random number generator
			Random random = new Random();
			// Generate a random string of the specified length with only digits
			char[] digits = new char[10];
			for (int i = 0; i < 10; i++)
			{
				digits[i] = (char)('0' + random.Next(10));
			}
 
			return new string(digits);
		}

		public async Task<ReturnResult<IEnumerable<MeldungenReadDTO>>> GetMeldungen()
		{
			var result = new ReturnResult<IEnumerable<MeldungenReadDTO>>()
			{
				Result = new List<MeldungenReadDTO>()
			};
			try
			{
				var allMeldungen = await _repositoryContext.GetAll1(orderBy: x => x.OrderByDescending(p => p.CreateDate), includes: x => x.Massnahmen);

				var tmpModel = _mapper.Map<List<MeldungenReadDTO>>(allMeldungen); ;

				foreach (var item in tmpModel)
				{
					for (int i = 0; i < item.Massnahmen.Count; i++)
					{
						var tmp = await _repositoryWeitereInfoContext.Get(x => x.MassnahmeId == item.Massnahmen.ToList()[i].Id);
						if (tmp != null)
						{
							item.Massnahmen.ToList()[i].WeitereInfo = _mapper.Map<WeitereInfosReadDTO>(tmp);
						}
					}
				}


				result.Result = tmpModel;
				result.IsSuccess = true;
			}
			catch (Exception ex)
			{
				result.IsSuccess = false;
				result.ErrorMessage = ex.Message;
			}
			return result;
		}

		public async Task<ReturnResult<MeldungenReadDTO>> GetMeldungById(string code)
		{
			var result = new ReturnResult<MeldungenReadDTO>()
			{
				Result = new MeldungenReadDTO()
			};
			var meldung = await _repositoryContext.Get(x => x.Code == code, x => x.Massnahmen);

			if (meldung == null)
			{
				result.IsSuccess = false;
				result.ErrorMessage = $"There is no record for this ID={code}";

				return result;
			}
			try
			{

				var tmpModel = _mapper.Map<MeldungenReadDTO>(meldung);

				for (int i = 0; i < tmpModel.Massnahmen.Count; i++)
				{
					var tmp = await _repositoryWeitereInfoContext.Get(x => x.MassnahmeId == tmpModel.Massnahmen.ToList()[i].Id);
					if (tmp != null)
					{
						tmpModel.Massnahmen.ToList()[i].WeitereInfo = _mapper.Map<WeitereInfosReadDTO>(tmp);
					}
				}

				result.Result = tmpModel;
				result.IsSuccess = true;
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
