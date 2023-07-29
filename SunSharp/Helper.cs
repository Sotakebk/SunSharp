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
                    nonZeroValues++;
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

        // this code is translated from sunvox.h

        /// <summary>
        /// Get x, y position from one xy value received from sv_get_module_xy(int, int).
        /// </summary>
        public static (short x, short y) SplitValueTo2DPosition(uint xy)
        {
            var x = xy & 0xFFFF;
            var y = (xy >> 16) & 0xFFFF;
            return (ToShortBitwise(x), ToShortBitwise(y));
        }

        /// <summary>
        /// Get fine-tune and relative note value from packed fine-tune value received from sv_get_module_finetune(int, int).
        /// </summary>
        public static (short fineTune, short relativeNote) SplitValueToFineTune(uint packedFineTune)
        {
            var outFineTune = packedFineTune & 0xFFFF;
            var outRelativeNote = (packedFineTune >> 16) & 0xFFFF;
            return (ToShortBitwise(outFineTune), ToShortBitwise(outRelativeNote));
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
            return 30720.0 - Math.Log(frequency / 16.333984375, 2) * 3072.0;
        }

        #endregion macros
    }
}
