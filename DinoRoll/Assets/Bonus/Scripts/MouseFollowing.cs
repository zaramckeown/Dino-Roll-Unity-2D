using UnityEngine;
using System.Collections;

public class MouseFollowing : MonoBehaviour 
{
	//delcaring the vector so that it can be the postion of the mouse
	private Vector3 mousePosition;

	//declaring the animator 
	private Animator animator;

	private GameObject player;
		
	//the speed that which the player moves after the mouse
	public float moveSpeed = 0.3f;

	[HideInInspector]
	//setting up bools for moving and dead
	public static bool move = false;
	[HideInInspector]
	public static bool dead = false;
	[HideInInspector]
	public static bool color = false;
	
	//for testing purposes to make it easy 
	public bool godMode = false;

	//  clip for when the player dies.
	public AudioClip deadMusic;			
	

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");

		//getting the animator 
		animator = GetComponent<Animator> ();
		
		//checking that it is found 
		if(animator == null) 
		{
			Debug.LogError("Didn't find animator!");
		}//if

		dead = false;
	}//Start()
		
	void Update () 
	{
		//press a key to move 
		if(Input.anyKeyDown)
		{
			//setting the bool to true and playing the animation for rolling 
			move = true;
		}//if

		//setting the vector to the mouse
		mousePosition = Input.mousePosition;
	
		//Transforms position from screen space into world space.
		mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
	
		//Linearly interpolates between two vectors. Interpolates between from current and to mouseposition 
		//by the speed of 0.3f.
		transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
	
		if(Input.GetMouseButtonDown(0))
		{
			if(animator.GetBool("Color")==true)
			{	
				color = false;
				animator.SetBool ("Color", false);
			}//if

			else
			{
				color = true;
				animator.SetBool ("Color", true);
			}//else
		}//if

		if(Input.GetKeyDown(KeyCode.G))
		{	if(godMode==false)
			{
				godMode=true;
			}
			
			else 
			{
				godMode=false;
			}
		}
			
		
	}//Update()

	//loading the game over menu with a delay
	IEnumerator GameOverLoad(float delay, int level)
	{
		//setting up how many seconds to delay it for
		yield return new WaitForSeconds(delay);
		
		//loading the level
		Application.LoadLevel(level);
	}//GameOverLoad(float delay, int level)

	void OnTriggerEnter2D(Collider2D col)
	{
		//dont hit with anything else
		if(godMode)
			return;

		// If the player hits the trigger...
		if(col.tag == "Clouds")
		{
			audio.clip = deadMusic;
			audio.Play();
			
			// ... destroy the obj.
			Destroy (col.gameObject);
			
			//setting the player to dead
			dead = true;

			Debug.Log("dead");
		}//if

		if(col.tag == "Excape")
		{
			audio.clip = deadMusic;
			audio.Play();
			
			// ... destroy the obj.
			Destroy (col.gameObject);
			
			//setting the player to dead
			dead = true;
			
			Debug.Log("dead");
		}//if

	
		//load new level when player is dead
		if(dead == true)
		{
			audio.clip = deadMusic;
			audio.Play();

			//playing the dead animation 
			animator.SetBool("Dead",true);
			
			//loading the level and delaying it by one second
			StartCoroutine(GameOverLoad(1.0f,5));
		}//if
		
	}//OnTriggerEnter2D(Collider2D col)


		
}//class
