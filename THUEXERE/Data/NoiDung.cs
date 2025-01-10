using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBAPI.Data
{
    [Table("NoiDung")]
    public class NoiDung
    {
        [Key]
        [StringLength(7)]
        public string MaNoiDung {  get; set; }
        [ForeignKey("BaiViet")]
        [StringLength(7)]
        public string MaBV {  get; set; }
        public BaiViet BaiViet { get; set; }
        public string TieuDe {  get; set; }
        public string noiDung {  get; set; }
        public ICollection<AnhNoiDung> AnhNoiDungs { get; set; }

    }
}
