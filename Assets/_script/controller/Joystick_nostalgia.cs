﻿using UnityEngine;
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
		public bool use_turrent;
		public bool you_died = false;
		public damage.motor.HP_motor hp_house;

		#region funciones protegdas
		protected override void Update()
		{
			update_all_axis();
			update_all_buttons();
			if ( you_died )
				return;
			var c = controller as Controller_player;
			if ( c != null )
				c.joystick = this;
			if ( is_pass_deadzone_esdf_axis )
			{
				if ( c != null && !use_turrent )
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
				if ( c != null && !use_turrent )
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
				if ( turrent && use_turrent )
					turrent.shot();
			}
			if ( _fire_key_down( 3 ) )
			{
				//YAMATO
			}
		}

		protected override void _init_cache()
		{
			base._init_cache();
			if ( !hp_house )
				Debug.LogError( "el hp de la casa no esta asignado al joystick" );
		}
		#endregion
	}
}
