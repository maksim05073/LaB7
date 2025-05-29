namespace LB7;

public class Device : IComparable<Device>, ICloneable
{
        public string NameDevice { get; set; }
        public float Price { get; set; }
        public DateTime Date { get; set; }
    
        public Device(string nameDevice, int price, DateTime date)
        {
            this.NameDevice = nameDevice;
            this.Price = price;
            this.Date = date;
        }
    
        public Device()
        {
            NameDevice = "Noname";
            Price = 0;
            Date = DateTime.Now;
        }

        public int CompareTo(Device other)
        {
            if (other == null) return 1;

            int result = string.Compare(NameDevice, other.NameDevice, StringComparison.OrdinalIgnoreCase);
            if (result != 0) return result;

            result = Price.CompareTo(other.Price);
            if (result != 0) return result;

            result = Date.CompareTo(other.Date);
            return result;
        }

        public object CloneTo()
        {
            return new Device
            {
                NameDevice = this.NameDevice,
                Price = this.Price,
                Date = this.Date
            };
        }
        
        public override string ToString()
        {
            return $"Назва: {NameDevice}, Вартість: {Price}, Дата випуску: {Date}";
        }
}