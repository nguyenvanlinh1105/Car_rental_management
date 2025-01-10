using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace THUEXERE.Migrations
{
    /// <inheritdoc />
    public partial class MapDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DanhMucXe",
                columns: table => new
                {
                    IdDanhMuc = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    TenXe = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucXe", x => x.IdDanhMuc);
                });

            migrationBuilder.CreateTable(
                name: "DichVu",
                columns: table => new
                {
                    MaDV = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    TenDV = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnhMinhHoaUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TinhTrang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DonGia = table.Column<float>(type: "real", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    HinhThuc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DonVi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Loai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DichVu", x => x.MaDV);
                });

            migrationBuilder.CreateTable(
                name: "LoaiXe",
                columns: table => new
                {
                    IdLoaiXe = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    loaiXe = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiXe", x => x.IdLoaiXe);
                });

            migrationBuilder.CreateTable(
                name: "MauXe",
                columns: table => new
                {
                    IdMauXe = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    mauXe = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MauXe", x => x.IdMauXe);
                });

            migrationBuilder.CreateTable(
                name: "NguoiDung",
                columns: table => new
                {
                    MaND = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CCCD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GioiTinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TinhTrang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnhDaiDienUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDung", x => x.MaND);
                });

            migrationBuilder.CreateTable(
                name: "VaiTro",
                columns: table => new
                {
                    MaVT = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    TenVT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaiTro", x => x.MaVT);
                });

            migrationBuilder.CreateTable(
                name: "Xe",
                columns: table => new
                {
                    MaXe = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    IdDanhMuc = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    IdLoaiXe = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    IdMauXe = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    TinhTrang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoKhung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KhoiLuong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamSX = table.Column<int>(type: "int", nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BienSo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CongSuat = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Xe", x => x.MaXe);
                    table.ForeignKey(
                        name: "FK_Xe_DanhMucXe_IdDanhMuc",
                        column: x => x.IdDanhMuc,
                        principalTable: "DanhMucXe",
                        principalColumn: "IdDanhMuc");
                    table.ForeignKey(
                        name: "FK_Xe_LoaiXe_IdLoaiXe",
                        column: x => x.IdLoaiXe,
                        principalTable: "LoaiXe",
                        principalColumn: "IdLoaiXe");
                    table.ForeignKey(
                        name: "FK_Xe_MauXe_IdMauXe",
                        column: x => x.IdMauXe,
                        principalTable: "MauXe",
                        principalColumn: "IdMauXe");
                });

            migrationBuilder.CreateTable(
                name: "BaiViet",
                columns: table => new
                {
                    MaBV = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    MaND = table.Column<string>(type: "nvarchar(7)", nullable: true),
                    TieuDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoDau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TinhTrang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DanhMuc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnhMinhHoaUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayDang = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaiViet", x => x.MaBV);
                    table.ForeignKey(
                        name: "FK_BaiViet_NguoiDung_MaND",
                        column: x => x.MaND,
                        principalTable: "NguoiDung",
                        principalColumn: "MaND");
                });

            migrationBuilder.CreateTable(
                name: "DonThue",
                columns: table => new
                {
                    MaDT = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    MaKH = table.Column<string>(type: "nvarchar(7)", nullable: true),
                    MaNVHT = table.Column<string>(type: "nvarchar(7)", nullable: true),
                    PTThanhToan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TinhTrangDon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TongTien = table.Column<float>(type: "real", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonThue", x => x.MaDT);
                    table.ForeignKey(
                        name: "FK_DonThue_NguoiDung_MaKH",
                        column: x => x.MaKH,
                        principalTable: "NguoiDung",
                        principalColumn: "MaND");
                    table.ForeignKey(
                        name: "FK_DonThue_NguoiDung_MaNVHT",
                        column: x => x.MaNVHT,
                        principalTable: "NguoiDung",
                        principalColumn: "MaND");
                });

            migrationBuilder.CreateTable(
                name: "VaiTro_NguoiDung",
                columns: table => new
                {
                    MaVT = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    MaND = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaiTro_NguoiDung", x => new { x.MaVT, x.MaND });
                    table.ForeignKey(
                        name: "FK_VaiTro_NguoiDung_NguoiDung_MaND",
                        column: x => x.MaND,
                        principalTable: "NguoiDung",
                        principalColumn: "MaND",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VaiTro_NguoiDung_VaiTro_MaVT",
                        column: x => x.MaVT,
                        principalTable: "VaiTro",
                        principalColumn: "MaVT",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BangGia",
                columns: table => new
                {
                    MaBangGia = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    MaXe = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    Gia1Den5 = table.Column<float>(type: "real", nullable: false),
                    Gia6Den10 = table.Column<float>(type: "real", nullable: false),
                    Gia11Den15 = table.Column<float>(type: "real", nullable: false),
                    Gia16Den20 = table.Column<float>(type: "real", nullable: false),
                    Gia21Den30 = table.Column<float>(type: "real", nullable: false),
                    Gia31 = table.Column<float>(type: "real", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BangGia", x => x.MaBangGia);
                    table.ForeignKey(
                        name: "FK_BangGia_Xe_MaXe",
                        column: x => x.MaXe,
                        principalTable: "Xe",
                        principalColumn: "MaXe");
                });

            migrationBuilder.CreateTable(
                name: "NoiDung",
                columns: table => new
                {
                    MaNoiDung = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    MaBV = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    TieuDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    noiDung = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoiDung", x => x.MaNoiDung);
                    table.ForeignKey(
                        name: "FK_NoiDung_BaiViet_MaBV",
                        column: x => x.MaBV,
                        principalTable: "BaiViet",
                        principalColumn: "MaBV");
                });

            migrationBuilder.CreateTable(
                name: "ChiTietDonThue",
                columns: table => new
                {
                    MaCTDT = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    MaDT = table.Column<string>(type: "nvarchar(7)", nullable: true),
                    MaXe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayNhan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayTra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TienCocGiuXe = table.Column<float>(type: "real", nullable: false),
                    TienCoc = table.Column<float>(type: "real", nullable: false),
                    ThanhTien = table.Column<float>(type: "real", nullable: false),
                    PTThanhToan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TinhTrangBanGiao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnhMinhChungURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoiNhan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoiTra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GiaHan = table.Column<int>(type: "int", nullable: false),
                    NgayGiaHan = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietDonThue", x => x.MaCTDT);
                    table.ForeignKey(
                        name: "FK_ChiTietDonThue_DonThue_MaDT",
                        column: x => x.MaDT,
                        principalTable: "DonThue",
                        principalColumn: "MaDT");
                });

            migrationBuilder.CreateTable(
                name: "DonThue_DichVu",
                columns: table => new
                {
                    MaDT = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    MaDV = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonThue_DichVu", x => new { x.MaDV, x.MaDT });
                    table.ForeignKey(
                        name: "FK_DonThue_DichVu_DichVu_MaDV",
                        column: x => x.MaDV,
                        principalTable: "DichVu",
                        principalColumn: "MaDV",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DonThue_DichVu_DonThue_MaDT",
                        column: x => x.MaDT,
                        principalTable: "DonThue",
                        principalColumn: "MaDT",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GopY",
                columns: table => new
                {
                    MaGY = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaDT = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GopY", x => x.MaGY);
                    table.ForeignKey(
                        name: "FK_GopY_DonThue_MaDT",
                        column: x => x.MaDT,
                        principalTable: "DonThue",
                        principalColumn: "MaDT");
                });

            migrationBuilder.CreateTable(
                name: "AnhNoiDung",
                columns: table => new
                {
                    MaAnh = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    MaNoiDung = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    AnhUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnhNoiDung", x => x.MaAnh);
                    table.ForeignKey(
                        name: "FK_AnhNoiDung_NoiDung_MaNoiDung",
                        column: x => x.MaNoiDung,
                        principalTable: "NoiDung",
                        principalColumn: "MaNoiDung");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnhNoiDung_MaNoiDung",
                table: "AnhNoiDung",
                column: "MaNoiDung");

            migrationBuilder.CreateIndex(
                name: "IX_BaiViet_MaND",
                table: "BaiViet",
                column: "MaND");

            migrationBuilder.CreateIndex(
                name: "IX_BangGia_MaXe",
                table: "BangGia",
                column: "MaXe");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDonThue_MaDT",
                table: "ChiTietDonThue",
                column: "MaDT");

            migrationBuilder.CreateIndex(
                name: "IX_DonThue_MaKH",
                table: "DonThue",
                column: "MaKH");

            migrationBuilder.CreateIndex(
                name: "IX_DonThue_MaNVHT",
                table: "DonThue",
                column: "MaNVHT");

            migrationBuilder.CreateIndex(
                name: "IX_DonThue_DichVu_MaDT",
                table: "DonThue_DichVu",
                column: "MaDT");

            migrationBuilder.CreateIndex(
                name: "IX_GopY_MaDT",
                table: "GopY",
                column: "MaDT");

            migrationBuilder.CreateIndex(
                name: "IX_NoiDung_MaBV",
                table: "NoiDung",
                column: "MaBV");

            migrationBuilder.CreateIndex(
                name: "IX_VaiTro_NguoiDung_MaND",
                table: "VaiTro_NguoiDung",
                column: "MaND");

            migrationBuilder.CreateIndex(
                name: "IX_Xe_IdDanhMuc",
                table: "Xe",
                column: "IdDanhMuc");

            migrationBuilder.CreateIndex(
                name: "IX_Xe_IdLoaiXe",
                table: "Xe",
                column: "IdLoaiXe");

            migrationBuilder.CreateIndex(
                name: "IX_Xe_IdMauXe",
                table: "Xe",
                column: "IdMauXe");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnhNoiDung");

            migrationBuilder.DropTable(
                name: "BangGia");

            migrationBuilder.DropTable(
                name: "ChiTietDonThue");

            migrationBuilder.DropTable(
                name: "DonThue_DichVu");

            migrationBuilder.DropTable(
                name: "GopY");

            migrationBuilder.DropTable(
                name: "VaiTro_NguoiDung");

            migrationBuilder.DropTable(
                name: "NoiDung");

            migrationBuilder.DropTable(
                name: "Xe");

            migrationBuilder.DropTable(
                name: "DichVu");

            migrationBuilder.DropTable(
                name: "DonThue");

            migrationBuilder.DropTable(
                name: "VaiTro");

            migrationBuilder.DropTable(
                name: "BaiViet");

            migrationBuilder.DropTable(
                name: "DanhMucXe");

            migrationBuilder.DropTable(
                name: "LoaiXe");

            migrationBuilder.DropTable(
                name: "MauXe");

            migrationBuilder.DropTable(
                name: "NguoiDung");
        }
    }
}
