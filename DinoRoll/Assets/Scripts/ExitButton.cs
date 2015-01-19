using UnityEngine;
using System.Collections;

public class ExitButton : MonoBehaviour 
{
	//these are set in the inspector of the ExitButton
	public Texture2D exitNormal;
	public Texture2D exitHover;
	
	void  OnMouseEnter (){
		//when hovering use this texture
		guiTexture.texture = exitHover;
	}//OnMouseEnter
	
	void  OnMouseExit (){
		//when not hovering use this texture
		guiTexture.texture = exitNormal;
	}//OnMouseExit
	
	void  OnMouseDown (){
		//quit the whole game and close window
		Application.LoadLevel ("Controls");
	}//OnMouseDown
}//class