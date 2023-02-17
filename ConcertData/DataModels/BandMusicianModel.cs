using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertData.DataModels
{
    [Table("BandMusician")]
    public class BandMusicianModel
    {
        public int BandId { get; set; }
        public BandModel Band { get; set; } = null!;
        public int MusicianId { get; set; }
        public MusicianModel Musician { get; set; } = null!;


    }
}
