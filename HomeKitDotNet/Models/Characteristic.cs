// HomeKitDotNet Copyright (C) 2024 
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as published by
// the Free Software Foundation, either version 3 of the License, or any later version.
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY, without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
// See the GNU Affero General Public License for more details.
// You should have received a copy of the GNU Affero General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using HomeKitDotNet.JSON;
using System.Text.Json;

namespace HomeKitDotNet.Models
{
    public class Characteristic<T> : ICharacteristic where T : struct
    {
        private Service service;
        private CharacteristicJSON _json;
        protected Characteristic(Service service, CharacteristicJSON json)
        {
            this.service = service;
            this._json = json;
            this.Type = json.Type;
            MapValue(json.Value);
        }

        protected async Task<bool> Write(T value)
        {
            if (!CanWrite)
                throw new InvalidOperationException("Writing is prohibited");
            CharacteristicWriteJSON write = new CharacteristicWriteJSON(service.Accessory.ID, InstanceID);
            write.Value = JsonSerializer.SerializeToElement(LastValue);
            Dictionary<string, CharacteristicWriteJSON[]> dict = new Dictionary<string, CharacteristicWriteJSON[]>();
            dict.Add("characteristics", [write]);
            return (await service.Accessory.EndPoint.Connection.Put("/characteristics", JsonSerializer.SerializeToUtf8Bytes(dict))).StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        protected async Task<T?> Read()
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

        protected async Task Subscribe()
        {
            if (!CanSubscribe)
                throw new InvalidOperationException("Subscriptions are prohibited");
            //TODO
        }

        protected void MapValue(JsonElement? value)
        {
            if (value.HasValue)
            {
                if (typeof(T) == typeof(float) && value.Value.ValueKind == JsonValueKind.Number)
                    this.LastValue = (T)(object)value.Value.GetSingle();
                else if (typeof(T) == typeof(int) && value.Value.ValueKind == JsonValueKind.Number)
                    this.LastValue = (T)(object)value.Value.GetInt32();
                else if (typeof(T) == typeof(string) && value.Value.ValueKind == JsonValueKind.String)
                    this.LastValue = (T?)(object?)value.Value.GetString();
                else if (typeof(T) == typeof(byte) && value.Value.ValueKind == JsonValueKind.Number)
                    this.LastValue = (T)(object)value.Value.GetByte();
                else if (typeof(T) == typeof(ushort) && value.Value.ValueKind == JsonValueKind.Number)
                    this.LastValue = (T)(object)value.Value.GetUInt16();
                else if (typeof(T) == typeof(uint) && value.Value.ValueKind == JsonValueKind.Number)
                    this.LastValue = (T)(object)value.Value.GetUInt32();
                else if (typeof(T) == typeof(ulong) && value.Value.ValueKind == JsonValueKind.Number)
                    this.LastValue = (T)(object)value.Value.GetUInt64();
                else if (typeof(T) == typeof(bool) && (value.Value.ValueKind == JsonValueKind.True || value.Value.ValueKind == JsonValueKind.False))
                    this.LastValue = (T)(object)value.Value.GetBoolean();
                else if (typeof(T) == typeof(Enum) && value.Value.ValueKind == JsonValueKind.Number)
                    this.LastValue = (T)(object)value.Value.GetUInt32();
                else
                    throw new ArgumentException("Value Mismatch " + value);
            }
            else
                LastValue = null;
        }

        public string Type { get; init; }
        public T? LastValue { get; private set; }
        public int InstanceID => _json.InstanceID;
        public CharacteristicPermission[] Permissions => _json.Permissions;
        public string? Description => _json.Description;
        public string? Unit => _json.Description;
        public float? MinValue => _json.MinValue;
        public float? MaxValue => _json.MaxValue;
        public float? MinStep => _json.MinStep;
        public float[]? ValidValues => _json.ValidValues;
        public float[]? ValidValuesRange => _json.ValidValuesRange;


        public bool CanRead { get { return Permissions.Contains(CharacteristicPermission.pr); } }
        public bool CanWrite { get { return Permissions.Contains(CharacteristicPermission.pw); } }
        public bool CanSubscribe { get { return Permissions.Contains(CharacteristicPermission.ev); } }
    }
}
