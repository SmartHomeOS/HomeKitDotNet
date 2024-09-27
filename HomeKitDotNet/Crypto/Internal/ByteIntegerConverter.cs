﻿//Public Domain
using System.Collections.Generic;
using System.Numerics;

namespace HomeKitDotNet.Crypto.Internal
{
    // Loops? Arrays? Never heard of that stuff
    // Library avoids unnecessary heap allocations and unsafe code
    // so this ugly code becomes necessary :(
    internal static class ByteIntegerConverter
    {
        #region Individual

        public static uint LoadLittleEndian32(byte[] buf, int offset)
        {
            return
                buf[offset + 0]
            | (uint)buf[offset + 1] << 8
            | (uint)buf[offset + 2] << 16
            | (uint)buf[offset + 3] << 24;
        }

        public static void StoreLittleEndian32(byte[] buf, int offset, uint value)
        {
            buf[offset + 0] = unchecked((byte)value);
            buf[offset + 1] = unchecked((byte)(value >> 8));
            buf[offset + 2] = unchecked((byte)(value >> 16));
            buf[offset + 3] = unchecked((byte)(value >> 24));
        }

        public static ulong LoadBigEndian64(byte[] buf, int offset)
        {
            return
                buf[offset + 7]
                | (ulong)buf[offset + 6] << 8
                | (ulong)buf[offset + 5] << 16
                | (ulong)buf[offset + 4] << 24
                | (ulong)buf[offset + 3] << 32
                | (ulong)buf[offset + 2] << 40
                | (ulong)buf[offset + 1] << 48
                | (ulong)buf[offset + 0] << 56;
        }

        public static void StoreBigEndian64(byte[] buf, int offset, ulong value)
        {
            buf[offset + 7] = unchecked((byte)value);
            buf[offset + 6] = unchecked((byte)(value >> 8));
            buf[offset + 5] = unchecked((byte)(value >> 16));
            buf[offset + 4] = unchecked((byte)(value >> 24));
            buf[offset + 3] = unchecked((byte)(value >> 32));
            buf[offset + 2] = unchecked((byte)(value >> 40));
            buf[offset + 1] = unchecked((byte)(value >> 48));
            buf[offset + 0] = unchecked((byte)(value >> 56));
        }

        #endregion

        #region Array8

        public static void Array8LoadLittleEndian32(out Array8<uint> output, byte[] input, int inputOffset)
        {
            output.x0 = LoadLittleEndian32(input, inputOffset + 0);
            output.x1 = LoadLittleEndian32(input, inputOffset + 4);
            output.x2 = LoadLittleEndian32(input, inputOffset + 8);
            output.x3 = LoadLittleEndian32(input, inputOffset + 12);
            output.x4 = LoadLittleEndian32(input, inputOffset + 16);
            output.x5 = LoadLittleEndian32(input, inputOffset + 20);
            output.x6 = LoadLittleEndian32(input, inputOffset + 24);
            output.x7 = LoadLittleEndian32(input, inputOffset + 28);
        }

