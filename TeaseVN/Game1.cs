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
        private Texture2D cursorPointer;
        private Vector2 cursorPos;
        public bool usePointerCursor;

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
            cursorPointer = Content.Load<Texture2D>("assets/hand-cursor");
            _sceneManager = new SceneManager(this, new FirstDayChoiceScene(this));
            _roomManager = new RoomManager(this);
        }

        protected override void Update(GameTime gameTime)
        {
            MouseState lastMouseState = this.currentMouseState;
            this.currentMouseState = Mouse.GetState();
            cursorPos = new Vector2(this.currentMouseState.X, this.currentMouseState.Y);


            if (_sceneManager.hasActiveScene)
            {
                //SCENE LOGIC BLOCK

                //******* UI RESPONSE *******//
                //**************************//
                usePointerCursor = _sceneManager.processHoveredButtons(this.currentMouseState);

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
                usePointerCursor = _roomManager.processHoveredClickables(this.currentMouseState);

                //Left Click
                if (lastMouseState.LeftButton == ButtonState.Released && this.currentMouseState.LeftButton == ButtonState.Pressed)
                {
                    //_sceneManager.setCurrentScene(new FirstDayChoiceScene(this));
                    _roomManager.processClickedClickables(this.currentMouseState);
                }
            }

            //Esc
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
                //TBD - autosave here
            }


            if (usePointerCursor)
            {
                SceneUiHelper.setCursorToPointer(this);
            }
            else
            {
                SceneUiHelper.setCursorToDefault(this);
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

                foreach(Clickable item in _roomManager.getCurrentRoomClickables())
                {
                    _spriteBatch.Draw(item.texture, item.clickableArea, Color.White);
                }
            }
            //******* DEBUG LOGIC ********//
            //***************************//

            if (this.usePointerCursor)
            {
                _spriteBatch.Draw(cursorPointer, cursorPos, Color.White);
            }

            //FPS Counter
            var fps = string.Format("FPS: {0}", _frameCounter.AverageFramesPerSecond);
            _spriteBatch.DrawString(font, fps, new Vector2(1, 1), Color.Red);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
