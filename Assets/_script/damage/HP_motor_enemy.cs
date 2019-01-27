using UnityEngine;
using UnityEngine.UI;

namespace damage
{
	namespace motor
	{
		public class HP_motor_enemy : HP_motor
		{
			public override void take_damage( Damage damage )
			{
				base.take_damage( damage );
				if ( is_dead )
				{
					var e = GetComponent<Enemy_attack>();
					if ( e )
						e.died();
				}
			}
		}
	}
}
