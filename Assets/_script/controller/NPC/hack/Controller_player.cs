using UnityEngine;
using System.Collections.Generic;
using chibi.motor;

namespace chibi.controller.npc
{
	public class Controller_player : Controller_npc
	{
		public motor.animator.Player_0 animator;

		public virtual void take_torreta()
		{
			animator.is_turrent = !animator.is_turrent;
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
