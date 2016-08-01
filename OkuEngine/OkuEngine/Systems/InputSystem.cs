using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OkuBase;
using OkuBase.Input;
using OkuEngine.Events;
using OkuEngine.Input;
using OkuEngine.Levels;

namespace OkuEngine.Systems
{
  internal class InputSystem : GameSystem
  {
    private HashSet<int> _actionCodes = new HashSet<int>();

    public override void Execute(Level currentLevel)
    {
      _actionCodes.Clear();

      InputManager input = OkuManager.Instance.Input;

      //Keyboard key presses
      List<Keys> pressedKeys = input.Keyboard.GetPressedButtons();
      foreach (var key in pressedKeys)
      {
        currentLevel.API.QueueEvent(EventNames.GetGenericInputEventName(key, InputAction.Down));
        _actionCodes.Add(GetInputActionCode(key, InputAction.Down));
      }

      //Keyboard key raises
      List<Keys> raisedKeys = input.Keyboard.GetRaisedButtons();
      foreach (var key in raisedKeys)
      {
        currentLevel.API.QueueEvent(EventNames.GetGenericInputEventName(key, InputAction.Up));
        _actionCodes.Add(GetInputActionCode(key, InputAction.Up));
      }

      //Mouse button presses
      List<MouseButton> pressedButtons = input.Mouse.GetPressedButtons();
      foreach (var button in pressedButtons)
      {
        currentLevel.API.QueueEvent(EventNames.GetGenericInputEventName(button, InputAction.Down));
        _actionCodes.Add(GetInputActionCode(button, InputAction.Down));
      }

      //Mouse button raises
      List<MouseButton> raisedButtons = input.Mouse.GetRaisedButtons();
      foreach (var button in raisedButtons)
      {
        currentLevel.API.QueueEvent(EventNames.GetGenericInputEventName(button, InputAction.Up));
        _actionCodes.Add(GetInputActionCode(button, InputAction.Up));
      }

      //Process input contexts of current level
      foreach (var context in currentLevel.InputContexts)
      {
        foreach (var actionMapping in context.ActionMappings)
        {
          bool doQueue = false;
          foreach (var action in actionMapping.Actions)
          {
            if (_actionCodes.Contains(action.Code))
            {
              doQueue = true;
              break;
            }
          }

          if (doQueue)
            currentLevel.API.QueueEvent(actionMapping.EventName);
        }
      }

    }

    private int GetInputActionCode(Keys key, InputAction action)
    {
      return (int)InputDevice.Keyboard | (int)key | (int)action;
    }

    private int GetInputActionCode(MouseButton button, InputAction action)
    {
      return (int)InputDevice.Mouse | (int)button | (int)action;
    }
    
  }
}
