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
            private const int size_of_book = 100;

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
                    $"{this.name_and_surname_of_driver}, {this.max_load_capacity}");
            }
        }

        class Autopark
        {
            private static string name_of_autopark = "My_autopark";
            private static List<object> list_of_cars;

            public Autopark()
            {
                List<object> list_of_cars = new List<object>(20);
            }

            /*public static List<object> List_of_cars
            {
                get { return list_of_cars; }
                set { list_of_cars.Add(value); }
            }*/

            public static void add_car_to_list_of_cars(object ref car)
            {
                object new_car = ref car;
                Console.WriteLine(new_car);
                list_of_cars.Add(new_car);
            }

            public override string ToString()
            {
                string info_about_auto_park = "";

                foreach (object car in list_of_cars)
                {
                    info_about_auto_park += car;
                }
                return $"";
            }

        }

        public static void Main(string[] args)
        {
            Car porche = new Car("porche", "200", "2022");
            Autopark.add_car_to_list_of_cars(ref porche);
            Console.WriteLine(porche.ToString());
        }
    }
}
