using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Maze_try2
{
    static class Solving
    {
        public static void Solve()
        {
            AppData.AppState = AppData.AppStates.LongTask;

            //MazePoint[,] precMatrix;
            //int[,] distMatrix;
            var solvePath = new List<MazePoint>();

            var heatMatrix = HeatMap.Generate(MazeData.EntrancePoint.X, MazeData.EntrancePoint.Y, false, MazeData.ExitPoint.X, MazeData.ExitPoint.Y);
            var currentPoint = new MazePoint(MazeData.ExitPoint.X, MazeData.ExitPoint.Y);
            while (currentPoint != null)
            {
                var lastPoint = currentPoint;
                if (AppData.AppState == AppData.AppStates.Idle)
                    break;
                if (heatMatrix[currentPoint.X, currentPoint.Y].Preceding != null &&
                    (Math.Abs(currentPoint.X - heatMatrix[currentPoint.X, currentPoint.Y].Preceding.X) > 1 ||
                    Math.Abs(currentPoint.Y - heatMatrix[currentPoint.X, currentPoint.Y].Preceding.Y) > 1))
                {
                    var extraWeavePoint = new MazePoint((currentPoint.X + heatMatrix[currentPoint.X, currentPoint.Y].Preceding.X) / 2, (currentPoint.Y + heatMatrix[currentPoint.X, currentPoint.Y].Preceding.Y) / 2);
                    solvePath.Add(extraWeavePoint);
                }
                solvePath.Add(currentPoint);
                currentPoint = heatMatrix[currentPoint.X, currentPoint.Y].Preceding;
                //if (AnimateCheckBox.Checked && Convert.ToInt32(DelayTextBox.Text) > 0)
                //    Thread.Sleep(Convert.ToInt32(DelayTextBox.Text));
            }

            //foreach (var solvePoint in solvePath)
            for(var i = 1; i < solvePath.Count - 1; i++)
                MazeData.MazeMatrix[solvePath[i].X, solvePath[i].Y].Display = MazeData.MazeColors[CellState.AutoPath];

            /*if (!AnimateCheckBox.Checked)
            {
                foreach (var solvePoint in solvePath)
                    DrawCell(solvePoint.X, solvePoint.Y, MazeColors.AutoPath.Brush);
                RefreshPictureBox();
            }*/
            /*BeginInvoke(new MethodInvoker(() =>
            {
                EnableButtons();
                GameStepsLabel.Visible = true;
                GameStepsLabel.Text = @"Shortest path - " + solvePath.Count;
            }));*/
        }

    }
}
