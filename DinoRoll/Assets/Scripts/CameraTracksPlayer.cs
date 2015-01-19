using UnityEngine;
using System.Collections;

public class CameraTracksPlayer : MonoBehaviour 
{
	//player transform
	Transform player;

	//the offset float
	float offsetX;

	//the player
	GameObject player_go;
	
	// Use this for initialization
	void Start () 
	{
		//finding the player
		player_go = GameObject.FindGameObjectWithTag("Player");

		//ensuring that the player is not null
		if(player_go == null) 
		{
			Debug.LogError("Couldn't find an object with tag 'Player'!");
			return;
		}//if

		//setting the transform to the players current 
		player = player_go.transform;

		//setting up the offset
		offsetX = transform.position.x - player.position.x;
	}//Start()
	
	// Update is called once per frame
	void Update () 
	{
		//ensuring that the player isnt null
		if(player != null) 
		{
			Vector3 pos = transform.position;
			pos.x = player.position.x + offsetX;
			transform.position = pos;
		}//if
	}//Update()
}//class