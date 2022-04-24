using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using TeaseVN.Core;
using TeaseVN.Core.SceneUtil;
using TeaseVN.Scenes.Intro;

namespace TeaseVN
{
    /*
 * TO DO 
 * 
 * Refactor choices into clickables
 * Saves
 * Quest management
 * "Computer" training etc...
 * Different characters for different dialogue
 * 
 * Stat UI
 * Inventory UI
 * Quest UI
 * 
 * Papercuts
 * - Scene routing has issues
 * Still using "return panelsById[x]"
 * Need to remember to remove "guaranteedNextPanel" if I modify things
 * 
 * - Need more descriptive errors for simple things
 * like forgetting to click the save button in the content saver
 *
 *- Still need to manually copy jsons to release folders
 *
 *- Need to remember to change a lot of things when doing a clickable
 */

    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        
        private SceneManager sceneManager;
        private RoomManager roomManager;

        public UiManager uiManager;
        public FlagManager flagManager;
        public EventManager eventManager;
        public TimeManager timeManager;
        
        public RoomStorage roomStorage;
        private SceneStorage sceneStorage;

        //Debug
        private FrameCounter frameCounter = new FrameCounter();
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
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            uiManager = new UiManager(this);

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
            this.uiManager.update();
            this.sceneManager.update();
            MouseState currentMouseState = Mouse.GetState();

            NextEvent nextEvent = null;

            if (sceneManager.hasActiveScene)
            {
                //SCENE LOGIC BLOCK
                sceneManager.processHoveredButtons(currentMouseState);

                //Left Click
                if (this.uiManager.leftMouseClicked())
                {
                    nextEvent = sceneManager.processClickedButtons(currentMouseState);
                }
            }
            else
            {
                //ROOM LOGIC BLOCK
                roomManager.processHoveredClickables(currentMouseState);

                //Left Click
                if (this.uiManager.leftMouseClicked())
                {
                    nextEvent = roomManager.processClickedClickables(currentMouseState);
                }
            }

            if (nextEvent != null)
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

            //We were in a scene & now we aren't
            if(this.sceneManager.returnedToRoom())
            {
                this.roomManager.refreshCurrentRoom();
            }

            //Esc
            if (this.uiManager.escapeKeyPressed())
            {
                Exit();
                //TBD - autosave here
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
                spriteBatch.Draw(sceneManager.getCurrentBackground(), this.uiManager.backgroundRectangle, Color.White);

                //Draw choice buttons
                foreach (Button choiceButton in sceneManager.currentSceneChoiceButtons)
                {
                    spriteBatch.Draw(choiceButton.buttonTexture, choiceButton.buttonRect, Color.White);
                    spriteBatch.DrawString(this.uiManager.font, choiceButton.buttonText, choiceButton.buttonPosition, Color.White);
                }

                //Draw dialogue box
                spriteBatch.Draw(sceneManager.dialogueBox.boxTexture, sceneManager.dialogueBox.boxRect, Color.White);
                spriteBatch.DrawString(this.uiManager.font, sceneManager.dialogueBox.boxText, sceneManager.dialogueBox.textPosition, Color.White);

            }
            else
            {
                //ROOM LOGIC
                spriteBatch.Draw(roomManager.getCurrentBackground(), this.uiManager.backgroundRectangle, Color.White);

                foreach(Clickable item in roomManager.getCurrentRoomClickables())
                {
                    spriteBatch.Draw(item.texture, item.clickableArea, Color.White);
                }

                foreach (Clickable item in roomManager.getCurrentTravelOptions())
                {
                   spriteBatch.Draw(item.texture, item.clickableArea, Color.White);
                }
            }

            if (this.uiManager.usePointerCursor)
            {
                spriteBatch.Draw(this.uiManager.cursorPointer, this.uiManager.cursorPosition, Color.White);
            }

            spriteBatch.DrawString(this.uiManager.font, timeManager.hour.ToString(), this.uiManager.timePosition, Color.Green);
            spriteBatch.DrawString(this.uiManager.font, timeManager.dayOfWeek.ToString(), this.uiManager.dayPosition, Color.Green);
            spriteBatch.DrawString(this.uiManager.font, timeManager.day.ToString(), this.uiManager.dayCountPosition, Color.Green);

            //******* DEBUG LOGIC ********//
            //***************************//

            if (debugMode)
            {
                int currentYPos = 20;
                spriteBatch.DrawString(this.uiManager.font, "Cleanliness: " + this.flagManager.playerFlags.cleanliness.ToString(), new Vector2(1, currentYPos), Color.Red);
                currentYPos = 40;
                spriteBatch.DrawString(this.uiManager.font, "Dinner Cooked: " + this.flagManager.globalFlags.dinnerCooked.ToString(), new Vector2(1, currentYPos), Color.Black);
            }

            //FPS Counter
            var fps = string.Format("FPS: {0}", frameCounter.AverageFramesPerSecond);
            spriteBatch.DrawString(this.uiManager.font, fps, new Vector2(1, 1), Color.Red);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
