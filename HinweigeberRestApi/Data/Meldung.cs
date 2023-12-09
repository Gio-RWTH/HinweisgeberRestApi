using System.ComponentModel.DataAnnotations;

namespace HinweigeberRestApi.Data
{
    public class Meldung
    {
        public Meldung()
        {
            Massnahmen = new HashSet<Massnahme>();
            //Weitereinfos = new HashSet<Weitereinfo>();
        }
        public int Id { get; set; }
        [StringLength(1000)]
        public string Beschreibung { get; set; }
        [StringLength(10)]
        public string Code { get; set; }
        public DateTime CreateDate { get; set; }
        public bool isFinished { get; set; }
        public int PartnerId { get; set; }
        virtual public ICollection<Massnahme> Massnahmen { get; set; }
		//virtual public ICollection<Weitereinfo> Weitereinfos { get; set; }
	}
}
