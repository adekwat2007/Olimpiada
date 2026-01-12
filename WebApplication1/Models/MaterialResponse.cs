namespace WebApplication1.Models
{
    public class MaterialResponse
    {
        public int MaterialID { get; set; }
        public string MaterialName { get; set; } = string.Empty;
        public string? MaterialDescription { get; set; }
        public string MaterialType { get; set; } = string.Empty;
        public string Area { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public List<string> Authors { get; set; } = new List<string>();
        public List<string> Trainings { get; set; } = new List<string>();
    }
}
