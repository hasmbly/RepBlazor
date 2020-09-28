namespace RepBlazor.WebUI.Pages
{
    public partial class Index
    {
        public class Car
        {
            public string Name { get; set; }
            public double Price { get; set; }
            public int Horsepower { get; set; }

            public Car(string name, double price, int horsepower)
            {
                Name = name;
                Price = price;
                Horsepower = horsepower;
            }
        }

        Car[] cars = new[]
        {
            new Car("Volkswagen Golf", 10000, 220),
            new Car("Volkswagen Passat", 11000, 240),
            new Car("Volkswagen Polo", 12000, 110),
            new Car("Ford Focus", 13000, 200),
            new Car("Ford Fiesta", 14000, 160),
            new Car("Ford Fusion", 15000, 260),
            new Car("Ford Mondeo", 16000, 120),
        };
    }
}