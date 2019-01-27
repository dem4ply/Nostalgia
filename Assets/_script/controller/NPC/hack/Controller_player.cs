using UnityEngine;
using System.Collections.Generic;
using chibi.motor;

namespace chibi.controller.npc
{
	public class Controller_player : Controller_npc
	{
		public motor.animator.Player_0 animator;
		private giroTorreta _turrent;
		public joystick.Joystick_nostalgia joystick;

		public giroTorreta turrent
		{
			get {
				return _turrent;
			}

			set {
				_turrent = value;
				if ( value == null )
					joystick.turrent = null;
			}
		}

		public virtual void take_torreta()
		{
			if ( turrent == null )
			{
				animator.is_turrent = false;
				joystick.turrent = null;
			}
			else if ( !animator.is_turrent )
			{
				animator.is_turrent = true;
				transform.position = turrent.position.position;
				desire_direction = turrent.position.forward;
				speed = 0f;
				joystick.turrent = turrent;
			}
			else
			{
				turrent = null;
				animator.is_turrent = false;
			}
		}

		protected override void load_motors()
		{
			base.load_motors();
			animator = GetComponent<motor.animator.Player_0>();
			if ( animator == null )
				Debug.LogError(
					string.Format(
						"no se encontro un motor de animator en el object {0}",
						helper.game_object.name.full( gameObject ) ) );
		}
	}
}
