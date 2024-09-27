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
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CharacteristicPermission
    {
        /// <summary>
        /// Paired Read
        /// </summary>
        pr = 0,
        /// <summary>
        /// Paired Write
        /// </summary>
        pw = 1,
        /// <summary>
        /// Event
        /// </summary>
        ev = 2,
        /// <summary>
        /// Additional Authorization
        /// </summary>
        aa = 3,
        /// <summary>
        /// Timed Write
        /// </summary>
        tw,
        /// <summary>
        /// Hidden
        /// </summary>
        hd,
        /// <summary>
        /// Write Response
        /// </summary>
        wr
    }
}
