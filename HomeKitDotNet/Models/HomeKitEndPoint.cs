using HomeKitDotNet.JSON;

namespace HomeKitDotNet.Models
{
    public class HomeKitEndPoint
    {
        public HomeKitEndPoint(Connection connection, AccessoriesJSON accessories)
        {
            this.Connection = connection;

            List<Accessory> list = new List<Accessory>();
            foreach (AccessoryJSON accessory in accessories.Accessories)
                list.Add(new Accessory(this, accessory));
            Accessories = list.ToArray();
        }

        public Accessory[] Accessories { get; init; }
        public Connection Connection { get; set; }
    }
}
