using UnityEngine;
using System.Collections;
using controller;
using controller.animator;
using Unity.Entities;
using System;

namespace chibi.motor.behavior
{
	public class Look_at : chibi.Chibi_behaviour
	{
		public GameObject target;

		protected Vector3 _desire_direction = Vector3.forward;

		public Vector3 desire_direction
		{
			get {
				if ( helper.game_object.comp.is_null( target ) )
					return _desire_direction;
				else
					return target.transform.position - transform.position;
			}
			set {
				_desire_direction = value;
			}
		}
	}
}