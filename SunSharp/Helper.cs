using System;
using System.Runtime.InteropServices;

namespace SunSharp
{
    public static class Helper
    {
        public static short ToShortBitwise(uint value)
        {
            if ((value & 0x8000) == 0)
                return (short)value;

            var val = (int)value;
            return (short)(val - 0x10000);
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

        public static float PitchToFrequency(float pitch)
        {
            return (float)PitchToFrequency((double)pitch);
        }

        // from SunVox pitch to Hz: freq = pow( 2, ( 30720 - pitch ) / 3072 ) * 16.333984375
        public static double PitchToFrequency(double pitch)
        {
            return Math.Pow(2, (30720.0 - pitch) / 3072.0) * 16.333984375;
        }

        public static float FrequencyToPitch(float frequency)
        {
            return (float)FrequencyToPitch((double)frequency);
        }

        // from Hz to SunVox pitch: pitch = 30720 - log2( freq / 16.333984375 ) * 3072
        public static double FrequencyToPitch(double frequency)
        {
            return 30720.0 - (Math.Log(frequency / 16.333984375, 2) * 3072.0);
        }

        #endregion macros
    }
}
