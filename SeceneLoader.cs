using UnityEngine;
using System.Collections;

[System.Serializable]
public class SeceneLoader : MonoBehaviour {

	public float lastTimePlayed = 0f;
	public float currentTime = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void LoadLevel ()
	{
		try
		{
			LoadSavedGame();
		}
		catch
		{
			Application.LoadLevel("NewGame");
		}
	}

	void LoadSavedGame ()
	{
	}
}
