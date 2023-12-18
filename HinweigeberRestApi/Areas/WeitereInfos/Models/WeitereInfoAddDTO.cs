using System.ComponentModel.DataAnnotations;

namespace HinweigeberRestApi.Areas.WeitereInfos.Models
{
	public class WeitereInfoAddDTO
	{
		[StringLength(10)]
		public string Code { get; set; }
		[StringLength(1000)]
		public string Beschreibung { get; set; }
		public int MassnahmeId { get; set; }
	}
}
