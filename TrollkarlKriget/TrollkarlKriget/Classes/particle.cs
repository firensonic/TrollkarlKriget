﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Wizards
{
    public class particle
    {
        private Vector2 pos;
        private Vector2 speed;
        private Texture2D texture;
        private double initTime;
        public double endTime;
        private double initRoll;
        private double endRoll;
        private double initScale;
        private double endScale;
        private double scale;
        private double roll;
        private double timeLength;

        private bool Destroy;

        private float initResistance;
        private float endResistance;

        private Color color;

        private Vector2 initGravity;
        private Vector2 endGravity;

        private Color initColor;
        private Color endColor;
         
        public particle(Vector2 pos, Vector2 speed, Texture2D texture,
            double initTime, double endTime, Color initColor, 
            Color endColor, double initScale, double endScale,
            float initResistance, float endResistance,
            Vector2 initGravity, Vector2 endGravity, 
            double initRoll, double endRoll)
        {
            this.pos = pos;
            this.speed = speed;
            this.texture = texture;
            this.initTime = initTime;
            this.endTime = endTime;
            this.timeLength = endTime - initTime;
            this.initColor = initColor;
            this.color = initColor;
            this.endColor = endColor;
            this.initScale = initScale;
            this.endScale = endScale;
            this.initResistance = initResistance;
            this.endResistance = endResistance;
            this.initGravity = initGravity;
            this.endGravity = endGravity;
            this.initRoll = initRoll;
            this.endRoll = endRoll;
        }

        public void Update(World world, GameTime gametime)
        {
            this.pos += speed;

            float tempTime = (float)((endTime - gametime.TotalGameTime.TotalMilliseconds) / timeLength); 
            // Returnerar en float som går från 1 till 0 beroende på tidpunkten som den räknas ut; Används för alla init/end variabler i Update.

            this.speed.X += (initGravity.X * tempTime) + (endGravity.X * (1 - tempTime));
            this.speed.Y += (initGravity.Y * tempTime) + (endGravity.Y * (1 - tempTime));
            // Räkna ut gravitationens påverkan på hastigheten

            if (speed.X != 0)
            {
                this.speed.X = (float)Math.Sqrt(Convert.ToDouble((speed.X * speed.X) *
                    (initResistance * tempTime + endResistance * (1 - tempTime)))) * speed.X / Math.Abs(speed.X);
            }
            if (speed.Y != 0)
            {
                this.speed.Y = (float)Math.Sqrt(Convert.ToDouble((speed.Y * speed.Y) *
                    (initResistance * tempTime + endResistance * (1 - tempTime)))) * speed.Y / Math.Abs(speed.Y);
            }
            // Kalkylera luftmotstånd


            this.color.R = (byte)((float)initColor.R * tempTime + (float)endColor.R * (1 - tempTime)); 
            this.color.G = (byte)((float)initColor.G * tempTime + (float)endColor.G * (1 - tempTime));
            this.color.B = (byte)((float)initColor.B * tempTime + (float)endColor.B * (1 - tempTime));
            this.color.A = (byte)((float)initColor.A * tempTime + (float)endColor.A * (1 - tempTime)); 
            //Räkna ut tidens påverkan på färgen

            this.roll = initRoll * tempTime + endRoll * (1 - tempTime);

            this.scale = initScale * tempTime + endScale * (1 - tempTime);
            // Räkna ut tidens påverkan på storleken
            int xpos = (int)(this.pos.X + ((this.texture.Width / 2) * this.scale * Math.Cos(this.roll)))/Settings.gridsize;
            int ypos = (int)(this.pos.Y + ((this.texture.Height / 2) * this.scale * Math.Sin(this.roll)))/Settings.gridsize;

            if (xpos >= 0 &&
                ypos >= 0 &&
                xpos <= (world.worldSize - 1) &&
                ypos <= (world.worldSize - 1))
            {
                world.map[xpos, ypos].type = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Camera cam)
        {
            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive);
            Vector2 drawpos = pos - cam.position;
            drawpos.X = (float)Math.Round(drawpos.X);
            drawpos.Y = (float)Math.Round(drawpos.Y);
            spriteBatch.Draw(texture, drawpos, new Rectangle(0, 0,
    (int)texture.Width, (int)texture.Height), this.color, (float)this.roll, new Vector2(texture.Width / 2, texture.Height / 2), new Vector2((float)this.scale,(float)this.scale), SpriteEffects.None, 0f);
            spriteBatch.End();
            spriteBatch.Begin();
        }
    }
}
