/*
 * Do not modify this file manually.
*/

#nullable enable

#if !GENERATION
namespace SunSharp.Modules
{
    /// <summary>
    /// This module sends the incoming events (notes, pitch change, phase change) to any number of connected modules (receivers).
    /// </summary>
    public partial interface IMultiSynthModuleHandle : ITypedModuleHandle
    {

        /// <summary>
        /// Value range: displayed: -128-128, real: 0-256
        /// Original name: 0 'Transpose'
        /// </summary>
        int GetTranspose(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: -128-128, real: 0-256
        /// Original name: 0 'Transpose'
        /// </summary>
        void SetTranspose(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-4096
        /// Original name: 1 'Random pitch'
        /// </summary>
        int GetRandomPitch(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-4096
        /// Original name: 1 'Random pitch'
        /// </summary>
        void SetRandomPitch(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 2 'Velocity'
        /// </summary>
        int GetVelocity(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 2 'Velocity'
        /// </summary>
        void SetVelocity(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: -256-256, real: 0-512
        /// Original name: 3 'Finetune'
        /// </summary>
        int GetFinetune(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: displayed: -256-256, real: 0-512
        /// Original name: 3 'Finetune'
        /// </summary>
        void SetFinetune(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-32768
        /// Original name: 4 'Random phase'
        /// </summary>
        int GetRandomPhase(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-32768
        /// Original name: 4 'Random phase'
        /// </summary>
        void SetRandomPhase(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-32768
        /// Original name: 5 'Random velocity'
        /// </summary>
        int GetRandomVelocity(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-32768
        /// Original name: 5 'Random velocity'
        /// </summary>
        void SetRandomVelocity(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-32768
        /// Original name: 6 'Phase'
        /// </summary>
        int GetPhase(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-32768
        /// Original name: 6 'Phase'
        /// </summary>
        void SetPhase(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 7 'Curve2 influence'
        /// </summary>
        int GetCurve2Influence(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-256
        /// Original name: 7 'Curve2 influence'
        /// </summary>
        void SetCurve2Influence(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Velocity to apply to arriving note.
        /// <br>
        /// <br> Write to curve 0 of MultiSynth.
        /// <br> The curve contains 128 values in range of 0 to 1.
        /// </summary>
        int WriteCurveNoteToVelocity(float[] buffer);

        /// <summary>
        /// Velocity to apply to arriving note.
        /// <br>
        /// <br> Read from curve 0 of MultiSynth.
        /// <br> The curve contains 128 values in range of 0 to 1.
        /// </summary>
        int ReadCurveNoteToVelocity(float[] buffer);

        /// <summary>
        /// Map velocity values.
        /// <br>
        /// <br> Write to curve 1 of MultiSynth.
        /// <br> The curve contains 257 values in range of 0 to 1.
        /// </summary>
        int WriteCurveVelocityToVelocity(float[] buffer);

        /// <summary>
        /// Map velocity values.
        /// <br>
        /// <br> Read from curve 1 of MultiSynth.
        /// <br> The curve contains 257 values in range of 0 to 1.
        /// </summary>
        int ReadCurveVelocityToVelocity(float[] buffer);

        /// <summary>
        /// Map incoming note to a pitch value.
        /// <br>
        /// <br> Write to curve 2 of MultiSynth.
        /// <br> The curve contains 128 values in range of 0.2500038 to 0.74610513.
        /// </summary>
        int WriteCurveNoteToPitch(float[] buffer);

        /// <summary>
        /// Map incoming note to a pitch value.
        /// <br>
        /// <br> Read from curve 2 of MultiSynth.
        /// <br> The curve contains 128 values in range of 0.2500038 to 0.74610513.
        /// </summary>
        int ReadCurveNoteToPitch(float[] buffer);
    }

    /// <inheritdoc cref="IMultiSynthModuleHandle"/>
    public readonly partial struct MultiSynthModuleHandle : IMultiSynthModuleHandle
    {
        public SynthModuleHandle ModuleHandle { get; }

        public MultiSynthModuleHandle(SynthModuleHandle moduleHandle)
        {
            ModuleHandle = moduleHandle;
        }

        public static implicit operator SynthModuleHandle(MultiSynthModuleHandle handle)
        {
            return handle.ModuleHandle;
        }

        /// <inheritdoc/>
        public bool IsCorrectHandleType()
        {
            return ModuleHandle.GetModuleType() == SynthModuleType.MultiSynth;
        }

        /// <inheritdoc/>
        public void AssertCorrectHandleType()
        {
            const SynthModuleType expected = SynthModuleType.MultiSynth;
            var actual = ModuleHandle.GetModuleType();
            if(actual != expected)
            {
                throw new IncorrectSynthHandleTypeException(expected, actual);
            }
        }

        /// <inheritdoc cref="IMultiSynthModuleHandle.GetTranspose" />
        public int GetTranspose(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(0, valueScalingMode);

        /// <inheritdoc cref="IMultiSynthModuleHandle.SetTranspose" />
        public void SetTranspose(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(0, value, valueScalingMode);

        /// <inheritdoc cref="IMultiSynthModuleHandle.GetRandomPitch" />
        public int GetRandomPitch(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(1, valueScalingMode);

        /// <inheritdoc cref="IMultiSynthModuleHandle.SetRandomPitch" />
        public void SetRandomPitch(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(1, value, valueScalingMode);

        /// <inheritdoc cref="IMultiSynthModuleHandle.GetVelocity" />
        public int GetVelocity(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(2, valueScalingMode);

        /// <inheritdoc cref="IMultiSynthModuleHandle.SetVelocity" />
        public void SetVelocity(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(2, value, valueScalingMode);

        /// <inheritdoc cref="IMultiSynthModuleHandle.GetFinetune" />
        public int GetFinetune(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(3, valueScalingMode);

        /// <inheritdoc cref="IMultiSynthModuleHandle.SetFinetune" />
        public void SetFinetune(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(3, value, valueScalingMode);

        /// <inheritdoc cref="IMultiSynthModuleHandle.GetRandomPhase" />
        public int GetRandomPhase(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(4, valueScalingMode);

        /// <inheritdoc cref="IMultiSynthModuleHandle.SetRandomPhase" />
        public void SetRandomPhase(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(4, value, valueScalingMode);

        /// <inheritdoc cref="IMultiSynthModuleHandle.GetRandomVelocity" />
        public int GetRandomVelocity(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(5, valueScalingMode);

        /// <inheritdoc cref="IMultiSynthModuleHandle.SetRandomVelocity" />
        public void SetRandomVelocity(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(5, value, valueScalingMode);

        /// <inheritdoc cref="IMultiSynthModuleHandle.GetPhase" />
        public int GetPhase(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(6, valueScalingMode);

        /// <inheritdoc cref="IMultiSynthModuleHandle.SetPhase" />
        public void SetPhase(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(6, value, valueScalingMode);

        /// <inheritdoc cref="IMultiSynthModuleHandle.GetCurve2Influence" />
        public int GetCurve2Influence(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(7, valueScalingMode);

        /// <inheritdoc cref="IMultiSynthModuleHandle.SetCurve2Influence" />
        public void SetCurve2Influence(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(7, value, valueScalingMode);

        /// <inheritdoc cref="IMultiSynthModuleHandle.ReadCurveNoteToVelocity"
        public int ReadCurveNoteToVelocity(float[] buffer) => ModuleHandle.ReadCurve(0, buffer);

        /// <inheritdoc cref="IMultiSynthModuleHandle.WriteCurveNoteToVelocity"
        public int WriteCurveNoteToVelocity(float[] buffer) => ModuleHandle.WriteCurve(0, buffer);

        /// <inheritdoc cref="IMultiSynthModuleHandle.ReadCurveVelocityToVelocity"
        public int ReadCurveVelocityToVelocity(float[] buffer) => ModuleHandle.ReadCurve(1, buffer);

        /// <inheritdoc cref="IMultiSynthModuleHandle.WriteCurveVelocityToVelocity"
        public int WriteCurveVelocityToVelocity(float[] buffer) => ModuleHandle.WriteCurve(1, buffer);

        /// <inheritdoc cref="IMultiSynthModuleHandle.ReadCurveNoteToPitch"
        public int ReadCurveNoteToPitch(float[] buffer) => ModuleHandle.ReadCurve(2, buffer);

        /// <inheritdoc cref="IMultiSynthModuleHandle.WriteCurveNoteToPitch"
        public int WriteCurveNoteToPitch(float[] buffer) => ModuleHandle.WriteCurve(2, buffer);
    }
}
#endif
