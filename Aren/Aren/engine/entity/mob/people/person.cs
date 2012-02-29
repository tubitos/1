using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Aren.engine;
using PloobsEngine.Modelo;
using PloobsEngine.Physics.Bepu;
using Aren.engine.objects;
using Aren.engine.entity.items;
using PloobsEngine.SceneControl;
using PloobsEngine;

namespace Aren.engine.entity.mob.people
{
	class Person : IScreenUpdateable
	{
		protected float health;
		protected float mana;
		protected int strength;
		protected int stamina;
		protected int luck;
		protected int wisdom;
		protected int intelligence;
		protected int agility;

		protected Backpack backpack;
		protected FullCharacterObject charecter;

		public float speed
		{
			get
			{
				return charecter.CharacterController.HorizontalMotionConstraint.Speed;
			}

			set
			{

			}
		}

		public Person (IScreen screen, Vector3 position, Matrix rotation, float width, float height)
			: base (screen)
		{
			health = 0;
			mana = 0;
			strength = 0;
			stamina = 0;
			luck = 0;
			wisdom = 0;
			intelligence = 0;
			agility = 0;

			backpack = new Backpack ();
			charecter = new FullCharacterObject (position, rotation, height, width, new Vector3 (.05F), 0, 120);
		}

		protected override void Update (GameTime gameTime)
		{
			
		}
	}
}