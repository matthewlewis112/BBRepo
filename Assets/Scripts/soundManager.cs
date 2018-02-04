using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour {

	public static AudioClip jumpSound, paintSound;
	static AudioSource audioSrc;

	// Use this for initialization
	void Start () {

		jumpSound = Resources.Load<AudioClip> ("Jump4");
		paintSound = Resources.Load<AudioClip> ("Sound40");

		audioSrc = GetComponent<AudioSource> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static void playSound (string clip)	{

		switch (clip) {
		case "Jump4":
			audioSrc.PlayOneShot (jumpSound);
			break;
		case "Sound40":
			audioSrc.PlayOneShot (paintSound);
			break;
		}

	}
}
