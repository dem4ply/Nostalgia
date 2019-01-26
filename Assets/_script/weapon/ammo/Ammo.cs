﻿using UnityEngine;
using damage;
using chibi.motor.weapons.gun.bullet;

namespace weapon
{
	namespace ammo
	{
		[ CreateAssetMenu( menuName="weapon/gun/ammo/base") ]
		public class Ammo : chibi_base.Chibi_object
		{
			public Bullet_motor prefab_bullet;

			public override string path_of_the_default
			{
				get { return "object/weapon/gun/ammo/default"; }
			}

			public virtual Bullet_motor instanciate()
			{
				Bullet_motor obj =
					singleton.object_pool.Ammo_pool.instance.pop( this );
				return obj;
			}

			public virtual Bullet_motor instanciate( Vector3 position )
			{
				Bullet_motor obj = instanciate();
				obj.transform.position = position;
				return obj;
			}

			public virtual Bullet_motor instanciate(
				Vector3 position, rol_sheet.Rol_sheet owner )
			{
				Bullet_motor obj = instanciate( position );
				/*
				Damage[] damages = obj.damages;
				foreach ( Damage damage in damages )
					damage.owner = owner;
				*/
				return obj;
			}
		}
	}
}