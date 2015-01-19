using UnityEngine;
using System.Collections;

public class MovingGroundForPlayer : MonoBehaviour 
{
	Rigidbody2D player;
	
	void Start () 
	{
		//getting the player by their tag
		GameObject player_go = GameObject.FindGameObjectWithTag("Player");

		//making sure that the player can be found by their tag
		if(player_go == null) 
		{
			Debug.LogError("Couldn't find an object with tag 'Player'!");
			return;
		}//if

		//checking to see if the player isnt dead
		if(CharacterScript.dead == true)
		{
			Debug.Log("Player is Dead");
			return;
		}//if

		else
		{
		
			player = player_go.rigidbody2D;
		}//else
		
	}//start
	
	void FixedUpdate() 
	{
		//checking to see that the player is not dead
		if(CharacterScript.dead == true)
		{
			Debug.Log("Player is Dead");
			return;
		}//if

		//if the player isnt dead it can then continue 
		else
		{

			float vel = player.velocity.x * 1f;
		
			transform.position = transform.position + Vector3.right * vel * Time.deltaTime;
		}//else
	}//FixedUpdate()
}//class
