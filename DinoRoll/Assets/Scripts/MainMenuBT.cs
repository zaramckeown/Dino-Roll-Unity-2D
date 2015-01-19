﻿using UnityEngine;
using System.Collections;

public class MainMenuBT : MonoBehaviour {

	//these are set in the inspector of the PlayButton
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
	
	void  OnMouseDown (){
		//loading game scene
		Application.LoadLevel("MainMenu");
	}//OnMouseDown
}