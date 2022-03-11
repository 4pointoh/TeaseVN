using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TeaseVN.Core;

namespace TeaseVN
{
    public class UiManager
    {
        private Game1 game;
        private MouseState currentMouseState = Mouse.GetState();
        private MouseState lastMouseState = Mouse.GetState();
        public Vector2 cursorPosition;

        //Basic UI Elements
        public SpriteFont font;
        public Rectangle backgroundRectangle;
        public Texture2D cursorPointer;
        public Vector2 timePosition = new Vector2();
        public Vector2 dayPosition = new Vector2();
        public Vector2 dayCountPosition = new Vector2();

        //Hover cursor
        public bool usePointerCursor = false;

        public UiManager(Game1 game)
        {
            this.game = game;
            this.cursorPosition = new Vector2(this.currentMouseState.X, this.currentMouseState.Y);
            this.font = this.game.Content.Load<SpriteFont>("assets/font");
            this.cursorPointer = this.game.Content.Load<Texture2D>("assets/hand-cursor");
            this.backgroundRectangle = this.game.GraphicsDevice.Viewport.Bounds;

            timePosition.X = 10;
            timePosition.Y = 60;
            dayPosition.X = 10;
            dayPosition.Y = 80;
            dayCountPosition.X = 10;
            dayCountPosition.Y = 100;
        }

        public void update()
        {
            this.lastMouseState = this.currentMouseState;
            this.currentMouseState = Mouse.GetState();
            this.cursorPosition = new Vector2(this.currentMouseState.X, this.currentMouseState.Y); ;
        }

        public void enablePointerCursor()
        {
            this.usePointerCursor = true;
            game.IsMouseVisible = false;
        }

        public void disablePointerCursor()
        {
            this.usePointerCursor = false;
            game.IsMouseVisible = true;
        }

        public bool leftMouseClicked()
        {
            if (this.lastMouseState.LeftButton == ButtonState.Released && this.currentMouseState.LeftButton == ButtonState.Pressed)
            {
                return true;
            }

            return false;
        }
        public bool escapeKeyPressed()
        {
            return Keyboard.GetState().IsKeyDown(Keys.Escape);
        }

        public static bool buttonIsHovered(MouseState mouseState, Button button)
        {
            var mousePoint = new Point(mouseState.X, mouseState.Y);
            return button.buttonRect.Contains(mousePoint);
        }

        public static bool clickableIsHovered(MouseState mouseState, Clickable clickable)
        {
            var mousePoint = new Point(mouseState.X, mouseState.Y);
            return clickable.clickableArea.Contains(mousePoint);
        }
    }
}
