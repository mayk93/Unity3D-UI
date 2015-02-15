using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {

	public static GameControl control;

	public float health = 0f;
	public float happiness = 0f;

	public float lastTimePlayed = 0f;
	public float currentTime = 0f;

	// Use this for initialization
	void Awake () {
		/* A singleton */
		/*
		 * If there is no control, make one and set it to this game object.
		 * If there is a control, but it's  not this game object, delete  it.
		*/
		if (control == null) 
		{
			DontDestroyOnLoad (gameObject);
			control = this;
		} 
		else if(control != this)
		{
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/* For debugging */
	void OnGUI()
	{
		GUI.Label (new Rect (10, 10, 100, 30), "Health: " + health);
		GUI.Label (new Rect (10, 40, 100, 30), "Happiness: " + happiness);
	}
}
