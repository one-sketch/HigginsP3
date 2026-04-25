using System.Collections.Generic;

namespace HigginsP3.Models
{
    public class Minor
    {
        public string? name { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public List<string>? courses { get; set; }
        public string? note { get; set; }
    }
}