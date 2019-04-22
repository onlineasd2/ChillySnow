using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleColor : MonoBehaviour {

	void Start () {
        ColorTypeConverter colCon = new ColorTypeConverter();
		string color = PlayerPrefs.GetString("savecolor");  
        
		ColorTypeConverter col = new ColorTypeConverter();
        ParticleSystem ps = GetComponent<ParticleSystem>();

        var main = ps.main;
        main.startColor = col.GetColorFromString(color);
	}
}
