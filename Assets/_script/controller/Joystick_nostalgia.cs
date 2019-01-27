using UnityEngine;
using System.Collections;
using controller.animator;
using controller.motor;
using controller.controllers;
using chibi;
using chibi.controller.npc;

namespace chibi.joystick
{
	public class Joystick_nostalgia : Joystick
	{
		#region funciones protegdas
		protected override void Update()
		{
			base.Update();
			if ( _fire_key_down( 1 ) )
			{
				var c = controller as Controller_player;
				if ( c != null )
					c.take_torreta();
				//tomar torreta
			}
			if ( _fire_key_down( 2 ) )
			{
				//disparar
			}
			if ( _fire_key_down( 3 ) )
			{
				//YAMATO
			}
		}
		#endregion
	}
}
