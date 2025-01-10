using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBAPI.Data
{
    [Table("VaiTro")]
    public class VaiTro
    {
        [Key]
        [StringLength(7)]
        public string MaVT {  get; set; }
        public string TenVT {  get; set; }
        public string MoTa { get; set; }
    }
}