        /*        public static void Array8LoadLittleEndian32(out Array8<uint> output, byte[] input, int inputOffset, int inputLength)
                {
        #if DEBUG
                    if (inputLength <= 0)
                        throw new ArgumentException();
        #endif
                    int inputEnd = inputOffset + inputLength;
                    UInt32 highestInt;
                    switch (inputLength & 3)
                    {
                        case 1:
                            highestInt = input[inputEnd - 1];
                            break;
                        case 2:
                            highestInt = (uint)(
                                (input[inputEnd - 1] << 8) |
                                (input[inputEnd - 2]));
                            break;
                        case 3:
                            highestInt = (uint)(
                                (input[inputEnd - 1] << 16) |
                                (input[inputEnd - 2] << 8) |
                                (input[inputEnd - 3]));
                            break;
                        case 0:
                            highestInt = (uint)(
                                (input[inputEnd - 1] << 24) |
                                (input[inputEnd - 2] << 16) |
                                (input[inputEnd - 3] << 8) |
                                (input[inputEnd - 4]));
                            break;
                        default:
                            throw new InvalidOperationException();
                    }
                    switch ((inputLength - 1) >> 2)
                    {
                        case 7:
                            output.x7 = highestInt;
                            output.x6 = LoadLittleEndian32(input, inputOffset + 6 * 4);
                            output.x5 = LoadLittleEndian32(input, inputOffset + 5 * 4);
                            output.x4 = LoadLittleEndian32(input, inputOffset + 4 * 4);
                            output.x3 = LoadLittleEndian32(input, inputOffset + 3 * 4);
                            output.x2 = LoadLittleEndian32(input, inputOffset + 2 * 4);
                            output.x1 = LoadLittleEndian32(input, inputOffset + 1 * 4);
                            output.x0 = LoadLittleEndian32(input, inputOffset + 0 * 4);
                            return;
                        case 6:
                            output.x7 = 0;
                            output.x6 = highestInt;
                            output.x5 = LoadLittleEndian32(input, inputOffset + 5 * 4);
                            output.x4 = LoadLittleEndian32(input, inputOffset + 4 * 4);
                            output.x3 = LoadLittleEndian32(input, inputOffset + 3 * 4);
                            output.x2 = LoadLittleEndian32(input, inputOffset + 2 * 4);
                            output.x1 = LoadLittleEndian32(input, inputOffset + 1 * 4);
                            output.x0 = LoadLittleEndian32(input, inputOffset + 0 * 4);
                            return;
                        case 5:
                            output.x7 = 0;
                            output.x6 = 0;
                            output.x5 = highestInt;
                            output.x4 = LoadLittleEndian32(input, inputOffset + 4 * 4);
                            output.x3 = LoadLittleEndian32(input, inputOffset + 3 * 4);
                            output.x2 = LoadLittleEndian32(input, inputOffset + 2 * 4);
                            output.x1 = LoadLittleEndian32(input, inputOffset + 1 * 4);
                            output.x0 = LoadLittleEndian32(input, inputOffset + 0 * 4);
                            return;
                        case 4:
                            output.x7 = 0;
                            output.x6 = 0;
                            output.x5 = 0;
                            output.x4 = highestInt;
                            output.x3 = LoadLittleEndian32(input, inputOffset + 3 * 4);
                            output.x2 = LoadLittleEndian32(input, inputOffset + 2 * 4);
                            output.x1 = LoadLittleEndian32(input, inputOffset + 1 * 4);
                            output.x0 = LoadLittleEndian32(input, inputOffset + 0 * 4);
                            return;
                        case 3:
                            output.x7 = 0;
                            output.x6 = 0;
                            output.x5 = 0;
                            output.x4 = 0;
                            output.x3 = highestInt;
                            output.x2 = LoadLittleEndian32(input, inputOffset + 2 * 4);
                            output.x1 = LoadLittleEndian32(input, inputOffset + 1 * 4);
                            output.x0 = LoadLittleEndian32(input, inputOffset + 0 * 4);
                            return;
                        case 2:
                            output.x7 = 0;
                            output.x6 = 0;
                            output.x5 = 0;
                            output.x4 = 0;
                            output.x3 = 0;
                            output.x2 = highestInt;
                            output.x1 = LoadLittleEndian32(input, inputOffset + 1 * 4);
                            output.x0 = LoadLittleEndian32(input, inputOffset + 0 * 4);
                            return;
                        case 1:
                            output.x7 = 0;
                            output.x6 = 0;
                            output.x5 = 0;
                            output.x4 = 0;
                            output.x3 = 0;
                            output.x2 = 0;
                            output.x1 = highestInt;
                            output.x0 = LoadLittleEndian32(input, inputOffset + 0 * 4);
                            return;
                        case 0:
                            output.x7 = 0;
                            output.x6 = 0;
                            output.x5 = 0;
                            output.x4 = 0;
                            output.x3 = 0;
                            output.x2 = 0;
                            output.x1 = 0;
                            output.x0 = highestInt;
                            return;
                        default:
                            throw new InvalidOperationException();
                    }
                }*/

