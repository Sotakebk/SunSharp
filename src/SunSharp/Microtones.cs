using System;

namespace SunSharp
{
    /// <summary>
    /// Provides conversion methods between SunVox pitch values and frequencies in Hz.
    /// </summary>
    public static class Microtones
    {
        private const double ReferencePitch = 30720.0;
        private const double PitchScaleDivisor = 3072.0;
        private const double ReferenceFrequency = 16.333984375;

        /// <summary>
        /// Converts a SunVox pitch value to frequency in Hz.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when pitch results in an invalid frequency.</exception>
        /// <remarks>
        /// Formula: freq = 2^((30720 - pitch) / 3072) * 16.333984375
        /// </remarks>
        public static double PitchToFrequency(double pitch)
        {
            if (double.IsNaN(pitch) || double.IsInfinity(pitch))
            {
                throw new ArgumentException("Pitch must be a valid finite number.", nameof(pitch));
            }

            double result = Math.Pow(2, (ReferencePitch - pitch) / PitchScaleDivisor) * ReferenceFrequency;

            if (double.IsNaN(result) || double.IsInfinity(result))
            {
                throw new ArgumentException($"Pitch value results in an invalid frequency.", nameof(pitch));
            }

            return result;
        }

        /// <inheritdoc cref="PitchToFrequency(double)"/>
        public static float PitchToFrequency(float pitch) => (float)PitchToFrequency((double)pitch);

        /// <summary>
        /// Converts a frequency in Hz to a SunVox pitch value.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when frequency is not a positive finite number.</exception>
        /// <remarks>
        /// Formula: pitch = 30720 - log2(freq / 16.333984375) * 3072
        /// </remarks>
        public static double FrequencyToPitch(double frequency)
        {
            if (double.IsNaN(frequency) || double.IsInfinity(frequency) || frequency <= 0)
            {
                throw new ArgumentException("Frequency must be a positive finite number.", nameof(frequency));
            }

            double result = ReferencePitch - (Math.Log(frequency / ReferenceFrequency, 2) * PitchScaleDivisor);

            if (double.IsNaN(result) || double.IsInfinity(result))
            {
                throw new ArgumentException($"Frequency value results in an invalid pitch.", nameof(frequency));
            }

            return result;
        }

        /// <inheritdoc cref="FrequencyToPitch(double)"/>
        public static float FrequencyToPitch(float frequency) => (float)FrequencyToPitch((double)frequency);

        /// <summary>
        /// Converts a musical note name and octave to a SunVox pitch value.
        /// </summary>
        /// <returns>The SunVox pitch value corresponding to the given note and octave.</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <remarks>
        /// Supported range is from C0 (0x7800) to C10 (0x0000).
        /// </remarks>
        public static short NoteToPitch(NoteName noteName, int octave)
        {
            const int C0Pitch = 0x7800;
            const int PitchPerSemitone = 0x100;

            if (!noteName.IsValidNoteName())
            {
                throw new ArgumentException("Invalid note name.", nameof(noteName));
            }

            var v = noteName - NoteName.C + (octave * 12) + 1;
            var semitonesFromC0 = v - 1;
            var pitch = C0Pitch - (semitonesFromC0 * PitchPerSemitone);
            if (pitch < 0 || pitch > C0Pitch)
            {
                throw new ArgumentOutOfRangeException(nameof(octave), "The resulting pitch is out of the supported range.");
            }

            return (short)pitch;
        }
    }
}
