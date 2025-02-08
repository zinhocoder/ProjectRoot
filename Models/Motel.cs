namespace ProjectRoot.Models
{
    using System.Collections.Generic;

    public class Motel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public List<SuiteType>? Suites { get; set; }
    }
}