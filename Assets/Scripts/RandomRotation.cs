using UnityEngine;
using System.Collections;

public class RandomRotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.transform.rotation = Random.rotationUniform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
