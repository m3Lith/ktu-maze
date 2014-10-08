using System;
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
        private bool[,] _mazeMatrix;

        private void Form1_Load(object sender, EventArgs e)
        {
            var size = Convert.ToInt32(SizeTextBox.Text);
            size = (size - 1)*2 + 1;
            _mazeMatrix = new bool[size,size];
            _mazeEngine = new MazeEngine(MainRenderControl, _mazeMatrix);
            new Thread(() => Invoke(new MethodInvoker(() => _mazeEngine.Run(MainRenderControl)))){IsBackground =  true}.Start();
        }

        private void GenerateMazeButton_Click(object sender, EventArgs e)
        {
            _mazeMatrix[5, 5] = true;
            _mazeMatrix[6, 7] = true;
        }
    }
}
