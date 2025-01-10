using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBAPI.Data
{
    [Table("GopY")]
    public class GopY
    {
        [Key]
        [StringLength(7)]
        public string MaGY {  get; set; }
        public string NoiDung {  get; set; }
        public DateTime NgayTao { get; set; }
        [ForeignKey("DonThue")]
        [StringLength(7)]
        public string MaDT {  get; set; }
        public DonThue DonThue { get; set; }
    }
}
