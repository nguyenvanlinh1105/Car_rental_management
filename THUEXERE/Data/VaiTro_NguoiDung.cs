using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBAPI.Data
{
    [Table("VaiTro_NguoiDung")]
    public class VaiTro_NguoiDung
    {
        [ForeignKey("VaiTro")]
        [StringLength(7)]
        public string MaVT {  get; set; }
        public VaiTro VaiTro { get; set; }

        [ForeignKey("NguoiDung")]
        [StringLength(7)]
        public string MaND {  get; set; }
        public NguoiDung NguoiDung { get; set; }

        

    }
}
