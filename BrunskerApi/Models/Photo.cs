namespace BrunskerApi.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }

        /*EF Relation */
        public User User { get; set; }
        public int UserId { get; set; }
    }
}