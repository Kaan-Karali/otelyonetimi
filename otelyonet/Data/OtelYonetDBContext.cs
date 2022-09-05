using Microsoft.EntityFrameworkCore;
using otelyonet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace otelyonet.Data
{
    public class OtelYonetDBContext : DbContext
    {
        public OtelYonetDBContext(DbContextOptions<OtelYonetDBContext> options)
         : base(options)
        {

        }

        public DbSet<Oda> Odalar { get; set; }
        public DbSet<Birim> Birimler { get; set; }
        public DbSet<Kullanıcı> Kullanıcılar { get; set; }
        public DbSet<Rol> Roller { get; set; }
        public DbSet<Müşteri> Müşteriler { get; set; }
        public DbSet<MüşteriTipi> MüşteriTipleri { get; set; }
        public DbSet<Cinsiyet> Cinsiyetler { get; set; }
        public DbSet<Hizmet> Hizmetler { get; set; }
        public DbSet<Profil> Profiller { get; set; }
        public DbSet<OdaResim> OdaResimleri { get; set; }
        public DbSet<OdaÖzellik> OdaÖzellikleri { get; set; }
        public DbSet<Manzara> Manzaralar { get; set; }
        public DbSet<OdaTipi> OdaTipleri { get; set; }
        public DbSet<DuşTipi> DuşTipleri { get; set; }
        public DbSet<Kategori> Kategoriler{ get; set; }
        public DbSet<ÖdemeTipi> ÖdemeTipleri { get; set; }
        public DbSet<Rezervasyon> Rezervasyonlar { get; set; }
        public DbSet<Tesis> Tesisler { get; set; } 


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Rol>().HasData(
                                                new Rol { RolID = 1, RolAdı = "Admin" },
                                                new Rol { RolID = 2, RolAdı = "Supervisor" },
                                                new Rol { RolID = 3, RolAdı = "Anonim" },
                                                new Rol { RolID = 4, RolAdı = "Gold" },
                                                new Rol { RolID = 5, RolAdı = "Memur" },
                                                new Rol { RolID = 6, RolAdı = "Platin" }
                                               );



            modelBuilder.Entity<Kullanıcı>().HasData(
                                                new Kullanıcı { KullanıcıID = 1, EPosta = "abc@test.com",RolID=1,Sifre="123345" },
                                                new Kullanıcı { KullanıcıID = 2, EPosta = "gfdg@test.com",RolID = 2, Sifre = "54321" },
                                                new Kullanıcı { KullanıcıID = 3, EPosta = "dfg@test.com", RolID = 3, Sifre = "789456" },
                                                new Kullanıcı { KullanıcıID = 4, EPosta = "jkl@test.com", RolID = 4, Sifre = "357753" },
                                                new Kullanıcı { KullanıcıID = 5, EPosta = "mnb@test.com", RolID = 5, Sifre = "987456" }



                                               );
            modelBuilder.Entity<Cinsiyet>().HasData(
                                                new Cinsiyet { CinsiyetID = 1, CinsiyetAdı="Erkek" },
                                                new Cinsiyet { CinsiyetID = 2, CinsiyetAdı = "Kadın" }



                                               );
            modelBuilder.Entity<Birim>().HasData(
                                               new Birim { BirimID=1,BirimAdı="İnsan Kaynakları"},
                                               new Birim { BirimID = 2, BirimAdı = "F&B" },
                                               new Birim { BirimID = 3, BirimAdı = "Satın Alma" },
                                               new Birim { BirimID = 4, BirimAdı = "Güvenlik" },
                                               new Birim { BirimID = 5, BirimAdı = "House Keeping" }
                                              );
            modelBuilder.Entity<Oda>().HasData(
                                               new Oda { OdaID = 1, OdaAdı = "101", KatNO = 1, YatakSayısı = 3, OdaFiyatı = 100 },
                                               new Oda { OdaID = 2, OdaAdı = "102", KatNO = 1, YatakSayısı = 5, OdaFiyatı = 150 },
                                               new Oda { OdaID = 3, OdaAdı = "103", KatNO = 1, YatakSayısı = 2, OdaFiyatı = 200 },
                                               new Oda { OdaID = 4, OdaAdı = "200", KatNO = 2, YatakSayısı = 1, OdaFiyatı = 400 },
                                               new Oda { OdaID = 5, OdaAdı = "280", KatNO = 2, YatakSayısı = 6, OdaFiyatı = 550 },
                                               new Oda { OdaID = 6, OdaAdı = "360", KatNO = 3, YatakSayısı = 2, OdaFiyatı = 1100},
                                               new Oda { OdaID = 7, OdaAdı = "550", KatNO = 5, YatakSayısı = 3, OdaFiyatı = 880 },
                                               new Oda { OdaID = 8, OdaAdı = "590", KatNO = 5, YatakSayısı = 4, OdaFiyatı = 740 },
                                               new Oda { OdaID = 9, OdaAdı = "485", KatNO = 4, YatakSayısı = 1, OdaFiyatı = 930 }

                                              );

            modelBuilder.Entity<OdaÖzellik>().HasData(
                                               new OdaÖzellik {OdaÖzellikID=1, OdaID=1, OdaTipiID=1, ManzaraID=1, DuşTipiID=1, Açıklama="" }, 
                                               new OdaÖzellik {OdaÖzellikID=2, OdaID=2, OdaTipiID=2, ManzaraID=2, DuşTipiID=2, Açıklama="" }, 
                                               new OdaÖzellik {OdaÖzellikID=3, OdaID=3, OdaTipiID=3, ManzaraID=3, DuşTipiID=3, Açıklama="" }, 
                                               new OdaÖzellik {OdaÖzellikID=4, OdaID=4, OdaTipiID=1, ManzaraID=1, DuşTipiID=1, Açıklama="" }, 
                                               new OdaÖzellik {OdaÖzellikID=5, OdaID=5, OdaTipiID=2, ManzaraID=2, DuşTipiID=2, Açıklama="" }, 
                                               new OdaÖzellik {OdaÖzellikID=6, OdaID=6, OdaTipiID=3, ManzaraID=3, DuşTipiID=3, Açıklama="" }, 
                                               new OdaÖzellik {OdaÖzellikID=7, OdaID=7, OdaTipiID=1, ManzaraID=1, DuşTipiID=1, Açıklama="" }, 
                                               new OdaÖzellik {OdaÖzellikID=8, OdaID=8, OdaTipiID=2, ManzaraID=2, DuşTipiID=2, Açıklama="" }, 
                                               new OdaÖzellik {OdaÖzellikID=9, OdaID=9, OdaTipiID=3, ManzaraID=3, DuşTipiID=3, Açıklama="" }


                                               );

            modelBuilder.Entity<Hizmet>().HasData(
                                                new Hizmet {HizmetID = 1, HizmetAdı = "Kapalı Havuz",Açıklama = " Tam olimpik kapalı havuz", ResimYolu = "1.jpg" },
                                                new Hizmet {HizmetID = 2, HizmetAdı = "Açık Büfe",Açıklama =    " 24 saat 65 farklı çeşit ", ResimYolu = "2.jpg" },
                                                new Hizmet {HizmetID = 3, HizmetAdı = "Spor Kompleksi",Açıklama = "Tenis,Basketbol,Futbol",  ResimYolu = "3.jpg" },
                                                new Hizmet {HizmetID = 4, HizmetAdı = "Masaj",Açıklama = "gbbgf",ResimYolu = "4.jpg" }



                                                    );




            

            modelBuilder.Entity<OdaTipi>().HasData(
                                               new OdaTipi { OdaTipiID=1,OdaTipiAdı="King"},
                                               new OdaTipi { OdaTipiID = 2, OdaTipiAdı = "Premium" },
                                               new OdaTipi { OdaTipiID = 3, OdaTipiAdı = "Standart" }
                                              );
            modelBuilder.Entity<DuşTipi>().HasData(
                                               new DuşTipi { DuşTipiID = 1, DuşTipiAdı = "Jakuzi" },
                                               new DuşTipi { DuşTipiID = 2, DuşTipiAdı = "Standart" },
                                               new DuşTipi { DuşTipiID = 3, DuşTipiAdı = "Küvet" }


                                              );
            modelBuilder.Entity<Manzara>().HasData(
                                               new Manzara { ManzaraID = 1, ManzaraAdı = "Deniz" },
                                               new Manzara { ManzaraID = 2, ManzaraAdı = "Orman" },
                                               new Manzara { ManzaraID = 3, ManzaraAdı = "Boğaz" }

                                              );
            modelBuilder.Entity<MüşteriTipi>().HasData(
                                               new MüşteriTipi { MüşteriTipiID = 1, MüşteriTipiAdı = "Bireysel" },
                                               new MüşteriTipi { MüşteriTipiID = 2, MüşteriTipiAdı = "Kurumsal" }
                                               



                                              );
            modelBuilder.Entity<Müşteri>().HasData(
                                              new Müşteri { MüşteriID = 1, MüşteriTamAdı="iskender",MüşteriSoyadi="cihan",MobilNO="5555555555",CinsiyetID=1,MüşteriTipiID=1 },
                                              new Müşteri { MüşteriID = 2, MüşteriTamAdı = "ali",   MüşteriSoyadi = "can", MobilNO = "5555555553", CinsiyetID = 1, MüşteriTipiID = 1 },
                                              new Müşteri { MüşteriID = 3, MüşteriTamAdı = "fatma", MüşteriSoyadi = "aslan", MobilNO = "5555555554", CinsiyetID = 2, MüşteriTipiID = 2 }




                                             );
            modelBuilder.Entity<ÖdemeTipi>().HasData(
                                              new ÖdemeTipi { ÖdemeTipiID = 1, ÖdemeTipiAdı = "Peşin Ödeme"},
                                              new ÖdemeTipi { ÖdemeTipiID= 2, ÖdemeTipiAdı = "Kredi Kartı İle"}




                                             );
            modelBuilder.Entity<Tesis>().HasData(
                                                new Tesis { TesisID = 1, TesisAdı = "Spor Kompleksi", Açıklama = "Spor Kompleksimiz 350 kişi kapasitelidir"},
                                                new Tesis { TesisID = 2, TesisAdı = "Düğün Salonu", Açıklama = "Düğün salonumuz 1250 kişiliktir"},
                                                new Tesis { TesisID = 3, TesisAdı = "Spa Center", Açıklama = "Uzman 50 Kişilik kadro"},
                                                new Tesis { TesisID = 4, TesisAdı = "Gym", Açıklama = "200 Kişilik kapasite"},
                                                new Tesis { TesisID = 5, TesisAdı = "Eğlence Merkezi", Açıklama = "Eğlence Merkezimiz 2500 kişi kapasitelidir"},
                                                new Tesis { TesisID = 6, TesisAdı = "Kapalı Havuz", Açıklama = "Tam Olimpik Kapalı Havuz"}
                
                
                
                
                
                                                
                                                 );









        }



    }
}

