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
		public giroTorreta turrent;
		#region funciones protegdas
		protected override void Update()
		{
			update_all_axis();
			update_all_buttons();
			var c = controller as Controller_player;
			if ( c != null )
				c.joystick = this;
			if ( is_pass_deadzone_esdf_axis )
			{
				if ( c != null && turrent == null )
				{
					c.desire_direction = axis_esdf;
					c.speed = 1f;
				}
				else
				{
					turrent.turn( axis_esdf );
				}
			}
			else
			{
				if ( c != null && turrent == null )
				{
					c.desire_direction = Vector3.zero;
					c.speed = 1f;
				}
				else
				{
					turrent.turn( Vector3.zero );
				}
			}

			if ( _fire_key_down( 1 ) )
			{
				if ( c != null )
					c.take_torreta();
				//tomar torreta
			}
			if ( _fire_key_down( 2 ) )
			{
				if ( turrent )
					turrent.shot();
			}
			if ( _fire_key_down( 3 ) )
			{
				//YAMATO
			}
		}
		#endregion
	}
}
