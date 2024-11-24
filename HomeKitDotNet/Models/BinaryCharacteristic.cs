using HomeKitDotNet.JSON;
using System.Buffers.Text;
using System.Text.Json;

namespace HomeKitDotNet.Models
{
    public class BinaryCharacteristic : CharacteristicBase
    {
        public delegate Task AsyncEventHandler(Service service, BinaryCharacteristic characteristic, byte[] newValue);
        public event AsyncEventHandler? Updated;
        protected BinaryCharacteristic(Service service, CharacteristicJSON json) : base(service, json)
        {
            LastValue = MapValue(json.Value);
        }

        protected async Task<bool> Write(byte[] value, CancellationToken token = default)
        {
            if (!CanWrite)
                throw new InvalidOperationException("Writing is prohibited");
            CharacteristicValueJSON write = new CharacteristicValueJSON(service.Accessory.ID, InstanceID);
            write.Value = JsonSerializer.SerializeToElement(Convert.ToBase64String(value));
            Dictionary<string, CharacteristicValueJSON[]> dict = new Dictionary<string, CharacteristicValueJSON[]>();
            dict.Add("characteristics", [write]);
            return (await service.Accessory.EndPoint.Connection.Put("/characteristics", JsonSerializer.SerializeToUtf8Bytes(dict), token)).StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        protected async Task<byte[]> Read(CancellationToken token = default)
        {
            if (!CanRead)
                throw new InvalidOperationException("Reading is prohibited");
            HttpResponseMessage msg = await service.Accessory.EndPoint.Connection.Get($"/characteristics?id={service.Accessory.ID}.{InstanceID}", token);
            if (!msg.IsSuccessStatusCode)
                return Array.Empty<byte>();
            CharacteristicsJSON? chars = JsonSerializer.Deserialize<CharacteristicsJSON>(msg.Content.ReadAsStream());
            if (chars == null || chars.Characteristics.Length == 0)
                return Array.Empty<byte>();
            LastValue = MapValue(chars.Characteristics[0].Value);
            return LastValue;
        }

        protected byte[] MapValue(JsonElement? value)
        {
            if (value.HasValue)
            {
                if (value.Value.ValueKind == JsonValueKind.String)
                    return Convert.FromBase64String(value.Value.GetString() ?? string.Empty);
                else
                    throw new ArgumentException("Value Mismatch " + value);
            }
            else
                return Array.Empty<byte>();
        }

        internal override void FireUpdate(JsonElement? value)
        {
            byte[] newVal = MapValue(value);
            if (Updated != null)
                Updated.Invoke(service, this, newVal);
            LastValue = newVal;
        }

        public byte[] LastValue { get; set; }
        public float? MaxLength => _json.MaxLength;
        public float? MaxDataLength => _json.MaxDataLength;
    }
}
