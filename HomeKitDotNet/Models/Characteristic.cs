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
    public class Characteristic<T> : CharacteristicBase where T : struct
    {
        public delegate Task AsyncEventHandler<TEventArgs>(Service service, Characteristic<TEventArgs> characteristic, TEventArgs? newValue) where TEventArgs : struct;
        public event AsyncEventHandler<T>? Updated;
        protected Characteristic(Service service, CharacteristicJSON json) : base(service, json)
        {
            this.LastValue = MapValue(json.Value);
        }

        protected async Task<bool> Write(T value, CancellationToken token = default)
        {
            if (!CanWrite)
                throw new InvalidOperationException("Writing is prohibited");
            CharacteristicValueJSON write = new CharacteristicValueJSON(service.Accessory.ID, InstanceID);
            write.Value = JsonSerializer.SerializeToElement(value);
            Dictionary<string, CharacteristicValueJSON[]> dict = new Dictionary<string, CharacteristicValueJSON[]>();
            dict.Add("characteristics", [write]);
            return (await service.Accessory.EndPoint.Connection.Put("/characteristics", JsonSerializer.SerializeToUtf8Bytes(dict), token)).StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        protected async Task<T?> Read(CancellationToken token = default)
        {
            if (!CanRead)
                throw new InvalidOperationException("Reading is prohibited");
            HttpResponseMessage msg = await service.Accessory.EndPoint.Connection.Get($"/characteristics?id={service.Accessory.ID}.{InstanceID}", token);
            if (!msg.IsSuccessStatusCode)
                return null;
            CharacteristicsJSON? chars = JsonSerializer.Deserialize<CharacteristicsJSON>(msg.Content.ReadAsStream());
            if (chars == null || chars.Characteristics.Length == 0)
                return null;
            this.LastValue = MapValue(chars.Characteristics[0].Value);
            return LastValue;
        }

        protected T? MapValue(JsonElement? value)
        {
            if (value.HasValue)
            {
                if (typeof(T).IsEnum && Enum.GetUnderlyingType(typeof(T)) == typeof(byte) && value.Value.ValueKind == JsonValueKind.Number)
                    return (T)(object)value.Value.GetByte();
                if (typeof(T) == typeof(float) && value.Value.ValueKind == JsonValueKind.Number)
                    return (T)(object)value.Value.GetSingle();
                else if (typeof(T) == typeof(int) && value.Value.ValueKind == JsonValueKind.Number)
                    return (T)(object)value.Value.GetInt32();
                else if (typeof(T) == typeof(string) && value.Value.ValueKind == JsonValueKind.String)
                    return (T?)(object?)value.Value.GetString();
                else if (typeof(T) == typeof(byte) && value.Value.ValueKind == JsonValueKind.Number)
                    return (T)(object)value.Value.GetByte();
                else if (typeof(T) == typeof(ushort) && value.Value.ValueKind == JsonValueKind.Number)
                    return (T)(object)value.Value.GetUInt16();
                else if (typeof(T) == typeof(uint) && value.Value.ValueKind == JsonValueKind.Number)
                    return   (T)(object)value.Value.GetUInt32();
                else if (typeof(T) == typeof(ulong) && value.Value.ValueKind == JsonValueKind.Number)
                    return (T)(object)value.Value.GetUInt64();
                else if (typeof(T) == typeof(bool) && (value.Value.ValueKind == JsonValueKind.True || value.Value.ValueKind == JsonValueKind.False))
                    return (T)(object)value.Value.GetBoolean();
                else if (typeof(T) == typeof(Enum) && value.Value.ValueKind == JsonValueKind.Number)
                    return (T)(object)value.Value.GetUInt32();
                else
                    throw new ArgumentException("Value Mismatch " + value);
            }
            else
                return null;
        }

        internal override void FireUpdate(JsonElement? value)
        {
            T? newVal = MapValue(value);
            if (Updated != null)
                Updated.Invoke(service, this, newVal);
            LastValue = newVal;
        }

        public T? LastValue { get; private set; }
        public float? MinValue => _json.MinValue;
        public float? MaxValue => _json.MaxValue;
        public float? MinStep => _json.MinStep;
        public float[]? ValidValues => _json.ValidValues;
        public float[]? ValidValuesRange => _json.ValidValuesRange;
    }
}
