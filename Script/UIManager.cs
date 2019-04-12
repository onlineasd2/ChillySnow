using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

	public GameObject player;

	public GameObject GameOverContain;
	public Image ReloadUIImage;

	public Button btnStartGame;
	public bool secondeChance = false;
	float t = 1;
	float tSecond = 0;

	void Update ()
	{
		ShowReloadUI();
		
		if (secondeChance)
			SecondChanceDelay();

		if (!player.activeSelf && secondeChance)
			ReloadScene();
	}

	public void ShowAds() 
	{
		print("Show Ads");
	}

	void SecondChanceTimer()
	{
		t -= 0.3f * Time.deltaTime;

		ReloadUIImage.GetComponent<Image>().fillAmount = t;

		if(ReloadUIImage.GetComponent<Image>().fillAmount <= 0)
			ReloadScene();
	}

    void ShowReloadUI()
    {
		if (!secondeChance) {
			if (!player.activeSelf) {
				GameOverContain.SetActive(true);
				SecondChanceTimer();
			}
		}
    }

	public void SecondChanceDelay() 
	{
		tSecond += Time.deltaTime;
		if(tSecond >= .5f)
			player.GetComponent<Collider>().enabled = true;
	}
	
	// Enabled btn
	public void StartGame()
	{
		player.GetComponent<Player>().startGame = true;
		Destroy(btnStartGame.gameObject);
	}

	// Enabled btn
	public void SecondeChance() {
		if(!secondeChance) {
			ShowAds();

			secondeChance = true;
			player.SetActive(true);
			player.GetComponent<Collider>().enabled = false;
			GameOverContain.SetActive(false);
		}

	}
	// Enabled btn
	public void ReloadScene() {
		SceneManager.LoadScene(0);
	}
}
