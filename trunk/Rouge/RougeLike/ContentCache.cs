using System;
using System.Collections.Generic;
using System.IO;
using OkuBase;
using OkuBase.Audio;
using OkuBase.Graphics;
using JSONator;

namespace RougeLike
{
  /// <summary>
  /// Caches content so it is not loaded multiple times.
  /// </summary>
  public class ContentCache
  {
    private Dictionary<string, Animation> _animations = new Dictionary<string, Animation>();
    private Dictionary<string, Image> _images = new Dictionary<string, Image>();

    private Dictionary<string, Sound> _sounds = new Dictionary<string, Sound>();
    private Dictionary<string, List<Source>> _sources = new Dictionary<string, List<Source>>();

    public ContentCache()
    {
    }

    /// <summary>
    /// Clears the cache and releases all content that has been loaded.
    /// </summary>
    public void Clear()
    {
      //Anims can be cleared directly, as their images are released in the next step
      _animations.Clear();

      //Release images
      foreach (Image image in _images.Values)
        OkuManager.Instance.Graphics.ReleaseImage(image);

      _images.Clear();

      //Release sounds
      foreach (List<Source> sources in _sources.Values)
      {
        foreach (Source source in sources)
        {
          OkuManager.Instance.Audio.ReleaseSound(source);
        }
      }
      _sources.Clear();

      //Sounds do not have to be released
      _sounds.Clear();
    }

    /// <summary>
    /// Gets the animation with the given name.
    /// </summary>
    /// <param name="animName">The name of the animation, either with or without the ".json" file extension.</param>
    /// <returns>The animation with the given name.</returns>
    public Animation GetAnimation(string animName)
    {
      //Add extension if it was not given
      if (Path.GetExtension(animName) == "")
        animName += ".json";

      if (_animations.ContainsKey(animName))
      {
        Animation source = _animations[animName];
        Animation result = new Animation();
        result.Frames = new List<ImageBase>(source.Frames);
        result.FrameTime = source.FrameTime;
        result.Loop = source.Loop;
        return result;
      }
      else
      {

        JSONObjectValue root = GameUtil.ParseJsonFile(Path.Combine(".\\Content\\Animations", animName));

        Animation result = new Animation();
        result.Loop = root.GetBool("loop").Value;
        result.FrameTime = (int)root.GetNumber("frametime").Value;

        foreach (JSONStringValue frame in root.GetArray("frames"))
          result.Frames.Add(GetImage(frame.Value));

        _animations.Add(animName, result);

        return result;
      }
    }

    /// <summary>
    /// Gets the image with the given name.
    /// </summary>
    /// <param name="fileName">The name of the image, either with or without the ".png" extension.</param>
    /// <returns>The image with the given name.</returns>
    public Image GetImage(string fileName)
    {
      //Add extension if it was not given
      if (Path.GetExtension(fileName) == "")
        fileName += ".png";

      if (_images.ContainsKey(fileName))
        return _images[fileName];

      string fullPath = Path.Combine(".\\Content\\Graphics", fileName);
      if (!File.Exists(fullPath))
        throw new OkuException("There is no file called " + fileName + " in the content folder!");

      ImageData data = ImageData.FromFile(fullPath);
      Image image = OkuManager.Instance.Graphics.NewImage(data);

      _images.Add(fileName, image);

      return image;
    }

    /// <summary>
    /// Gets a new sound source for the sound with the given name.
    /// </summary>
    /// <param name="filename">The name of the sound, either with or without the ".wav" extension.</param>
    /// <returns>A new source for the sound with given name.</returns>
    public Source GetSound(string filename)
    {
      if (Path.GetExtension(filename) == "")
        filename += ".wav";

      Sound sound = null;
      if (_sounds.ContainsKey(filename))
        sound = _sounds[filename];
      else
        sound = Sound.FromFile(Path.Combine(".\\Content\\Sounds", filename));

      Source result = OkuManager.Instance.Audio.NewSource(sound);
      if (!_sources.ContainsKey(filename))
        _sources.Add(filename, new List<Source>());
      _sources[filename].Add(result);

      return result;
    }

  }
}
