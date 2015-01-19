using UnityEngine;
using System.Collections;

public class ChangeTexture : MonoBehaviour 
{

	//declaring the font so that it can be put into the inspector 
	public Font font;
	
	//the texture so that it can be placed in the inspector
	public Texture2D saveButton;

	//high score name variable 
	private string HighScoreName = "Name";

	//text to display on the label
	private string typeYourName = "Please type your name";

	//the highscore 
	private int highScore;

	//declaring the rectangle which is going to be used for the size of the button
	private Rect rect;

	//declaring the mouse
	private Vector2 mouse;

	void Awake()
	{
		//setting the rectangle up 
		rect = new Rect (Screen.width - saveButton.width - 10, Screen.height - saveButton.height - 10, saveButton.width, saveButton.height);
	}//Awake()

	//to send the details of the score to the server
	IEnumerator StoreScore()
	{
		string url = "https://dunluce.infc.ulst.ac.uk/d12mckz/games/scores.php?name="+HighScoreName+"&score="+Score.score;
		WWW scoreUrl = new WWW (url);
		yield return scoreUrl;
	}//StoreScore()

	void Update()
	{
		//setting the postion of the mouse
		mouse = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);

		//checking to see if the mouse has been clicked 
		if(rect.Contains(mouse) && Input.GetMouseButtonDown(0))
		{	StartCoroutine(StoreScore());
			print ("Clicked on image!");
			//saving the data 
			//loading the menu
			Application.LoadLevel("MainMenu");
			Score.score = 0;

		}//if
	}//Update()

	void OnGUI()
	{
		//setting the font 
		GUI.skin.font = font;
	
		//drawing the save button onto the screen
		GUI.DrawTexture(rect, saveButton); 
	
		//setting the high score text field in order for the user to input their text
		HighScoreName = GUI.TextField(new Rect(10, 35, 200, 20), HighScoreName , 25);

		//setting up the area to draw the label in
		GUILayout.BeginArea(new Rect(10, 10, 200, 30));

		//setting color of the font 
		GUI.color = Color.red;

		//putting the label on the GUI
		GUILayout.Label (typeYourName);

		//ending the area 
		GUILayout.EndArea();

	}//OnGUI()

}//class
