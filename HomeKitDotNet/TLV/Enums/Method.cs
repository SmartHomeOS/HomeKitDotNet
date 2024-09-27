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

namespace HomeKitDotNet.TLV.Enums
{
    public enum Method : byte
    {
        PairSetup = 0x0,
        PairSetupWithAuth = 0x1,
        PairVerify = 0x2,
        AddPairing = 0x3,
        RemovePairing = 0x4,
        ListPairings = 0x5
    }
}
