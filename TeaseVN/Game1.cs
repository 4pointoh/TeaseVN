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
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private SceneManager sceneManager;
        private RoomManager roomManager;
        public FlagManager flagManager;
        public EventManager eventManager;
        public TimeManager timeManager;
        private SceneStorage sceneStorage;
        public RoomStorage roomStorage;
        public SpriteFont font;
        private FrameCounter frameCounter = new FrameCounter();
        private Rectangle backgroundRectangle;
        private MouseState currentMouseState = Mouse.GetState();
        private Texture2D cursorPointer;
        private Vector2 cursorPos;
        public bool usePointerCursor;
        public bool debugMode = true;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            
            //remove this to lock framerate to 60
            graphics.SynchronizeWithVerticalRetrace = false;
            this.IsFixedTimeStep = false;
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            graphics.ApplyChanges();
            this.backgroundRectangle = GraphicsDevice.Viewport.Bounds;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("assets/font");
            cursorPointer = Content.Load<Texture2D>("assets/hand-cursor");
            flagManager = new FlagManager();
            timeManager = new TimeManager();
            eventManager = new EventManager(this);
            sceneStorage = new SceneStorage(this);
            sceneManager = new SceneManager(this, sceneStorage.getScene(SceneStorage.FIRST_DAY_SCENE));
            roomStorage = new RoomStorage(this);
            roomManager = new RoomManager(this, roomStorage.getRoom(RoomStorage.KITCHEN_ROOM));
        }

        protected override void Update(GameTime gameTime)
        {
            MouseState lastMouseState = this.currentMouseState;
            this.currentMouseState = Mouse.GetState();
            cursorPos = new Vector2(this.currentMouseState.X, this.currentMouseState.Y);
            NextEvent nextEvent = null;


            if (sceneManager.hasActiveScene)
            {
                //SCENE LOGIC BLOCK

                //******* UI RESPONSE *******//
                //**************************//
                usePointerCursor = sceneManager.processHoveredButtons(this.currentMouseState);

                //****** HANDLE INPUT*******//
                //*************************//

                //Left Click
                if (lastMouseState.LeftButton == ButtonState.Released && this.currentMouseState.LeftButton == ButtonState.Pressed)
                {
                    //TBD shift this to similar logic as the room manager
                    nextEvent = sceneManager.processClickedButtons(this.currentMouseState);
                }
            }
            else
            {
                //ROOM LOGIC BLOCK
                usePointerCursor = roomManager.processHoveredClickables(this.currentMouseState);

                //Left Click
                if (lastMouseState.LeftButton == ButtonState.Released && this.currentMouseState.LeftButton == ButtonState.Pressed)
                {
                    nextEvent = roomManager.processClickedClickables(this.currentMouseState);
                }
            }

            if(nextEvent != null)
            {
                if (nextEvent.nextEventIsRoom)
                {
                    Room nextRoom = roomStorage.getRoom(nextEvent.nextId);
                    roomManager.setCurrentRoom(nextRoom);
                }else if (nextEvent.nextEventIsScene)
                {
                    Scene nextScene = sceneStorage.getScene(nextEvent.nextId);
                    sceneManager.setCurrentScene(nextScene);
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
            frameCounter.Update(deltaTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            if (sceneManager.hasActiveScene)
            {
                //SCENE LOGIC
                //Actual background image
                spriteBatch.Draw(sceneManager.getCurrentBackground(), this.backgroundRectangle, Color.White);

                //Draw choice buttons
                foreach (Button choiceButton in sceneManager.currentSceneChoiceButtons)
                {
                    spriteBatch.Draw(choiceButton.buttonTexture, choiceButton.buttonRect, Color.White);
                    spriteBatch.DrawString(font, choiceButton.buttonText, choiceButton.buttonPosition, Color.White);
                }

                //Draw dialogue box
                spriteBatch.Draw(sceneManager.dialogueBox.boxTexture, sceneManager.dialogueBox.boxRect, Color.White);
                spriteBatch.DrawString(font, sceneManager.dialogueBox.boxText, sceneManager.dialogueBox.textPosition, Color.White);

            }
            else
            {
                //ROOM LOGIC
                spriteBatch.Draw(roomManager.getCurrentBackground(), this.backgroundRectangle, Color.White);

                foreach(Clickable item in roomManager.getCurrentRoomClickables())
                {
                    spriteBatch.Draw(item.texture, item.clickableArea, Color.White);
                }

                foreach (Clickable item in roomManager.getCurrentTravelOptions())
                {
                   spriteBatch.Draw(item.texture, item.clickableArea, Color.White);
                }
            }

            if (this.usePointerCursor)
            {
                spriteBatch.Draw(cursorPointer, cursorPos, Color.White);
            }

            //******* DEBUG LOGIC ********//
            //***************************//

            if (debugMode)
            {
                int currentYPos = 20;
                spriteBatch.DrawString(font, "Cleanliness: " + this.flagManager.playerFlags.cleanliness.ToString(), new Vector2(1, currentYPos), Color.Red);
                currentYPos = 40;
                spriteBatch.DrawString(font, "Dinner Cooked: " + this.flagManager.globalFlags.dinnerCooked.ToString(), new Vector2(1, currentYPos), Color.Black);
            }

            //FPS Counter
            var fps = string.Format("FPS: {0}", frameCounter.AverageFramesPerSecond);
            spriteBatch.DrawString(font, fps, new Vector2(1, 1), Color.Red);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
