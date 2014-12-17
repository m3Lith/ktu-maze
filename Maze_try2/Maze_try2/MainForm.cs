using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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

        private double _delayValue = 0d;
        private int _behaviorValue = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            _mazeEngine = new MazeEngine(MainRenderControl);
            AlgorithmComboBox.SelectedIndex = 0;
            new Thread(() => Invoke(new MethodInvoker(() => _mazeEngine.Run(MainRenderControl)))){IsBackground =  true}.Start();
        }

        private void GenerateMazeButton_Click(object sender, EventArgs e)
        {
            var size = (Convert.ToInt32(SizeTextBox.Text) - 1)*2 + 1;
            var rng = new Random();
            BaseAlgorithm alg;
            switch (AlgorithmComboBox.SelectedIndex)
            {
                case 0:
                    alg = new KruskalsAlgorithm(rng);
                    break;
                case 1:
                    alg = new RecursiveDivisionAlgorithm(rng);
                    break;
                case 2:
                    alg = new SidewinderAlgorithm(rng);
                    break;
                case 3:
                    alg = new GrowingTreeAlgorithm(rng);
                    break;
                default:
                    throw new Exception("Algorithm index not found");
            }
            new Thread(() => alg.GenerateMaze(size, ref _delayValue, ref _behaviorValue)) {IsBackground = true}.Start();
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            new HelpForm().Show();
        }

        private void DelayTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !(e.KeyChar == '.' && !DelayTextBox.Text.Contains('.') && DelayTextBox.Text != string.Empty))
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

        private void AbortButton_Click(object sender, EventArgs e)
        {
            AppData.AppState = AppData.AppStates.Idle;
        }

        private void SolveButton_Click(object sender, EventArgs e)
        {
            Solving.Solve();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog
            {
                Filter = @"png images (*.png)|*.png|All files (*.*)|*.*"
            };
            //dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _mazeEngine.SaveImage(dialog.FileName);
            }
            
        }

        private void DelayTextBox_TextChanged(object sender, EventArgs e)
        {
            _delayValue = 0d;
            double.TryParse(DelayTextBox.Text, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out _delayValue);
        }

        private void BehaviorTrackBar_Scroll(object sender, EventArgs e)
        {
            _behaviorValue = BehaviorTrackBar.Value;
        }
    }
}
