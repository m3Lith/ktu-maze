using System;
using System.Collections.Generic;
using System.Threading;

namespace Maze_try2
{
    class KruskalsAlgorithm : BaseAlgorithm
    {
        private Random _rng;

        public KruskalsAlgorithm()
        {
            _rng = new Random();
        }

        public KruskalsAlgorithm(Random rng)
        {
            _rng = rng;
        }

        public override void GenerateMaze(int size, ref double animationDelay, ref int behaviorValue)
        {
            MazeData.CreateEmpty(size);

            var tree = new KruskalTree(size);
            
            var mazeWidth = size;
            var mazeHeight = size;

            AppData.AppState = AppData.AppStates.LongTask;

            var walls = new LinkedList<MazePoint>();
            for (var i = 1; i < mazeWidth - 1; i++)
            {
                var extra = i % 2 == 0 ? 1 : 0;
                for (var j = 2 - extra; j < mazeHeight - 2 + extra; j += 2)
                    if (MazeData.MazeMatrix[i, j].State == CellState.Wall)
                        walls.AddLast(new MazePoint(i, j));
            }
            walls.Shuffle();


            while (walls.First != null && AppData.AppState == AppData.AppStates.LongTask)
            {
                /*if (AnimateCheckBox.Checked)
                    BeginInvoke(fetchKruskalInfoDelegate);*/

                var wall = walls.First.Value;
                var x = 0;
                var y = 0;
                if (wall.X % 2 == 0 && wall.Y % 2 == 1)
                    x = 1;
                else if (wall.X % 2 == 1 && wall.Y % 2 == 0)
                    y = 1;

                var connected = tree.AreConnected(wall.X - x, wall.Y - y, wall.X + x, wall.Y + y);
                if (!connected)
                {
                    MazeData.MazeMatrix[wall.X - x, wall.Y - y].State = CellState.Walkway;
                    MazeData.MazeMatrix[wall.X, wall.Y].State = CellState.Walkway;
                    MazeData.MazeMatrix[wall.X + x, wall.Y + y].State = CellState.Walkway;
                    tree.Connect(wall.X - x, wall.Y - y, wall.X + x, wall.Y + y);

                    if (animationDelay > 0)
                        Utils.Sleep(animationDelay);
                }

                walls.RemoveFirst();
            }

            MakeEntranceExit();
            AppData.AppState = AppData.AppStates.Idle;

            /*MakeEntranceExit(AnimateCheckBox.Checked);
            if (!AnimateCheckBox.Checked)
                DrawMatrix(true);
            Invoke(() => EnableButtons());
            _debugStopwatch.Toc(true);
            _debugStopwatch.Reset(true);*/
        }
    }
}
