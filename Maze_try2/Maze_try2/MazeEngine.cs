using System.Linq;
using SharpDX;
using SharpDX.Toolkit;
using SharpDX.Toolkit.Graphics;
using SharpDX.Windows;

namespace Maze_try2
{
    class MazeEngine : Game
    {
        private GraphicsDeviceManager _graphicsDeviceManager;
        private PrimitiveBatch<VertexPositionColor> _mainPrimitiveBatch;
        private BasicEffect _mainBasicEffect;
        private readonly bool[,] _sourceMatrix;
        private readonly RenderControl _target;
        private int _mazeSize = 0;
        private int _cellSize = 0;
        private int _offsetX = 0;
        private int _offsetY = 0;

        public int MazeSize
        {
            get { return _mazeSize; }
            set
            {
                _mazeSize = value;
                RecalculateMazeDrawParams();
            }
        }

        public MazeEngine(RenderControl target, bool[,] sourceMatrix)
        {
            _graphicsDeviceManager = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = target.Width,
                PreferredBackBufferHeight = target.Height
            };
            _target = target;
            _sourceMatrix = sourceMatrix;
            MazeSize = sourceMatrix.GetLength(0);
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void LoadContent()
        {
            _mainPrimitiveBatch = new PrimitiveBatch<VertexPositionColor>(GraphicsDevice);
            _mainBasicEffect = new BasicEffect(GraphicsDevice)
            {
                VertexColorEnabled = true,
                TextureEnabled = false,
                LightingEnabled = false
            };
            base.LoadContent();
        }

        private void RecalculateMazeDrawParams()
        {
            if (_mazeSize == 0)
                return;

            var minSize = _target.Width < _target.Height ? _target.Width : _target.Height;
            _cellSize = minSize/_mazeSize;
            _offsetX = _target.Width - _cellSize * _mazeSize;
            _offsetY = _target.Width - _cellSize * _mazeSize;
        }

        private void DrawCell(int x, int y, Color color)
        {
            var cellFromX = _offsetX + _cellSize*x;
            var cellFromY = _offsetY + _cellSize*y;
            var cellToX = cellFromX + _cellSize;
            var cellToY = cellFromY + _cellSize;

            var resizeFactorX = _target.Width/2f;
            var resizeFactorY = _target.Height/2f;

            var finalFromX = cellFromX / resizeFactorX - 1;
            var finalFromY = cellFromY / resizeFactorY - 1;
            var finalToX = cellToX / resizeFactorX - 1;
            var finalToY = cellToY / resizeFactorY - 1;


            _mainPrimitiveBatch.DrawQuad(
                new VertexPositionColor(new Vector3(finalFromX, finalFromY, 0.0f), color),
                new VertexPositionColor(new Vector3(finalFromX, finalToY, 0.0f), color),
                new VertexPositionColor(new Vector3(finalToX, finalToY, 0.0f), color),
                new VertexPositionColor(new Vector3(finalToX, finalFromY, 0.0f), color)
                );
        }

        protected override void Draw(GameTime gameTime)
        {

            if (_mazeSize == 0)
                return;

            GraphicsDevice.Clear(Color.Black);

            _mainBasicEffect.CurrentTechnique.Passes[0].Apply();
            _mainPrimitiveBatch.Begin();

            for(var i = 0; i < _mazeSize; i++)
                for (var j = 0; j < _mazeSize; j++)
                {
                    DrawCell(i,j,_sourceMatrix[i,j] ? Color.DarkGreen : Color.Black);
                }

            _mainPrimitiveBatch.End();

            //base.Draw(gameTime);
        }

    }
}
