using ConcertData.DataModels;
using ConcertData.Enums;
using Microsoft.EntityFrameworkCore;

namespace ConcertAPI.Context
{
    /// <summary>
    /// This class is used to malke the connection to the Data as well as build the Database
    /// </summary>
    public class ConcertContext : DbContext
    {
        //Use DbSet on Data Models to initialize the tables

        public DbSet<BandModel> BandModels { get; set; }
        public DbSet<ConcertModel> Concerts { get; set; }
        public DbSet<MusicianModel> Musicians { get; set; }
        public DbSet<VenueModel> Venues { get; set; }

        /// <summary>
        /// The Configuration Event that is call by entity framework to initialize the connection
        /// </summary>
        /// <param name="optionsBuilder">DbContextOptionsBuilder class</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //ToDo Change this to match the Database name as needed
            if (Environment.UserName.ToUpper() == "JOHN")
            {
                string connectionString = @"Data Source=localhost;Initial Catalog=ConcertData;Integrated Security=True;Encrypt=False";
                optionsBuilder.UseSqlServer(connectionString);
            }
            else
            {
                string connectionString = @"Server=(localdb)\\mssqllocaldb;Database=ConcertData;Trusted_Connection=True;";
                optionsBuilder.UseSqlServer(connectionString);
            }

        }

        /// <summary>
        /// The Model Creating Event called while Entity Framework builds/Changes the database structure
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VenueModel>().HasData(
                new VenueModel { Id = 1, Name = "KEMBA Live!", LogoURL = @"https://lh3.googleusercontent.com/p/AF1QipOCzZhPE1I7VOx6sqrXTbaaE9DZm2lYkrHYPzCF=s680-w680-h510" },
                new VenueModel { Id = 2, Name = "Newport Music Hall", LogoURL = @"https://lh3.googleusercontent.com/p/AF1QipOC8C3lLf-X-4yMGvg-GTNrg3bWMXDLWdj1LOnx=s680-w680-h510" },
                new VenueModel { Id = 3, Name = "Blossom Music Center", LogoURL = @"https://lh3.googleusercontent.com/p/AF1QipOC8C3lLf-X-4yMGvg-GTNrg3bWMXDLWdj1LOnx=s680-w680-h510" }
                );
            modelBuilder.Entity<MusicianModel>().HasData(
              new MusicianModel { Id = 1, FullName = "Gus Dapperton", Bio = "Punk musician played with Hippo Campusip in concerts", PreformerCategory = GenreEnum.Punk_Rock, ProfilePictureUrl = @"https://www.gusdapperton.com/sites/g/files/g2000015461/files/2022-10/artwork-440x440.jpg" },
              new MusicianModel { Id = 2, FullName = "Hippo Smith", Bio = "Punk musician", PreformerCategory = GenreEnum.Punk_Rock, ProfilePictureUrl = @"https://www.gusdapperton.com/sites/g/files/g2000015461/files/2022-10/artwork-440x440.jpg" },
              new MusicianModel { Id = 3, FullName = "Johnny Cash", Bio = "Great country singer", PreformerCategory = GenreEnum.Country, ProfilePictureUrl = @"https://books.google.com/books/content?id=yL6MRZfrWjkC&pg=PP1&img=1&zoom=3&hl=en&bul=1&sig=ACfU3U02TmfmNvXIpXhrD026A0Nktcb3zw&w=1280" },
              new MusicianModel { Id = 4, FullName = "Jimmy Buffett", Bio = "Great country singer", PreformerCategory = GenreEnum.Country, ProfilePictureUrl = @"http://t1.gstatic.com/licensed-image?q=tbn:ANd9GcQD84Z5E5op_ZJJNwOl4W-YSizPPEAE9mZc7aTI8CNnfCA3Mzbi_DI_H7NxT-b8A6CiAai85Fla0ud_ZM4" }
              );
            modelBuilder.Entity<BandModel>().HasData(
                new BandModel { Id = 5, FullName = "Barenaked Ladies", PreformerCategory = GenreEnum.Pop, Bio = "Great band, been together for years.", ProfilePictureUrl = @"https://www.barenakedladies.com/wp-content/uploads/2015/05/large.scyd5regTuwzFP5b4C-t66Qz7O_ftON3oFMxT1lWFUg-300x300.jpg" },
                new BandModel { Id = 6, FullName = "Two Friends", PreformerCategory = GenreEnum.Country, Bio = "Good solid music, for a simple evening.", ProfilePictureUrl = @"https://cdn.shopify.com/s/files/1/0015/2708/7192/products/DMYourCrush_1_2186932c-3e15-481b-9849-a2fb91b2def2_800x.png?v=1664902157" },
                new BandModel { Id = 7, FullName = "Hippo Campusip", PreformerCategory = GenreEnum.Punk_Rock, Bio = "Great Punck Rock Band", ProfilePictureUrl = @"https://cdn.shopify.com/s/files/1/0219/6940/products/CD_MOCK_square_1024x1024.jpg?v=1623341625" }
                );

            modelBuilder.Entity<ConcertModel>().HasData(
                new ConcertModel { Id = 1, VenueId = 1, Name = "Big Concert at the River", ConcertGenre = GenreEnum.Country, Description = "This is a good ole boys concert", Price = 10.00, ConcertDate = DateTime.Parse("07/04/2023 10:30:00"), ImageURL = @"https://images.pexels.com/photos/1105666/pexels-photo-1105666.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                new ConcertModel { Id = 2, VenueId = 2, Name = "Concert at the Beach", ConcertGenre = GenreEnum.Pop, Description = "This is a good ole boys concert", Price = 10.00, ConcertDate = DateTime.Parse("07/08/2023 10:30:00"), ImageURL = @"https://images.pexels.com/photos/1190297/pexels-photo-1190297.jpeg" },
                new ConcertModel { Id = 3, VenueId = 3, Name = "Concert at the Beach", ConcertGenre = GenreEnum.Pop, Description = "This is a good ole boys concert", Price = 10.00, ConcertDate = DateTime.Parse("08/01/2023 10:30:00"), ImageURL = @"https://images.pexels.com/photos/995301/pexels-photo-995301.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" }
                );

        }
    }
}

//https://stackoverflow.com/questions/66081011/seeding-data-in-man