using UnityEngine;
using System.Collections;

public class ParticleSpawner : MonoBehaviour 
{

	//getting the prefab 
	public GameObject[] particle;

	//getting the prefab Transporter
	public GameObject[] transporter;

	//creating the gameobj player
	GameObject player;

	//delcaring the two positions
	float posx;
	float posy;

	//creating the two vectors
	Vector3 transporterPosition;
	//Vector3 particlePosition;

	// Use this for initialization
	void Start () 
	{
		
		//finding the player
		player = GameObject.FindGameObjectWithTag ("Player");
	}//start
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		//finding the position of the player
		posx = player.transform.position.x;
		posy = player.transform.position.y;

		
	}//FixedUpdate ()
	
	void OnTriggerExit2D(Collider2D col)
	{
		//setting the postion of the next respawn 
		transporterPosition = new Vector3(posx, -3.40025f, 0);

		//setting the postion for the particle positio
		//particlePosition = new Vector3 (posx, posy+5, 0);

		//getting a random value
		float randValue = Random.value;

		//ensuring that the particle system is random as in when it appears 
		if (randValue > .9f) // 45% of the time	
		{
			//Instantiate(particlePosition[0],transporterPosition, transform.rotation);
			//Instantiate(transporter[0],transporterPosition, transform.rotation);
		}//if
	
	}//OnTriggerExit2D(Collider2D col)
	

		
}//class
