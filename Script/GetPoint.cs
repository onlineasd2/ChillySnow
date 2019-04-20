using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetPoint : MonoBehaviour {

	public int point = 1;
	public Transform player;
	public Animation getPointAnim;
	public AnimationClip getPointClip;
	public GameObject pointText;
	public GameObject containNumber;

	void Start () 
	{
		if (getPointAnim)
			getPointAnim = GetComponentInParent<Animation>();

		if (!player)
            player = GameObject.FindWithTag("Player").transform;
		
		pointText.SetActive(false);
	}

	void OnTriggerEnter2D () 
	{
		getPointAnim.Play(getPointClip.name);
		if (!pointText.GetComponent<Animation>().isPlaying)
		{
			pointText.SetActive(true);
			pointText.GetComponent<TextMesh>().color = player.GetComponent<SpriteRenderer>().color;
			pointText.GetComponent<TextMesh>().text = "+" + player.GetComponent<Player>().point;
			pointText.GetComponent<Animation>().Play();
			player.GetComponent<Player>().score += point + player.GetComponent<Player>().point;
			player.GetComponent<Player>().point++;
		}
	}
}
