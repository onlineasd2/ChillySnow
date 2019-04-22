using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour {

	public AudioClip clip;
	public int mute = 0;

	void Start ()
	{
		mute = PlayerPrefs.GetInt("savemute");
	}

	public void PlaySound() {
		mute++;
		if (mute >= 0)
		{
			GetComponent<AudioSource>().clip = clip;
			GetComponent<AudioSource>().Play();
		}
		if (mute > 1)
			mute = 0;
	}
}
