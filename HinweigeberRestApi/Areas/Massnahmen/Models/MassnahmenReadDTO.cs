using HinweigeberRestApi.Areas.Meldungen.Models;
using HinweigeberRestApi.Areas.WeitereInfos.Models;
using System.ComponentModel.DataAnnotations;

namespace HinweigeberRestApi.Areas.Massnahmen.Models
{
    public class MassnahmenReadDTO
    {
        public int Id { get; set; }
        [StringLength(1000)]
        public string Beschreibung { get; set; }
        [StringLength(10)]
        public string Code { get; set; }
        public string CreateDate { get; set; }
        public List<MeldungenReadDTO> Meldungen { get; set; }
        public WeitereInfosReadDTO WeitereInfo { get; set; }
    }
}
