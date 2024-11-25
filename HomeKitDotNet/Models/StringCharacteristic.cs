using HomeKitDotNet.JSON;
using System.Text.Json;

namespace HomeKitDotNet.Models
{
    public class StringCharacteristic : CharacteristicBase
    {
        public delegate Task AsyncEventHandler(Service service, StringCharacteristic characteristic, string? newValue);
        public event AsyncEventHandler? Updated;
        protected StringCharacteristic(Service service, CharacteristicJSON json) : base(service, json)
        {
            LastValue = MapValue(json.Value);
        }

        protected async Task<bool> Write(string value, CancellationToken token = default)
        {
            if (!CanWrite)
                throw new InvalidOperationException("Writing is prohibited");
            CharacteristicValueJSON write = new CharacteristicValueJSON(service.Accessory.ID, InstanceID);
            write.Value = JsonSerializer.SerializeToElement(value);
            Dictionary<string, CharacteristicValueJSON[]> dict = new Dictionary<string, CharacteristicValueJSON[]>();
            dict.Add("characteristics", [write]);
            return (await service.Accessory.EndPoint.Connection.PutJson("/characteristics", JsonSerializer.SerializeToUtf8Bytes(dict), token)).StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        protected async Task<string?> Read(CancellationToken token = default)
        {
            if (!CanRead)
                throw new InvalidOperationException("Reading is prohibited");
            HttpResponseMessage msg = await service.Accessory.EndPoint.Connection.Get($"/characteristics?id={service.Accessory.ID}.{InstanceID}", token);
            if (!msg.IsSuccessStatusCode)
                return null;
            CharacteristicsJSON? chars = JsonSerializer.Deserialize<CharacteristicsJSON>(msg.Content.ReadAsStream());
            if (chars == null || chars.Characteristics.Length == 0)
                return null;
            LastValue = MapValue(chars.Characteristics[0].Value);
            return LastValue;
        }

        protected string? MapValue(JsonElement? value)
        {
            if (value.HasValue)
            {
                if (value.Value.ValueKind == JsonValueKind.String)
                    return value.Value.GetString();
                else
                    throw new ArgumentException("Value Mismatch " + value);
            }
            else
                return null;
        }

        internal override void FireUpdate(JsonElement? value)
        {
            string? newVal = MapValue(value);
            if (Updated != null)
                Updated.Invoke(service, this, newVal);
            LastValue = newVal;
        }

        public string? LastValue { get; set; }
        public float? MaxLength => _json.MaxLength;
        public float? MaxDataLength => _json.MaxDataLength;
    }
}
