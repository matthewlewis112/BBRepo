using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSystem : MonoBehaviour {

	private GameObject player;
	private Vector3 offset;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		offset = transform.position - player.transform.position;
		offset = new Vector3(offset.x + (float)3, offset.y + 2, offset.z);
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = new Vector3(player.transform.position.x + offset.x/2,
		 player.transform.position.y + offset.y / 2,
		player.transform.position.z + offset.z);
	}
}
