using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maze_try2
{
    class BaseAlgorithm : IMazeAlgorithm
    {
        public virtual void GenerateMaze(int size, ref double animationDelay, ref int behaviorValue)
        {
            //throw new NotImplementedException("Please define a maze generation algorithm");
        }

        public virtual void MakeEntranceExit()
        {
            // TODO move this shit
            var rng = new Random();
            MazeData.EntrancePoint = new MazePoint(1, rng.Next(0, (MazeData.MazeSize / 2) - 1) * 2 + 1);
            MazeData.ExitPoint = new MazePoint(MazeData.MazeSize - 2, rng.Next(0, (MazeData.MazeSize / 2) - 1) * 2 + 1);
            MazeData.MazeMatrix[MazeData.EntrancePoint.X, MazeData.EntrancePoint.Y].Display = MazeData.MazeColors[CellState.Entrance];
            MazeData.MazeMatrix[MazeData.ExitPoint.X, MazeData.ExitPoint.Y].Display = MazeData.MazeColors[CellState.Exit];
        }
    }
}
