using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBAPI.Data
{
    [Table("MauXe")]
    public class MauXe
    {
        [Key]
        [StringLength(7)]
        public string IdMauXe { set; get; }
        [StringLength(255)]
        public string mauXe { set; get; }
        public ICollection<Xe> Xes { get; set; }
    }
}
