using UnityEngine;
using System.Collections;

[System.Serializable]
public class SeceneLoader : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadLevel ()
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
		Application.LoadLevel("NewGame");
	}
}
