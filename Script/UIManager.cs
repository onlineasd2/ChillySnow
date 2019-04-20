using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

	public GameObject player;
	public GameObject GameOverContain;
	public GameObject MenuContent;
	public GameObject ground;

	[Space]
	public GameObject GroundSkinsContent;
	public GameObject PlayerSkinsContent;
	[Space]

	public Image ReloadUIImage;
    public Text score;
    public Text bestScore;
	public Button btnMenu;
	public Button btnStartGame;
	public bool secondeChance = false;
	public bool openMenu = false;
	float t = 1;
	float tSecond = 0;
	public int record;


    void Start ()
    {
		record = PlayerPrefs.GetInt("savescore");
		bestScore.text = "Best: " + record.ToString();

		
		string s = PlayerPrefs.GetString("savecolorground");

    }

	void Update ()
	{
		ShowReloadUI();
		ScoreUpdate();
        
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

    void ScoreUpdate()
    {
        score.text = Mathf.FloorToInt(player.GetComponent<Player>().score).ToString();
    }

    void ShowReloadUI()
    {
		if (!secondeChance) {
			if (!player.activeSelf) {
				GameOverContain.SetActive(true);
				ReloadUIImage.GetComponent<Image>().color = player.GetComponent<SpriteRenderer>().color;
				SecondChanceTimer();
			}
		}
    }

	public void SecondChanceDelay() 
	{
		tSecond += Time.deltaTime;
		if(tSecond >= .5f)
			player.GetComponent<Collider2D>().enabled = true;
	}

		// Enabled btn
	public void GetMaterialGround(CustomColor c)
	{
		ground.GetComponent<SpriteRenderer>().color = new Color32(
			c.GetComponent<CustomColor>().color.r, 
			c.GetComponent<CustomColor>().color.g, 
			c.GetComponent<CustomColor>().color.b, 
			255);

		ColorTypeConverter col = new ColorTypeConverter();
		string colorSaved = col.ToRGBHex(ground.GetComponent<SpriteRenderer>().color);
		Debug.Log(colorSaved);
        // Save record
        PlayerPrefs.SetString("savecolorground", colorSaved);
        PlayerPrefs.Save();
	}

	// Enabled btn
	public void GetMaterial(CustomColor c)
	{
		player.GetComponent<SpriteRenderer>().color = new Color32(
			c.GetComponent<CustomColor>().color.r, 
			c.GetComponent<CustomColor>().color.g, 
			c.GetComponent<CustomColor>().color.b, 
			255);

		player.GetComponent<TrailRenderer>().startColor = new Color32(
			c.GetComponent<CustomColor>().color.r, 
			c.GetComponent<CustomColor>().color.g, 
			c.GetComponent<CustomColor>().color.b, 
			255);

		player.GetComponent<TrailRenderer>().endColor = new Color32(
			c.GetComponent<CustomColor>().color.r, 
			c.GetComponent<CustomColor>().color.g, 
			c.GetComponent<CustomColor>().color.b, 
			0);

		ColorTypeConverter col = new ColorTypeConverter();
		string colorSaved = col.ToRGBHex(c.GetComponent<CustomColor>().color);
		Debug.Log(colorSaved);
        // Save record
        PlayerPrefs.SetString("savecolor", colorSaved);
        PlayerPrefs.Save();
	}

	// Enabled btn
	public void ShowSkins()
	{
		GroundSkinsContent.SetActive(false);
		PlayerSkinsContent.SetActive(true);	
	}
	// Enabled btn	
	public void ShowGround()
	{
		GroundSkinsContent.SetActive(true);
		PlayerSkinsContent.SetActive(false);	
	}

	// Enabled btn
	public void MenuOpen ()
	{
		openMenu = !openMenu;
		MenuContent.SetActive(openMenu);
	}
	
	// Enabled btn
	public void StartGame()
	{
		player.GetComponent<Player>().startGame = true;
		Destroy(btnStartGame.gameObject);
		btnMenu.gameObject.SetActive(false);
	}

	// Enabled btn
	public void SecondeChance()
	{
		if(!secondeChance)
		{
			ShowAds();

			secondeChance = true;
			player.SetActive(true);
			player.GetComponent<Collider2D>().enabled = false;
			player.GetComponent<Player>().shadow.gameObject.SetActive(true);
			GameOverContain.SetActive(false);
		}
		
	}
	// Enabled btn
	public void ReloadScene() {
		SceneManager.LoadScene(0);
	}
}
