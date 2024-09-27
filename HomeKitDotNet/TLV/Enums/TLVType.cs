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
   public enum TLVType : byte
    {
        kTLVType_Method = 0x0,
        kTLVType_Identifier = 0x1,
        kTLVType_Salt = 0x2,
        kTLVType_PublicKey = 0x3,
        kTLVType_Proof = 0x4,
        kTLVType_EncryptedData = 0x5,
        kTLVType_State = 0x6,
        kTLVType_Error  = 0x7,
        kTLVType_RetryDelay = 0x8,
        kTLVType_Certificate = 0x9,
        kTLVType_Signature = 0xA,
        kTLVType_Permissions = 0xB,
        kTLVType_FragmentData = 0xC,
        kTLVType_FragmentLast = 0xD,
        kTLVType_Flags = 0x13,
        kTLVType_Separator = 0xFF
    }
}
