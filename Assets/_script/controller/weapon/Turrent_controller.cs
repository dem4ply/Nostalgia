using UnityEngine;
using System.Collections;
using controller.animator;
using controller.motor;
using System;

namespace chibi.motor.weapons.gun.controller
{
	public class Turrent_controller : chibi.controller.Controller
	{
		giroTorreta turrent;
		protected override void load_motors()
		{
			turrent = GetComponent<giroTorreta>();
			if ( !turrent )
			{
				Debug.LogError(
					string.Format(
						"no se encontro una torreta en el object {0}" +
						helper.game_object.name.full( gameObject ) ) );
			}
			else
			{
				turrent.controller = this;
			}
		}
	}
}
