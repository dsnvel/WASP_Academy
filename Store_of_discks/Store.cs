using System.Globalization;

namespace Program
{
    class Program
    {
        public static void Main(string[] args)
        {
            Store my_store = new Store("restore", "Red square");

            Audio audio1 = new Audio("New Yourk", "rap", 12.59, "Noname", "Noname", 2);
            my_store.add_audio_to_store(audio1);
            Audio audio2 = new Audio("Cradles", "pop", 19.05, "Sub Urban", "The famous st", 5);
            my_store.add_audio_to_store(audio2);

            DVD dvd1 = new DVD("John Huse", "20th Century Studios", 103, "Home alone", "Comedy", 15.99);
            my_store.add_dvd_to_store(dvd1);
            DVD dvd2 = new DVD("Chris Meledandri", "Illumination", 90, "Grinch", "Comedy", 9.99);
            my_store.add_dvd_to_store(dvd1);

            Console.WriteLine(my_store.ToString());

            audio1.Burn();
            Console.WriteLine("-----------------------------");
            Console.WriteLine($"{audio1.Name} = {audio1.DiskSize}");
            Console.WriteLine($"{audio2.Name} = {audio2.DiskSize}");
            Console.WriteLine($"{dvd1.Name} = {dvd1.DiskSize}");
            Console.WriteLine($"{dvd2.Name} = {dvd2.DiskSize}");
        }   
    }

    interface IStoreItem
    {
        double Price { get; set; }

        void DiscountPrice(int percent)
        {
            Price = percent * Price / 100;
        }
    }


    class Disk : IStoreItem
    {
        private string name;
        private string genre;
        private int burnCount;

        public Disk(string name, string genre, double price)
        {
            this.name = name;
            this.genre = genre;
        }

        public string Name { get { return name; } }
        public string Genre { get { return genre; } }
        public int BurnCount { get { return burnCount; } set { burnCount = value; } }

        virtual public int DiskSize { get; }

        virtual public void Burn(params string[] values)
        {
            burnCount += values.Length;
        }

        public double Price { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void DiscountPrice(int percent)
        {
            this.Price = percent * this.Price / 100;
        }
    }


    class Audio : Disk
    {
        private string artist;
        private string recordingStudio;
        private int songsNumber;

        public Audio(string name, string genre, double price,
            string artist, string recotdingStudio, int songsNumber)
            : base(name, genre, price)
        {
            this.artist = artist;
            this.recordingStudio = recotdingStudio;
            this.songsNumber = songsNumber;
        }

        public int SongsNumber { get; set; }

        public override int DiskSize { get { return this.songsNumber * 8; } }

        public override void Burn(params string[] values)
        {
            SongsNumber += values.Length; 
            this.BurnCount++;
        }

        public override string ToString()
        {
            return $"{this.Name}, {this.Genre}, {this.artist}, {this.recordingStudio}, " +
                $"{this.songsNumber}, {this.BurnCount}";
        }
    }
    class DVD : Disk
    {
        private string producer;
        private string filmCompany;
        private int minutesCount;

        public DVD(string producer, string filmCompany, int minutesCount,
            string name, string genre, double price)
            : base(name, genre, price)
        {
            this.producer = producer;
            this.filmCompany = filmCompany;
            this.minutesCount = minutesCount;
        }

        public override int DiskSize { get { return this.minutesCount / 64 * 2; } }

        public override void Burn(params string[] values)
        {
            this.BurnCount++;
        }

        public override string ToString()
        {
            return $"{this.Name}, {this.Genre}, {this.producer}, {this.filmCompany}, " +
            $"{this.minutesCount}, {this.BurnCount}";
        }
    }


    class Store
    {
        private string storeName;
        private string address;
        private List<Audio> audios;
        private List<DVD> dvds;

        public Store(string storeName, string address)
        {
            this.storeName = storeName;
            this.address = address;
            this.audios = new List<Audio>();
            this.dvds = new List<DVD>();
        }

        public void add_audio_to_store(Audio audio)
        {
            audios.Add(audio);
        }

        public void add_dvd_to_store(DVD dvd)
        {
            dvds.Add(dvd);
        }

        public override string ToString()
        {
            string list_of_items = "Goods in store: \n";
            foreach (Audio item in this.audios)
            {
                list_of_items += item.ToString() + "\n";
            }
            foreach (DVD item in this.dvds)
            {
                list_of_items += item.ToString() + "\n";
            }
            return list_of_items;
        }
    }
}
