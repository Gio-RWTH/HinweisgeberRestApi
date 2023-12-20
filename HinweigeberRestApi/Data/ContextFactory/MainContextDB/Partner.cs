using System.ComponentModel.DataAnnotations;

namespace HinweigeberRestApi.Data.ContextFactory.MainContextDB
{
	public class Partner
	{
		public Partner()
		{
			Filiale = new HashSet<Filiale>();
		}

		public Guid Id { get; set; } = Guid.Empty;
		[StringLength(25)]
		public string Name { get; set; }
		public byte[] ConStr { get; set; }
		public bool Active { get; set; }
		public virtual ICollection<Filiale> Filiale { get; set; }
	}
}
