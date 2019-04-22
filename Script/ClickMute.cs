using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickMute : MonoBehaviour {

	public Sprite muteS;
	public Sprite voiceS;
	public int mute;
	void Start () {
		mute = PlayerPrefs.GetInt("savemute");

		if (mute >= 0)
		{
			GetComponent<Image>().sprite = voiceS;
		} else if (mute == 1) {
			GetComponent<Image>().sprite = muteS;
		}
		if (mute > 1)
			mute = 0;
	}

	public void Update() {
		if (mute == 0)
		{
			GetComponent<Image>().sprite = voiceS;
		} else if (mute == 1) {
			GetComponent<Image>().sprite = muteS;
		}
		if (mute > 1)
			mute = 0;
	}

	public void SwitchIcon () {
		
		if(mute < 1)
			mute++;	
		else
			mute = 0;

		PlayerPrefs.SetInt("savemute", mute);
	}
}
