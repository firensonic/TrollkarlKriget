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

namespace Trollkarlkriget
{
    class physobj
    {
        protected bool isAlive = true;

        public physobj(Texture2D texture, Vector2 position)
        {

        }
        public bool CheckCollision(physobj other)
        {
            return false;
        }
    }
}
