using UnityEngine;


namespace helper
{
	namespace life
	{
		public class Life_tiemr_nostalgia : chibi_base.Chibi_behaviour
		{
			public Life_span live_span;

			protected float _live_time = 0f;

			protected override void Start()
			{
				base.Start();
				if ( live_span == null )
					Destroy( this );
			}

			protected virtual void Update()
			{
				_live_time += Time.deltaTime;
				if ( _live_time > live_span.seconds_of_life )
					died();
			}

			protected virtual void died()
			{
				Destroy( gameObject );
			}
		}
	}
}
