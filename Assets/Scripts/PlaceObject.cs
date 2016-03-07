using UnityEngine;
using System.Collections;

public class PlaceObject : MonoBehaviour {
	public Spawner s;

	void Start () {
		this.s = GameObject.Find ("Spawner").GetComponent<Spawner> ();
	}
	void Update () {
		this.transform.Translate(0, 0, s.speed * Time.deltaTime);
		if (this.transform.position.z > 0) {
			this.Place ();
		}
	}

	public void SetupInitialPosition(float x, float z) {
		this.transform.position = new Vector3 (x, -20, -z);
	}

	void Place() {
		var position = this.transform.position;
		position.z -= s.fogdepth;
		s.next_frame ++;

		switch ( s.phase ) {	
		case 1:	// asteroids field
			if ( Random.value < 0.97 ) {
				position.x = (Random.value*3000-1500) * s.scale;
				position.y = (Random.value*3000-1500) * s.scale;
			} else {
				position.x = s.ship.x;
				position.y = s.ship.y;
			}
			break;
		case 2:
			position.x = (Mathf.Cos(s.next_frame/s.p[0])*s.p[1] + Mathf.Cos(s.next_frame/s.p[2])*s.p[3]) * s.scale;
			position.y = (Mathf.Sin(s.next_frame/s.p[4])*s.p[5] + Mathf.Sin(s.next_frame/s.p[6])*s.p[7]) * s.scale;
			break;
		case 3:
			position.x = (Mathf.Cos(s.next_frame/s.p[0])*s.p[1] + Mathf.Cos(s.next_frame/s.p[2])*s.p[3]) * s.scale;
			position.y = (Mathf.Sin(s.next_frame/s.p[4])*s.p[5] + Mathf.Sin(s.next_frame/s.p[6])*s.p[7]) * s.scale;
			break;
		case 4:
			var r = Mathf.Cos(s.next_frame/s.p[0])*2000*s.scale;
			position.x = Mathf.Cos(s.next_frame/s.p[1])*r;
			position.y = Mathf.Sin(s.next_frame/s.p[1])*r;
			break;
		case 5:
			if ( Random.value < 0.95 ) {
				position.x = s.ship.x;
				position.y = s.ship.y;
			} else {
				position.x = ( Random.value*3000-1500) * s.scale;
				position.y = ( Random.value*3000-1500) * s.scale;
			}
			break;		
		}

		this.transform.position = position;
	}
}
