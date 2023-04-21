using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace UlearnGame
{
    public class Game1 : Game
    {
        private Texture2D _playerTexture;
        private Texture2D _bulletTexture;

        private GraphicsDeviceManager _graphicsManager;
        private GraphicsAdapter _graphicsAdapter;

        private SpriteBatch _spriteBatch;

        private int _windowWidth;
        private int _windowHeight;

        private Player player;


        public Game1()
        {
            _graphicsManager = new GraphicsDeviceManager(this);
            _graphicsAdapter = new GraphicsAdapter();
            _graphicsManager.PreferredBackBufferWidth = _graphicsAdapter.CurrentDisplayMode.Width;
            _graphicsManager.PreferredBackBufferHeight = _graphicsAdapter.CurrentDisplayMode.Height;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphicsManager.IsFullScreen = true;
            _windowWidth = Window.ClientBounds.Width;
            _windowHeight = Window.ClientBounds.Height;
        }

        protected override void Initialize()
        {
            _playerTexture = Content.Load<Texture2D>("knight_f_idle_anim_f0");
            _bulletTexture = new Texture2D(GraphicsDevice, 50, 50);
            var startPosition = new Vector2(_windowWidth / 2, _windowHeight / 2);
            player = new Player(_playerTexture, startPosition, 300);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            player.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.BlueViolet);
            _spriteBatch.Begin();
            player.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}