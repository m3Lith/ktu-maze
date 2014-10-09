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
        private int _cellSize = 0;
        private int _offsetX = 0;
        private int _offsetY = 0;

        public MazeEngine(RenderControl target)
        {
            _graphicsDeviceManager = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = target.Width,
                PreferredBackBufferHeight = target.Height
            };
            _target = target;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (!MazeData.MazeExists)
                return;

            RecalculateMazeDrawParams();
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
            if (!MazeData.MazeExists)
                return;

            var minSize = _target.Width < _target.Height ? _target.Width : _target.Height;
            _cellSize = minSize/MazeData.MazeSize;
            _offsetX = _target.Width - _cellSize * MazeData.MazeSize;
            _offsetY = _target.Width - _cellSize * MazeData.MazeSize;
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

            if (!MazeData.MazeExists)
                return;

            GraphicsDevice.Clear(MazeData.MazeColors[CellState.Wall]);

            _mainBasicEffect.CurrentTechnique.Passes[0].Apply();
            _mainPrimitiveBatch.Begin();

            for(var i = 0; i < MazeData.MazeSize; i++)
                for (var j = 0; j < MazeData.MazeSize; j++)
                    if(MazeData.MazeMatrix[i,j] != CellState.Wall)
                        DrawCell(i, j, MazeData.MazeColors[MazeData.MazeMatrix[i, j]]);

            _mainPrimitiveBatch.End();

        }

    }
}
