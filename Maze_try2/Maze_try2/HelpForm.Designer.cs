namespace Maze_try2
{
    partial class HelpForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpForm));
            this.AboutGroupBox = new System.Windows.Forms.GroupBox();
            this.AboutLabel = new System.Windows.Forms.Label();
            this.HelpGroupBox = new System.Windows.Forms.GroupBox();
            this.HelpLabel = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            this.AboutGroupBox.SuspendLayout();
            this.HelpGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // AboutGroupBox
            // 
            this.AboutGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AboutGroupBox.Controls.Add(this.AboutLabel);
            this.AboutGroupBox.Location = new System.Drawing.Point(10, 15);
            this.AboutGroupBox.Name = "AboutGroupBox";
            this.AboutGroupBox.Size = new System.Drawing.Size(658, 104);
            this.AboutGroupBox.TabIndex = 0;
            this.AboutGroupBox.TabStop = false;
            this.AboutGroupBox.Text = "About";
            // 
            // AboutLabel
            // 
            this.AboutLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AboutLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.AboutLabel.Location = new System.Drawing.Point(3, 16);
            this.AboutLabel.Name = "AboutLabel";
            this.AboutLabel.Size = new System.Drawing.Size(652, 85);
            this.AboutLabel.TabIndex = 0;
            this.AboutLabel.Text = "The Maze Generator project is created by Paulius Andriekus, Gediminas Masaitis an" +
    "d Karolis Valaika.\r\nVersion 1.0.0a";
            this.AboutLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HelpGroupBox
            // 
            this.HelpGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HelpGroupBox.Controls.Add(this.HelpLabel);
            this.HelpGroupBox.Location = new System.Drawing.Point(10, 125);
            this.HelpGroupBox.Name = "HelpGroupBox";
            this.HelpGroupBox.Size = new System.Drawing.Size(658, 151);
            this.HelpGroupBox.TabIndex = 1;
            this.HelpGroupBox.TabStop = false;
            this.HelpGroupBox.Text = "Help";
            // 
            // HelpLabel
            // 
            this.HelpLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HelpLabel.Location = new System.Drawing.Point(3, 16);
            this.HelpLabel.Name = "HelpLabel";
            this.HelpLabel.Size = new System.Drawing.Size(652, 132);
            this.HelpLabel.TabIndex = 0;
            this.HelpLabel.Text = resources.GetString("HelpLabel.Text");
            this.HelpLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.Location = new System.Drawing.Point(10, 287);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(660, 31);
            this.CloseButton.TabIndex = 2;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // HelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 325);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.HelpGroupBox);
            this.Controls.Add(this.AboutGroupBox);
            this.Name = "HelpForm";
            this.Text = "Help";
            this.Load += new System.EventHandler(this.HelpForm_Load);
            this.AboutGroupBox.ResumeLayout(false);
            this.HelpGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox AboutGroupBox;
        private System.Windows.Forms.Label AboutLabel;
        private System.Windows.Forms.GroupBox HelpGroupBox;
        private System.Windows.Forms.Label HelpLabel;
        private System.Windows.Forms.Button CloseButton;
    }
}