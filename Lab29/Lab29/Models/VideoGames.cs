using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab29.Models
{
    public class VideoGames
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Rating { get; set; }
        public string Description { get; set; }
        public bool IsReleased { get; set; }
    }
}
