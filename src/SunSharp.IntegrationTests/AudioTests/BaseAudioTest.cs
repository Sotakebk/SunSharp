using System.IO;
using System.Runtime.CompilerServices;

namespace SunSharp.IntegrationTests.AudioTests;

internal class BaseAudioTest : BaseIntegrationTest
{
    protected static string GetTestAudioPath(string fileName)
    {
        var dir = Path.GetDirectoryName(GetThisFilePath()) ?? throw new();
        return Path.Combine(dir, "output", fileName);
    }

    protected static string GetThisFilePath([CallerFilePath] string callerFilePath = "")
    {
        return callerFilePath;
    }

    protected byte[] ToWave(float[] array, int sampleRate, int channels)
    {
        // turn float to PCM for now
        var shortArray = new short[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            var clamped = Math.Clamp(array[i], -1.0f, 1.0f);
            shortArray[i] = (short)(clamped * 32767);
        }
        return ToWave(shortArray, sampleRate, channels);
    }

    protected byte[] ToWave(short[] array, int sampleRate, int channels)
    {
        using var memoryStream = new MemoryStream();
        using var writer = new BinaryWriter(memoryStream);

        const short bitsPerSample = 16;
        const short bytesPerSample = bitsPerSample / 8;
        int dataSize = array.Length * bytesPerSample;
        int byteRate = sampleRate * channels * bytesPerSample;
        short blockAlign = (short)(channels * bytesPerSample);

        // RIFF header
        writer.Write("RIFF"u8);
        writer.Write(36 + dataSize);
        writer.Write("WAVE"u8);

        // Format chunk
        writer.Write("fmt "u8);
        writer.Write(16);
        writer.Write((short)1);
        writer.Write((short)channels);
        writer.Write(sampleRate);
        writer.Write(byteRate);
        writer.Write(blockAlign);
        writer.Write(bitsPerSample);

        // Data chunk
        writer.Write("data"u8);
        writer.Write(dataSize);

        foreach (var sample in array)
        {
            writer.Write(sample);
        }

        return memoryStream.ToArray();
    }

    protected void TestResultantAudio(byte[] audioData, string hash, string fileName)
    {
        // first, read existing file, check hash, overwrite if different or not existing
        var filePath = GetTestAudioPath(fileName);
        var fileHash = ComputeHash(audioData);
        var shouldWriteFile = true;
        if (File.Exists(filePath))
        {
            var existingData = File.ReadAllBytes(filePath);
            var existingDataHash = ComputeHash(existingData);
            if (string.Equals(existingDataHash.ToString(), fileHash.ToString()))
            {
                shouldWriteFile = false;
            }
        }

        if (shouldWriteFile)
        {
            File.WriteAllBytes(filePath, audioData);
        }

        fileHash.ToString().Should().Be(hash, "the resultant audio file hash should match the expected hash");
    }

    private object ComputeHash(byte[] data)
    {
        using var sha256 = System.Security.Cryptography.SHA256.Create();
        var hashBytes = sha256.ComputeHash(data);
        return Convert.ToBase64String(hashBytes);
    }


    protected SunVox MakeSunVoxWithUserManagedAudio(int sampleRate, OutputType outputType)
    {

#if SUNSHARP_RELEASE
        return SunVox.WithUserManagedAudio(_libc!, sampleRate, outputType);
#else
        return SunVox.WithUserManagedAudio(Lib, sampleRate, outputType);
#endif
    }
}
