using Microsoft.EntityFrameworkCore;
using PI4_website.Models;
using System.Collections.Generic;

namespace PI4_website.Data
{

    public class OnderwerpenContext : DbContext
    {
        public OnderwerpenContext(DbContextOptions options) : base(options)
        {
/*            Database.EnsureDeleted();
*/            Database.EnsureCreated();
        }

        public DbSet<Onderwerpen> Onderwerpen { get; set; }
        public DbSet<Video> Videos { get; set; }

        public DbSet<KoppelTabel> KoppelTabel { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Onderwerpen>()
            .HasMany<KoppelTabel>(s => s.Koppelingen)
             .WithOne(i => i.Onderwerpen)
             .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Video>()
            .HasMany<KoppelTabel>(c => c.Koppelingen)
            .WithOne(i => i.Video)
            .OnDelete(DeleteBehavior.ClientCascade);



            modelBuilder.Entity<Onderwerpen>().HasData(
                new Onderwerpen { OnderwerpID = 1, Name = "Stamina" },
                new Onderwerpen { OnderwerpID = 2, Name = "Side Kick"},
                new Onderwerpen { OnderwerpID = 3, Name = "Ontwijking van gevaar" },
                new Onderwerpen { OnderwerpID = 4, Name = "Back Fist" },
                new Onderwerpen { OnderwerpID = 5, Name = "Back Kick" },
                new Onderwerpen { OnderwerpID = 6, Name = "Front Kick" },
                new Onderwerpen { OnderwerpID = 7, Name = "RoundHouse Kick" },
                new Onderwerpen { OnderwerpID = 8, Name = "Uppercut" },
                new Onderwerpen { OnderwerpID = 9, Name = "The Jab" },
                new Onderwerpen { OnderwerpID = 10, Name = "The Hook" }

                );
            modelBuilder.Entity<Video>().HasData(
                new Video { VideoID = 1, Name= "Spinning Back Fist", Link= "https://www.youtube.com/embed/gNd5c2C8Doc" },
                new Video { VideoID = 2, Name = "Shooting", Link = "https://www.youtube.com/embed/NMGFwBM7Uo4" },
                new Video { VideoID = 3, Name = "Side Kick 4.3", Link = "https://www.youtube.com/embed/Mgb8wujuit0" },
                new Video { VideoID = 4, Name = "Slipping and Evading 3.6", Link = "https://www.youtube.com/embed/Nz7mAvVysrI" },
                new Video { VideoID = 5, Name = "The Hook 3.2", Link = "https://www.youtube.com/embed/ocqFWvSVOLc" },
                new Video { VideoID = 6, Name = "The Jab 3.1", Link = "https://www.youtube.com/embed/uVsfBos88CI" },
                new Video { VideoID = 7, Name = "The Uppercut 3.3", Link = "https://www.youtube.com/embed/QoL2fQDCPas" },
                new Video { VideoID = 8, Name = "Deadly Combinations 3.4", Link = "https://www.youtube.com/embed/1Wzi6j1REWI" },
                new Video { VideoID = 9, Name = "Uithoudingsvermogen(NL) 1.4", Link = "https://www.youtube.com/embed/lDMZximoLmk" },
                new Video { VideoID = 10, Name = "Small series of different exercises for combat stamina", Link = "https://www.youtube.com/embed/G5mJKBT4HH4" },
                new Video { VideoID = 11, Name = "Voetenwerk (NL) 1.3", Link = "https://www.youtube.com/embed/vr4Mwf0Ymm8" },
                new Video { VideoID = 12, Name = "Flying Front Kick 4.8", Link = "https://www.youtube.com/embed/iygxaot9Vms" },
                new Video { VideoID = 13, Name = "Roundhouse kick 4.2", Link = "https://www.youtube.com/embed/cRX5-wS4M8s" },
                new Video { VideoID = 14, Name = "Vicious Combinations 4.6", Link = "https://www.youtube.com/embed/aRGVRt-i9ww" },
                new Video { VideoID = 15, Name = "Jo Bonten - Wat te doen bij een terroristische aanslag", Link = "https://www.youtube.com/embed/Sa3_tBJXSSg" },
                new Video { VideoID = 16, Name = "Zo SCHUIL je voor KOGELS | Man Bijt Hond | KIJK", Link = "https://www.youtube.com/embed/SJ6gUtVuMWE" },
                new Video { VideoID = 17, Name = "Headbutt", Link = "https://www.youtube.com/embed/EvJSNf75Ouw" }
               
                );

            modelBuilder.Entity<KoppelTabel>().HasData(
                new KoppelTabel { KoppelID = 1, OnderwerpID = 1, VideoID = 1 },
                new KoppelTabel { KoppelID = 2, OnderwerpID = 3, VideoID = 2 },
                new KoppelTabel { KoppelID = 3, OnderwerpID = 2, VideoID = 3 },
                new KoppelTabel { KoppelID = 4, OnderwerpID = 3, VideoID = 4 },
                new KoppelTabel { KoppelID = 5, OnderwerpID = 10, VideoID = 5 },
                new KoppelTabel { KoppelID = 6, OnderwerpID = 9, VideoID = 6 },
                new KoppelTabel { KoppelID = 7, OnderwerpID = 8, VideoID = 7 },
                new KoppelTabel { KoppelID = 8, OnderwerpID = 1, VideoID = 8 },
                new KoppelTabel { KoppelID = 9, OnderwerpID = 1, VideoID = 9 },
                new KoppelTabel { KoppelID = 10, OnderwerpID = 1, VideoID = 10 },
                new KoppelTabel { KoppelID = 11, OnderwerpID = 1, VideoID = 11 },
                new KoppelTabel { KoppelID = 12, OnderwerpID = 6, VideoID = 12 },
                new KoppelTabel { KoppelID = 13, OnderwerpID = 7, VideoID = 13 },
                new KoppelTabel { KoppelID = 14, OnderwerpID = 1, VideoID = 14 },
                new KoppelTabel { KoppelID = 15, OnderwerpID = 3, VideoID = 15 },
                new KoppelTabel { KoppelID = 16, OnderwerpID = 3, VideoID = 16 },
                new KoppelTabel { KoppelID = 17, OnderwerpID = 1, VideoID = 17 }


                );



            /*            modelBuilder.Entity<KoppelTabel>()
                            .HasMany<Video>(o => o.Videos)*/




        }




    }
}
