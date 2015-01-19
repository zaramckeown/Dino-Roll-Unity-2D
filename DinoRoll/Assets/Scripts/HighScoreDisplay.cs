using UnityEngine;
using System.Collections;

public class HighScoreDisplay : MonoBehaviour 
{

	//the texture so that it can be placed in the inspector
	public Texture2D mainMenuButton;

	//OLD VARIABLES FOR PLAYERPERFERENCES 
//	private int highScore;
//	private int secondHighScore;
//	private int thirdHighScore;
//	private string HighScoreName1;
//	private string HighScoreName2;
//	private string HighScoreName3;

	private string scoreInfo;

	//declaring the rectangle which is going to be used for the size of the button
	private Rect rect;
	
	//declaring the mouse
	private Vector2 mouse;


	// Use this for initialization
	void Start () 
	{
		scoreInfo = "High Scores\n\n";
		StartCoroutine (ReturnScores());
//		highScore = PlayerPrefs.GetInt ("highScore");
//		secondHighScore = PlayerPrefs.GetInt ("secondHighScore");
//		thirdHighScore = PlayerPrefs.GetInt ("thirdHighScore");
//		HighScoreName1 = PlayerPrefs.GetString ("HighScoreName1");
//		HighScoreName2 = PlayerPrefs.GetString ("HighScoreName2");
//		HighScoreName3 = PlayerPrefs.GetString ("HighScoreName3");
//
	}//Start () 

	void Awake()
	{
		//setting the rectangle up 
		rect = new Rect (Screen.width - mainMenuButton.width - 10, Screen.height - mainMenuButton.height - 10, mainMenuButton.width, mainMenuButton.height);
	}//Awake()

	void Update()
	{
		//setting the postion of the mouse
		mouse = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
		
		//checking to see if the mouse has been clicked 
		if(rect.Contains(mouse) && Input.GetMouseButtonDown(0))
		{	
			print ("Clicked on mainMenu!");
			//saving the data 
			
			//loading the menu
			Application.LoadLevel("MainMenu");
		}//if
	}//Update()

	IEnumerator ReturnScores()
	{
		string url = "https://dunluce.infc.ulst.ac.uk/d12mckz/games/scores.php";
		WWW scoreUrl = new WWW (url);
		yield return scoreUrl;
		//Creating a list of all the data recived. Should be the top 5 highscore
		scoreInfo = scoreInfo + scoreUrl.text;
	}//ReturnScores()

	void OnGUI()
	{
		//drawing the save button onto the screen
		GUI.DrawTexture(rect, mainMenuButton); 

		//Setting the color to red for the text
		GUI.color = Color.black;
	
		//Drawing on the name and score of the player
		GUILayout.BeginArea(new Rect(350, 10, 200, 200));
		GUILayout.Label (scoreInfo);
		GUILayout.EndArea();
	
	}//OnGUI()
}//class
