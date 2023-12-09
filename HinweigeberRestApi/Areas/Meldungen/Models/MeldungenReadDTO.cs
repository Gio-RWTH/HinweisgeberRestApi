using HinweigeberRestApi.Areas.Massnahmen.Models;
using HinweigeberRestApi.Areas.WeitereInfos.Models;
using HinweigeberRestApi.Data;
using System.ComponentModel.DataAnnotations;

namespace HinweigeberRestApi.Areas.Meldungen.Models
{
    public class MeldungenReadDTO
    {
        public int Id { get; set; }
        [StringLength(1000)]
        public string Beschreibung { get; set; }
        [StringLength(10)]
        public string Code { get; set; }
        public string CreateDate { get; set; }
		public bool isFinished { get; set; } = false;
		public int PartnerId { get; set; }
        public List<MassnahmenReadDTO> Massnahmen { get; set; }
	}
}
