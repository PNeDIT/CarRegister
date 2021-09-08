namespace CarRegister.Data.Models
{
    using System;

    public class Car
    {
        public int Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public int Seats{ get; set; }

        public DateTime ReleaseDate { get; set; }

        public bool IsDeleted { get; set; }
    }
}
