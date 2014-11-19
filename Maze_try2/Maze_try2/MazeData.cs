﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;

namespace Maze_try2
{
    public enum CellState
    {
        Wall,
        Walkway,
        Generating
    }

    static class MazeData
    {
        static MazeData()
        {
            MazeSize = 0;
            MazeExists = false;

            MazeColors = new Dictionary<CellState, Color>
            {
                {CellState.Wall, Color.Black},
                {CellState.Walkway, Color.Green},
                {CellState.Generating, Color.BurlyWood}
            };
        }

        public static Dictionary<CellState, Color> MazeColors { get; private set; }
        public static CellState[,] MazeMatrix { get; set; }
        public static int MazeSize { get; set; }
        public static bool MazeExists { get; set; }

        public static void CreateEmpty(int size, bool preFill = false)
        {
            MazeMatrix = new CellState[size, size];

            if (preFill)
                for (var i = 1; i < size - 1; i++)
                    for (var j = 1; j < size - 1; j++)
                        MazeMatrix[i, j] = CellState.Walkway;
            else
                for (var i = 0; i < size; i++)
                    for (var j = 0; j < size; j++)
                        MazeMatrix[i,j] = CellState.Wall;
            MazeSize = size;
            MazeExists = true;
        }
    }
}
