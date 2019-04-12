using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObstacle : MonoBehaviour {

	public GameObject player;

	void Start () {
		if(!player)
			player = GameObject.FindWithTag("Player");
	}
	void Update () {
		if(player)
			if(transform.position.y - 50 > player.transform.position.y)
				Destroy(gameObject);
	}
}
