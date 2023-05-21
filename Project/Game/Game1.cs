using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace UlearnGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphicsManager;
        private GameManager _gameManager;
        public static SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphicsManager = new GraphicsDeviceManager(this); 
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphicsManager.IsFullScreen = true;
        }

        protected override void Initialize()
        {
            _graphicsManager.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            _graphicsManager.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            _graphicsManager.ApplyChanges();

            Globals.Content = Content;
            _gameManager = new GameManager();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.SpriteBatch = _spriteBatch;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            Globals.Update(gameTime);
            _gameManager.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.BlueViolet);
            _gameManager.Draw();
            base.Draw(gameTime);
        }
    }
}