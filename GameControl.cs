using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {

	public static GameControl control;

	public AudioClip[] feedSounds;
	public AudioClip[] happySounds;
	public Sprite[] spritesArray;

	public float health = 0f;
	public float happiness = 0f;

	public float lastTimePlayed = 0f;
	public float currentTime = 0f;

	float foodAmmount = 0.1f;
	float playAmmount = 0.1f;

	float minHealth = 0.3f;
	float minHappy = 0.5f;

	float recoverHealth = 0.5f;
	float recoverHappy = 0.7f;

	float foodDecay = 0.01f;
	float happyDecay = 0.02f;

	GameObject critter;

	bool canFeed = true;
	bool canHappy = true;

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

		InvokeRepeating("changeStats", 1, 1);
		critter = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		try
		{
			if( this.health <= minHealth )
			{
				critter.GetComponent<SpriteRenderer>().color = Color.red;
			}
			
			if( this.happiness <= minHappy )
			{
				critter.GetComponent<SpriteRenderer>().color = Color.blue;
			}
			
			if( this.health >= recoverHealth )
			{
				critter.GetComponent<SpriteRenderer>().color = Color.white;
			}
			
			if( this.happiness >= recoverHappy )
			{
				critter.GetComponent<SpriteRenderer>().color = Color.white;
			}

			if( this.health <= 0 | this.happiness <= 0 )
			{
				Application.LoadLevel("GameOver");
			}
		}
		catch{}
	}

	void changeStats()
	{
		this.health = this.health - foodDecay;
		this.happiness = this.happiness - happyDecay;
	}

	/* For debugging */
	/*
	void OnGUI()
	{
		GUI.Label (new Rect (10, 10, 100, 30), "Health: " + health);
		GUI.Label (new Rect (10, 40, 100, 30), "Happiness: " + happiness);
	}
	*/

	IEnumerator waitForHealth()
	{
		GameObject critter = GameObject.FindGameObjectWithTag("Player");
		critter.GetComponent<SpriteRenderer> ().sprite = spritesArray [Random.Range (0, spritesArray.Length - 1)];
		yield return new WaitForSeconds(3);
		canFeed = true;
	}
	
	IEnumerator waitForHappy()
	{
		GameObject critter = GameObject.FindGameObjectWithTag("Player");
		critter.GetComponent<SpriteRenderer>().sprite = spritesArray[Random.Range(0,spritesArray.Length-1)];
		yield return new WaitForSeconds(3);
		canHappy = true;
	}

	public void addHealth ()
	{
		if(canFeed == true)
		{
			audio.PlayOneShot(feedSounds[Random.Range(0,feedSounds.Length-1)]);
			
			if(health + foodAmmount >= 1)
			{
				health = 1;
			}
			else
			{
				health = health + foodAmmount;
			}
			
			canFeed = false;
			StartCoroutine(waitForHealth());
		}
	}

	public void addHappiness ()
	{
		if(canHappy == true)
		{
			audio.PlayOneShot(happySounds[Random.Range(0,feedSounds.Length-1)]);

			if(happiness + playAmmount >= 1)
			{
				happiness = 1;
			}
			else
			{
				happiness = happiness + playAmmount;
			}

			canHappy = false;
			StartCoroutine(waitForHappy());
		}
	}
}
