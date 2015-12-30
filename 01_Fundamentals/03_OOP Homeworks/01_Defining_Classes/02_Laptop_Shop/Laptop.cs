using System;
//create a laptop and a battery class, laptop has an instance of battery in it.
// if any of the string fields are empty -> throw new exception("invalid X") 
//have 2 construcotrs - 1 takse only model and price; 2 takes all the info.

namespace _02_Laptop_Shop
{
    class Laptop
    {
        private string model;
        private int price;
        private string manufacturer;
        private string processor;
        private int ram;
        private string graphicsCard;
        private string hdd;
        private string screen;
        Battery battery;
        
        private string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                if (value == "") throw new Exception("Invalid model");
                this.model = value;
            }
        }
        private int Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0) throw new Exception("Invalid price");
                this.price = value;
            }
        }
        private string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            set
            {
                this.manufacturer = value;
            }
        }
        private string Processor
        {
            get
            {
                return this.processor;
            }
            set
            {
                this.processor = value;
            }
        }
        private int Ram
        {
            get
            {
                return this.ram;
            }
            set
            {
                this.ram = value;
            }
        }
        private string GraphicsCard
        {
            get
            {
                return this.graphicsCard;
            }
            set
            {
                this.graphicsCard = value;
            }
        }
        private string Hdd
        {
            get
            {
                return this.hdd;
            }
            set
            {
                this.hdd = value;
            }
        }
        private string Screen
        {
            get
            {
                return this.screen;
            }
            set
            {
                this.screen = value;
            }
        }
        private string Battery
        {
            get
            {
                return this.battery.ToString();
            }
            set
            {
                this.battery = new Battery(value);
            }
        }
        public Laptop(string model, int price) :this(model,price,null,null,0,null,null,null," 0")
        {}
        public Laptop(string model, int price,string manufacturer, string processor, int ram, string graphicsCard, string hdd, string screen, string battery)
        {                               
            this.Model = model;         
            this.Price = price;
            this.Manufacturer = manufacturer;
            this.Processor = processor;
            this.Ram = ram;
            this.GraphicsCard = graphicsCard;
            this.Hdd = hdd;
            this.Screen = screen;
            this.Battery = battery;     
        }
        public override string ToString()
        {
            return String.Format("Laptop model: {0}{9} price: {1},{9} manufacturer: {2},{9} processor: {3},{9} ram: {4},{9} graphics card:{5},{9} hdd: {6},{9} screen: {7},{9} battery {8};", this.Model, this.Price,this.Manufacturer,this.Processor,this.Ram,this.GraphicsCard,this.Hdd,this.Screen,this.Battery,Environment.NewLine);
        }
    }                                   

    class Battery
    {
        private string batteryName;
        private int hours;

        public string BatteryName
        {
            get
            {
                return String.Format("Battery: {0}",this.batteryName);
            }
            set
            {
                this.batteryName = value;
            }
        }
        public String Hours
        {
            get
            {
                return String.Format("battery hours: {0}", this.hours);                    
            }
            set
            {
                this.hours = int.Parse(value);
            }
        }

        public Battery(string input)
        {
            string[] arg = input.Split();
            this.BatteryName = arg[0];
            this.Hours = arg[1];
        }

        public override string ToString()
        {
            return String.Format("{0}, {1}", this.BatteryName, this.Hours);
        }
    }
}
