using UnityEngine;
using System.Collections;

public class SpawningObstacles : MonoBehaviour {

	//public Transform prefab;
	Vector3 position;

	//Transform canvas;
	GameObject player;

	//setting up the obstacles so they can be passed in 
	public GameObject[] obstacles;

	//the position of the player on the x axis 
	float posx;

	void Start()
	{
		//finding the player
		player = GameObject.FindGameObjectWithTag ("Player");
	}//Start()

	// Update is called once per frame
	void FixedUpdate () 
	{
		//finding the position of the player
		posx = player.transform.position.x;

	}//FixedUpdate ()
		
	void OnTriggerExit2D(Collider2D col)
	{
		//setting the postion of the next respawn 
		position = new Vector3(posx, -3.40025f, 0);

		// Instantiate a random 
		int obstaclesIndex = Random.Range(0, obstacles.Length);
		Instantiate(obstacles[obstaclesIndex],position, transform.rotation);

		//Deleting all the previous obstacles after 12 seconds
		foreach(GameObject obstacle in GameObject.FindGameObjectsWithTag("Obstacles"))
		{
			//destroy being called 
			Destroy(obstacle, 12.0f);
		}//foreach

		//Deleting all the previous berries after 9 seconds
		foreach(GameObject point in GameObject.FindGameObjectsWithTag("Points"))
		{
			//destroy being called 
			Destroy(point, 9.0f);
		}//foreach

	}//OnTriggerExit2D(Collider2D col)

}//class
