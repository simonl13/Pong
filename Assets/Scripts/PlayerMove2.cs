using UnityEngine;
using System.Collections;

public class PlayerMove2 : MonoBehaviour {
	public int speed = 40; //sets the default speed to 10.
	bool left;
	bool right;
	public Transform leftwall; //pos of left wall
	public Transform rightwall; //pos of right wall
	
	// Update is called once per frame
	void Update () {
		Movement ();
		Raycasting ();
	}
	void Movement () {
		if ( Input.GetKey (KeyCode.LeftArrow) && left == false){
			transform.Translate (Vector3.left * speed * Time.deltaTime);
		}
		if ( Input.GetKey (KeyCode.RightArrow) && right == false) {
			transform.Translate (Vector3.right * speed * Time.deltaTime);
		}
	}
	
	//Object Collision Detection
	
	void Raycasting () {
		left = Physics.Linecast (this.transform.position, rightwall.position);
		right = Physics.Linecast (this.transform.position, leftwall.position);
	}
}