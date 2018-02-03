using UnityEngine;
using System.Collections;

public class ChangeColor : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	public static void changeColor(SpriteRenderer s, Color c){
		s.color = c;
	}
}

