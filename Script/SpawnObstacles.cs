using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour {

    public GameObject player;
    public new Camera camera;
    public GameObject[] obstacles;
    public float amountOfOnstacles;
    public float minX, maxX;
    private float marginFirst;
    
    public float camPos;

	void Start () {
        if (!player)
            player = GameObject.FindWithTag("Player");
        
        marginFirst = 50f;

        camPos = camera.orthographicSize / 2;

        for (int i = 0; i < amountOfOnstacles; i++)
        {
            float xAXIS, yAXIS;
            xAXIS = Random.Range(-camPos, camPos);
            yAXIS = Random.Range(player.transform.position.y - marginFirst, transform.localPosition.y - 120f);

            Vector3 pos = new Vector3(xAXIS, yAXIS, 0);
            int k = Random.Range(0, obstacles.Length);
            Transform obs = Instantiate(obstacles[k].transform, pos, Quaternion.identity);
            
            obs.GetComponentInChildren<SpriteRenderer>().sortingOrder = -i;
            obs.GetChild(3).GetComponent<SpriteRenderer>().sortingOrder -= i + Mathf.FloorToInt(amountOfOnstacles);
        }
	}

    void Update () {
        camPos = camera.orthographicSize / 2;
    }
    
}
