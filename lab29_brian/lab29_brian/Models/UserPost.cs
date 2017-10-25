using System.ComponentModel.DataAnnotations;
using System.Runtime.ConstrainedExecution;

namespace lab29_brian.Models
{
    public class UserPost
    {
        [Key]
        public int UserPostID { get; set; }
        public string PostContent { get; set; }
        public string Picture { get; set; }
        public string GeoLocation { get; set; }
    }
}
