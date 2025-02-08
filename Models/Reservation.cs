namespace ProjectRoot.Models
{
    using System;

    public class Reservation
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int MotelId { get; set; }
        public int SuiteTypeId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public decimal TotalPrice { get; set; }
    }
}