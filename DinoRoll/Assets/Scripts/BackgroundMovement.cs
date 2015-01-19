using UnityEngine;
using System.Collections;

public class BackgroundMovement : MonoBehaviour 
{
	//setting the speed for the background movement 
	public float speed =0.2f;

	// Update is called once per frame
	void Update () 
	{
		if(CharacterScript.move == true || MouseFollowing.move == true)
		renderer.material.mainTextureOffset = new Vector2(Time.time * speed, 0f);
	}//Update()
}//class
