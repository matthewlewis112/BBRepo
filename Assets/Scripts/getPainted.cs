using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getPainted : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void onCollisionEnter (Collision col){
		if (col.gameObject.name == "redBucket") {
			gameObject.GetComponent<SpriteRenderer> ().color = Color.red;
		}
	}
}
