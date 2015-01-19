using UnityEngine;
using System.Collections;

public class Berries : MonoBehaviour {

	public float moveSpeed = 2f;		// The speed the enemy moves at.
	public AudioClip[] deathClips;		// An array of audioclips that can play when the berry dies

	void FixedUpdate ()
	{
		// Set the berries velocity to moveSpeed in the x direction.
		rigidbody2D.velocity = new Vector2(transform.localScale.x * moveSpeed, rigidbody2D.velocity.y);	
	}//FixedUpdate ()
	
	void OnTriggerEnter2D(Collider2D col)
	{
		//Deleting all the previous Berries after 2 seconds
		foreach(GameObject berry in GameObject.FindGameObjectsWithTag("Berries"))
		{
			//destroy being called 
			Destroy(berry, 10.0f);
		}//foreach

		//Deleting all the previous Berries after 2 seconds
		foreach(GameObject pinkBerries in GameObject.FindGameObjectsWithTag("PinkBerryBonus"))
		{
			//destroy being called 
			Destroy(pinkBerries, 10.0f);
		}//foreach

		//Deleting all the previous Berries after 2 seconds
		foreach(GameObject purpleBerries in GameObject.FindGameObjectsWithTag("PurpleBerryBonus"))
		{
			//destroy being called 
			Destroy(purpleBerries, 10.0f);
		}//foreach


	}//OnTriggerEnter2D(Collider2D col)
}
