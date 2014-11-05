namespace Maze_try2
{
    public class MazePoint
    {
        public int X;
        public int Y;

        public MazePoint(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            var q = obj as MazePoint;
            return q != null && q.X == X && q.Y == Y;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }
    }
}
