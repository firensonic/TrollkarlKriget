﻿﻿#region Using Statements
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
#endregion


namespace Wizards
{
    public class Cursor
    {
        public Vector2 position;
        public Texture2D Texture;
        public MouseState mousestate;
        public MouseState laststate;
        public Cursor(Texture2D texture)
        {
            this.Texture = texture;
        }
        public void Update(Camera cam, World tellus)
        {
            laststate = mousestate;
            mousestate = Mouse.GetState();
            position.X = mousestate.X;
            position.Y = mousestate.Y;
            /*if ((mousestate.LeftButton == ButtonState.Pressed) && (laststate.LeftButton != ButtonState.Pressed))
            {
                int x = (Convert.ToInt32(cam.position.X + position.X)) / Settings.gridsize;
                int y = (Convert.ToInt32(cam.position.Y + position.Y)) / Settings.gridsize;
                try
                {
                    tellus.map[x, y].Clicked();
                }
                catch (IndexOutOfRangeException e)
                {
                    return;
                }
            }*/
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, position, Color.AliceBlue);
        }
    }
}