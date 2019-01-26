using UnityEngine;
using System.Collections;
using controller;
using controller.animator;
using Unity.Entities;
using System;

namespace chibi.motor.behavior
{
	public class Look_at_motor_forward : chibi.Chibi_behaviour
	{
		public Vector3 desire_vector;
	}
}