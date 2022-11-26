namespace Program
{
    class Program
    {
        class Car
        {
            private string brand;
            private string force;
            private string year_of_made;

            public Car(string brand, string force, string year_of_made)
            {
                this.brand = brand;
                this.force = force;
                this.year_of_made = year_of_made;
                ///Autopark.add_car_to_list_of_cars(this);

            }

            public string Brand { get { return brand; } }
            public string Force { get { return force; } }
            public string Year_of_made { get { return year_of_made; } }

            override public string ToString()
            {
                return $"{this.brand}, {this.force}, {this.year_of_made}";
            }
        }

        sealed class PassengerCar : Car
        {
            private int count_of_passengers;
            private Dictionary<string, List<int>> repair_book;

            public PassengerCar(string brand, string force, string year_of_made, int count_of_passengers)
                : base(brand, force, year_of_made)
            {
                this.repair_book = new Dictionary<string, List<int>>();
                this.count_of_passengers = count_of_passengers;
            }

            public void add_repair_to_book(string name_of_part, int year_of_repair)
            {
                if (this.repair_book.ContainsKey(name_of_part))
                    this.repair_book[name_of_part].Add(year_of_repair);
                else
                {
                    List<int> list_of_years = new List<int>();
                    list_of_years.Add(year_of_repair);
                    this.repair_book.Add(name_of_part, list_of_years);
                }
            }

            public void get_year_by_name_of_part(string name_of_part)
            {
                Console.WriteLine(this.repair_book[name_of_part]);
            }

            public void print_repair_book()
            {
                Console.WriteLine("--------------------");
                Console.WriteLine("Repair book for:");
                foreach (string detail in this.repair_book.Keys)
                {
                    string list_of_years_string = "";
                    List<int> list_of_years = this.repair_book[detail];
                    foreach (int year in list_of_years)
                    {
                        list_of_years_string += " " + year;
                    }

                    Console.WriteLine($"{detail}: {list_of_years_string}");
                }
                Console.WriteLine("--------------------");
            }

            public override string ToString()
            {
                return $"{this.Brand}, {this.Force}, {this.Year_of_made}, {this.count_of_passengers}";
            }
        }

        sealed class Truck : Car
        {
            private int max_load_capacity;
            private string name_and_surname_of_driver;
            private Dictionary<string, int> current_cargo;

            public Truck(string brand, string force, string year_of_made,
                int max_load_capacity, string name_and_surname_of_driver)
                : base(brand, force, year_of_made)
            {
                this.max_load_capacity = max_load_capacity;
                this.name_and_surname_of_driver = name_and_surname_of_driver;
                this.current_cargo = new Dictionary<string, int>();
            }

            public string Name_and_surname_of_driver
            {
                get { return name_and_surname_of_driver; }
                set
                {
                    if (value == null)
                        throw new ArgumentNullException("Enter the name and surname of driver");
                    else
                        name_and_surname_of_driver = value;
                }
            }

            public void print_curent_cargo()
            {
                Console.WriteLine("--------------------");
                Console.WriteLine("List of current cargo:");
                foreach (string cargo in this.current_cargo.Keys)
                {
                    Console.WriteLine($"{cargo}: {current_cargo[cargo]}");
                }
                Console.WriteLine("--------------------");
            }

            public override string ToString()
            {
                return ($"{this.Brand}, {this.Force}, {this.Year_of_made}, " +
                    $"{this.max_load_capacity}, {this.name_and_surname_of_driver}");
            }
        }

        class Autopark
        {
            private static string name_of_autopark = "My_autopark";
            private static List<Car> list_of_cars = new List<Car>();
            /*List<Car> list_of_cars = new List<Car>();*/

            public Autopark() { }

            public static void add_car_to_list_of_cars(Car car)
            {
                list_of_cars.Add(car);
            }

            public static string ToString()
            {
                string info_about_auto_park = "";

                Console.WriteLine("--------------------");
                Console.WriteLine("Autopark:");
                Console.WriteLine("--------------------");
                int counter = 1;
                foreach (Car car in list_of_cars)
                {
                    string info = car.ToString();
                    info_about_auto_park += $"{counter}. " + info + "\n";
                    counter++;
                }
                info_about_auto_park += "--------------------";
                return info_about_auto_park;
            }

        }

        public static void Main(string[] args)
        {
            Autopark autopark = new Autopark();

            Car car1 = new Car("Porche", "350", "2022");
            Autopark.add_car_to_list_of_cars(car1);

            Car car2 = new PassengerCar("Ferrari", "600", "2019", 4);
            Autopark.add_car_to_list_of_cars(car2);

            Car car3 = new Truck("Ford", "300", "2020", 20, "Danil Vdovenko");
            Autopark.add_car_to_list_of_cars(car3);

            Car car4 = new PassengerCar("BMW", "250", "2022", 3);
            Autopark.add_car_to_list_of_cars(car4);

            Car car5 = new Truck("Tundra", "400", "2022", 100, "ne_Danil Vdovenko");
            Autopark.add_car_to_list_of_cars(car5);

            string result = Autopark.ToString();
            Console.WriteLine(result);
        }
    }
}
