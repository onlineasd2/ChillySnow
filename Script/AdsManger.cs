﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManger : MonoBehaviour {
    
    public int countofdeaths;
    private string store_id = "3113414";

    private string video_ad = "video";
    void Start ()
    {
        Advertisement.Initialize(store_id);
        countofdeaths = PlayerPrefs.GetInt("saveCountOfDeaths");
    }
	
	void Update () {

        ViewAds();
    }

    // View Ads
    void ViewAds ()
    {
        if (countofdeaths >= 5)
        {
            
            if (Advertisement.IsReady(video_ad))
            {
                if (Advertisement.isSupported)
                {
                    Advertisement.Show();
                }
            }

            countofdeaths = 0;
            PlayerPrefs.SetInt("saveCountOfDeaths", 0);
            PlayerPrefs.Save();
        }
    }
}