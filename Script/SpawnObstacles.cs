using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour {

    public GameObject player;
    public GameObject[] obstacles;
    public float amountOfOnstacles;
    public float minX, maxX;
    private float marginFirst;
    
	void Start () {
        if (!player)
            player = GameObject.FindWithTag("Player");
        
            marginFirst = 50f;

        for (int i = 0; i < amountOfOnstacles; i++)
        {
            float xAXIS, yAXIS;
            xAXIS = Random.Range(minX, maxX);
            yAXIS = Random.Range(player.transform.position.y - marginFirst, transform.localPosition.y - 120f);

            Vector3 pos = new Vector3(xAXIS, yAXIS, 0);
            int k = Random.Range(0, obstacles.Length);
            Transform obs = Instantiate(obstacles[k].transform, pos, Quaternion.identity);
            
            obs.GetComponentInChildren<SpriteRenderer>().sortingOrder = -i;
        }
	}
    
}
