using HomeKitDotNet.JSON;
using System.Text.Json;

namespace HomeKitDotNet.Models
{
    public class HomeKitEndPoint
    {
        public HomeKitEndPoint(Connection connection, AccessoriesJSON accessories)
        {
            this.Connection = connection;
            this.Connection.EventReceived += Connection_EventReceived;

            List<Accessory> list = new List<Accessory>();
            foreach (AccessoryJSON accessory in accessories.Accessories)
                list.Add(new Accessory(this, accessory));
            Accessories = list.ToArray();
        }

        private void Connection_EventReceived(object? sender, HttpResponseMessage msg)
        {
            try
            {
                Dictionary<string, CharacteristicEventJSON[]>? charUpdate = JsonSerializer.Deserialize<Dictionary<string, CharacteristicEventJSON[]>>(msg.Content.ReadAsStream());
                if (charUpdate != null && charUpdate.TryGetValue("characteristics", out CharacteristicEventJSON[]? chars))
                {
                    foreach (CharacteristicEventJSON characteristic in chars)
                    {
                        Accessory accessory = Accessories.First(a => a.ID == characteristic.AccessoryID);
                        accessory.InvokeEvent(characteristic);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Failed to process event: " + ex.ToString());
            }
        }

        public Accessory[] Accessories { get; init; }
        public Connection Connection { get; set; }
    }
}
