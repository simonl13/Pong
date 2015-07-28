using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BallMove : MonoBehaviour {

	Rigidbody move;
	AudioSource hitmarker;
	public int speed = 100;

	// Use this for initialization
	void Start () {
		move = GetComponent<Rigidbody> ();
		hitmarker = GetComponent<AudioSource> ();
		gameObject.GetComponent<SpawnPongBall> ();
		move.AddForce (Vector3.forward * speed);
	}

	void Update () {
		if (Input.GetKey (KeyCode.E)) {
			Destroy (this.gameObject);
			gameObject.GetComponent<SpawnPongBall> ();
			SpawnPongBall.ballexists = false;
		}
		if (move.position.y < 0) {
			gameObject.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
		}
	}

	void onCollisionEnter (Collision collisionInfo) {
		var localVel = transform.InverseTransformDirection (move.velocity);
		move.AddForce (Vector3.Reflect (localVel, collisionInfo.contacts[0].normal) * speed, ForceMode.Impulse);
		hitmarker.Play ();
		speed += 10;
	}

	void onTriggerEnter(Collider other) {
		if (other.tag == "Wall") {
			Destroy (this.gameObject);
			gameObject.GetComponent<SpawnPongBall> ();
			SpawnPongBall.ballexists = false;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "Player1") {
			move.velocity = Vector3.zero;
			move.AddForce (Vector3.forward * speed);
			Debug.Log ("Player1 ball hit");
		}
		if (other.tag == "Player2") {
			move.velocity = Vector3.zero;
			move.AddForce (Vector3.back * speed);
			Debug.Log ("Player2 ball hit");
		}
		if (other.tag == "leftwall") {
			gameObject.transform.position = new Vector3(4, 1, 25);
			move.velocity = new Vector3(0, 0, -20);
			//move.AddForce (Vector3.left * speed);
			Score2.score2 += 1;
			Debug.Log (Score2.score2);
			Debug.Log ("Ball hit leftwall");
		}
		if (other.tag == "rightwall") {
			gameObject.transform.position = new Vector3(4, 1, 25);
			move.velocity = new Vector3(0, 0, 20);
			Score1.score1 += 1;
			Debug.Log (Score1.score1);
			Debug.Log ("Ball hit rightwall");
		}
	}
}