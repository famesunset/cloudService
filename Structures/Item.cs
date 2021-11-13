using System.Text.Json.Serialization;

namespace Structures
{
    public class Item
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public long Id { get; set; }
    }
}