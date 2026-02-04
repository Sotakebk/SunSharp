/*
 * Do not modify this file manually.
*/

#nullable enable

#if !SUNSHARP_GENERATION
using SunSharp.Modules;

namespace SunSharp
{
    public partial interface ISynthModuleHandle
    {
        IOutputModuleHandle AsOutput();

        IAnalogGeneratorModuleHandle AsAnalogGenerator();

        IDrumSynthModuleHandle AsDrumSynth();

        IFmModuleHandle AsFm();

        IFmxModuleHandle AsFmx();

        IGeneratorModuleHandle AsGenerator();

        IInputModuleHandle AsInput();

        IKickerModuleHandle AsKicker();

        IVorbisPlayerModuleHandle AsVorbisPlayer();

        ISamplerModuleHandle AsSampler();

        ISpectraVoiceModuleHandle AsSpectraVoice();

        IAmplifierModuleHandle AsAmplifier();

        ICompressorModuleHandle AsCompressor();

        IDcBlockerModuleHandle AsDcBlocker();

        IDelayModuleHandle AsDelay();

        IDistortionModuleHandle AsDistortion();

        IEchoModuleHandle AsEcho();

        IEqModuleHandle AsEq();

        IFftModuleHandle AsFft();

        IFilterModuleHandle AsFilter();

        IFilterProModuleHandle AsFilterPro();

        IFlangerModuleHandle AsFlanger();

        ILfoModuleHandle AsLfo();

        ILoopModuleHandle AsLoop();

        IModulatorModuleHandle AsModulator();

        IPitchShifterModuleHandle AsPitchShifter();

        IReverbModuleHandle AsReverb();

        IVocalFilterModuleHandle AsVocalFilter();

        IVibratoModuleHandle AsVibrato();

        IWaveShaperModuleHandle AsWaveShaper();

        IAdsrModuleHandle AsAdsr();

        IControlToNoteModuleHandle AsControlToNote();

        IFeedbackModuleHandle AsFeedback();

        IGlideModuleHandle AsGlide();

        IGpioModuleHandle AsGpio();

        IMetaModuleModuleHandle AsMetaModule();

        IMultiControlModuleHandle AsMultiControl();

        IMultiSynthModuleHandle AsMultiSynth();

        IPitchToControlModuleHandle AsPitchToControl();

        IPitchDetectorModuleHandle AsPitchDetector();

        ISoundToControlModuleHandle AsSoundToControl();

        IVelocityToControlModuleHandle AsVelocityToControl();
    }

