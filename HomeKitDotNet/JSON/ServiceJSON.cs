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

using System.Text.Json.Serialization;

namespace HomeKitDotNet.JSON
{
    public record ServiceJSON
    {
        [JsonPropertyName("type")]
        public string Type { get; init; }
        [JsonPropertyName("iid")]
        public int InstanceID {  get; init; }
        [JsonPropertyName("characteristics")]
        public CharacteristicJSON[] Characteristics { get; init; }
        [JsonPropertyName("hidden")]
        public bool HiddenService { get; init; }
        [JsonPropertyName("primary")]
        public bool PrimaryService { get; init; }
        [JsonPropertyName("linked")]
        public int[] LinkedServices { get; init; }
    }
}
