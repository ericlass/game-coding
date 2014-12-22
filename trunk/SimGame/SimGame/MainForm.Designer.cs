namespace SimGame
{
  partial class MainForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.txtEvent = new System.Windows.Forms.TextBox();
      this.btnTrigger = new System.Windows.Forms.Button();
      this.txtLog = new System.Windows.Forms.TextBox();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.SuspendLayout();
      // 
      // txtEvent
      // 
      this.txtEvent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtEvent.Location = new System.Drawing.Point(12, 12);
      this.txtEvent.Name = "txtEvent";
      this.txtEvent.Size = new System.Drawing.Size(946, 31);
      this.txtEvent.TabIndex = 0;
      // 
      // btnTrigger
      // 
      this.btnTrigger.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnTrigger.Location = new System.Drawing.Point(964, 12);
      this.btnTrigger.Name = "btnTrigger";
      this.btnTrigger.Size = new System.Drawing.Size(125, 42);
      this.btnTrigger.TabIndex = 1;
      this.btnTrigger.Text = "Trigger";
      this.btnTrigger.UseVisualStyleBackColor = true;
      this.btnTrigger.Click += new System.EventHandler(this.btnTrigger_Click);
      // 
      // txtLog
      // 
      this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtLog.Location = new System.Drawing.Point(12, 60);
      this.txtLog.Multiline = true;
      this.txtLog.Name = "txtLog";
      this.txtLog.ReadOnly = true;
      this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.txtLog.Size = new System.Drawing.Size(1077, 606);
      this.txtLog.TabIndex = 2;
      // 
      // timer1
      // 
      this.timer1.Enabled = true;
      this.timer1.Interval = 250;
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.ClientSize = new System.Drawing.Size(1101, 678);
      this.Controls.Add(this.txtLog);
      this.Controls.Add(this.btnTrigger);
      this.Controls.Add(this.txtEvent);
      this.Name = "MainForm";
      this.Text = "Form1";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox txtEvent;
    private System.Windows.Forms.Button btnTrigger;
    private System.Windows.Forms.TextBox txtLog;
    private System.Windows.Forms.Timer timer1;

  }
}

