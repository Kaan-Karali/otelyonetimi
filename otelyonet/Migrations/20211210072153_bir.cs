using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace otelyonet.Migrations
{
    public partial class bir : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Birimler",
                columns: table => new
                {
                    BirimID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BirimAdı = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Birimler", x => x.BirimID);
                });

            migrationBuilder.CreateTable(
                name: "Cinsiyetler",
                columns: table => new
                {
                    CinsiyetID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CinsiyetAdı = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinsiyetler", x => x.CinsiyetID);
                });

            migrationBuilder.CreateTable(
                name: "DuşTipleri",
                columns: table => new
                {
                    DuşTipiID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DuşTipiAdı = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuşTipleri", x => x.DuşTipiID);
                });

            migrationBuilder.CreateTable(
                name: "Hizmetler",
                columns: table => new
                {
                    HizmetID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HizmetAdı = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Açıklama = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    ResimYolu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hizmetler", x => x.HizmetID);
                });

            migrationBuilder.CreateTable(
                name: "Kategoriler",
                columns: table => new
                {
                    KategoriID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAdı = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    BabaKategoriID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriler", x => x.KategoriID);
                    table.ForeignKey(
                        name: "FK_Kategoriler_Kategoriler_BabaKategoriID",
                        column: x => x.BabaKategoriID,
                        principalTable: "Kategoriler",
                        principalColumn: "KategoriID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Manzaralar",
                columns: table => new
                {
                    ManzaraID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManzaraAdı = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manzaralar", x => x.ManzaraID);
                });

            migrationBuilder.CreateTable(
                name: "MüşteriTipleri",
                columns: table => new
                {
                    MüşteriTipiID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MüşteriTipiAdı = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MüşteriTipleri", x => x.MüşteriTipiID);
                });

            migrationBuilder.CreateTable(
                name: "Odalar",
                columns: table => new
                {
                    OdaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OdaAdı = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    KatNO = table.Column<int>(type: "int", nullable: false),
                    YatakSayısı = table.Column<int>(type: "int", nullable: false),
                    OdaFiyatı = table.Column<decimal>(type: "decimal(8,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odalar", x => x.OdaID);
                });

            migrationBuilder.CreateTable(
                name: "OdaTipleri",
                columns: table => new
                {
                    OdaTipiID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OdaTipiAdı = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdaTipleri", x => x.OdaTipiID);
                });

            migrationBuilder.CreateTable(
                name: "ÖdemeTipleri",
                columns: table => new
                {
                    ÖdemeTipiID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ÖdemeTipiAdı = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ÖdemeTipleri", x => x.ÖdemeTipiID);
                });

            migrationBuilder.CreateTable(
                name: "Roller",
                columns: table => new
                {
                    RolID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolAdı = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roller", x => x.RolID);
                });

            migrationBuilder.CreateTable(
                name: "Tesisler",
                columns: table => new
                {
                    TesisID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TesisAdı = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Açıklama = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tesisler", x => x.TesisID);
                });

            migrationBuilder.CreateTable(
                name: "Müşteriler",
                columns: table => new
                {
                    MüşteriID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MüşteriTamAdı = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    MüşteriSoyadi = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MobilNO = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CinsiyetID = table.Column<int>(type: "int", nullable: false),
                    MüşteriTipiID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Müşteriler", x => x.MüşteriID);
                    table.ForeignKey(
                        name: "FK_Müşteriler_Cinsiyetler_CinsiyetID",
                        column: x => x.CinsiyetID,
                        principalTable: "Cinsiyetler",
                        principalColumn: "CinsiyetID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Müşteriler_MüşteriTipleri_MüşteriTipiID",
                        column: x => x.MüşteriTipiID,
                        principalTable: "MüşteriTipleri",
                        principalColumn: "MüşteriTipiID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OdaResimleri",
                columns: table => new
                {
                    OdaResimID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OdaID = table.Column<int>(type: "int", nullable: false),
                    ResimYolu = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdaResimleri", x => x.OdaResimID);
                    table.ForeignKey(
                        name: "FK_OdaResimleri_Odalar_OdaID",
                        column: x => x.OdaID,
                        principalTable: "Odalar",
                        principalColumn: "OdaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OdaÖzellikleri",
                columns: table => new
                {
                    OdaÖzellikID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OdaID = table.Column<int>(type: "int", nullable: false),
                    ManzaraID = table.Column<int>(type: "int", nullable: false),
                    OdaTipiID = table.Column<int>(type: "int", nullable: false),
                    DuşTipiID = table.Column<int>(type: "int", nullable: false),
                    Açıklama = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdaÖzellikleri", x => x.OdaÖzellikID);
                    table.ForeignKey(
                        name: "FK_OdaÖzellikleri_DuşTipleri_DuşTipiID",
                        column: x => x.DuşTipiID,
                        principalTable: "DuşTipleri",
                        principalColumn: "DuşTipiID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OdaÖzellikleri_Manzaralar_ManzaraID",
                        column: x => x.ManzaraID,
                        principalTable: "Manzaralar",
                        principalColumn: "ManzaraID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OdaÖzellikleri_Odalar_OdaID",
                        column: x => x.OdaID,
                        principalTable: "Odalar",
                        principalColumn: "OdaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OdaÖzellikleri_OdaTipleri_OdaTipiID",
                        column: x => x.OdaTipiID,
                        principalTable: "OdaTipleri",
                        principalColumn: "OdaTipiID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kullanıcılar",
                columns: table => new
                {
                    KullanıcıID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EPosta = table.Column<string>(type: "nvarchar(52)", maxLength: 52, nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    RolID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanıcılar", x => x.KullanıcıID);
                    table.ForeignKey(
                        name: "FK_Kullanıcılar_Roller_RolID",
                        column: x => x.RolID,
                        principalTable: "Roller",
                        principalColumn: "RolID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rezervasyonlar",
                columns: table => new
                {
                    RezervasyonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MüşteriID = table.Column<int>(type: "int", nullable: false),
                    OdaID = table.Column<int>(type: "int", nullable: false),
                    ÖdemeTipiID = table.Column<int>(type: "int", nullable: false),
                    BasTarih = table.Column<DateTime>(type: "Date", nullable: false),
                    BitTarih = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervasyonlar", x => x.RezervasyonID);
                    table.ForeignKey(
                        name: "FK_Rezervasyonlar_Müşteriler_MüşteriID",
                        column: x => x.MüşteriID,
                        principalTable: "Müşteriler",
                        principalColumn: "MüşteriID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rezervasyonlar_Odalar_OdaID",
                        column: x => x.OdaID,
                        principalTable: "Odalar",
                        principalColumn: "OdaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rezervasyonlar_ÖdemeTipleri_ÖdemeTipiID",
                        column: x => x.ÖdemeTipiID,
                        principalTable: "ÖdemeTipleri",
                        principalColumn: "ÖdemeTipiID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profiller",
                columns: table => new
                {
                    ProfilID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullanıcıID = table.Column<int>(type: "int", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CepNO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EvNO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    İşNO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Meslek = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResimYolu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiller", x => x.ProfilID);
                    table.ForeignKey(
                        name: "FK_Profiller_Kullanıcılar_KullanıcıID",
                        column: x => x.KullanıcıID,
                        principalTable: "Kullanıcılar",
                        principalColumn: "KullanıcıID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Birimler",
                columns: new[] { "BirimID", "BirimAdı" },
                values: new object[,]
                {
                    { 1, "İnsan Kaynakları" },
                    { 2, "F&B" },
                    { 3, "Satın Alma" },
                    { 4, "Güvenlik" },
                    { 5, "House Keeping" }
                });

            migrationBuilder.InsertData(
                table: "Cinsiyetler",
                columns: new[] { "CinsiyetID", "CinsiyetAdı" },
                values: new object[,]
                {
                    { 1, "Erkek" },
                    { 2, "Kadın" }
                });

            migrationBuilder.InsertData(
                table: "DuşTipleri",
                columns: new[] { "DuşTipiID", "DuşTipiAdı" },
                values: new object[,]
                {
                    { 1, "Jakuzi" },
                    { 2, "Standart" },
                    { 3, "Küvet" }
                });

            migrationBuilder.InsertData(
                table: "Hizmetler",
                columns: new[] { "HizmetID", "Açıklama", "HizmetAdı", "ResimYolu" },
                values: new object[,]
                {
                    { 4, "gbbgf", "Masaj", "4.jpg" },
                    { 3, "Tenis,Basketbol,Futbol", "Spor Kompleksi", "3.jpg" },
                    { 1, " Tam olimpik kapalı havuz", "Kapalı Havuz", "1.jpg" },
                    { 2, " 24 saat 65 farklı çeşit ", "Açık Büfe", "2.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Manzaralar",
                columns: new[] { "ManzaraID", "ManzaraAdı" },
                values: new object[,]
                {
                    { 1, "Deniz" },
                    { 2, "Orman" },
                    { 3, "Boğaz" }
                });

            migrationBuilder.InsertData(
                table: "MüşteriTipleri",
                columns: new[] { "MüşteriTipiID", "MüşteriTipiAdı" },
                values: new object[,]
                {
                    { 1, "Bireysel" },
                    { 2, "Kurumsal" }
                });

            migrationBuilder.InsertData(
                table: "OdaTipleri",
                columns: new[] { "OdaTipiID", "OdaTipiAdı" },
                values: new object[,]
                {
                    { 3, "Standart" },
                    { 2, "Premium" },
                    { 1, "King" }
                });

            migrationBuilder.InsertData(
                table: "Odalar",
                columns: new[] { "OdaID", "KatNO", "OdaAdı", "OdaFiyatı", "YatakSayısı" },
                values: new object[,]
                {
                    { 8, 5, "590", 740m, 4 },
                    { 9, 4, "485", 930m, 1 },
                    { 7, 5, "550", 880m, 3 },
                    { 4, 2, "200", 400m, 1 },
                    { 5, 2, "280", 550m, 6 },
                    { 3, 1, "103", 200m, 2 },
                    { 2, 1, "102", 150m, 5 },
                    { 1, 1, "101", 100m, 3 },
                    { 6, 3, "360", 1100m, 2 }
                });

            migrationBuilder.InsertData(
                table: "Roller",
                columns: new[] { "RolID", "RolAdı" },
                values: new object[,]
                {
                    { 6, "Platin" },
                    { 4, "Gold" },
                    { 5, "Memur" },
                    { 2, "Supervisor" },
                    { 1, "Admin" },
                    { 3, "Anonim" }
                });

            migrationBuilder.InsertData(
                table: "Tesisler",
                columns: new[] { "TesisID", "Açıklama", "TesisAdı" },
                values: new object[,]
                {
                    { 1, "Spor Kompleksimiz 350 kişi kapasitelidir", "Spor Kompleksi" },
                    { 2, "Düğün salonumuz 1250 kişiliktir", "Düğün Salonu" },
                    { 3, "Uzman 50 Kişilik kadro", "Spa Center" },
                    { 4, "200 Kişilik kapasite", "Gym" },
                    { 5, "Eğlence Merkezimiz 2500 kişi kapasitelidir", "Eğlence Merkezi" }
                });

            migrationBuilder.InsertData(
                table: "Tesisler",
                columns: new[] { "TesisID", "Açıklama", "TesisAdı" },
                values: new object[] { 6, "Tam Olimpik Kapalı Havuz", "Kapalı Havuz" });

            migrationBuilder.InsertData(
                table: "ÖdemeTipleri",
                columns: new[] { "ÖdemeTipiID", "ÖdemeTipiAdı" },
                values: new object[] { 1, "Peşin Ödeme" });

            migrationBuilder.InsertData(
                table: "ÖdemeTipleri",
                columns: new[] { "ÖdemeTipiID", "ÖdemeTipiAdı" },
                values: new object[] { 2, "Kredi Kartı İle" });

            migrationBuilder.InsertData(
                table: "Kullanıcılar",
                columns: new[] { "KullanıcıID", "EPosta", "RolID", "Sifre" },
                values: new object[,]
                {
                    { 5, "mnb@test.com", 5, "987456" },
                    { 3, "dfg@test.com", 3, "789456" },
                    { 2, "gfdg@test.com", 2, "54321" },
                    { 1, "abc@test.com", 1, "123345" },
                    { 4, "jkl@test.com", 4, "357753" }
                });

            migrationBuilder.InsertData(
                table: "Müşteriler",
                columns: new[] { "MüşteriID", "CinsiyetID", "MobilNO", "MüşteriSoyadi", "MüşteriTamAdı", "MüşteriTipiID" },
                values: new object[,]
                {
                    { 1, 1, "5555555555", "cihan", "iskender", 1 },
                    { 3, 2, "5555555554", "aslan", "fatma", 2 },
                    { 2, 1, "5555555553", "can", "ali", 1 }
                });

            migrationBuilder.InsertData(
                table: "OdaÖzellikleri",
                columns: new[] { "OdaÖzellikID", "Açıklama", "DuşTipiID", "ManzaraID", "OdaID", "OdaTipiID" },
                values: new object[,]
                {
                    { 2, "", 2, 2, 2, 2 },
                    { 5, "", 2, 2, 5, 2 },
                    { 4, "", 1, 1, 4, 1 },
                    { 3, "", 3, 3, 3, 3 },
                    { 6, "", 3, 3, 6, 3 },
                    { 9, "", 3, 3, 9, 3 },
                    { 1, "", 1, 1, 1, 1 },
                    { 7, "", 1, 1, 7, 1 },
                    { 8, "", 2, 2, 8, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kategoriler_BabaKategoriID",
                table: "Kategoriler",
                column: "BabaKategoriID");

            migrationBuilder.CreateIndex(
                name: "IX_Kullanıcılar_RolID",
                table: "Kullanıcılar",
                column: "RolID");

            migrationBuilder.CreateIndex(
                name: "IX_Müşteriler_CinsiyetID",
                table: "Müşteriler",
                column: "CinsiyetID");

            migrationBuilder.CreateIndex(
                name: "IX_Müşteriler_MüşteriTipiID",
                table: "Müşteriler",
                column: "MüşteriTipiID");

            migrationBuilder.CreateIndex(
                name: "IX_OdaÖzellikleri_DuşTipiID",
                table: "OdaÖzellikleri",
                column: "DuşTipiID");

            migrationBuilder.CreateIndex(
                name: "IX_OdaÖzellikleri_ManzaraID",
                table: "OdaÖzellikleri",
                column: "ManzaraID");

            migrationBuilder.CreateIndex(
                name: "IX_OdaÖzellikleri_OdaID",
                table: "OdaÖzellikleri",
                column: "OdaID");

            migrationBuilder.CreateIndex(
                name: "IX_OdaÖzellikleri_OdaTipiID",
                table: "OdaÖzellikleri",
                column: "OdaTipiID");

            migrationBuilder.CreateIndex(
                name: "IX_OdaResimleri_OdaID",
                table: "OdaResimleri",
                column: "OdaID");

            migrationBuilder.CreateIndex(
                name: "IX_Profiller_KullanıcıID",
                table: "Profiller",
                column: "KullanıcıID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervasyonlar_MüşteriID",
                table: "Rezervasyonlar",
                column: "MüşteriID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervasyonlar_OdaID",
                table: "Rezervasyonlar",
                column: "OdaID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervasyonlar_ÖdemeTipiID",
                table: "Rezervasyonlar",
                column: "ÖdemeTipiID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Birimler");

            migrationBuilder.DropTable(
                name: "Hizmetler");

            migrationBuilder.DropTable(
                name: "Kategoriler");

            migrationBuilder.DropTable(
                name: "OdaÖzellikleri");

            migrationBuilder.DropTable(
                name: "OdaResimleri");

            migrationBuilder.DropTable(
                name: "Profiller");

            migrationBuilder.DropTable(
                name: "Rezervasyonlar");

            migrationBuilder.DropTable(
                name: "Tesisler");

            migrationBuilder.DropTable(
                name: "DuşTipleri");

            migrationBuilder.DropTable(
                name: "Manzaralar");

            migrationBuilder.DropTable(
                name: "OdaTipleri");

            migrationBuilder.DropTable(
                name: "Kullanıcılar");

            migrationBuilder.DropTable(
                name: "Müşteriler");

            migrationBuilder.DropTable(
                name: "Odalar");

            migrationBuilder.DropTable(
                name: "ÖdemeTipleri");

            migrationBuilder.DropTable(
                name: "Roller");

            migrationBuilder.DropTable(
                name: "Cinsiyetler");

            migrationBuilder.DropTable(
                name: "MüşteriTipleri");
        }
    }
}
