using System.ComponentModel.DataAnnotations.Schema;

namespace HinweigeberRestApi.Data.ContextFactory.MainContextDB
{
	public class Filiale
	{
		public int Id { get; set; }
		public int FilialNr { get; set; }
		public string AnsichtName { get; set; }
		public string Email { get; set; }

		[ForeignKey(nameof(Partner))]
		public Guid PartnerId { get; set; }
		public virtual Partner Partner { get; set; }
	}
}
