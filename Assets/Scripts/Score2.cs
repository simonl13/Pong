using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score2 : MonoBehaviour {
	
	public static int score2 = 0;
	AudioSource scoreSound;
	TextMesh textObject;
	
	// Use this for initialization
	void Start () {
		scoreSound = GetComponent<AudioSource> ();
		textObject = GameObject.Find("S2").GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
		textObject.text = score2.ToString ();
	}
}
