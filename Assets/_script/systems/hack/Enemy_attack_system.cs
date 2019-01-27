using UnityEngine;
using Unity.Entities;
using Unity.Jobs;
using Unity.Burst;
using Unity.Mathematics;
using Unity.Transforms;
using System.Collections;
using chibi.controller;
using chibi.motor.npc;

namespace chibi.systems.hack
{
	public class Enemy_attack_system : ComponentSystem
	{

		struct group
		{
			public Enemy_attack enemy;
		}

		protected override void OnUpdate()
		{
			float delta_time = Time.deltaTime;
			foreach ( var entity in GetEntities<group>() )
			{
				if ( entity.enemy.is_going_to_attack )
				{
					float ratio_damage = 1 / entity.enemy.attack_by_second;
					entity.enemy.last_time_attack += delta_time;
					if ( entity.enemy.last_time_attack > ratio_damage )
					{
						entity.enemy.instance_damage();
						entity.enemy.last_time_attack -= ratio_damage;
					}
				}
			}
		}
	}
}
