namespace ThinGLTest
{
  partial class Form1
  {
    /// <summary>
    /// Erforderliche Designervariable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Verwendete Ressourcen bereinigen.
    /// </summary>
    /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Vom Windows Form-Designer generierter Code

    /// <summary>
    /// Erforderliche Methode für die Designerunterstützung.
    /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
    /// </summary>
    private void InitializeComponent()
    {
      this.btnInit = new System.Windows.Forms.Button();
      this.pnlCanvas = new System.Windows.Forms.Panel();
      this.SuspendLayout();
      // 
      // btnInit
      // 
      this.btnInit.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.btnInit.Location = new System.Drawing.Point(12, 12);
      this.btnInit.Name = "btnInit";
      this.btnInit.Size = new System.Drawing.Size(75, 23);
      this.btnInit.TabIndex = 0;
      this.btnInit.Text = "Init";
      this.btnInit.UseVisualStyleBackColor = true;
      this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
      // 
      // pnlCanvas
      // 
      this.pnlCanvas.Location = new System.Drawing.Point(12, 41);
      this.pnlCanvas.Name = "pnlCanvas";
      this.pnlCanvas.Size = new System.Drawing.Size(640, 480);
      this.pnlCanvas.TabIndex = 1;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(673, 559);
      this.Controls.Add(this.pnlCanvas);
      this.Controls.Add(this.btnInit);
      this.Name = "Form1";
      this.Text = "Form1";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btnInit;
    private System.Windows.Forms.Panel pnlCanvas;
  }
}

