namespace WF_Control
{
    partial class FrmMain
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
            this.scene = new WF_Control.Scene();
            this.SuspendLayout();
            // 
            // scene
            // 
            this.scene.BackColor = System.Drawing.Color.Purple;
            this.scene.Location = new System.Drawing.Point(211, 105);
            this.scene.Name = "scene";
            this.scene.Size = new System.Drawing.Size(317, 214);
            this.scene.TabIndex = 1;
            this.scene.Text = "scene";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.scene);
            this.Name = "FrmMain";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Scene scene;
    }
}