        /*public static void Array8XorLittleEndian(byte[] output, int outputOffset, byte[] input, int inputOffset, ref Array8<uint> keyStream, int length)
        {
#if DEBUG
            InternalAssert(length > 0);
#endif
            int outputEnd = outputOffset + length;
            UInt32 highestInt;
            switch ((length - 1) >> 2)
            {
                case 7:
                    highestInt = keyStream.x7;
                    XorLittleEndian32(output, outputOffset + 6 * 4, input, inputOffset + 6 * 4, keyStream.x6);
                    XorLittleEndian32(output, outputOffset + 5 * 4, input, inputOffset + 6 * 4, keyStream.x5);
                    XorLittleEndian32(output, outputOffset + 4 * 4, input, inputOffset + 6 * 4, keyStream.x4);
                    XorLittleEndian32(output, outputOffset + 3 * 4, input, inputOffset + 6 * 4, keyStream.x3);
                    XorLittleEndian32(output, outputOffset + 2 * 4, input, inputOffset + 6 * 4, keyStream.x2);
                    XorLittleEndian32(output, outputOffset + 1 * 4, input, inputOffset + 6 * 4, keyStream.x1);
                    XorLittleEndian32(output, outputOffset + 0 * 4, input, inputOffset + 6 * 4, keyStream.x0);
                    break;
                case 6:
                    highestInt = keyStream.x6;
                    XorLittleEndian32(output, outputOffset + 5 * 4, input, inputOffset + 6 * 4, keyStream.x5);
                    XorLittleEndian32(output, outputOffset + 4 * 4, input, inputOffset + 6 * 4, keyStream.x4);
                    XorLittleEndian32(output, outputOffset + 3 * 4, input, inputOffset + 6 * 4, keyStream.x3);
                    XorLittleEndian32(output, outputOffset + 2 * 4, input, inputOffset + 6 * 4, keyStream.x2);
                    XorLittleEndian32(output, outputOffset + 1 * 4, input, inputOffset + 6 * 4, keyStream.x1);
                    XorLittleEndian32(output, outputOffset + 0 * 4, input, inputOffset + 6 * 4, keyStream.x0);
                    break;
                case 5:
                    highestInt = keyStream.x5;
                    XorLittleEndian32(output, outputOffset + 4 * 4, input, inputOffset + 6 * 4, keyStream.x4);
                    XorLittleEndian32(output, outputOffset + 3 * 4, input, inputOffset + 6 * 4, keyStream.x3);
                    XorLittleEndian32(output, outputOffset + 2 * 4, input, inputOffset + 6 * 4, keyStream.x2);
                    XorLittleEndian32(output, outputOffset + 1 * 4, input, inputOffset + 6 * 4, keyStream.x1);
                    XorLittleEndian32(output, outputOffset + 0 * 4, input, inputOffset + 6 * 4, keyStream.x0);
                    break;
                case 4:
                    highestInt = keyStream.x4;
                    XorLittleEndian32(output, outputOffset + 3 * 4, input, inputOffset + 6 * 4, keyStream.x3);
                    XorLittleEndian32(output, outputOffset + 2 * 4, input, inputOffset + 6 * 4, keyStream.x2);
                    XorLittleEndian32(output, outputOffset + 1 * 4, input, inputOffset + 6 * 4, keyStream.x1);
                    XorLittleEndian32(output, outputOffset + 0 * 4, input, inputOffset + 6 * 4, keyStream.x0);
                    break;
                case 3:
                    highestInt = keyStream.x3;
                    XorLittleEndian32(output, outputOffset + 2 * 4, input, inputOffset + 6 * 4, keyStream.x2);
                    XorLittleEndian32(output, outputOffset + 1 * 4, input, inputOffset + 6 * 4, keyStream.x1);
                    XorLittleEndian32(output, outputOffset + 0 * 4, input, inputOffset + 6 * 4, keyStream.x0);
                    break;
                case 2:
                    highestInt = keyStream.x2;
                    XorLittleEndian32(output, outputOffset + 1 * 4, input, inputOffset + 6 * 4, keyStream.x1);
                    XorLittleEndian32(output, outputOffset + 0 * 4, input, inputOffset + 6 * 4, keyStream.x0);
                    break;
                case 1:
                    highestInt = keyStream.x1;
                    XorLittleEndian32(output, outputOffset + 0 * 4, input, inputOffset + 6 * 4, keyStream.x0);
                    break;
                case 0:
                    highestInt = keyStream.x0;
                    break;
                default:
                    throw new InvalidOperationException();
            }
            switch (length & 3)
            {
                case 1:
                    output[outputEnd - 1] ^= (byte)highestInt;
                    break;
                case 2:
                    output[outputEnd - 1] ^= (byte)(highestInt >> 8);
                    output[outputEnd - 2] ^= (byte)highestInt;
                    break;
                case 3:
                    output[outputEnd - 1] ^= (byte)(highestInt >> 16);
                    output[outputEnd - 2] ^= (byte)(highestInt >> 8);
                    output[outputEnd - 3] ^= (byte)highestInt;
                    break;
                case 0:
                    output[outputEnd - 1] ^= (byte)(highestInt >> 24);
                    output[outputEnd - 2] ^= (byte)(highestInt >> 16);
                    output[outputEnd - 3] ^= (byte)(highestInt >> 8);
                    output[outputEnd - 4] ^= (byte)highestInt;
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }*/

