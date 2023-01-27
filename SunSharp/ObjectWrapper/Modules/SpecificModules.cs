using System;

namespace SunSharp.ObjectWrapper.Modules
{
    public static class ModuleExtensions
    {
        public static ADSR AsADSR(this Module module) => new ADSR(module);
    }

    public struct ADSR
    {
        public Module Module { get; private set; }

        public ADSR(Module module){
            Module = module;
        }

        #region controllers

        ///<summary>
        /// Value range: 0 to 10000.
        ///</summary>
        public short GetAttack() => (short)Module.GetControllerValue(2, true);

        ///<summary>
        /// Value range: 0 to 10000.
        ///</summary>
        public void SetAttack(float value) => Module.SetControllerValue(2, value, 0, 10000);

        public CurveType GetAttackCurve() => (CurveType)Module.GetControllerValue(6, true);

        public void SetAttackCurve(CurveType value) => Module.SetControllerValue(6, (short)value);

        ///<summary>
        /// Value range: 0 to 10000.
        ///</summary>
        public short GetDecay() => (short)Module.GetControllerValue(3, true);

        ///<summary>
        /// Value range: 0 to 10000.
        ///</summary>
        public void SetDecay(float value) => Module.SetControllerValue(3, value, 0, 10000);

        public CurveType GetDecayCurve() => (CurveType)Module.GetControllerValue(7, true);

        public void SetDecayCurve(CurveType value) => Module.SetControllerValue(7, (short)value);

        public Mode GetMode() => (Mode)Module.GetControllerValue(13, true);

        public void SetMode(Mode value) => Module.SetControllerValue(13, (short)value);

        public OnNoteOffBehaviour GetOnNoteOFF() => (OnNoteOffBehaviour)Module.GetControllerValue(13, true);

        public void SetOnNoteOFF(OnNoteOffBehaviour value) => Module.SetControllerValue(13, (short)value);

        public OnNoteOnBehaviour GetOnNoteON() => (OnNoteOnBehaviour)Module.GetControllerValue(12, true);

        public void SetOnNoteON(OnNoteOnBehaviour value) => Module.SetControllerValue(12, (short)value);

        ///<summary>
        /// Value range: 0 to 10000.
        ///</summary>
        public short GetRelease() => (short)Module.GetControllerValue(5, true);

        ///<summary>
        /// Value range: 0 to 10000.
        ///</summary>
        public void SetRelease(float value) => Module.SetControllerValue(5, value, 0, 10000);

        public CurveType GetReleaseCurve() => (CurveType)Module.GetControllerValue(8, true);

        public void SetReleaseCurve(CurveType value) => Module.SetControllerValue(8, (short)value);

        public SmoothTransitionMode GetSmoothTransitions() => (SmoothTransitionMode)Module.GetControllerValue(13, true);

        public void SetSmoothTransitions(SmoothTransitionMode value) => Module.SetControllerValue(13, (short)value);

        public Active GetState() => (Active)Module.GetControllerValue(11, true);

        public void SetState(Active value) => Module.SetControllerValue(11, (short)value);

        public SustainMode GetSustain() => (SustainMode)Module.GetControllerValue(9, true);

        public void SetSustain(SustainMode value) => Module.SetControllerValue(9, (short)value);

        ///<summary>
        /// Value range: 0 to 32768.
        ///</summary>
        public short GetSustainLevel() => (short)Module.GetControllerValue(4, true);

        ///<summary>
        /// Value range: 0 to 32768.
        ///</summary>
        public void SetSustainLevel(float value) => Module.SetControllerValue(4, value, 0, 32768);

        public Toggle GetSustainPedal() => (Toggle)Module.GetControllerValue(10, true);

        public void SetSustainPedal(Toggle value) => Module.SetControllerValue(10, (short)value);

        ///<summary>
        /// Value range: 0 to 32768.
        ///</summary>
        public short GetVolume() => (short)Module.GetControllerValue(1, true);

        ///<summary>
        /// Value range: 0 to 32768.
        ///</summary>
        public void SetVolume(float value) => Module.SetControllerValue(1, value, 0, 32768);

        #endregion controllers

        #region enums
        
        public enum Active : short
        {
            Stop = 0,
            Start = 1,
        }

        public enum CurveType : short
        {
            Linear = 0,
            Exp1 = 1,
            Exp2 = 2,
            Nexp1 = 3,
            Nexp2 = 4,
            Sin = 5,
        }

        public enum Mode : short
        {
            Generator = 0,
            AmplitudeModulatorMono = 1,
            AmplitudeModulatorStereo = 2,
        }

        public enum OnNoteOffBehaviour : short
        {
            DoNothing = 0,
            StopOnLastNote = 1,
            Stop = 2,
        }

        public enum OnNoteOnBehaviour : short
        {
            DoNothing = 0,
            StartOnFirstNote = 1,
            Start = 2,
        }

        public enum SmoothTransitionMode : short
        {
            Off = 0,
            RestartAndVolumeChange = 1,
            RestartAndVolumeChangeSmooth = 2,
            VolumeChange = 3,
        }

        public enum SustainMode : short
        {
            Off = 0,
            On = 1,
            Repeat = 2,
        }

        public enum Toggle : short
        {
            Off = 0,
            On = 1,
        }

        #endregion enums
    }
}
