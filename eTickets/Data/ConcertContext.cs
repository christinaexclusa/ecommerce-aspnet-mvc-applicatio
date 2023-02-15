using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data
{
	public class ConcertContext : DbContext
	{
		//constructor
		//public ConcertContext(DbContextOptions<ConcertContext> options) : base(options)
		//{
		//}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			//ToDo Change this to match the Database name as needed
			//@name of server; Name of Database; If its secure; tell it not to encrypt
			var connectionString = "Server=(localdb)\\mssqllocaldb;Database=eTicketsTesting;Trusted_Connection=True;";
			//tell optionbuilder to build a connection  to sql server using the connection string


			base.OnConfiguring(optionsBuilder);
			optionsBuilder.UseSqlServer(connectionString);
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Musician_Band>().HasKey(mb => new
			{
				mb.MusicianId,
				mb.BandId
			});

			modelBuilder.Entity<Musician_Band>().HasOne(b => b.Band).WithMany
				(mb => mb.Musicians_Bands).HasForeignKey(b => b.BandId);
			modelBuilder.Entity<Musician_Band>().HasOne(b => b.Musician).WithMany
				(mb => mb.Musicians_Bands).HasForeignKey(b => b.MusicianId);

			base.OnModelCreating(modelBuilder);


		}
		//Create the tables
		public DbSet<MusicianModel> Musicians { get; set; }
		public DbSet<BandModel> Bands { get; set; }
		public DbSet<Musician_Band> Musician_Band { get; set; }
		public DbSet<VenueModel> Venues { get; set; }
		public DbSet<ConcertModel> Concerts { get; set; }

		public DbSet<Concert_Bands> Concert_Bands { get; set; }


	}


	}
