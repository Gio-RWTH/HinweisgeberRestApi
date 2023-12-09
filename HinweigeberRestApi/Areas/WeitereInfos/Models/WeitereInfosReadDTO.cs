using HinweigeberRestApi.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HinweigeberRestApi.Areas.WeitereInfos.Models
{
	public class WeitereInfosReadDTO
	{
		public int Id { get; set; }
		[StringLength(10)]
		public string Code { get; set; }
		public string CreateDate { get; set; }
		[StringLength(1000)]
		public string Beschreibung { get; set; }
	}
}
