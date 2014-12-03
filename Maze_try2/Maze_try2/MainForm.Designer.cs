using System.Windows.Forms;

namespace Maze_try2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainRenderControl = new SharpDX.Windows.RenderControl();
            this.AlgorithmLabel = new System.Windows.Forms.Label();
            this.AlgorithmComboBox = new System.Windows.Forms.ComboBox();
            this.BehaviorTrackBar = new System.Windows.Forms.TrackBar();
            this.BehaviorLabel = new System.Windows.Forms.Label();
            this.SizeLabel = new System.Windows.Forms.Label();
            this.SizeTextBox = new System.Windows.Forms.TextBox();
            this.AnimateCheckBox = new System.Windows.Forms.CheckBox();
            this.DelayLabel = new System.Windows.Forms.Label();
            this.DelayTextBox = new System.Windows.Forms.TextBox();
            this.GenerateMazeButton = new System.Windows.Forms.Button();
            this.AbortButton = new System.Windows.Forms.Button();
            this.SolveButton = new System.Windows.Forms.Button();
            this.HelpButton = new System.Windows.Forms.Button();
            this.msLabel = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.BehaviorTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // MainRenderControl
            // 
            this.MainRenderControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainRenderControl.Location = new System.Drawing.Point(316, 1);
            this.MainRenderControl.Name = "MainRenderControl";
            this.MainRenderControl.Size = new System.Drawing.Size(549, 479);
            this.MainRenderControl.TabIndex = 0;
            // 
            // AlgorithmLabel
            // 
            this.AlgorithmLabel.AutoSize = true;
            this.AlgorithmLabel.Location = new System.Drawing.Point(13, 13);
            this.AlgorithmLabel.Name = "AlgorithmLabel";
            this.AlgorithmLabel.Size = new System.Drawing.Size(53, 13);
            this.AlgorithmLabel.TabIndex = 1;
            this.AlgorithmLabel.Text = "Algorithm:";
            // 
            // AlgorithmComboBox
            // 
            this.AlgorithmComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AlgorithmComboBox.FormattingEnabled = true;
            this.AlgorithmComboBox.Items.AddRange(new object[] {
            "Kruskal\'s",
            "Recursive division",
            "Sidewinder"});
            this.AlgorithmComboBox.Location = new System.Drawing.Point(72, 10);
            this.AlgorithmComboBox.Name = "AlgorithmComboBox";
            this.AlgorithmComboBox.Size = new System.Drawing.Size(226, 21);
            this.AlgorithmComboBox.TabIndex = 2;
            // 
            // BehaviorTrackBar
            // 
            this.BehaviorTrackBar.Location = new System.Drawing.Point(13, 49);
            this.BehaviorTrackBar.Maximum = 1000;
            this.BehaviorTrackBar.Name = "BehaviorTrackBar";
            this.BehaviorTrackBar.Size = new System.Drawing.Size(297, 45);
            this.BehaviorTrackBar.TabIndex = 3;
            // 
            // BehaviorLabel
            // 
            this.BehaviorLabel.AutoSize = true;
            this.BehaviorLabel.BackColor = System.Drawing.Color.Transparent;
            this.BehaviorLabel.Location = new System.Drawing.Point(134, 67);
            this.BehaviorLabel.Name = "BehaviorLabel";
            this.BehaviorLabel.Size = new System.Drawing.Size(49, 13);
            this.BehaviorLabel.TabIndex = 4;
            this.BehaviorLabel.Text = "Behavior";
            // 
            // SizeLabel
            // 
            this.SizeLabel.AutoSize = true;
            this.SizeLabel.Location = new System.Drawing.Point(152, 108);
            this.SizeLabel.Name = "SizeLabel";
            this.SizeLabel.Size = new System.Drawing.Size(30, 13);
            this.SizeLabel.TabIndex = 5;
            this.SizeLabel.Text = "Size:";
            // 
            // SizeTextBox
            // 
            this.SizeTextBox.Location = new System.Drawing.Point(188, 105);
            this.SizeTextBox.MaxLength = 5;
            this.SizeTextBox.Name = "SizeTextBox";
            this.SizeTextBox.Size = new System.Drawing.Size(79, 20);
            this.SizeTextBox.TabIndex = 6;
            this.SizeTextBox.Text = "10";
            this.SizeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SizeTextBox_KeyPress);
            // 
            // AnimateCheckBox
            // 
            this.AnimateCheckBox.AutoSize = true;
            this.AnimateCheckBox.Location = new System.Drawing.Point(18, 148);
            this.AnimateCheckBox.Name = "AnimateCheckBox";
            this.AnimateCheckBox.Size = new System.Drawing.Size(64, 17);
            this.AnimateCheckBox.TabIndex = 7;
            this.AnimateCheckBox.Text = "Animate";
            this.AnimateCheckBox.UseVisualStyleBackColor = true;
            this.AnimateCheckBox.CheckedChanged += new System.EventHandler(this.AnimateCheckBox_CheckedChanged);
            // 
            // DelayLabel
            // 
            this.DelayLabel.AutoSize = true;
            this.DelayLabel.Location = new System.Drawing.Point(99, 149);
            this.DelayLabel.Name = "DelayLabel";
            this.DelayLabel.Size = new System.Drawing.Size(84, 13);
            this.DelayLabel.TabIndex = 8;
            this.DelayLabel.Text = "Animation delay:";
            // 
            // DelayTextBox
            // 
            this.DelayTextBox.Enabled = false;
            this.DelayTextBox.Location = new System.Drawing.Point(188, 146);
            this.DelayTextBox.MaxLength = 5;
            this.DelayTextBox.Name = "DelayTextBox";
            this.DelayTextBox.Size = new System.Drawing.Size(79, 20);
            this.DelayTextBox.TabIndex = 9;
            this.DelayTextBox.Text = "0";
            this.DelayTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DelayTextBox_KeyPress);
            // 
            // GenerateMazeButton
            // 
            this.GenerateMazeButton.Location = new System.Drawing.Point(18, 288);
            this.GenerateMazeButton.Name = "GenerateMazeButton";
            this.GenerateMazeButton.Size = new System.Drawing.Size(131, 23);
            this.GenerateMazeButton.TabIndex = 10;
            this.GenerateMazeButton.Text = "Generate Maze";
            this.GenerateMazeButton.UseVisualStyleBackColor = true;
            this.GenerateMazeButton.Click += new System.EventHandler(this.GenerateMazeButton_Click);
            // 
            // AbortButton
            // 
            this.AbortButton.Location = new System.Drawing.Point(164, 288);
            this.AbortButton.Name = "AbortButton";
            this.AbortButton.Size = new System.Drawing.Size(134, 23);
            this.AbortButton.TabIndex = 11;
            this.AbortButton.Text = "Abort";
            this.AbortButton.UseVisualStyleBackColor = true;
            this.AbortButton.Click += new System.EventHandler(this.AbortButton_Click);
            // 
            // SolveButton
            // 
            this.SolveButton.Location = new System.Drawing.Point(18, 325);
            this.SolveButton.Name = "SolveButton";
            this.SolveButton.Size = new System.Drawing.Size(131, 23);
            this.SolveButton.TabIndex = 12;
            this.SolveButton.Text = "Solve";
            this.SolveButton.UseVisualStyleBackColor = true;
            this.SolveButton.Click += new System.EventHandler(this.SolveButton_Click);
            // 
            // HelpButton
            // 
            this.HelpButton.Location = new System.Drawing.Point(164, 325);
            this.HelpButton.Name = "HelpButton";
            this.HelpButton.Size = new System.Drawing.Size(134, 23);
            this.HelpButton.TabIndex = 13;
            this.HelpButton.Text = "Help me";
            this.HelpButton.UseVisualStyleBackColor = true;
            this.HelpButton.Click += new System.EventHandler(this.HelpButton_Click);
            // 
            // msLabel
            // 
            this.msLabel.AutoSize = true;
            this.msLabel.Location = new System.Drawing.Point(269, 149);
            this.msLabel.Name = "msLabel";
            this.msLabel.Size = new System.Drawing.Size(20, 13);
            this.msLabel.TabIndex = 14;
            this.msLabel.Text = "ms";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(18, 361);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(131, 23);
            this.SaveButton.TabIndex = 15;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 483);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.msLabel);
            this.Controls.Add(this.HelpButton);
            this.Controls.Add(this.SolveButton);
            this.Controls.Add(this.AbortButton);
            this.Controls.Add(this.GenerateMazeButton);
            this.Controls.Add(this.DelayTextBox);
            this.Controls.Add(this.DelayLabel);
            this.Controls.Add(this.AnimateCheckBox);
            this.Controls.Add(this.SizeTextBox);
            this.Controls.Add(this.SizeLabel);
            this.Controls.Add(this.BehaviorLabel);
            this.Controls.Add(this.BehaviorTrackBar);
            this.Controls.Add(this.AlgorithmComboBox);
            this.Controls.Add(this.AlgorithmLabel);
            this.Controls.Add(this.MainRenderControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Maze Generator";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BehaviorTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SharpDX.Windows.RenderControl MainRenderControl;
        private System.Windows.Forms.Label AlgorithmLabel;
        private System.Windows.Forms.ComboBox AlgorithmComboBox;
        private System.Windows.Forms.TrackBar BehaviorTrackBar;
        private System.Windows.Forms.Label BehaviorLabel;
        private System.Windows.Forms.Label SizeLabel;
        private System.Windows.Forms.TextBox SizeTextBox;
        private System.Windows.Forms.CheckBox AnimateCheckBox;
        private System.Windows.Forms.Label DelayLabel;
        private System.Windows.Forms.TextBox DelayTextBox;
        private System.Windows.Forms.Button GenerateMazeButton;
        private System.Windows.Forms.Button AbortButton;
        private System.Windows.Forms.Button SolveButton;
        private System.Windows.Forms.Button HelpButton;
        private System.Windows.Forms.Label msLabel;
        private Button SaveButton;
    }
}

