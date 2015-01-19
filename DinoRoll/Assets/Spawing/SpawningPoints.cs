using UnityEngine;
using System.Collections;

public class SpawningPoints : MonoBehaviour 
{
	//public Transform prefab;
	GameObject player;

	//for the x and y axis position
	float posx;
	float posy;

	//getting the prefab 
	public GameObject[] berries;		

	//initalizing the vector
	Vector3 position;

	void Start()
	{
		//finding the player and getting its current position
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		posx = player.transform.position.x;
		posy = player.transform.position.y;

		//setting the postion 
		position = new Vector3 (posx+30, posy+5, 0);

	}//FixedUpdate () 
	
	void OnTriggerExit2D(Collider2D col)
	{
		// Instantiate a random .
		int pointIndex = Random.Range(0, berries.Length);
		Instantiate(berries[pointIndex],position, transform.rotation);

		
	}//OnTriggerExit2D(Collider2D col)
}//class


