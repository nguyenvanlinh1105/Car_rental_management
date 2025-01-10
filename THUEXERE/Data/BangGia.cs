using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBAPI.Data
{
    [Table("BangGia")]
    public class BangGia
    {
        [Key]
        [StringLength(7)]
        public string MaBangGia { set; get; }
        [ForeignKey("Xe")]
        [StringLength(7)]
        public string MaXe { set; get; }
        public Xe Xe {  set; get; }
        public float Gia1Den5 {  set; get; }
        public float Gia6Den10 { set; get; }
        public float Gia11Den15 {  set; get; }
        public float Gia16Den20 { set; get; }
        public float Gia21Den30 {  set; get; }
        public float Gia31 {  set; get; }
        public string MoTa { set; get; }
        public DateTime NgayCapNhat { get; set; }
    }
}
