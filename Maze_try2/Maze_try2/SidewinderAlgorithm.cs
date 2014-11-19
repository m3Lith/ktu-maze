using System;
using System.Collections.Generic;
using System.Threading;

namespace Maze_try2
{
    class SidewinderAlgorithm : IMazeAlgorithm
    {
        private Random _rng;

        public SidewinderAlgorithm()
        {
            _rng = new Random();
        }

        public SidewinderAlgorithm(Random rng)
        {
            _rng = rng;
        }

        public void GenerateMaze(int size, int animationDelay = 0)
        {
            MazeData.CreateEmpty(size);
            
            var mazeWidth = size;
            var mazeHeight = size;

            AppData.AppState = AppData.AppStates.LongTask;

            var verticalInfluenceValue = 500;
            var binaryTreeValue = 0;

            const bool startFromBottom = false;

            for (var j = startFromBottom ? 1 : mazeHeight - 2; startFromBottom ? j < mazeHeight - 1 : j > 0 ; j += startFromBottom ? 2 : -2)
            {
                if (AppData.AppState != AppData.AppStates.LongTask)
                    break;
                var setLength = 1;
                for (var i = 1; i < mazeWidth - 1; i += 2)
                {
                    if (AppData.AppState != AppData.AppStates.LongTask)
                        break;
                    
                    bool digHorizontal;
                    var useBinaryTree = _rng.Next(0, 1000) >= binaryTreeValue;

                    //var dirX = binaryTreeValue == 0 && (NWBiasRadioButton.Checked || SWBiasRadioButton.Checked) ? -1 : 1;
                    //var dirY = binaryTreeValue == 0 && (SWBiasRadioButton.Checked || SEBiasRadioButton.Checked) ? 1 : -1;

                    var dirX = 1;
                    var dirY = 1;

                    var canGoHorizontal = dirX > 0 ? i < MazeData.MazeSize - 2 : i > 2;
                    var canGoVertical = dirY > 0 ? j < MazeData.MazeSize - 2 : j > 2;

                    //var canGoHorizontal = i > 2 && i < MazeData.MazeSize - 2;
                    //var canGoVertical = j > 2 && j < MazeData.MazeSize - 2;

                    //var canGoHorizontal = _mazeRectangle.Contains(i + dirX * 2, j);
                    //var canGoVertical = _mazeRectangle.Contains(i, j + dirY * 2);

                    if (!canGoHorizontal && !canGoVertical)
                        continue;
                    if (canGoHorizontal && canGoVertical)
                        digHorizontal = _rng.Next(0, 1000) >= verticalInfluenceValue;
                    else if (canGoHorizontal)
                        digHorizontal = true;
                    else digHorizontal = false;


                    if (digHorizontal)
                    {
                        setLength++;
                        MazeData.MazeMatrix[i + dirX, j] = CellState.Walkway;
                        MazeData.MazeMatrix[i + dirX * 2, j] = CellState.Walkway;
                    }
                    else
                    {
                        //var rand = useBinaryTree ? 0 : _rng.Next(0, setLength) * 2;
                        var rand = _rng.Next(0, setLength) * 2;
                        setLength = 1;
                        MazeData.MazeMatrix[i - rand, j + dirY] = CellState.Walkway;
                    }
                    MazeData.MazeMatrix[i, j] = CellState.Walkway;

                    if (animationDelay > 0)
                        Thread.Sleep(animationDelay);
                }
            }

            AppData.AppState = AppData.AppStates.Idle;
        }
    }
}
