using System.ComponentModel.DataAnnotations;

namespace HinweigeberRestApi.Data
{
    public class Massnahme
    {
        public Massnahme()
        {
            Meldungen = new HashSet<Meldung>();
        }
        public int Id { get; set; }
        [StringLength(1000)]
        public string Beschreibung { get; set; }
        [StringLength(10)]
        public string Code { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual ICollection<Meldung> Meldungen { get; set; }
    }
}
