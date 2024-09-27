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

using System.Text.Json;
using System.Text.Json.Serialization;

namespace HomeKitDotNet.JSON
{
    public record CharacteristicJSON
    {
        [JsonPropertyName("type")]
        public string Type { get; init; }
        [JsonPropertyName("iid")]
        public int InstanceID { get; init; }
        [JsonPropertyName("value")]
        public JsonElement? Value { get; init; }
        [JsonPropertyName("perms")]
        public CharacteristicPermission[] Permissions { get; init; }
        [JsonPropertyName("ev")]
        public bool? EventNotifications { get; init; }
        [JsonPropertyName("description")]
        public string? Description { get; init; }
        [JsonPropertyName("format")]
        public string? Format { get; init; }
        [JsonPropertyName("unit")]
        public string? Unit { get; init; }
        [JsonPropertyName("minValue")]
        public float? MinValue { get; init; }
        [JsonPropertyName("maxValue")]
        public float? MaxValue { get; init; }
        [JsonPropertyName("minStep")]
        public float? MinStep { get; init; }
        [JsonPropertyName("maxLen")]
        public float? MaxLength { get; init; }
        [JsonPropertyName("maxDataLen")]
        public float? MaxDataLength { get; init; }
        [JsonPropertyName("valid-values")]
        public float[]? ValidValues { get; init; }
        [JsonPropertyName("valid-values-range")]
        public float[]? ValidValuesRange { get; init; }
        public long? TTL {  get; init; }
        [JsonPropertyName("pid")]
        public ulong? PID { get; init; }
    }
}
