using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBAPI.Data
{
    [Table("DanhMucXe")]
    public class DanhMucXe
    {
        [Key]
        [StringLength(7)]
        public string IdDanhMuc { set; get; }
        [StringLength(255)]
        public string TenXe { set; get; }
        public ICollection<Xe> Xes { get; set; }
    }
}
