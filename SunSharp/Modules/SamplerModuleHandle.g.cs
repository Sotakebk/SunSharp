/*
 * Do not modify this file manually.
*/

#nullable enable

#if !GENERATION
namespace SunSharp.Modules
{
    /// <summary>
    /// Sampler can play and record audio files. Supported file formats: WAV (PCM, uncompressed), AIFF (PCM, uncompressed), XI, OGG (Vorbis), MP3, FLAC, JPEG, RAW.
    /// </summary>
    public partial interface ISamplerModuleHandle : ITypedModuleHandle
    {

        /// <summary>
        /// Value range: 0-512
        /// Original name: 0 'Volume'
        /// </summary>
        int GetVolume(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-512
        /// Original name: 0 'Volume'
        /// </summary>
        void SetVolume(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: -128-128, real: 0-256
        /// Original name: 1 'Panning'
        /// </summary>
        int GetPanning(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: -128-128, real: 0-256
        /// Original name: 1 'Panning'
        /// </summary>
        void SetPanning(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 2 'Sample interpolation'
        /// </summary>
        SamplerInterpolation GetSampleInterpolation();

        /// <summary>
        /// Original name: 2 'Sample interpolation'
        /// </summary>
        void SetSampleInterpolation(SamplerInterpolation value);

        /// <summary>
        /// Original name: 3 'Envelope interpolation'
        /// </summary>
        SamplerEnvelopeInterpolation GetEnvelopeInterpolation();

        /// <summary>
        /// Original name: 3 'Envelope interpolation'
        /// </summary>
        void SetEnvelopeInterpolation(SamplerEnvelopeInterpolation value);

        /// <summary>
        /// Value range: 1-32
        /// Original name: 4 'Polyphony'
        /// </summary>
        int GetPolyphony(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 1-32
        /// Original name: 4 'Polyphony'
        /// </summary>
        void SetPolyphony(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-10000
        /// Original name: 5 'Rec threshold'
        /// </summary>
        int GetRecThreshold(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-10000
        /// Original name: 5 'Rec threshold'
        /// </summary>
        void SetRecThreshold(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);
    }

    /// <inheritdoc cref="ISamplerModuleHandle"/>
    public readonly partial struct SamplerModuleHandle : ISamplerModuleHandle
    {
        public SynthModuleHandle ModuleHandle { get; }

        public SamplerModuleHandle(SynthModuleHandle moduleHandle)
        {
            ModuleHandle = moduleHandle;
        }

        public static implicit operator SynthModuleHandle(SamplerModuleHandle handle)
        {
            return handle.ModuleHandle;
        }

        /// <inheritdoc/>
        public bool IsCorrectHandleType()
        {
            return ModuleHandle.GetModuleType() == SynthModuleType.Sampler;
        }

        /// <inheritdoc/>
        public void AssertCorrectHandleType()
        {
            const SynthModuleType expected = SynthModuleType.Sampler;
            var actual = ModuleHandle.GetModuleType();
            if(actual != expected)
            {
                throw new IncorrectSynthHandleTypeException(expected, actual);
            }
        }

        /// <inheritdoc cref="ISamplerModuleHandle.GetVolume" />
        public int GetVolume(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(0, valueScalingMode);

        /// <inheritdoc cref="ISamplerModuleHandle.SetVolume" />
        public void SetVolume(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(0, value, valueScalingMode);

        /// <inheritdoc cref="ISamplerModuleHandle.GetPanning" />
        public int GetPanning(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(1, valueScalingMode);

        /// <inheritdoc cref="ISamplerModuleHandle.SetPanning" />
        public void SetPanning(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(1, value, valueScalingMode);

        /// <inheritdoc cref="ISamplerModuleHandle.GetSampleInterpolation" />
        public SamplerInterpolation GetSampleInterpolation() => (SamplerInterpolation)ModuleHandle.GetControllerValue(2, ValueScalingMode.Displayed);

        /// <inheritdoc cref="ISamplerModuleHandle.SetSampleInterpolation" />
        public void SetSampleInterpolation(SamplerInterpolation value) => ModuleHandle.SetControllerValue(2, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="ISamplerModuleHandle.GetEnvelopeInterpolation" />
        public SamplerEnvelopeInterpolation GetEnvelopeInterpolation() => (SamplerEnvelopeInterpolation)ModuleHandle.GetControllerValue(3, ValueScalingMode.Displayed);

        /// <inheritdoc cref="ISamplerModuleHandle.SetEnvelopeInterpolation" />
        public void SetEnvelopeInterpolation(SamplerEnvelopeInterpolation value) => ModuleHandle.SetControllerValue(3, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="ISamplerModuleHandle.GetPolyphony" />
        public int GetPolyphony(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(4, valueScalingMode);

        /// <inheritdoc cref="ISamplerModuleHandle.SetPolyphony" />
        public void SetPolyphony(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(4, value, valueScalingMode);

        /// <inheritdoc cref="ISamplerModuleHandle.GetRecThreshold" />
        public int GetRecThreshold(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(5, valueScalingMode);

        /// <inheritdoc cref="ISamplerModuleHandle.SetRecThreshold" />
        public void SetRecThreshold(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(5, value, valueScalingMode);
    }
}
#endif
