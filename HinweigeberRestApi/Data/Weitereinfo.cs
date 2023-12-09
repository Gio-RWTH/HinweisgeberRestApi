using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HinweigeberRestApi.Data
{
    public class Weitereinfo
    {
        public int Id { get; set; }
        [StringLength(10)]
        public string Code { get; set; }
        public DateTime CreateDate { get; set; }
		[StringLength(1000)]
		public string Beschreibung { get; set; }
		//[ForeignKey(nameof(Meldung))]
		//public int MeldungId { get; set; }
		//public virtual Meldung Meldung { get; set; }

		[ForeignKey("Masshahme")]
		public int MassnahmeId { get; set; }
		public virtual Massnahme Massnahme { get; set; }
	}
}
