using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBAPI.Data
{
    [Table("LoaiXe")]
    public class LoaiXe
    {
      
        public LoaiXe() { }
        [Key]
        [StringLength(7)]
        public string IdLoaiXe { set; get; }
        [StringLength(255)]
        public string loaiXe { set; get;}

       public ICollection<Xe> Xes { get; set; }

    }
}
