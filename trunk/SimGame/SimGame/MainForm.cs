using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimGame
{
  public partial class MainForm : Form, IStateMachine
  {
    private EventManager _manager = null;
    private string _currentState = null;

    public MainForm()
    {
      InitializeComponent();

      var factory = CreateObjectFactory();
      _manager = new EventManager(factory);
      _manager.Logger = new TextBoxLogger(txtLog);

      _manager.RegisterHandler("game.start", new EventHandler("timer", 5.0f, "timer1.finished"));
      _manager.RegisterHandler("timer1.finished", new EventHandler("switch_state", "first_state", this));
      _manager.RegisterHandler("timer1.finished", new EventHandler("timer", 5.0f, "timer2.finished"));
      _manager.RegisterHandler("timer2.finished", new EventHandler("switch_state", "second_state", this));
    }

    private ActionFactory CreateObjectFactory()
    {
      var result = new ActionFactory();

      result.RegisterConstructor("timer", ActionConstructors.CreateTimerAction);
      result.RegisterConstructor("switch_state", ActionConstructors.CreateSwitchStateAction);

      return result;
    }    

    private void timer1_Tick(object sender, EventArgs e)
    {
      _manager.Update(timer1.Interval / 1000.0f);
    }

    private void btnTrigger_Click(object sender, EventArgs e)
    {
      _manager.QueueEvent(txtEvent.Text.Trim());
    }
    public string CurrentState
    {
      get
      {
        return _currentState;
      }
      set
      {
        _manager.Logger.Log("NewState: " + value);
        _currentState = value;
      }
    }
  }
}
