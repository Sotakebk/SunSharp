using System;
using System.Runtime.InteropServices;

namespace SunSharp
{
    public static class UtilityHelper
    {
        public static short ToShortBitwise(uint value)
        {
            return unchecked((short)(ushort)value);
        }

        public static int[] CopyIntArraySkipNegativeOnes(IntPtr address, int count)
        {
            if (address == IntPtr.Zero)
            {
                return Array.Empty<int>();
            }

            var nonZeroValues = 0;
            for (var i = 0; i < count; i++)
            {
                if (Marshal.ReadInt32(address, i * sizeof(int)) != -1)
                {
                    nonZeroValues++;
                }
            }

            var arr = new int[nonZeroValues];

            var index = 0;
            for (var i = 0; i < count; i++)
            {
                var value = Marshal.ReadInt32(address, i * sizeof(int));
                if (value == -1)
                    continue;

                arr[index] = value;
                index++;
            }

            return arr;
        }

        #region macros

        // this code is translated from sunvox.h, adapted to C#

        // use to split position and fine-tune
        public static (short lowerBytes, short upperBytes) UnpackTwoSignedShorts(uint value)
        {
            var x = value & 0xFFFF;
            var y = (value >> 16) & 0xFFFF;
            return (unchecked((short)x), unchecked((short)y));
        }

        public static uint PackTwoSignedShorts(short lowerBytes, short upperBytes)
        {
            return unchecked((ushort)lowerBytes) | ((uint)upperBytes << 16);
        }

        #endregion macros
    }
}