    public readonly partial struct SynthModuleHandle : ISynthModuleHandle
    {
        public OutputModuleHandle AsOutput() => new OutputModuleHandle(this);

        IOutputModuleHandle ISynthModuleHandle.AsOutput() => new OutputModuleHandle(this);

        public AnalogGeneratorModuleHandle AsAnalogGenerator() => new AnalogGeneratorModuleHandle(this);

        IAnalogGeneratorModuleHandle ISynthModuleHandle.AsAnalogGenerator() => new AnalogGeneratorModuleHandle(this);

        public DrumSynthModuleHandle AsDrumSynth() => new DrumSynthModuleHandle(this);

        IDrumSynthModuleHandle ISynthModuleHandle.AsDrumSynth() => new DrumSynthModuleHandle(this);

        public FmModuleHandle AsFm() => new FmModuleHandle(this);

        IFmModuleHandle ISynthModuleHandle.AsFm() => new FmModuleHandle(this);

        public FmxModuleHandle AsFmx() => new FmxModuleHandle(this);

        IFmxModuleHandle ISynthModuleHandle.AsFmx() => new FmxModuleHandle(this);

        public GeneratorModuleHandle AsGenerator() => new GeneratorModuleHandle(this);

        IGeneratorModuleHandle ISynthModuleHandle.AsGenerator() => new GeneratorModuleHandle(this);

        public InputModuleHandle AsInput() => new InputModuleHandle(this);

        IInputModuleHandle ISynthModuleHandle.AsInput() => new InputModuleHandle(this);

        public KickerModuleHandle AsKicker() => new KickerModuleHandle(this);

        IKickerModuleHandle ISynthModuleHandle.AsKicker() => new KickerModuleHandle(this);

        public VorbisPlayerModuleHandle AsVorbisPlayer() => new VorbisPlayerModuleHandle(this);

        IVorbisPlayerModuleHandle ISynthModuleHandle.AsVorbisPlayer() => new VorbisPlayerModuleHandle(this);

        public SamplerModuleHandle AsSampler() => new SamplerModuleHandle(this);

        ISamplerModuleHandle ISynthModuleHandle.AsSampler() => new SamplerModuleHandle(this);

        public SpectraVoiceModuleHandle AsSpectraVoice() => new SpectraVoiceModuleHandle(this);

        ISpectraVoiceModuleHandle ISynthModuleHandle.AsSpectraVoice() => new SpectraVoiceModuleHandle(this);

        public AmplifierModuleHandle AsAmplifier() => new AmplifierModuleHandle(this);

        IAmplifierModuleHandle ISynthModuleHandle.AsAmplifier() => new AmplifierModuleHandle(this);

        public CompressorModuleHandle AsCompressor() => new CompressorModuleHandle(this);

        ICompressorModuleHandle ISynthModuleHandle.AsCompressor() => new CompressorModuleHandle(this);

        public DcBlockerModuleHandle AsDcBlocker() => new DcBlockerModuleHandle(this);

        IDcBlockerModuleHandle ISynthModuleHandle.AsDcBlocker() => new DcBlockerModuleHandle(this);

        public DelayModuleHandle AsDelay() => new DelayModuleHandle(this);

        IDelayModuleHandle ISynthModuleHandle.AsDelay() => new DelayModuleHandle(this);

        public DistortionModuleHandle AsDistortion() => new DistortionModuleHandle(this);

        IDistortionModuleHandle ISynthModuleHandle.AsDistortion() => new DistortionModuleHandle(this);

        public EchoModuleHandle AsEcho() => new EchoModuleHandle(this);

        IEchoModuleHandle ISynthModuleHandle.AsEcho() => new EchoModuleHandle(this);

        public EqModuleHandle AsEq() => new EqModuleHandle(this);

        IEqModuleHandle ISynthModuleHandle.AsEq() => new EqModuleHandle(this);

        public FftModuleHandle AsFft() => new FftModuleHandle(this);

        IFftModuleHandle ISynthModuleHandle.AsFft() => new FftModuleHandle(this);

        public FilterModuleHandle AsFilter() => new FilterModuleHandle(this);

        IFilterModuleHandle ISynthModuleHandle.AsFilter() => new FilterModuleHandle(this);

        public FilterProModuleHandle AsFilterPro() => new FilterProModuleHandle(this);

        IFilterProModuleHandle ISynthModuleHandle.AsFilterPro() => new FilterProModuleHandle(this);

        public FlangerModuleHandle AsFlanger() => new FlangerModuleHandle(this);

        IFlangerModuleHandle ISynthModuleHandle.AsFlanger() => new FlangerModuleHandle(this);

        public LfoModuleHandle AsLfo() => new LfoModuleHandle(this);

        ILfoModuleHandle ISynthModuleHandle.AsLfo() => new LfoModuleHandle(this);

        public LoopModuleHandle AsLoop() => new LoopModuleHandle(this);

        ILoopModuleHandle ISynthModuleHandle.AsLoop() => new LoopModuleHandle(this);

        public ModulatorModuleHandle AsModulator() => new ModulatorModuleHandle(this);

        IModulatorModuleHandle ISynthModuleHandle.AsModulator() => new ModulatorModuleHandle(this);

        public PitchShifterModuleHandle AsPitchShifter() => new PitchShifterModuleHandle(this);

        IPitchShifterModuleHandle ISynthModuleHandle.AsPitchShifter() => new PitchShifterModuleHandle(this);

        public ReverbModuleHandle AsReverb() => new ReverbModuleHandle(this);

        IReverbModuleHandle ISynthModuleHandle.AsReverb() => new ReverbModuleHandle(this);

        public VocalFilterModuleHandle AsVocalFilter() => new VocalFilterModuleHandle(this);

        IVocalFilterModuleHandle ISynthModuleHandle.AsVocalFilter() => new VocalFilterModuleHandle(this);

        public VibratoModuleHandle AsVibrato() => new VibratoModuleHandle(this);

        IVibratoModuleHandle ISynthModuleHandle.AsVibrato() => new VibratoModuleHandle(this);

        public WaveShaperModuleHandle AsWaveShaper() => new WaveShaperModuleHandle(this);

        IWaveShaperModuleHandle ISynthModuleHandle.AsWaveShaper() => new WaveShaperModuleHandle(this);

        public AdsrModuleHandle AsAdsr() => new AdsrModuleHandle(this);

        IAdsrModuleHandle ISynthModuleHandle.AsAdsr() => new AdsrModuleHandle(this);

        public ControlToNoteModuleHandle AsControlToNote() => new ControlToNoteModuleHandle(this);

        IControlToNoteModuleHandle ISynthModuleHandle.AsControlToNote() => new ControlToNoteModuleHandle(this);

        public FeedbackModuleHandle AsFeedback() => new FeedbackModuleHandle(this);

        IFeedbackModuleHandle ISynthModuleHandle.AsFeedback() => new FeedbackModuleHandle(this);

        public GlideModuleHandle AsGlide() => new GlideModuleHandle(this);

        IGlideModuleHandle ISynthModuleHandle.AsGlide() => new GlideModuleHandle(this);

        public GpioModuleHandle AsGpio() => new GpioModuleHandle(this);

        IGpioModuleHandle ISynthModuleHandle.AsGpio() => new GpioModuleHandle(this);

        public MetaModuleModuleHandle AsMetaModule() => new MetaModuleModuleHandle(this);

        IMetaModuleModuleHandle ISynthModuleHandle.AsMetaModule() => new MetaModuleModuleHandle(this);

        public MultiControlModuleHandle AsMultiControl() => new MultiControlModuleHandle(this);

        IMultiControlModuleHandle ISynthModuleHandle.AsMultiControl() => new MultiControlModuleHandle(this);

        public MultiSynthModuleHandle AsMultiSynth() => new MultiSynthModuleHandle(this);

        IMultiSynthModuleHandle ISynthModuleHandle.AsMultiSynth() => new MultiSynthModuleHandle(this);

        public PitchToControlModuleHandle AsPitchToControl() => new PitchToControlModuleHandle(this);

        IPitchToControlModuleHandle ISynthModuleHandle.AsPitchToControl() => new PitchToControlModuleHandle(this);

        public PitchDetectorModuleHandle AsPitchDetector() => new PitchDetectorModuleHandle(this);

        IPitchDetectorModuleHandle ISynthModuleHandle.AsPitchDetector() => new PitchDetectorModuleHandle(this);

        public SoundToControlModuleHandle AsSoundToControl() => new SoundToControlModuleHandle(this);

        ISoundToControlModuleHandle ISynthModuleHandle.AsSoundToControl() => new SoundToControlModuleHandle(this);

        public VelocityToControlModuleHandle AsVelocityToControl() => new VelocityToControlModuleHandle(this);

        IVelocityToControlModuleHandle ISynthModuleHandle.AsVelocityToControl() => new VelocityToControlModuleHandle(this);
    }
}
#endif
