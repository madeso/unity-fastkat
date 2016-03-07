using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public PlaceObject Object;

	public int phase = 1;
	public int next_frame = 0;
	const int maxp = 8;
	public float[] p;
	public Vector3 ship = new Vector3(0,0,0);
	public float fogdepth = 1000;
	public float scale = 0.5f;
	public float track;
	public float speed = 80;

	// Use this for initialization
	void Start () {
		p =  new float[maxp];
		for (int i = 0; i < maxp; ++i) {
			p [i] = 0;
		}

		const int count = 1500;
		for (int i = 0; i < count; ++i) {
			var o = GameObject.Instantiate (Object);
			o.SetupInitialPosition (100 * ((i%2) - 0.5f), fogdepth * ((float)i / count));
		}
	}
	
	// Update is called once per frame
	void Update () {
		UpdateTrack ();

		RenderSettings.fog = true;
		RenderSettings.fogEndDistance = fogdepth;
		RenderSettings.fogStartDistance = fogdepth / 2;
	}

	public float TrackLength = 5;

	void UpdateTrack() {
		track -= speed * Time.deltaTime;
		if (track < 0) {
			track += TrackLength + Random.value * TrackLength;

			phase = (int) Mathf.Floor(Random.value * 5) + 1;

			switch (phase) {
			case 1:
				break;

			case 2:	// twirl 1
				p [0] = Random.value * 3 + 0.01f;
				p [1] = 300 + Random.value * 900;
				p [4] = p [0];
				p [5] = 300 + Random.value * 900;

				p [2] = 8 + Random.value * 77;	// x secondary
				p [3] = Random.value * 500;	// x secondary
				p [6] = 8 + Random.value * 77;	// y secondary
				p [7] = Random.value * 400;	// y secondary

				break;
			case 3: // snake
				p [0] = Random.value * 30 + 7;
				p [1] = 300 + Random.value * 900;
				p [4] = p [0];
				p [5] = 300 + Random.value * 700;

				p [2] = 8 + Random.value * 77;		// x secondary
				p [3] = 200 + Random.value * 1000;	// x secondary
				p [6] = 8 + Random.value * 77;		// y secondary
				p [7] = 200 + Random.value * 1000;	// y secondary

				break;							
			case 4:	// plane
				p [0] = Random.value * 3 + 0.01f;
				p [1] = (Random.value * 500 + 40) * (Random.value > 0.5 ? 1 : -1);
				break;		

			}
		}
	}
}
