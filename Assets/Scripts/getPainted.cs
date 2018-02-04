using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getPainted : MonoBehaviour {

	public Color c;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D (Collider2D other){
		soundManager.playSound ("Sound40");
		if (other.tag == "Player") {
			if (gameObject.tag == "redBucket")
				other.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
			if (gameObject.tag == "blueBucket")
				other.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
			if (gameObject.tag == "yellowBucket")
				other.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
			if (gameObject.tag == "demoBucket")
				other.gameObject.GetComponent<SpriteRenderer> ().color = Color.white;
		}
	}
}
