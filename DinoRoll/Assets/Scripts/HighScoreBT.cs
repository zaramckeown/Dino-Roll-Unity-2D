using UnityEngine;
using System.Collections;

public class HighScoreBT : MonoBehaviour 
{

	//these are set in the inspector of the highscorebt
	public Texture2D playNormal;
	public Texture2D playHover;
	
	void  OnMouseEnter ()
	{
		//use the playExit texture when mouse is hovering on button
		guiTexture.texture = playHover;
	}//OnMouseEnter
	
	void  OnMouseExit ()
	{
		//use the playNormal texture when the mouse is not hovering
		guiTexture.texture = playNormal;
	}//OnMouseExit
	
	void  OnMouseDown ()
	{
		Application.LoadLevel("HighScores");
	
	}//OnMouseDown
}
