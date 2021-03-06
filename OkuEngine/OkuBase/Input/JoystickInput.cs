﻿using System;
using System.Collections.Generic;
using OkuBase.Platform;

namespace OkuBase.Input
{
  /// <summary>
  /// JoystickInput is a list of all joysticks currently connected to the system.
  /// You should call the <code>Update</code> or <code>UpdateAll</code> method periodically
  /// in your game loop. These will update the current state of the joysticks.
  /// </summary>
  internal class JoystickInput : List<JoystickInfo>
  {
    private const int MAX_BUTTONS = 32;
    private JOYINFOEX _state;

    /// <summary>
    /// Creates a new JoystickInput. This will also load infos about all joyticks connected to the system.
    /// </summary>
    public JoystickInput()
    {
      Initialize();
    }

    /// <summary>
    /// Refreshes all joystick information that is currently stored. 
    /// This can be used to check if a joystick has been connected/disconnected 
    /// recently.
    /// </summary>
    public void Initialize()
    {
      Clear();

      _state = new JOYINFOEX();
      _state.dwSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(_state);
      _state.dwFlags = Winmm.JOY_RETURNALL;

      JOYCAPS caps = new JOYCAPS();
      uint capsSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(caps);

      for (uint i = 0; i < Winmm.joyGetNumDevs(); i++)
      {
        //Check for each joystick if it is ready
        bool active = Winmm.joyGetPosEx(i, ref _state) == 0;
        if (active)
        {
          if (Winmm.joyGetDevCaps(i, ref caps, capsSize) != 0)
            throw new Exception("OKUERR-002: Caps of joystick " + i + " could not be read even it is considered active!");

          Add(new JoystickInfo(i, caps, _state));
        }
      }
    }

    /// <summary>
    /// Updates the states of all joysticks. Should be called before accessing the joysticks data.
    /// </summary>
    public void UpdateAll()
    {
      foreach (JoystickInfo info in this)
      {
        if (Winmm.joyGetPosEx(info.ID, ref _state) == 0)
          info.SetState(_state);
        else
          throw new Exception("OKUERR-001: State of joystick " + info.ID + " could not be read even it is considered active!");
      }
    }

    /// <summary>
    /// Updates the state of a single joystick. Should be called before accessing the joysticks data.
    /// </summary>
    /// <param name="index"></param>
    public void Update(int index)
    {
      if (index < 0 || index >= Count)
        throw new Exception("OKUERR-003: Joystick index " + index + "is invalid. It must be in the range 0.." + (Count - 1) + "!");

      if (Winmm.joyGetPosEx(this[index].ID, ref _state) == 0)
        this[index].SetState(_state);
      else
        throw new Exception("OKUERR-001: State of joystick " + index + " could not be read even it is considered active!");
    }

  }
}
