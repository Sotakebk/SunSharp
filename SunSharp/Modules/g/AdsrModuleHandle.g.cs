/*
 * Do not modify this file manually.
*/

#nullable enable

#if !GENERATION
namespace SunSharp.Modules
{
    /// <summary>
    /// ADSR envelope generator. The module can be started either by notes at the input (reacts to note ON/OFF), or by setting the 'State' controller to the 'start' value.
    /// </summary>
    public partial interface IAdsrModuleHandle : ITypedModuleHandle
    {

        /// <summary>
        /// Value range: 0-32768
        /// Original name: 0 'Volume'
        /// </summary>
        int GetVolume(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-32768
        /// Original name: 0 'Volume'
        /// </summary>
        void SetVolume(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-10000
        /// Original name: 1 'Attack'
        /// </summary>
        int GetAttack(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-10000
        /// Original name: 1 'Attack'
        /// </summary>
        void SetAttack(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-10000
        /// Original name: 2 'Decay'
        /// </summary>
        int GetDecay(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-10000
        /// Original name: 2 'Decay'
        /// </summary>
        void SetDecay(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-32768
        /// Original name: 3 'Sustain level'
        /// </summary>
        int GetSustainLevel(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-32768
        /// Original name: 3 'Sustain level'
        /// </summary>
        void SetSustainLevel(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-10000
        /// Original name: 4 'Release'
        /// </summary>
        int GetRelease(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Value range: 0-10000
        /// Original name: 4 'Release'
        /// </summary>
        void SetRelease(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed);

        /// <summary>
        /// Original name: 5 'Attack curve'
        /// </summary>
        AdsrCurveType GetAttackCurve();

        /// <summary>
        /// Original name: 5 'Attack curve'
        /// </summary>
        void SetAttackCurve(AdsrCurveType value);

        /// <summary>
        /// Original name: 6 'Decay curve'
        /// </summary>
        AdsrCurveType GetDecayCurve();

        /// <summary>
        /// Original name: 6 'Decay curve'
        /// </summary>
        void SetDecayCurve(AdsrCurveType value);

        /// <summary>
        /// Original name: 7 'Release curve'
        /// </summary>
        AdsrCurveType GetReleaseCurve();

        /// <summary>
        /// Original name: 7 'Release curve'
        /// </summary>
        void SetReleaseCurve(AdsrCurveType value);

        /// <summary>
        /// Original name: 8 'Sustain'
        /// </summary>
        AdsrSustainMode GetSustain();

        /// <summary>
        /// Original name: 8 'Sustain'
        /// </summary>
        void SetSustain(AdsrSustainMode value);

        /// <summary>
        /// Original name: 9 'Sustain pedal'
        /// </summary>
        Toggle GetSustainPedal();

        /// <summary>
        /// Original name: 9 'Sustain pedal'
        /// </summary>
        void SetSustainPedal(Toggle value);

        /// <summary>
        /// Original name: 10 'State'
        /// </summary>
        Toggle GetState();

        /// <summary>
        /// Original name: 10 'State'
        /// </summary>
        void SetState(Toggle value);

        /// <summary>
        /// Original name: 11 'On NoteON'
        /// </summary>
        AdsrOnNoteOnBehaviour GetOnNoteon();

        /// <summary>
        /// Original name: 11 'On NoteON'
        /// </summary>
        void SetOnNoteon(AdsrOnNoteOnBehaviour value);

        /// <summary>
        /// Original name: 12 'On NoteOFF'
        /// </summary>
        AdsrOnNoteOffBehaviour GetOnNoteoff();

        /// <summary>
        /// Original name: 12 'On NoteOFF'
        /// </summary>
        void SetOnNoteoff(AdsrOnNoteOffBehaviour value);

        /// <summary>
        /// Original name: 13 'Mode'
        /// </summary>
        AdsrMode GetMode();

        /// <summary>
        /// Original name: 13 'Mode'
        /// </summary>
        void SetMode(AdsrMode value);

        /// <summary>
        /// Original name: 14 'Smooth transitions'
        /// </summary>
        AdsrSmoothTransitions GetSmoothTransitions();

        /// <summary>
        /// Original name: 14 'Smooth transitions'
        /// </summary>
        void SetSmoothTransitions(AdsrSmoothTransitions value);
    }

    /// <inheritdoc cref="IAdsrModuleHandle"/>
    public readonly partial struct AdsrModuleHandle : IAdsrModuleHandle
    {
        public SynthModuleHandle ModuleHandle { get; }

        public AdsrModuleHandle(SynthModuleHandle moduleHandle)
        {
            ModuleHandle = moduleHandle;
        }

        public static implicit operator SynthModuleHandle(AdsrModuleHandle handle)
        {
            return handle.ModuleHandle;
        }

        /// <inheritdoc/>
        public bool IsCorrectHandleType()
        {
            return ModuleHandle.GetModuleType() == SynthModuleType.Adsr;
        }

        /// <inheritdoc/>
        public void AssertCorrectHandleType()
        {
            const SynthModuleType expected = SynthModuleType.Adsr;
            var actual = ModuleHandle.GetModuleType();
            if(actual != expected)
            {
                throw new IncorrectSynthHandleTypeException(expected, actual);
            }
        }

        #region IGenericSynthModuleHandle implementation

        public int Id => ModuleHandle.Id;

        public ISlot Slot => ModuleHandle.Slot;

        /// <inheritdoc/>
        public ModuleFlags GetFlags() => ModuleHandle.GetFlags();

        /// <inheritdoc/>
        public SynthModuleType? GetModuleType() => ModuleHandle.GetModuleType();

        /// <inheritdoc/>
        public bool GetExists() => ModuleHandle.GetExists();

        /// <inheritdoc/>
        public FineTunePair GetFineTune() => ModuleHandle.GetFineTune();

        /// <inheritdoc/>
        public void SetFineTune(FineTunePair fineTune) => ModuleHandle.SetFineTune(fineTune);

        /// <inheritdoc/>
        public int ReadScope(AudioChannel channel, short[] buffer) => ModuleHandle.ReadScope(channel, buffer);

        /// <inheritdoc/>
        public string? GetName() => ModuleHandle.GetName();

        /// <inheritdoc/>
        public void SetName(string name) => ModuleHandle.SetName(name);

        /// <inheritdoc/>
        public (int, int) GetPosition() => ModuleHandle.GetPosition();

        /// <inheritdoc/>
        public void SetPosition(int x, int y) => ModuleHandle.SetPosition(x, y);

        /// <inheritdoc/>
        public (byte, byte, byte) GetColor() => ModuleHandle.GetColor();

        /// <inheritdoc/>
        public void SetColor(byte r, byte g, byte b) => ModuleHandle.SetColor(r, g, b);

        /// <inheritdoc/>
        public int[] GetInputs() => ModuleHandle.GetInputs();

        /// <inheritdoc/>
        ISynthModuleHandle[] IGenericSynthModuleHandle.GetInputModules() => (ModuleHandle as IGenericSynthModuleHandle).GetInputModules();

        /// <inheritdoc/>
        public int[] GetOutputs() => ModuleHandle.GetOutputs();

        /// <inheritdoc/>
        ISynthModuleHandle[] IGenericSynthModuleHandle.GetOutputModules() => (ModuleHandle as IGenericSynthModuleHandle).GetOutputModules();

        /// <inheritdoc/>
        void IGenericSynthModuleHandle.ConnectInput(int targetModuleId) => ModuleHandle.ConnectInput(targetModuleId);

        /// <inheritdoc/>
        void IGenericSynthModuleHandle.ConnectInput(ISynthModuleHandle targetModule) => (ModuleHandle as IGenericSynthModuleHandle).ConnectInput(targetModule);

        /// <inheritdoc/>
        void IGenericSynthModuleHandle.ConnectOutput(int targetModuleId) => ModuleHandle.ConnectOutput(targetModuleId);

        /// <inheritdoc/>
        void IGenericSynthModuleHandle.ConnectOutput(ISynthModuleHandle targetModule) => (ModuleHandle as IGenericSynthModuleHandle).ConnectOutput(targetModule);

        /// <inheritdoc/>
        void IGenericSynthModuleHandle.DisconnectInput(int targetModuleId) => ModuleHandle.DisconnectInput(targetModuleId);

        /// <inheritdoc/>
        void IGenericSynthModuleHandle.DisconnectInput(ISynthModuleHandle targetModule) => (ModuleHandle as IGenericSynthModuleHandle).DisconnectInput(targetModule);

        /// <inheritdoc/>
        void IGenericSynthModuleHandle.DisconnectOutput(int targetModuleId) => ModuleHandle.DisconnectOutput(targetModuleId);

        /// <inheritdoc/>
        void IGenericSynthModuleHandle.DisconnectOutput(ISynthModuleHandle targetModule) => (ModuleHandle as IGenericSynthModuleHandle).DisconnectOutput(targetModule);

        /// <inheritdoc/>
        public PatternEvent MakeSetControllerValueEvent(byte controllerId, ushort value) => ModuleHandle.MakeSetControllerValueEvent(controllerId, value);

        /// <inheritdoc/>
        public PatternEvent MakeNoteEvent(Note note, byte? velocity = default) => ModuleHandle.MakeNoteEvent(note, velocity);

        /// <inheritdoc/>
        public PatternEvent MakeSetPitchEvent(ushort pitch, byte? velocity = default) => ModuleHandle.MakeSetPitchEvent(pitch, velocity);

        /// <inheritdoc/>
        public PatternEvent MakeSetFrequencyEvent(double frequency, byte? velocity = default) => ModuleHandle.MakeSetFrequencyEvent(frequency, velocity);

        /// <inheritdoc/>
        public PatternEvent MakeEvent(Note note = default, byte? velocity = default, byte? controller = default, Effect effect = Effect.None, ushort value = 0) => ModuleHandle.MakeEvent(note, velocity, controller, effect, value);

        /// <inheritdoc cref="SynthModuleHandle.GetInputModules"/>
        public SynthModuleHandle[] GetInputModules() => ModuleHandle.GetInputModules();

        /// <inheritdoc cref="SynthModuleHandle.GetOutputModules"/>
        public SynthModuleHandle[] GetOutputModules() => ModuleHandle.GetOutputModules();

        /// <inheritdoc cref="SynthModuleHandle.ConnectInput"/>
        public void ConnectInput(SynthModuleHandle targetModule) => ModuleHandle.ConnectInput(targetModule);

        /// <inheritdoc cref="SynthModuleHandle.ConnectOutput"/>
        public void ConnectOutput(SynthModuleHandle targetModule) => ModuleHandle.ConnectOutput(targetModule);

        /// <inheritdoc cref="SynthModuleHandle.DisconnectInput"/>
        public void DisconnectInput(SynthModuleHandle targetModule) => ModuleHandle.DisconnectInput(targetModule);

        /// <inheritdoc cref="SynthModuleHandle.DisconnectOutput"/>
        public void DisconnectOutput(SynthModuleHandle targetModule) => ModuleHandle.DisconnectOutput(targetModule);

        #endregion

        /// <inheritdoc cref="IAdsrModuleHandle.GetVolume" />
        public int GetVolume(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(0, valueScalingMode);

        /// <inheritdoc cref="IAdsrModuleHandle.SetVolume" />
        public void SetVolume(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(0, value, valueScalingMode);

        /// <inheritdoc cref="IAdsrModuleHandle.GetAttack" />
        public int GetAttack(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(1, valueScalingMode);

        /// <inheritdoc cref="IAdsrModuleHandle.SetAttack" />
        public void SetAttack(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(1, value, valueScalingMode);

        /// <inheritdoc cref="IAdsrModuleHandle.GetDecay" />
        public int GetDecay(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(2, valueScalingMode);

        /// <inheritdoc cref="IAdsrModuleHandle.SetDecay" />
        public void SetDecay(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(2, value, valueScalingMode);

        /// <inheritdoc cref="IAdsrModuleHandle.GetSustainLevel" />
        public int GetSustainLevel(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(3, valueScalingMode);

        /// <inheritdoc cref="IAdsrModuleHandle.SetSustainLevel" />
        public void SetSustainLevel(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(3, value, valueScalingMode);

        /// <inheritdoc cref="IAdsrModuleHandle.GetRelease" />
        public int GetRelease(ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.GetControllerValue(4, valueScalingMode);

        /// <inheritdoc cref="IAdsrModuleHandle.SetRelease" />
        public void SetRelease(int value, ValueScalingMode valueScalingMode = ValueScalingMode.Displayed) => ModuleHandle.SetControllerValue(4, value, valueScalingMode);

        /// <inheritdoc cref="IAdsrModuleHandle.GetAttackCurve" />
        public AdsrCurveType GetAttackCurve() => (AdsrCurveType)ModuleHandle.GetControllerValue(5, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IAdsrModuleHandle.SetAttackCurve" />
        public void SetAttackCurve(AdsrCurveType value) => ModuleHandle.SetControllerValue(5, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IAdsrModuleHandle.GetDecayCurve" />
        public AdsrCurveType GetDecayCurve() => (AdsrCurveType)ModuleHandle.GetControllerValue(6, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IAdsrModuleHandle.SetDecayCurve" />
        public void SetDecayCurve(AdsrCurveType value) => ModuleHandle.SetControllerValue(6, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IAdsrModuleHandle.GetReleaseCurve" />
        public AdsrCurveType GetReleaseCurve() => (AdsrCurveType)ModuleHandle.GetControllerValue(7, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IAdsrModuleHandle.SetReleaseCurve" />
        public void SetReleaseCurve(AdsrCurveType value) => ModuleHandle.SetControllerValue(7, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IAdsrModuleHandle.GetSustain" />
        public AdsrSustainMode GetSustain() => (AdsrSustainMode)ModuleHandle.GetControllerValue(8, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IAdsrModuleHandle.SetSustain" />
        public void SetSustain(AdsrSustainMode value) => ModuleHandle.SetControllerValue(8, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IAdsrModuleHandle.GetSustainPedal" />
        public Toggle GetSustainPedal() => (Toggle)ModuleHandle.GetControllerValue(9, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IAdsrModuleHandle.SetSustainPedal" />
        public void SetSustainPedal(Toggle value) => ModuleHandle.SetControllerValue(9, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IAdsrModuleHandle.GetState" />
        public Toggle GetState() => (Toggle)ModuleHandle.GetControllerValue(10, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IAdsrModuleHandle.SetState" />
        public void SetState(Toggle value) => ModuleHandle.SetControllerValue(10, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IAdsrModuleHandle.GetOnNoteon" />
        public AdsrOnNoteOnBehaviour GetOnNoteon() => (AdsrOnNoteOnBehaviour)ModuleHandle.GetControllerValue(11, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IAdsrModuleHandle.SetOnNoteon" />
        public void SetOnNoteon(AdsrOnNoteOnBehaviour value) => ModuleHandle.SetControllerValue(11, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IAdsrModuleHandle.GetOnNoteoff" />
        public AdsrOnNoteOffBehaviour GetOnNoteoff() => (AdsrOnNoteOffBehaviour)ModuleHandle.GetControllerValue(12, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IAdsrModuleHandle.SetOnNoteoff" />
        public void SetOnNoteoff(AdsrOnNoteOffBehaviour value) => ModuleHandle.SetControllerValue(12, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IAdsrModuleHandle.GetMode" />
        public AdsrMode GetMode() => (AdsrMode)ModuleHandle.GetControllerValue(13, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IAdsrModuleHandle.SetMode" />
        public void SetMode(AdsrMode value) => ModuleHandle.SetControllerValue(13, (int)value, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IAdsrModuleHandle.GetSmoothTransitions" />
        public AdsrSmoothTransitions GetSmoothTransitions() => (AdsrSmoothTransitions)ModuleHandle.GetControllerValue(14, ValueScalingMode.Displayed);

        /// <inheritdoc cref="IAdsrModuleHandle.SetSmoothTransitions" />
        public void SetSmoothTransitions(AdsrSmoothTransitions value) => ModuleHandle.SetControllerValue(14, (int)value, ValueScalingMode.Displayed);
    }
}
#endif
