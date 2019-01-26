using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using helper.test.assert;
using chibi.controller.ai;
using weapon.gun;

namespace tests.weapon.gun
{
	public class linear_gun : helper.tests.Scene_test
	{
		Assert_colision assert;
		Linear_gun gun;

		public override string scene_dir
		{
			get {
				return "tests/scene/controller/motor/weapons/gun/linear_gun";
			}
		}

		public override void Instanciate_scenary()
		{
			base.Instanciate_scenary();

			assert = helper.game_object.Find._<Assert_colision>(
				scene, "assert" );
			gun = helper.game_object.Find._<Linear_gun>( scene, "linear_gun" );
		}

		[UnityTest]
		public IEnumerator when_shot_should_create_a_bullet()
		{
			var bullet = gun.shot();
			yield return new WaitForSeconds( 1 );
			assert.assert_collision_enter( bullet );
		}
	}
}
