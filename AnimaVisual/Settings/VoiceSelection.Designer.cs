namespace Anima
{
    partial class VoiceSelection
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
            this.VoicesListBox = new System.Windows.Forms.ListBox();
            this.UpdateBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // VoicesListBox
            // 
            this.VoicesListBox.FormattingEnabled = true;
            this.VoicesListBox.Location = new System.Drawing.Point(13, 13);
            this.VoicesListBox.Name = "VoicesListBox";
            this.VoicesListBox.Size = new System.Drawing.Size(325, 290);
            this.VoicesListBox.TabIndex = 0;
            this.VoicesListBox.SelectedIndexChanged += new System.EventHandler(this.VoicesListBox_SelectedIndexChanged);
            // 
            // UpdateBtn
            // 
            this.UpdateBtn.Location = new System.Drawing.Point(13, 310);
            this.UpdateBtn.Name = "UpdateBtn";
            this.UpdateBtn.Size = new System.Drawing.Size(75, 23);
            this.UpdateBtn.TabIndex = 1;
            this.UpdateBtn.Text = "Update";
            this.UpdateBtn.UseVisualStyleBackColor = true;
            // 
            // VoiceSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 340);
            this.Controls.Add(this.UpdateBtn);
            this.Controls.Add(this.VoicesListBox);
            this.Name = "VoiceSelection";
            this.Text = "VoiceSelection";
            this.Load += new System.EventHandler(this.VoiceSelection_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox VoicesListBox;
        private System.Windows.Forms.Button UpdateBtn;
    }
}