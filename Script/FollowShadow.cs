using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowShadow : MonoBehaviour {

	public Transform player;

	void Update () {
		transform.position = new Vector2(player.position.x + .35f, player.position.y - .35f);
	}
}
