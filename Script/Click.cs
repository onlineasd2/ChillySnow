using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour {

	public AudioClip clip;
	public int mute;

	void Start ()
	{
		mute = PlayerPrefs.GetInt("savemute");
	}

	void Update() {
		
	}

	public void PlaySound() {

		mute = PlayerPrefs.GetInt("savemute");

		Debug.Log(mute);
		if (mute == 0)
		{
			GetComponent<AudioSource>().clip = clip;
			GetComponent<AudioSource>().Play();
		}
	}
}
