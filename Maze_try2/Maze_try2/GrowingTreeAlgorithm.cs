using System;
using System.Collections.Generic;
using System.Linq;

namespace Maze_try2
{
    class GrowingTreeAlgorithm : BaseAlgorithm
    {
        private Random _rng;

        public GrowingTreeAlgorithm()
        {
            _rng = new Random();
        }

        public GrowingTreeAlgorithm(Random rng)
        {
            _rng = rng;
        }

        public override void GenerateMaze(int size, ref double animationDelay, ref int behaviorValue)
        {
            MazeData.CreateEmpty(size);

            //var loopValue = 0;
            //var weaveValue = 0;

            var useInfluences = false;
            var leftInfluence = 0;
            var rightInfluence = 0;
            var upInfluence = 0;
            var downInfluence = 0;

            var _mazeWidth = size;
            var _mazeHeight = size;

            var row = _rng.Next(0, _mazeWidth/2 - 1)*2 + 1;
            var col = _rng.Next(0, _mazeHeight/2 - 1)*2 + 1;

            var path = new List<MazePoint> {new MazePoint(row, col)};

            MazeData.MazeMatrix[row, col].State = CellState.Walkway;
            AppData.AppState = AppData.AppStates.LongTask;

            //var permitloop = false;
            var success = true;
            var moveVect = MazeData.Directions[-1];
            while (path.Count > 0 && AppData.AppState == AppData.AppStates.LongTask)
            {
                int currIndex;
                if (_rng.Next(1, 1001) < behaviorValue)
                    currIndex = _rng.Next(0, path.Count);
                else
                    currIndex = path.Count - 1;

                row = path[currIndex].X;
                col = path[currIndex].Y;

                //var origRow = row;
                //var origCol = col;

                //success = TryDig(ref row, ref col, out moveVect, _rng.Next(0, 1001) < weaveValue, false, useInfluences ? new List<int> { leftInfluence, rightInfluence, upInfluence, downInfluence } : null);
                var rand = 0;
                //var val = 0;
                var probabilities = useInfluences
                    ? new List<int> {leftInfluence, rightInfluence, upInfluence, downInfluence}
                    : null;
                if (probabilities == null)
                    probabilities = new List<int> {1, 1, 1, 1};
                var dirCopy = new List<MazePoint>(MazeData.Directions.Values);

                for (var i = 0; i < 4; i++)
                {
                    if (probabilities.All(x => x == 0))
                        rand = _rng.Next(0, probabilities.Count);
                    else
                        for (var j = 0; j < probabilities.Count; j++)
                        {
                            var leftProb = 0;
                            for (var k = j; k < probabilities.Count; k++)
                                leftProb += probabilities[k];
                            var currProb = (1000000*probabilities[j])/leftProb;
                            if (_rng.Next(1, 1000001) < currProb)
                            {
                                rand = j;
                                break;
                            }
                        }

                    var direction = dirCopy[rand];

                    if (MazeData.IsPointInMaze(row + direction.X*2, col + direction.Y*2))
                    {
                        // Looping
                        //if (allowLoop)
                        //{
                        //    if (MazeData.MazeMatrix[row + direction.X, col + direction.Y] != CellState.Wall) continue;
                        //    MazeData.MazeMatrix[row + direction.X, col + direction.Y] = CellState.Walkway;
                        //    moveVector = new MyPoint(direction.X * 2, direction.Y * 2);
                        //    row += moveVector.X;
                        //    col += moveVector.Y;
                        //    return true;
                        //}

                        // Simple generation
                        if (MazeData.MazeMatrix[row + direction.X*2, col + direction.Y*2].State == CellState.Wall)
                        {
                            MazeData.MazeMatrix[row + direction.X, col + direction.Y].State = CellState.Walkway;
                            MazeData.MazeMatrix[row + direction.X, col + direction.Y].Display = MazeData.MazeColors[CellState.Generating];
                            MazeData.MazeMatrix[row + direction.X*2, col + direction.Y*2].State = CellState.Walkway;
                            MazeData.MazeMatrix[row + direction.X * 2, col + direction.Y * 2].Display = MazeData.MazeColors[CellState.Generating];

                            moveVect = new MazePoint(direction.X*2, direction.Y*2);
                            row += moveVect.X;
                            col += moveVect.Y;
                            success = true;
                            break;
                        }

                        // Weaving
                        //if (allowWeave && _mazeRectangle.Contains(row + direction.X * 4, col + direction.Y * 4)
                        //    && _mazeMatrix[row + direction.X * 2, col + direction.Y * 2] == CellState.Walkway
                        //    && _mazeMatrix[row + direction.X * 4, col + direction.Y * 4] == CellState.Wall
                        //    && _mazeMatrix[row + direction.X, col + direction.Y] == CellState.Wall)
                        //{
                        //    _mazeMatrix[row + direction.X * 2, col + direction.Y * 2] =
                        //        direction.Y == 0 ? CellState.HorWeave : CellState.VertWeave;
                        //    _mazeMatrix[row + direction.X, col + direction.Y] = CellState.Walkway;
                        //    _mazeMatrix[row + direction.X * 3, col + direction.Y * 3] = CellState.Walkway;
                        //    _mazeMatrix[row + direction.X * 4, col + direction.Y * 4] = CellState.Walkway;
                        //    moveVector = new MyPoint(direction.X * 4, direction.Y * 4);
                        //    row += moveVector.X;
                        //    col += moveVector.Y;
                        //    return true;
                        //}
                    }
                    dirCopy.RemoveAt(rand);
                    try
                    {
                        probabilities.RemoveAt(rand);
                    }
                    catch
                    {
                    }
                    if (i == 3)
                    {
                        //moveVect = MazeData.Directions[-1];
                        success = false;
                    }
                }
                // Failed to generate
                if (success)
                {
                    //permitloop = true;
                    path.Add(new MazePoint(row, col));
                }
                else
                {
                    //if (permitloop && _rng.Next(0, 101) < loopValue)
                    //{
                    //    TryDig(ref row, ref col, out moveVect, false, true, null);
                    //    if (AnimateCheckBox.Checked)
                    //    {
                    //        var rowDiff = row - origRow;
                    //        var colDiff = col - origCol;

                    //        if (rowDiff != 0)
                    //            DrawCell(origRow + (rowDiff > 0 ? 1 : -1), origCol, MazeColors.Walkway.Brush);
                    //        else if (colDiff != 0)
                    //            DrawCell(origRow, origCol + (colDiff > 0 ? 1 : -1), MazeColors.Walkway.Brush);

                    //        RefreshPictureBox(row, col, 1);
                    //    }
                    //}

                    //permitloop = false;
                    for (var i = -1; i < 4; i++)
                        for (var j = 1; j < 2; j++)
                        {
                            var x = row + MazeData.Directions[i].X * j;
                            var y = col + MazeData.Directions[i].Y * j;
                            if (MazeData.MazeMatrix[x, y] != null && MazeData.MazeMatrix[x, y].State != CellState.Wall)
                                MazeData.MazeMatrix[x, y].Display = MazeData.MazeColors[CellState.Walkway];
                        }
                    path.RemoveAt(currIndex);
                }

                if (animationDelay > 0)
                    Utils.Sleep(animationDelay);
            }


            //GC.Collect();

            MakeEntranceExit();
            AppData.AppState = AppData.AppStates.Idle;

        }

