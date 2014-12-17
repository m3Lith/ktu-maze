using System;
using System.Collections.Generic;
using SharpDX;

namespace Maze_try2
{
    public class Cell
    {
        private CellState _state;

        public Cell(CellState state)
        {
            State = state;
        }

        public CellState State
        {
            get { return _state; }
            set
            {
                if(value != CellState.Wall && value != CellState.Walkway)
                    throw new Exception("Tried to set an invalid CellState");
                _state = value;
                Display = MazeData.MazeColors[value];
            }
        }

        public Color Display { get; set; }

        public Color ResetDisplayColor()
        {
            Display = MazeData.MazeColors[State];
            return Display;
        }
    }

    public enum CellState
    {
        Wall,
        Walkway,
        Generating,
        AutoPath,
        Entrance,
        Exit,
        Furthest
    }

    static class MazeData
    {
        private static MazePoint _entrancePoint;
        private static MazePoint _exitPoint;

        static MazeData()
        {
            MazeSize = 0;
            MazeExists = false;

            MazeColors = new Dictionary<CellState, Color>
            {
                {CellState.Wall, Color.Black},
                {CellState.Walkway, Color.Green},
                {CellState.Generating, Color.BurlyWood},
                {CellState.AutoPath, Color.DeepSkyBlue},
                {CellState.Entrance, Color.Chartreuse},
                {CellState.Exit, Color.Orange},
                {CellState.Furthest, Color.Yellow}
            };

            Directions = new Dictionary<int, MazePoint>
            {
                {0, new MazePoint(-1, 0)},
                {1, new MazePoint(1, 0)},
                {2, new MazePoint(0, -1)},
                {3, new MazePoint(0, 1)},
                {-1, new MazePoint(0, 0)}
            };
        }

        public static Dictionary<CellState, Color> MazeColors { get; private set; }
        public static Cell[,] MazeMatrix { get; set; }
        public static int MazeSize { get; set; }
        public static bool MazeExists { get; set; }
        public static Dictionary<int, MazePoint> Directions { get; private set; }

        public static MazePoint EntrancePoint
        {
            get { return _entrancePoint; }
            set
            {
                if(_entrancePoint != null)
                    MazeMatrix[_entrancePoint.X, _entrancePoint.Y].ResetDisplayColor();
                _entrancePoint = value;
                MazeMatrix[_entrancePoint.X, _entrancePoint.Y].Display = MazeColors[CellState.Entrance];
            }
        }

        public static MazePoint ExitPoint
        {
            get { return _exitPoint; }
            set
            {
                if(_exitPoint != null)
                    MazeMatrix[_exitPoint.X, _exitPoint.Y].ResetDisplayColor();
                _exitPoint = value;
                MazeMatrix[_exitPoint.X, _exitPoint.Y].Display = MazeColors[CellState.Exit];
            }
        }

        public static void CreateEmpty(int size, bool preFill = false)
        {
            MazeMatrix = new Cell[size, size];

            //if (preFill)
                for (var i = 1; i < size - 1; i++)
                    for (var j = 1; j < size - 1; j++)
                        MazeMatrix[i, j] = new Cell(preFill ? CellState.Walkway : CellState.Wall);
            //else
            //    for (var i = 0; i < size; i++)
            //        for (var j = 0; j < size; j++)
            //            MazeMatrix[i,j] = new Cell(CellState.Wall);
            MazeSize = size;
            MazeExists = true;
        }

        #region GetAdjPoints
        public static IEnumerable<MazePoint> GetAdjPoints(MazePoint point)
        {
            return GetAdjPoints(point.X, point.Y);
        }

        public static IEnumerable<MazePoint> GetAdjPoints(int x, int y)
        {
            var adjPoints = new List<MazePoint>();
            for (var i = 0; i < 4; i++)
            {
                if (IsPointInMaze(x + Directions[i].X, y + Directions[i].Y)
                    && MazeMatrix[x + Directions[i].X, y + Directions[i].Y].State != CellState.Wall)
                    adjPoints.Add(new MazePoint(x + Directions[i].X, y + Directions[i].Y));
            }
            return adjPoints;
        }
        #endregion

        #region IsPointInMaze
        public static bool IsPointInMaze(MazePoint point)
        {
            return IsPointInMaze(point.X, point.Y);
        }

        public static bool IsPointInMaze(int x, int y)
        {
            return x > 0 && y > 0 && x < MazeSize - 1 && y < MazeSize - 1;
        }
        #endregion

    }
}
