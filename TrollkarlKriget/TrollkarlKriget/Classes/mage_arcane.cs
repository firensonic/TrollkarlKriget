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
	public class Arcanist : player
	{
		public Arcanist(Texture2D texture, Vector2 position, Keys jump, Keys right, Keys left, Keys melee, Keys spell)
			:base(texture, position,jump,right,left,melee,spell)
		{
		}
	}
}

