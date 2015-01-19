using UnityEngine;
using System.Collections;

public class CharacterScript : MonoBehaviour 
{
	//moving forward 
	public float forwardSpeed=3f;

	//setting up jumping variables
	public float jumpHeight=350f;
	public bool isJumping = false;

	//setting up bools for moving and dead
	public static bool move = false;
	public static bool dead = false;

	//for testing purposes to make it easy 
	public bool godMode = false;

	//declaring the animator 
	Animator anim;

	// Array of clips for when the player jumps.
	public AudioClip[] jumpClips;

	//  clip for when the player dies.
	public AudioClip deadMusic;			
	
	void Start()
	{
		//getting the animator 
		anim = GetComponent<Animator> ();

		//checking that it is found 
		if(anim == null) 
		{
			Debug.LogError("Didn't find animator!");
		}//if

		dead = false;
	}//Start()

	void Update()
	{
		//press a key to move 
		if(Input.anyKeyDown)
		{
			//setting the bool to true and playing the animation for rolling 
			move = true;
			anim.SetInteger("Pressed",1);

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

	void FixedUpdate()
	{
		//if the character is moving 
		if(move)
		{	
			transform.Translate(Vector2.right * forwardSpeed * Time.deltaTime);

			//if they are jumping 
			if(isJumping)
			{
				// Set the Jump animator trigger parameter.				
				anim.SetTrigger("Jump");

				// Play a random jump audio clip.
				int i = Random.Range(0, jumpClips.Length);
				AudioSource.PlayClipAtPoint(jumpClips[i], transform.position);

				// Add a vertical force to the player.
				rigidbody2D.AddForce(Vector2.up * jumpHeight);
			
				// Make sure the player can't jump again until the jump conditions from Update are satisfied.
				isJumping = false;
 
			}//if
		}//move
	}//FixedUpdate()

	void OnTriggerEnter2D(Collider2D col)
	{
		//dont hit with anything else
		if(godMode)
			return;

		// If the player hits the trigger...
		if(col.tag == "Obstacles")
		{
			audio.clip = deadMusic;
			audio.Play();

			// .. stop the camera tracking the player - GameCamera is the name of the script from the cam that follows the player
			GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraTracksPlayer>().enabled = false;
						
			// ... destroy the player.
			Destroy (col.gameObject);

			//setting the player to dead
			dead = true;
		}//if

		//load new level when player is dead
		if(dead == true)
		{
			audio.clip = deadMusic;
			audio.Play();

			//playing the dead animation 
			anim.SetBool("Dead",true);

			//loading the level and delaying it by one second
			StartCoroutine(GameOverLoad(1.0f,5));
		}//if


	}//OnCollisionEnter2D(Collision2D col)

	//loading the game over menu with a delay
	IEnumerator GameOverLoad(float delay, int level)
	{
		//setting up how many seconds to delay it for
		yield return new WaitForSeconds(delay);

		//loading the level
		Application.LoadLevel(level);
	}//GameOverLoad(float delay, int level)

	void OnCollisionEnter2D(Collision2D col)
	{
		// If the jump button is pressed and the player is grounded then the player should jump.
		if (Input.GetButtonDown("Jump")) 
		{
			isJumping = true;
		}//if
	}//OnCollisionEnter2D(Collision2D col)
	
}//class
