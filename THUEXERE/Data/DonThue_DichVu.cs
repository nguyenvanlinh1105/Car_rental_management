using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBAPI.Data
{
    [Table("DonThue_DichVu")]
    public class DonThue_DichVu
    {
        [ForeignKey("DonThue")]
        [StringLength(7)]
        public string MaDT { get; set; }
        public DonThue DonThue { get; set; }
        [ForeignKey("DichVu")]
        [StringLength(7)]
        public string MaDV {  get; set; }
        public DichVu DichVu { get; set; }

    }
}
