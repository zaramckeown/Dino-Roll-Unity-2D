using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour 
{
	//to keep a record of the score within the whole game
	public static int score;
	int highScore;

	//scores for the berries as each has a different num of points
	private int berryLifePoints = 10;
	private int moneyBag = 5;
	private int pinkBerry = 20;
	private int purpleBerry =3;

	//setting up the gameobjects for player and score
	private GameObject player_go;
	private GameObject score_obj;
	
	//points for bonus level 
	private int mixedBerry = 4;
	private int pinkColorBerry = 10;
	private int purpleColorBerry = 15; 

	//  clip for when the player collect berries.
	public AudioClip berryCollect;			

	// Use this for initialization
	void Start() 
	{
		//PlayerPrefs.DeleteAll ();
		player_go = GameObject.FindGameObjectWithTag("Player");
		score_obj = GameObject.FindGameObjectWithTag("Score");

		if(player_go == null) 
		{
			Debug.LogError("Could not find an object with tag 'Player'.");
		}//if

		if(score_obj == null) 
		{
			Debug.LogError("Could not find an object with tag 'score'.");
		}//if


//		//Returns the value corresponding to key in the preference file if it exists.
//		highScore = PlayerPrefs.GetInt ("highScore");
//		secondHighScore = PlayerPrefs.GetInt ("secondHighScore");
//		thirdHighScore = PlayerPrefs.GetInt ("thirdHighScore");

		if(CharacterScript.dead == true)
		{
			//setting the score to 0
			score = 0;
		}//setting the score to 0 if the player is dead 
	}//Start()

	void AddScore(int newScore)
	{
		//setting the score to the new score 
		score += newScore;

		//checking to see if the score achieved is greater than the previous 
		if(score > highScore)
		{
			//setting the highscore to score
			highScore = score;
		}//if


	}//AddScore()

	void FixedUpdate () 
	{
		//updating the text on the screen 
		score_obj.guiText.text = "Score: \n" + score;
	}//FixedUpdate () 


	void OnTriggerEnter2D(Collider2D collider) 
	{
		audio.clip = berryCollect;
		audio.volume = 1f;

		if(collider.tag == "BerryLife")
		{
			// Play a ping audio clip.
			audio.Play ();

			AddScore(berryLifePoints);
			
			Destroy(collider.gameObject);
		}//if

		if(collider.tag == "MoneyBag")
		{

			// Play a ping audio clip.
			audio.Play ();

			AddScore(moneyBag);
			
			Destroy(collider.gameObject);
		}//if

		if(collider.tag == "PinkBerry")
		{
			// Play a ping audio clip.
			audio.Play ();

			AddScore(pinkBerry);
			
			Destroy(collider.gameObject);
		}//if

		if(collider.tag == "PurpleBerry")
		{
			// Play a ping audio clip.
			audio.Play ();

			AddScore(purpleBerry);
			
			Destroy(collider.gameObject);
		}//if

		//if the player collides with the particle system it would then activate the particle system
		if(collider.tag == "ParticleSystem")
		{
			Debug.Log ("Bonus Level Activiated");
			
			Application.LoadLevel("Bonus");
		}//if


		//POINTS FOR BONUS LEVEL 

		//mixed berry points for bonus level
		if(collider.tag == "Berries")
		{
			// Play a ping audio clip.
			audio.Play ();

			AddScore(mixedBerry);
			
			Destroy(collider.gameObject);
		}//if

		if(collider.tag == "PurpleBerryBonus")
		{
			//checking to see if the player is purple or not 
			if(MouseFollowing.color == false)
			{	// Play a ping audio clip.
				audio.Play ();

				AddScore(purpleColorBerry);
		
				Destroy(collider.gameObject);
			}//if

			if(MouseFollowing.color == true)
				MouseFollowing.dead = true;
		}//if

		if(collider.tag == "PinkBerryBonus")
		{
			//checking to see if the player is pink or not
			if(MouseFollowing.color == true)
			{
				// Play a ping audio clip.
				audio.Play ();

				AddScore(pinkColorBerry);
			
				Destroy(collider.gameObject);
			}//if

			if(MouseFollowing.color == false)
				MouseFollowing.dead = true;
		}//if 
	}//OnTriggerEnter2D(Collider2D collider) 

}//class
