using System.ComponentModel.DataAnnotations;

namespace HinweigeberRestApi.Areas.Massnahmen.Models
{
    public class MassnahmeAddDTO
    {
		public string Beschreibung { get; set; }
		[StringLength(10)]
		public string Code { get; set; }
		public string CreateDate { get; set; }
	}
}