        /*private bool TryDig(ref int row, ref int col, out MazePoint moveVector, bool allowWeave, bool allowLoop, List<int> probabilities)
        {
            var rand = 0;
            //var val = 0;
            if (probabilities == null)
                probabilities = new List<int> { 1, 1, 1, 1 };
            var dirCopy = new List<MazePoint>(MazeData.Directions.Values);

            for (var i = 0; i < 4; i++)
            {
                if (probabilities.All(x => x == 0))
                    rand = _rng.Next(0, probabilities.Count);
                else
                    for (var j = 0; j < probabilities.Count; j++)
                    {
                        var leftProb = 0;
                        for (var k = j; k < probabilities.Count; k++)
                            leftProb += probabilities[k];
                        var currProb = (1000000 * probabilities[j]) / leftProb;
                        if (_rng.Next(1, 1000001) < currProb)
                        {
                            rand = j;
                            break;
                        }
                    }

                var direction = dirCopy[rand];

                if (MazeData.IsPointInMaze(row + direction.X*2, col + direction.Y*2)) 
                {
                    // Looping
                    //if (allowLoop)
                    //{
                    //    if (MazeData.MazeMatrix[row + direction.X, col + direction.Y] != CellState.Wall) continue;
                    //    MazeData.MazeMatrix[row + direction.X, col + direction.Y] = CellState.Walkway;
                    //    moveVector = new MyPoint(direction.X * 2, direction.Y * 2);
                    //    row += moveVector.X;
                    //    col += moveVector.Y;
                    //    return true;
                    //}

                    // Simple generation
                    if (MazeData.MazeMatrix[row + direction.X * 2, col + direction.Y * 2].State == CellState.Wall)
                    {
                        MazeData.MazeMatrix[row + direction.X, col + direction.Y].State = CellState.Walkway;
                        MazeData.MazeMatrix[row + direction.X * 2, col + direction.Y * 2].State = CellState.Walkway;
                        moveVector = new MazePoint(direction.X * 2, direction.Y * 2);
                        row += moveVector.X;
                        col += moveVector.Y;
                        return true;
                    }

                    // Weaving
                    //if (allowWeave && _mazeRectangle.Contains(row + direction.X * 4, col + direction.Y * 4)
                    //    && _mazeMatrix[row + direction.X * 2, col + direction.Y * 2] == CellState.Walkway
                    //    && _mazeMatrix[row + direction.X * 4, col + direction.Y * 4] == CellState.Wall
                    //    && _mazeMatrix[row + direction.X, col + direction.Y] == CellState.Wall)
                    //{
                    //    _mazeMatrix[row + direction.X * 2, col + direction.Y * 2] =
                    //        direction.Y == 0 ? CellState.HorWeave : CellState.VertWeave;
                    //    _mazeMatrix[row + direction.X, col + direction.Y] = CellState.Walkway;
                    //    _mazeMatrix[row + direction.X * 3, col + direction.Y * 3] = CellState.Walkway;
                    //    _mazeMatrix[row + direction.X * 4, col + direction.Y * 4] = CellState.Walkway;
                    //    moveVector = new MyPoint(direction.X * 4, direction.Y * 4);
                    //    row += moveVector.X;
                    //    col += moveVector.Y;
                    //    return true;
                    //}
                }
                dirCopy.RemoveAt(rand);
                try { probabilities.RemoveAt(rand); }
                catch { }
                // TODO: fix random error
            }
            // Failed to generate
            moveVector = MazeData.Directions[-1];
            return false;
        }*/

    }
}
