using UnityEngine;
using System.Collections;

public class EndScore : MonoBehaviour {

	GameObject score_obj;

	// Use this for initialization
	void Start () 
	{
		score_obj = GameObject.FindGameObjectWithTag("Score");
	}//Start () 
	
	// Update is called once per frame
	void Update () 
	{
		score_obj.guiText.text = "Total Score: \n\t\t\t\t\t\t\t\t\t\t" + Score.score;
	}//Update () 
}//class
