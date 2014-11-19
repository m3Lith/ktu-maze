﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace Maze_try2
{
    class RecursiveDivisionAlgorithm : IMazeAlgorithm
    {
        private Random _rng;

        public RecursiveDivisionAlgorithm()
        {
            _rng = new Random();
        }

        public RecursiveDivisionAlgorithm(Random rng)
        {
            _rng = rng;
        }

        public void GenerateMaze(int size, int animationDelay = 0)
        {
            MazeData.CreateEmpty(size, true);
            
            var mazeWidth = size;
            var mazeHeight = size;

            AppData.AppState = AppData.AppStates.LongTask;

            RecursivelyGenerate(0, 0, mazeWidth, mazeHeight, 1, animationDelay);
            
            AppData.AppState = AppData.AppStates.Idle;
        }


        private void RecursivelyGenerate(int x, int y, int width, int height, int depth, int animationDelay)
        {
            if (width < 4 || height < 4)
                return;

            if (AppData.AppState != AppData.AppStates.LongTask)
                return;

            var vertical = width > height;
            if (vertical)
            {
                var row = _rng.Next(1, width / 2) * 2;
                var col = _rng.Next(0, height / 2) * 2 + 1;
                for (var i = 1; i < height - 1; i++)
                {
                    MazeData.MazeMatrix[x + row, y + i] = CellState.Wall;
                    if (animationDelay > 0)
                        Thread.Sleep(animationDelay);
                    if (AppData.AppState != AppData.AppStates.LongTask)
                        return;
                }
                MazeData.MazeMatrix[x + row, y + col] = CellState.Walkway;

                if (animationDelay > 0)
                    Thread.Sleep(animationDelay);

                RecursivelyGenerate(x, y, row + 1, height, depth + 1, animationDelay);
                RecursivelyGenerate(x + row, y, width - row, height, depth + 1, animationDelay);
            }
            else
            {
                var row = _rng.Next(0, width / 2) * 2 + 1;
                var col = _rng.Next(1, height / 2) * 2;
                for (var i = 1; i < width - 1; i++)
                {
                    MazeData.MazeMatrix[x + i, y + col] = CellState.Wall;
                    if (animationDelay > 0)
                        Thread.Sleep(animationDelay);
                    if (AppData.AppState != AppData.AppStates.LongTask)
                        return;
                }
                MazeData.MazeMatrix[x + row, y + col] = CellState.Walkway;
                if (animationDelay > 0)
                    Thread.Sleep(animationDelay);

                RecursivelyGenerate(x, y, width, col + 1, depth + 1, animationDelay);
                RecursivelyGenerate(x, y + col, width, height - col, depth + 1, animationDelay);
            }
        }

    }
}
