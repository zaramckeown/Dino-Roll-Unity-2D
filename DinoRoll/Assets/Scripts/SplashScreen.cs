using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour 
{
	public float timer =1f;
	public string levelToLoad = "MainMenu";
	// Use this for initialization
	void Start () 
	{
		StartCoroutine ("DisplayScene");
	}//Start()
	
	IEnumerator DisplayScene()
	{
		yield return new WaitForSeconds(timer);
		Application.LoadLevel (levelToLoad);

	}//DisplayScene()
}//Class