        /*public static void Array8StoreLittleEndian32(byte[] output, int outputOffset, ref Array8<uint> input)
        {
            StoreLittleEndian32(output, outputOffset + 0, input.x0);
            StoreLittleEndian32(output, outputOffset + 4, input.x1);
            StoreLittleEndian32(output, outputOffset + 8, input.x2);
            StoreLittleEndian32(output, outputOffset + 12, input.x3);
            StoreLittleEndian32(output, outputOffset + 16, input.x4);
            StoreLittleEndian32(output, outputOffset + 20, input.x5);
            StoreLittleEndian32(output, outputOffset + 24, input.x6);
            StoreLittleEndian32(output, outputOffset + 28, input.x7);
        }*/
        #endregion

        public static void Array16LoadBigEndian64(out Array16<ulong> output, byte[] input, int inputOffset)
        {
            output.x0 = LoadBigEndian64(input, inputOffset + 0);
            output.x1 = LoadBigEndian64(input, inputOffset + 8);
            output.x2 = LoadBigEndian64(input, inputOffset + 16);
            output.x3 = LoadBigEndian64(input, inputOffset + 24);
            output.x4 = LoadBigEndian64(input, inputOffset + 32);
            output.x5 = LoadBigEndian64(input, inputOffset + 40);
            output.x6 = LoadBigEndian64(input, inputOffset + 48);
            output.x7 = LoadBigEndian64(input, inputOffset + 56);
            output.x8 = LoadBigEndian64(input, inputOffset + 64);
            output.x9 = LoadBigEndian64(input, inputOffset + 72);
            output.x10 = LoadBigEndian64(input, inputOffset + 80);
            output.x11 = LoadBigEndian64(input, inputOffset + 88);
            output.x12 = LoadBigEndian64(input, inputOffset + 96);
            output.x13 = LoadBigEndian64(input, inputOffset + 104);
            output.x14 = LoadBigEndian64(input, inputOffset + 112);
            output.x15 = LoadBigEndian64(input, inputOffset + 120);
        }
    }
}
