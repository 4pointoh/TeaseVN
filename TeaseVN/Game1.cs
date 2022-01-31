using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using TeaseVN.Core;
using TeaseVN.Core.SceneUtil;
using TeaseVN.Scenes.Intro;

namespace TeaseVN
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SceneManager _sceneManager;
        private RoomManager _roomManager;
        private FlagManager _flagManager;
        private TimeManager _timeManager;
        public SpriteFont font;
        private FrameCounter _frameCounter = new FrameCounter();
        private Rectangle backgroundRectangle;
        private MouseState currentMouseState = Mouse.GetState();

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            
            //remove this to lock framerate to 60
            _graphics.SynchronizeWithVerticalRetrace = false;
            this.IsFixedTimeStep = false;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();
            this.backgroundRectangle = GraphicsDevice.Viewport.Bounds;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("assets/font");
            _sceneManager = new SceneManager(this, new FirstDayChoiceScene(this));
            _roomManager = new RoomManager(this);
        }

        protected override void Update(GameTime gameTime)
        {
            MouseState lastMouseState = this.currentMouseState;
            this.currentMouseState = Mouse.GetState();


            if (_sceneManager.hasActiveScene)
            {
                //SCENE LOGIC BLOCK

                //******* UI RESPONSE *******//
                //**************************//
                _sceneManager.processHoveredButtons(this.currentMouseState);

                //****** HANDLE INPUT*******//
                //*************************//

                //Left Click
                if (lastMouseState.LeftButton == ButtonState.Released && this.currentMouseState.LeftButton == ButtonState.Pressed)
                {
                    _sceneManager.processClickedButtons(this.currentMouseState);
                    _sceneManager.progress();
                }
            }
            else
            {
                //ROOM LOGIC BLOCK

                //Left Click
                if (lastMouseState.LeftButton == ButtonState.Released && this.currentMouseState.LeftButton == ButtonState.Pressed)
                {
                    _sceneManager.setCurrentScene(new FirstDayChoiceScene(this));
                }
            }

            //Esc
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
                //TBD - autosave here
            }

            //******* DEBUG LOGIC ********//
            //***************************//
            var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            _frameCounter.Update(deltaTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            if (_sceneManager.hasActiveScene)
            {
                //SCENE LOGIC
                //Actual background image
                _spriteBatch.Draw(_sceneManager.getCurrentBackground(), this.backgroundRectangle, Color.White);

                //Draw choice buttons
                foreach (Button choiceButton in _sceneManager.currentSceneChoiceButtons)
                {
                    _spriteBatch.Draw(choiceButton.buttonTexture, choiceButton.buttonRect, Color.White);
                    _spriteBatch.DrawString(font, choiceButton.buttonText, choiceButton.buttonPosition, Color.White);
                }

                //Draw dialogue box
                _spriteBatch.Draw(_sceneManager.dialogueBox.boxTexture, _sceneManager.dialogueBox.boxRect, Color.White);
                _spriteBatch.DrawString(font, _sceneManager.dialogueBox.boxText, _sceneManager.dialogueBox.textPosition, Color.White);

            }
            else
            {
                //ROOM LOGIC
                _spriteBatch.Draw(_roomManager.getCurrentBackground(), this.backgroundRectangle, Color.White);
            }
            //******* DEBUG LOGIC ********//
            //***************************//

            //FPS Counter
            var fps = string.Format("FPS: {0}", _frameCounter.AverageFramesPerSecond);
            _spriteBatch.DrawString(font, fps, new Vector2(1, 1), Color.Red);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
