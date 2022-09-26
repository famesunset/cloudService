using System.Text.Json.Serialization;

namespace Structures
{
    public class Gift
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public double Accumulated { get; set; }
        public bool IsActive { get; set; }
    }
}