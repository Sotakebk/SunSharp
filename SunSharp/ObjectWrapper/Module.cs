using SunSharp.ThinWrapper;
using System.Linq;

namespace SunSharp.ObjectWrapper
{
    public struct Module
    {
        private readonly ISunVoxLib _lib;
        private readonly Slot _slot;
        private readonly int _id;
        private readonly int _slotId;

        public int Id => _id;
        public Slot Slot => _slot;

        internal Module(Synthesizer synthesizer, int id)
        {
            _slot = synthesizer.Slot;
            _slotId = _slot.Id;
            _lib = synthesizer.Slot.Library;
            _id = id;
        }

        public ModuleFlags GetFlags => _lib.GetModuleFlags(_slotId, _id);

        public string GetName() => _lib.GetModuleName(_slotId, _id);

        public (int x, int y) GetPosition() => _lib.GetModulePosition(_slotId, _id);

        public (int finetune, int relativeNote) GetFinetune() => _lib.GetModuleFinetune(_slotId, _id);

        public (byte R, byte G, byte B) GetColor() => _lib.GetModuleColor(_slotId, _id);

        public bool GetModuleExists() => _lib.GetModuleExists(_slotId, _id);

        public int[] GetModuleInputs() => _lib.GetModuleInputs(_slotId, _id);

        public Module[] GetModuleInputModules()
        {
            var synthesizer = _slot.Synthesizer;
            return _lib.GetModuleInputs(_slotId, _id).Select(i => new Module(synthesizer, i)).ToArray();
        }

        public int[] GetModuleOutputs() => _lib.GetModuleInputs(_slotId, _id);

        public Module[] GetModuleOutputModules()
        {
            var synthesizer = _slot.Synthesizer;
            return _lib.GetModuleOutputs(_slotId, _id).Select(i => new Module(synthesizer, i)).ToArray();
        }

        public void LoadSample(string path, int sampleSlot = -1)
        {
            var lib = _lib;
            var slotId = _slotId;
            var id = _id;
            _slot.RunInLock(() =>
            {
                lib.LoadSample(slotId, id, path, sampleSlot);
            });
        }

        public void LoadSample(byte[] data, int sampleSlot = -1)
        {
            var lib = _lib;
            var slotId = _slotId;
            var id = _id;
            _slot.RunInLock(() =>
            {
                lib.LoadSample(slotId, id, data, sampleSlot);
            });
        }

        public int ReadScope(Channel channel, short[] buffer)
        {
            return _lib.ReadModuleScope(_slotId, _id, (int)channel, buffer);
        }

        public int WriteModuleCurve(int curveId, float[] buffer)
        {
            var lib = _lib;
            var slotId = _slotId;
            var id = _id;
            return _slot.RunInLock(() =>
            {
                return lib.WriteModuleCurve(slotId, id, curveId, buffer);
            });
        }

        public int ReadModuleCurve(int curveId, float[] buffer)
        {
            var lib = _lib;
            var slotId = _slotId;
            var id = _id;
            return _slot.RunInLock(() =>
            {
                return lib.ReadModuleCurve(slotId, id, curveId, buffer);
            });
        }

        public int GetControllerCount()
        {
            return _lib.GetModuleControllerCount(_slotId, _id);
        }

        public string GetControllerName(int controllerId)
        {
            return _lib.GetModuleControllerName(_slotId, _id, controllerId);
        }

        public int GetControllerValue(int controllerId, bool scaled = false)
        {
            return _lib.GetModuleControllerValue(_slotId, _id, controllerId, scaled);
        }

        public void SetControllerValue(int controllerId, float value, int min, int max)
        {
            var svvalue = Map(value, min, max, 0, 0x8000);
            SetControllerValue(controllerId, (ushort)svvalue);
        }

        private static float Map(float value, float min_in, float max_in, float min_out, float max_out)
        {
            return min_out + (max_out - min_out) / (max_in - min_in) * (value - min_in);
        }

        /// <summary>
        /// Set controller value (counting up from zero). Value will be set as fast as possible.
        /// </summary>
        /// <param name="controllerId">Controller number (counted from zero, one less than in SunVox UI).</param>
        /// <param name="value">Value to be applied, in XXYY column value format.</param>
        public void SetControllerValue(int controllerId, ushort value)
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
