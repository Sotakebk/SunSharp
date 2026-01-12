/*
 * Do not modify this file manually.
*/

#nullable enable

#if !GENERATION
namespace SunSharp.Modules
{
    /// <summary>
    /// Frequency Modulation (FM) Synthesizer. Each voice of polyphony includes two operators with ADSR envelopes: 1) C (carrier) - base sine wave generator; 2) M (modulator) - sine wave that changes the frequency of the first operator. The sound quality of this module is better at a sample rate of 44100Hz.
    /// </summary>
    public partial interface IFmModuleHandle : ITypedModuleHandle
    {

        /// <summary>
        /// Value range: 0-256
        /// Original name: 0 'C.Volume'
        /// </summary>
        int GetCarrierVolume(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 0 'C.Volume'
        /// </summary>
        void SetCarrierVolume(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 1 'M.Volume'
        /// </summary>
        int GetModulatorVolume(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 1 'M.Volume'
        /// </summary>
        void SetModulatorVolume(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: -128-128, real: 0-256
        /// Original name: 2 'Panning'
        /// </summary>
        int GetPanning(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: -128-128, real: 0-256
        /// Original name: 2 'Panning'
        /// </summary>
        void SetPanning(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-16
        /// Original name: 3 'C.Freq ratio'
        /// </summary>
        int GetCarrierFrequencyRatio(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-16
        /// Original name: 3 'C.Freq ratio'
        /// </summary>
        void SetCarrierFrequencyRatio(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-16
        /// Original name: 4 'M.Freq ratio'
        /// </summary>
        int GetModulatorFrequencyRatio(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-16
        /// Original name: 4 'M.Freq ratio'
        /// </summary>
        void SetModulatorFrequencyRatio(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 5 'M.Self-modulation'
        /// </summary>
        int GetModulatorSelfModulation(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 5 'M.Self-modulation'
        /// </summary>
        void SetModulatorSelfModulation(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-512
        /// Original name: 6 'C.Attack'
        /// </summary>
        int GetCarrierAttack(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-512
        /// Original name: 6 'C.Attack'
        /// </summary>
        void SetCarrierAttack(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-512
        /// Original name: 7 'C.Decay'
        /// </summary>
        int GetCarrierDecay(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-512
        /// Original name: 7 'C.Decay'
        /// </summary>
        void SetCarrierDecay(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 8 'C.Sustain'
        /// </summary>
        int GetCarrierSustain(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 8 'C.Sustain'
        /// </summary>
        void SetCarrierSustain(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-512
        /// Original name: 9 'C.Release'
        /// </summary>
        int GetCarrierRelease(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-512
        /// Original name: 9 'C.Release'
        /// </summary>
        void SetCarrierRelease(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-512
        /// Original name: 10 'M.Attack'
        /// </summary>
        int GetModulatorAttack(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-512
        /// Original name: 10 'M.Attack'
        /// </summary>
        void SetModulatorAttack(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-512
        /// Original name: 11 'M.Decay'
        /// </summary>
        int GetModulatorDecay(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-512
        /// Original name: 11 'M.Decay'
        /// </summary>
        void SetModulatorDecay(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 12 'M.Sustain'
        /// </summary>
        int GetModulatorSustain(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 12 'M.Sustain'
        /// </summary>
        void SetModulatorSustain(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-512
        /// Original name: 13 'M.Release'
        /// </summary>
        int GetModulatorRelease(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-512
        /// Original name: 13 'M.Release'
        /// </summary>
        void SetModulatorRelease(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-4
        /// Original name: 14 'M.Scaling per key'
        /// </summary>
        int GetModulatorScalingPerKey(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-4
        /// Original name: 14 'M.Scaling per key'
        /// </summary>
        void SetModulatorScalingPerKey(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 1-16
        /// Original name: 15 'Polyphony'
        /// </summary>
        int GetPolyphony(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 1-16
        /// Original name: 15 'Polyphony'
        /// </summary>
        void SetPolyphony(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 16 'Mode'
        /// </summary>
        Quality GetMode();

        /// <summary>
        /// Original name: 16 'Mode'
        /// </summary>
        void SetMode(Quality value);
    }

    /// <inheritdoc cref="IFmModuleHandle"/>
    public readonly partial struct FmModuleHandle : IFmModuleHandle
    {
        public SynthModuleHandle ModuleHandle { get; }

        public FmModuleHandle(SynthModuleHandle moduleHandle)
        {
            ModuleHandle = moduleHandle;
        }

        public static implicit operator SynthModuleHandle(FmModuleHandle handle)
        {
            return handle.ModuleHandle;
        }

        /// <inheritdoc/>
        public bool IsCorrectHandleType()
        {
            return ModuleHandle.GetModuleType() == SynthModuleType.Fm;
        }

        /// <inheritdoc/>
        public void AssertCorrectHandleType()
        {
            const SynthModuleType expected = SynthModuleType.Fm;
            var actual = ModuleHandle.GetModuleType();
            if(actual != expected)
            {
                throw new IncorrectSynthHandleTypeException(expected, actual);
            }
        }

        /// <inheritdoc cref="IFmModuleHandle.GetCarrierVolume" />
        public int GetCarrierVolume(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(0, valueScalingMode);

        /// <inheritdoc cref="IFmModuleHandle.SetCarrierVolume" />
        public void SetCarrierVolume(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(0, value, valueScalingMode);

        /// <inheritdoc cref="IFmModuleHandle.GetModulatorVolume" />
        public int GetModulatorVolume(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(1, valueScalingMode);

        /// <inheritdoc cref="IFmModuleHandle.SetModulatorVolume" />
        public void SetModulatorVolume(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(1, value, valueScalingMode);

        /// <inheritdoc cref="IFmModuleHandle.GetPanning" />
        public int GetPanning(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(2, valueScalingMode);

        /// <inheritdoc cref="IFmModuleHandle.SetPanning" />
        public void SetPanning(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(2, value, valueScalingMode);

        /// <inheritdoc cref="IFmModuleHandle.GetCarrierFrequencyRatio" />
        public int GetCarrierFrequencyRatio(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(3, valueScalingMode);

        /// <inheritdoc cref="IFmModuleHandle.SetCarrierFrequencyRatio" />
        public void SetCarrierFrequencyRatio(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(3, value, valueScalingMode);

        /// <inheritdoc cref="IFmModuleHandle.GetModulatorFrequencyRatio" />
        public int GetModulatorFrequencyRatio(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(4, valueScalingMode);

        /// <inheritdoc cref="IFmModuleHandle.SetModulatorFrequencyRatio" />
        public void SetModulatorFrequencyRatio(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(4, value, valueScalingMode);

        /// <inheritdoc cref="IFmModuleHandle.GetModulatorSelfModulation" />
        public int GetModulatorSelfModulation(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(5, valueScalingMode);

        /// <inheritdoc cref="IFmModuleHandle.SetModulatorSelfModulation" />
        public void SetModulatorSelfModulation(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(5, value, valueScalingMode);

        /// <inheritdoc cref="IFmModuleHandle.GetCarrierAttack" />
        public int GetCarrierAttack(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(6, valueScalingMode);

        /// <inheritdoc cref="IFmModuleHandle.SetCarrierAttack" />
        public void SetCarrierAttack(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(6, value, valueScalingMode);

        /// <inheritdoc cref="IFmModuleHandle.GetCarrierDecay" />
        public int GetCarrierDecay(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(7, valueScalingMode);

        /// <inheritdoc cref="IFmModuleHandle.SetCarrierDecay" />
        public void SetCarrierDecay(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(7, value, valueScalingMode);

        /// <inheritdoc cref="IFmModuleHandle.GetCarrierSustain" />
        public int GetCarrierSustain(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(8, valueScalingMode);

        /// <inheritdoc cref="IFmModuleHandle.SetCarrierSustain" />
        public void SetCarrierSustain(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(8, value, valueScalingMode);

        /// <inheritdoc cref="IFmModuleHandle.GetCarrierRelease" />
        public int GetCarrierRelease(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(9, valueScalingMode);

        /// <inheritdoc cref="IFmModuleHandle.SetCarrierRelease" />
        public void SetCarrierRelease(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(9, value, valueScalingMode);

        /// <inheritdoc cref="IFmModuleHandle.GetModulatorAttack" />
        public int GetModulatorAttack(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(10, valueScalingMode);

        /// <inheritdoc cref="IFmModuleHandle.SetModulatorAttack" />
        public void SetModulatorAttack(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(10, value, valueScalingMode);

        /// <inheritdoc cref="IFmModuleHandle.GetModulatorDecay" />
        public int GetModulatorDecay(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(11, valueScalingMode);

        /// <inheritdoc cref="IFmModuleHandle.SetModulatorDecay" />
        public void SetModulatorDecay(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(11, value, valueScalingMode);

        /// <inheritdoc cref="IFmModuleHandle.GetModulatorSustain" />
        public int GetModulatorSustain(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(12, valueScalingMode);

        /// <inheritdoc cref="IFmModuleHandle.SetModulatorSustain" />
        public void SetModulatorSustain(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(12, value, valueScalingMode);

        /// <inheritdoc cref="IFmModuleHandle.GetModulatorRelease" />
        public int GetModulatorRelease(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(13, valueScalingMode);

        /// <inheritdoc cref="IFmModuleHandle.SetModulatorRelease" />
        public void SetModulatorRelease(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(13, value, valueScalingMode);

        /// <inheritdoc cref="IFmModuleHandle.GetModulatorScalingPerKey" />
        public int GetModulatorScalingPerKey(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(14, valueScalingMode);

        /// <inheritdoc cref="IFmModuleHandle.SetModulatorScalingPerKey" />
        public void SetModulatorScalingPerKey(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(14, value, valueScalingMode);

        /// <inheritdoc cref="IFmModuleHandle.GetPolyphony" />
        public int GetPolyphony(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(15, valueScalingMode);

        /// <inheritdoc cref="IFmModuleHandle.SetPolyphony" />
        public void SetPolyphony(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(15, value, valueScalingMode);

        /// <inheritdoc cref="IFmModuleHandle.GetMode" />
        public Quality GetMode() => (Quality)ModuleHandle.GetControllerValue(16, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IFmModuleHandle.SetMode" />
        public void SetMode(Quality value) => ModuleHandle.SetControllerValue(16, (int)value, ValueScalingMode.Displayed);
    }
}
#endif
