using System.ComponentModel.DataAnnotations;

namespace HinweigeberRestApi.Areas.Meldungen.Models
{
    public class MeldungenAddDTO
    {
        public string Beschreibung { get; set; }
        public string CreateDate { get; set; }
        public bool isFinished { get; set; } = false;
		public int PartnerId { get; set; }
    }
}
