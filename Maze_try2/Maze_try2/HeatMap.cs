using System.Collections.Generic;
using System.Linq;
using SharpDX;

namespace Maze_try2
{
    static class HeatMap
    {
        public class HeatPoint
        {
            public int Distance { get; set; }
            public MazePoint Preceding { get; set; }
        }

        public static HeatPoint[,] Generate(int fromX, int fromY, bool draw)
        {
            return Generate(fromX, fromY, draw, -1, -1);
        }

        public static HeatPoint[,] Generate(int fromX, int fromY, bool draw, int breakOnX, int breakOnY)
        {
            var _mazeWidth = MazeData.MazeSize;
            var _mazeHeight = MazeData.MazeSize;

            //distMatrix = new int[_mazeWidth, _mazeHeight];
            //precMatrix = new MazePoint[_mazeWidth, _mazeHeight];

            var heatMatrix = new HeatPoint[_mazeWidth,_mazeHeight];

            for (int i = 0; i < _mazeWidth; i++)
                for (int j = 0; j < _mazeHeight; j++)
                    heatMatrix[i, j] = new HeatPoint();

            var point = new MazePoint(fromX, fromY);
            var row = new LinkedList<MazePoint>();
            row.AddFirst(point);

            var endPointFound = false;
            var count = 1;
            var newCount = -1;
            var index = -1;
            for (var curr = row.First; curr != null; curr = curr.Next)
            {
                index++;
                if (AppData.AppState == AppData.AppStates.Idle)
                    break;

                if (index == count)
                    newCount = row.Count;

                if (index == newCount)
                {
                    for (var i = 0; i < count; i++)
                        row.RemoveFirst();
                    index -= count;
                    count = newCount - count;
                    newCount = row.Count;
                }

                var adjPoints = MazeData.GetAdjPoints(curr.Value);
                foreach (var adjPoint in adjPoints)
                {
                    MazePoint goToPoint;
                    /*if (MazeData.MazeMatrix[adjPoint.X, adjPoint.Y] == CellState.HorWeave ||
                        MazeData.MazeMatrix[adjPoint.X, adjPoint.Y] == CellState.VertWeave)
                    {
                        goToPoint = new MazePoint(adjPoint.X + (adjPoint.X - curr.Value.X),
                            adjPoint.Y + (adjPoint.Y - curr.Value.Y));
                    }
                    else*/
                        goToPoint = adjPoint;

                    if (row.Contains(goToPoint))
                        continue;
                    row.AddLast(goToPoint);
                    heatMatrix[goToPoint.X, goToPoint.Y].Preceding = curr.Value;
                    heatMatrix[goToPoint.X, goToPoint.Y].Distance = heatMatrix[curr.Value.X, curr.Value.Y].Distance + 1;

                    if (breakOnX > 0 && breakOnY > 0 && goToPoint.X == breakOnX && goToPoint.Y == breakOnY)
                    {
                        endPointFound = true;
                        break;
                    }
                }
                //if (AnimateCheckBox.Checked && Convert.ToInt32(DelayTextBox.Text) > 0)
                //    Thread.Sleep(Convert.ToInt32(DelayTextBox.Text));
                if (endPointFound)
                    break;
            }

            /*for (var i = 0; i < _mazeWidth; i++)
            {
                for (var j = 0; j < _mazeHeight; j++)
                {
                    switch (_mazeMatrix[i, j])
                    {
                        case CellState.VertWeave:
                            distMatrix[i, j] = (distMatrix[i + 1, j] + distMatrix[i - 1, j]) / 2;
                            break;
                        case CellState.HorWeave:
                            distMatrix[i, j] = (distMatrix[i, j + 1] + distMatrix[i, j - 1]) / 2;
                            break;
                    }
                }
            }*/

            if (!draw)
                return heatMatrix;

            var maxDist = 1;
            for (var i = 0; i < _mazeWidth; i++)
                for (var j = 0; j < _mazeHeight; j++)
                    if (heatMatrix[i, j].Distance > maxDist)
                        maxDist = heatMatrix[i, j].Distance;

            for (var i = 0; i < _mazeWidth; i++)
            {
                for (var j = 0; j < _mazeHeight; j++)
                {
                    if (MazeData.MazeMatrix[i, j] == null || MazeData.MazeMatrix[i, j].State == CellState.Wall)
                        continue;

                    var red = heatMatrix[i, j].Distance * 255 / maxDist;
                    Color c;
                    if (heatMatrix[i, j].Distance < 1)
                        c = MazeData.MazeColors[CellState.Entrance];
                    else if (heatMatrix[i, j].Distance > maxDist - 1)
                        c = MazeData.MazeColors[CellState.Furthest];
                    else c = Color.FromRgba(50 * 256 * 256 + 50 * 256 + red);
                    MazeData.MazeMatrix[i, j].Display = c;
                }
            }

            return heatMatrix;
        }

    }
}
