namespace TicTacToe
{
    partial class GameScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.winLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // winLabel
            // 
            this.winLabel.AutoSize = true;
            this.winLabel.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.winLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.winLabel.Location = new System.Drawing.Point(112, 9);
            this.winLabel.Name = "winLabel";
            this.winLabel.Size = new System.Drawing.Size(37, 15);
            this.winLabel.TabIndex = 0;
            this.winLabel.Text = "label1";
            this.winLabel.Visible = false;
            this.winLabel.Click += new System.EventHandler(this.winLabel_Click);
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BurlyWood;
            this.Controls.Add(this.winLabel);
            this.Name = "GameScreen";
            this.Size = new System.Drawing.Size(350, 350);
            this.Click += new System.EventHandler(this.GameScreen_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameScreen_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label winLabel;
    }
}
