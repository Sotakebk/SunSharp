using SunSharp.ThinWrapper;
using System.Linq;
using static SunSharp.ThinWrapper.SunVoxHelper;

namespace SunSharp.ObjectWrapper
{
    public enum ModuleType
    {
        Unknown,

        // Synths

        Analog_generator,
        DrumSynth,
        FM,
        FMX,
        Generator,
        Input,
        Kicker,
        Vorbis_player,
        Sampler,
        SpectraVoice,

        // Effects

        Amplifier,
        Compressor,
        DC_Blocker,
        Delay,
        Distortion,
        Echo,
        EQ,
        FFT,
        Filter,
        Filter_Pro,
        Flanger,
        LFO,
        Loop,
        Modulator,
        Pitch_shifter,
        Reverb,
        Vocal_filter,
        Vibrato,
        WaveShaper,

        // Misc

        ADSR,
        Ctl2Note,
        Feedback,
        Glide,
        GPIO,
        MetaModule,
        MultiCtl,
        MultiSynth,
        Pitch2Ctl,
        Pitch_Detector,
        Sound2Ctl,
        Velocity2Ctl,
    }

    public struct Module
    {
        public int Id => _id;

        public Slot Slot => _slot;

        private readonly ISunVoxLib _lib;
        private readonly Slot _slot;
        private readonly int _id;

        internal Module(Synthesizer synthesizer, int id)
        {
            _slot = synthesizer.Slot;
            _lib = synthesizer.Slot.Library;
            _id = id;
        }

        public ModuleFlags GetFlags => _lib.GetModuleFlags(_slot.Id, _id);

        public string GetName() => _lib.GetModuleName(_slot.Id, _id);

        public (int x, int y) GetPosition() => _lib.GetModulePosition(_slot.Id, _id);

        public (int finetune, int relativeNote) GetFinetune() => _lib.GetModuleFinetune(_slot.Id, _id);

        public (byte R, byte G, byte B) GetColor() => _lib.GetModuleColor(_slot.Id, _id);

        public bool GetModuleExists() => _lib.GetModuleExists(_slot.Id, _id);

        public int[] GetModuleInputs() => _lib.GetModuleInputs(_slot.Id, _id);

        public Module[] GetModuleInputModules()
        {
            var synthesizer = _slot.Synthesizer;
            return _lib.GetModuleInputs(_slot.Id, _id).Select(i => new Module(synthesizer, i)).ToArray();
        }

        public int[] GetModuleOutputs() => _lib.GetModuleInputs(_slot.Id, _id);

        public Module[] GetModuleOutputModules()
        {
            var synthesizer = _slot.Synthesizer;
            return _lib.GetModuleOutputs(_slot.Id, _id).Select(i => new Module(synthesizer, i)).ToArray();
        }

        public void LoadSample(string path, int sampleSlot = -1)
        {
            var lib = _lib;
            var slotId = _slot.Id;
            var id = _id;
            _slot.RunInLock(() =>
            {
                lib.LoadSample(slotId, id, path, sampleSlot);
            });
        }

        public void LoadSample(byte[] data, int sampleSlot = -1)
        {
            var lib = _lib;
            var slotId = _slot.Id;
            var id = _id;
            _slot.RunInLock(() =>
            {
                lib.LoadSample(slotId, id, data, sampleSlot);
            });
        }

        public int ReadScope(Channel channel, short[] buffer)
        {
            return _lib.ReadModuleScope(_slot.Id, _id, (int)channel, buffer);
        }

        public int WriteModuleCurve(int curveId, float[] buffer)
        {
            var lib = _lib;
            var slotId = _slot.Id;
            var id = _id;
            return _slot.RunInLock(() =>
            {
                return lib.WriteModuleCurve(slotId, id, curveId, buffer);
            });
        }

        public int ReadModuleCurve(int curveId, float[] buffer)
        {
            var lib = _lib;
            var slotId = _slot.Id;
            var id = _id;
            return _slot.RunInLock(() =>
            {
                return lib.ReadModuleCurve(slotId, id, curveId, buffer);
            });
        }

        public int GetControllerCount()
        {
            return _lib.GetModuleControllerCount(_slot.Id, _id);
        }

        public string GetControllerName(int controllerId)
        {
            return _lib.GetModuleControllerName(_slot.Id, _id, controllerId);
        }

        public int GetControllerValue(int controllerId, bool scaled = false)
        {
            return _lib.GetModuleControllerValue(_slot.Id, _id, controllerId, scaled);
        }

        public void SetControllerValue(int controllerId, float value, int min, int max)
        {
            var svvalue = Map(value, min, max, 0, 0x8000);
            SetControllerValue(controllerId, (short)svvalue);
        }

        private static float Map(float value, float min_in, float max_in, float min_out, float max_out)
        {
            return min_out + (max_out - min_out) / (max_in - min_in) * (value - min_in);
        }

        public void SetControllerValue(int controllerId, short value)
        {
            var @event = new Event()
            {
                MM = (ushort)(_id + 1),
                CC = (byte)(controllerId + 1),
                XXYY = value
            };

            Slot.VirtualPattern.SendEventImmediately(0, @event);
        }
    }
}
