using System.ComponentModel.DataAnnotations;

namespace HinweigeberRestApi.Data
{
    public class Weitereinfo
    {
        public int Id { get; set; }
        [StringLength(10)]
        public string Code { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
