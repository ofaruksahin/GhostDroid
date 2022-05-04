namespace GhostDroid.Domain.Models
{
    public class Notification : BaseModel
    {
        public string PackageName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
