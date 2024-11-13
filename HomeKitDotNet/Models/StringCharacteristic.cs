using HomeKitDotNet.JSON;
using System.Text.Json;

namespace HomeKitDotNet.Models
{
    public class StringCharacteristic : CharacteristicBase
    {
        protected StringCharacteristic(Service service, CharacteristicJSON json) : base(service, json)
        {
            MapValue(json.Value);
        }

        protected async Task<bool> Write(string value)
        {
            if (!CanWrite)
                throw new InvalidOperationException("Writing is prohibited");
            CharacteristicWriteJSON write = new CharacteristicWriteJSON(service.Accessory.ID, InstanceID);
            write.Value = JsonSerializer.SerializeToElement(LastValue);
            Dictionary<string, CharacteristicWriteJSON[]> dict = new Dictionary<string, CharacteristicWriteJSON[]>();
            dict.Add("characteristics", [write]);
            return (await service.Accessory.EndPoint.Connection.Put("/characteristics", JsonSerializer.SerializeToUtf8Bytes(dict))).StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        protected async Task<string?> Read()
        {
            if (!CanRead)
                throw new InvalidOperationException("Reading is prohibited");
            HttpResponseMessage msg = await service.Accessory.EndPoint.Connection.Get($"/characteristics?id={service.Accessory.ID}.{InstanceID}");
            if (!msg.IsSuccessStatusCode)
                return null;
            CharacteristicsJSON? chars = JsonSerializer.Deserialize<CharacteristicsJSON>(msg.Content.ReadAsStream());
            if (chars == null || chars.Characteristics.Length == 0)
                return null;
            MapValue(chars.Characteristics[0].Value);
            return LastValue;
        }

        protected void MapValue(JsonElement? value)
        {
            if (value.HasValue)
            {
                if (value.Value.ValueKind == JsonValueKind.String)
                    this.LastValue = value.Value.GetString();
                else
                    throw new ArgumentException("Value Mismatch " + value);
            }
            else
                LastValue = null;
        }

        public string? LastValue { get; set; }
        public float? MaxLength => _json.MaxLength;
        public float? MaxDataLength => _json.MaxDataLength;
    }
}
