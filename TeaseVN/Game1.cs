using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Screens.Transitions;
using MonoGame.Extended.Input.InputListeners;
using System;
using System.Diagnostics;
using MonoGame.Extended.Input;
using TeaseVN.Scenes.Intro;
using System.Collections.Generic;

namespace TeaseVN
{
    public class Game1 : Game
    {
        Texture2D backgroundTexture;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SceneManager _sceneManager;
        private SpriteFont font;
        MouseState currentMouseState = Mouse.GetState();
        private FrameCounter _frameCounter = new FrameCounter();
        private Rectangle backgroundRectangle;


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
            _sceneManager = new SceneManager(this, new FirstDayChoiceScene(this));
            _graphics.PreferredBackBufferWidth = 1600;
            _graphics.PreferredBackBufferHeight = 900;
            _graphics.ApplyChanges();
            this.backgroundRectangle = GraphicsDevice.Viewport.Bounds;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("assets/font");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            MouseState lastMouseState = this.currentMouseState;
            this.currentMouseState = Mouse.GetState();

            SceneUiManager.checkHoveringChoice(this.currentMouseState, _sceneManager);

            // Recognize a single click of the left mouse button
            bool mouseClicked = false;
            if (lastMouseState.LeftButton == ButtonState.Released && this.currentMouseState.LeftButton == ButtonState.Pressed)
            {
                SceneUiManager.checkClickedChoice(this.currentMouseState, _sceneManager);
                mouseClicked = true;
            }

            if (mouseClicked)
            {
                _sceneManager.progress();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            _spriteBatch.Draw(_sceneManager.getCurrentBackground(), this.backgroundRectangle, Color.White);

            //Draw choice buttons
            List<Button> choiceButtons = _sceneManager.currentSceneChoiceButtons;
            foreach(Button choiceButton in choiceButtons){
                _spriteBatch.Draw(choiceButton.buttonTexture, choiceButton.buttonRect, Color.White);
                _spriteBatch.DrawString(font, choiceButton.buttonText, choiceButton.buttonPosition, Color.White);
            }

            //Frame counter
            var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            _frameCounter.Update(deltaTime);
            var fps = string.Format("FPS: {0}", _frameCounter.AverageFramesPerSecond);
            _spriteBatch.DrawString(font, fps, new Vector2(1, 1), Color.Red);


            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
