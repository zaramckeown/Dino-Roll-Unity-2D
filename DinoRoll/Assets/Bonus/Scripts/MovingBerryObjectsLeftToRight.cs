using UnityEngine;
using System.Collections;

public class MovingBerryObjectsLeftToRight : MonoBehaviour 
{

	public Vector2 speed = new Vector2(1, 1);

	public Vector2 direction = new Vector2(-1, 0);

	private Vector2 movement;

	//set to play when started
	void Awake()
	{
		// starting movement 
		movement = new Vector2(speed.x * direction.x, speed.y * direction.y);
	}//Awake()
	
	
	void FixedUpdate ()
	{
		//changing the movement 
		rigidbody2D.velocity = movement;		
		
	}//FixedUpdate ()
	
	void OnTriggerEnter2D(Collider2D col)	
	{
		//if collides with left collider will change left
		if(col.tag == "LeftCollider")
		{
			movement = new Vector2(speed.x * -direction.x, speed.y * direction.y);	
		}//if
			
		//if collides with right collider will change to right 
		if(col.tag == "RightCollider")
		{
			movement = new Vector2(speed.x * direction.x, speed.y * direction.y);
		}//if
			
	}//OnTriggerEnter2

}//class
