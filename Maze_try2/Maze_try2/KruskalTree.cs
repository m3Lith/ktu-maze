namespace Maze_try2
{
    public class KruskalTree
    {
        private class KruskalNode
        {
            public KruskalNode Parent;

            public KruskalNode()
            {
                Parent = null;
            }
        }

        private KruskalNode[,] _innerMatrix;

        public KruskalTree(int width, int height)
        {
            InitializeTree(width, height);
        }
        
        public KruskalTree(int size)
        {
            InitializeTree(size, size);
        }

        private void InitializeTree(int width, int height)
        {
            _innerMatrix = new KruskalNode[width, height];
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    _innerMatrix[i, j] = new KruskalNode();
        }

        private KruskalNode FindRoot(int x, int y)
        {
            var origNode = _innerMatrix[x, y];
            if (origNode.Parent == null)
                return origNode;

            var node = origNode;
            while (node.Parent != null)
                node = node.Parent;
            origNode.Parent = node;
            return node;
        }

        public bool AreConnected(int aX, int aY, int bX, int bY)
        {
            return FindRoot(aX, aY) == FindRoot(bX, bY);
        }

        public bool Connect(int aX, int aY, int bX, int bY)
        {
            var rootA = FindRoot(aX, aY);
            var rootB = FindRoot(bX, bY);
            if (rootA == rootB)
                return false;
            rootA.Parent = rootB;
            return true;
        }
    }

}
