using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBAPI.Data
{
    [Table("AnhNoiDung")]
    public class AnhNoiDung
    {
        [Key]
        [StringLength(7)]
        public string MaAnh { get; set; }
        [ForeignKey("NoiDung")]
        [StringLength(7)]
        public string MaNoiDung { get; set; }
        public NoiDung NoiDung { get; set; }
        public string AnhUrl {  get; set; }
        public string MoTa {  get; set; }

    }
}
