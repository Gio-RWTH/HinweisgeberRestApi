namespace HinweigeberRestApi.Areas.Meldungen.Models
{
	public class MeldungUpdateDTO
	{
		public int Id { get; set; }
		public string Beschreibung { get; set; }
		public bool isFinished { get; set; } = false;
	}
}
