using UnityEngine;
using System.Collections;

public class SpawnPongBall : MonoBehaviour {

	public static bool ballexists;
	Object ballobject;

	// Use this for initialization
	void Start () {
		ballobject = Resources.Load ("prefabs/ball");
		ballexists = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (ballexists == false && Input.GetKeyDown (KeyCode.Space)) {
			Instantiate (ballobject, new Vector3 (0, -154, -156), Quaternion.identity);
			ballexists = true;
		}
	}
}
