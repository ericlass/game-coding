using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace OkuEngine
{
  /// <summary>
  /// Contains a wave form including some information about the format and the sample data itself.
  /// </summary>
  public class WaveForm
  {
    public uint NumberOfSamples { get; set; }
    public int SampleRate { get; set; }
    public int NumChannels { get; set; }
    public byte[] ChannelData { get; set; }
  }

  /// <summary>
  /// Can be used to load RIFF WAVE files (*.wav). At the moment only PCM (uncompressed) wave files
  /// with 16bit samples are supported. The number of channels and the sample rate can be choosen freely.
  /// </summary>
  class WaveLoader
  {
    /// <summary>
    /// Loads a RIFF WAVE from the given file.
    /// </summary>
    /// <param name="filename">The path to a wave file.</param>
    /// <returns>The loaded wave form or null if an error occurred.</returns>
    public static WaveForm LoadWave(string filename)
    {
      FileStream stream = new FileStream(filename, FileMode.Open);
      return LoadWave(stream);
    }

    /// <summary>
    /// Loads a RIFF WAVE from the given stream.
    /// </summary>
    /// <param name="stream">The stream that contains the wave file.</param>
    /// <returns>The loaded wave form or null if an error occurred.</returns>
    public static WaveForm LoadWave(Stream stream)
    {
      BinaryReader reader = new BinaryReader(stream, Encoding.ASCII);

      uint size = ReadRiffHeader(reader);
      WaveForm result = null;
      if (size != 0)
      {
        result = new WaveForm();
        if (!ReadFormatChunk(reader, result) || !ReadChannelData(reader, result))
          result = null;
      }

      reader.Close();
      return result;
    }

    /// <summary>
    /// Reads the header of a riff wave file using the given BinaryReader.
    /// </summary>
    /// <param name="reader">A binary reader with a riff wave base stream.</param>
    /// <returns>The size of the riff wave or 0 if the given stream is not a riff wave.</returns>
    private static uint ReadRiffHeader(BinaryReader reader)
    {
      reader.BaseStream.Seek(0, SeekOrigin.Begin);

      char[] fourcc = reader.ReadChars(4);
      string fccStr = new String(fourcc);
      if (fccStr != "RIFF")
        return 0;

      uint size = reader.ReadUInt32();

      fourcc = reader.ReadChars(4);
      fccStr = new String(fourcc);
      if (fccStr != "WAVE")
        return 0;

      return size;
    }

    /// <summary>
    /// Finds the given string in the given binary reader. If the string was found the stream
    /// pointer points to the first byte after the string. The search is started at the
    /// current position in the stream.
    /// </summary>
    /// <param name="reader">The reader to use.</param>
    /// <param name="str">The string to find.</param>
    /// <returns>True if the string was found, else False.</returns>
    private static bool FindString(BinaryReader reader, String str)
    {
      string fcc;
      do
      {
        fcc = null;
        char current = reader.ReadChar();
        while (current != str[0])
        {
          if (reader.BaseStream.Position < reader.BaseStream.Length - 1)
            current = reader.ReadChar();
          else
            break;
        }

        if ((reader.BaseStream.Length - reader.BaseStream.Position) > 3)
        {
          char[] rest = reader.ReadChars(3);
          fcc = current + new String(rest);
        }
        else
          break;
      } while (fcc != str);

      return fcc != null;
    }

    /// <summary>
    /// Reads the format chunk of a riff wave that is given in reader. 
    /// If the format chunk was read successfully the format information
    /// are stored in the given wave.
    /// </summary>
    /// <param name="reader">The reader to read the format chunk from.</param>
    /// <param name="wave">The wave form to put the format information into.</param>
    /// <returns></returns>
    private static bool ReadFormatChunk(BinaryReader reader, WaveForm wave)
    {
      reader.BaseStream.Seek(0, SeekOrigin.Begin);
      if (FindString(reader, "fmt "))
      {
        uint size = reader.ReadUInt32();
        if (size != 16)
          return false;

        ushort format = reader.ReadUInt16();
        /*if (format != 1)
          return false;*/

        ushort channels = reader.ReadUInt16();
        wave.NumChannels = channels;

        uint samplerate = reader.ReadUInt32();
        wave.SampleRate = (int)samplerate;

        reader.ReadUInt32();
        reader.ReadUInt16();

        ushort bits = reader.ReadUInt16();

        return true;
      }
      else
        return false;
    }

    /// <summary>
    /// Reads the channel sample data from a riff wave in the given reader.
    /// The channel data is returned in the ChannelData property of the wave
    /// parameter. This parameter has to be passed to the ReadFormatChunk
    /// method before, so the NumChannels property is setup correctly.
    /// </summary>
    /// <param name="reader">The BinaryReader used to the channel data.</param>
    /// <param name="wave">The wave form that will be filled with the channel data.</param>
    /// <returns>True if the channel data has been loaded successfully, else False.</returns>
    private static bool ReadChannelData(BinaryReader reader, WaveForm wave)
    {
      reader.BaseStream.Seek(0, SeekOrigin.Begin);
      if (FindString(reader, "data"))
      {
        uint size = reader.ReadUInt32();
        uint numSamples = size / (uint)wave.NumChannels / 2;
        wave.NumberOfSamples = numSamples;

        byte[] samples = reader.ReadBytes((int)size);

        wave.ChannelData = samples;
        return true;
      }
      else
        return false;
    }

  }
}
