using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimGame
{
  public partial class MainForm : Form
  {
    private EventManager _manager = null;

    public MainForm()
    {
      InitializeComponent();

      var factory = CreateObjectFactory();
      _manager = new EventManager(factory);
      _manager.Logger = new TextBoxLogger(txtLog);

      _manager.RegisterHandler("start", new EventHandler("timer", 5.0f, "stop"));
    }

    private ActionFactory CreateObjectFactory()
    {
      var result = new ActionFactory();

      result.RegisterConstructor("timer", CreateTimerAction);

      return result;
    }

    private TimerAction CreateTimerAction(object[] parameters)
    {
      TimerAction action;
      if (parameters.Length == 1)
        action = new TimerAction((float)parameters[0]);
      else if (parameters.Length == 2)
        action = new TimerAction((float)parameters[0], (string)parameters[1]);
      else
        throw new ArgumentException("Invalid number of parameters for TimerAcion!");

      return action;
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      _manager.Update(timer1.Interval / 1000.0f);
    }

    private void btnTrigger_Click(object sender, EventArgs e)
    {
      _manager.QueueEvent(txtEvent.Text.Trim());
    }

  }
}
