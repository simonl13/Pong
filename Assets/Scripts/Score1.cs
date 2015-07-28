using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score1 : MonoBehaviour {

	public static int score1 = 0;
	AudioSource scoreSound;
	TextMesh textObject;
	
	// Use this for initialization
	void Start () {
		scoreSound = GetComponent<AudioSource> ();
		textObject = GameObject.Find("S1").GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
		textObject.text = score1.ToString ();
	}
}
