﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maze_try2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private MazeEngine _mazeEngine;
        

        private void Form1_Load(object sender, EventArgs e)
        {
            _mazeEngine = new MazeEngine(MainRenderControl);
            new Thread(() => Invoke(new MethodInvoker(() => _mazeEngine.Run(MainRenderControl)))){IsBackground =  true}.Start();
        }

        private void GenerateMazeButton_Click(object sender, EventArgs e)
        {
            var size = (Convert.ToInt32(SizeTextBox.Text) - 1)*2 + 1;
            var alg = new KruskalsAlgorithm();
            var delay = Convert.ToInt32(DelayTextBox.Text == string.Empty ? "0" : DelayTextBox.Text);

            new Thread(() => alg.GenerateMaze(size, delay)) {IsBackground = true}.Start();
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            new HelpForm().Show();
        }

        private void DelayTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void SizeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void AnimateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //DelayTextBox.Enabled = AnimateCheckBox.Checked;
            if (AnimateCheckBox.Checked)
            {
                DelayTextBox.Enabled = true; 
                DelayTextBox.Text = "1";
            }
            else
            {
                DelayTextBox.Enabled = false;
                DelayTextBox.Text = "0";
            }
        }
    }
}
