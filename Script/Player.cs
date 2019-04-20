using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class Player : MonoBehaviour {

    public float score;
    public float movementSpeed;
    private float rotationSpeed;
    private bool movingLeft;

    public Transform shadow;
    public new Camera camera;

    private float rotationAngle = .17f;

    public bool isDead = false;
    private float t = 0;
    
    public bool startGame = false;
    public int point = 0;
    void Start ()
    {

        movingLeft = false;

        ColorTypeConverter colCon = new ColorTypeConverter();

		string color = PlayerPrefs.GetString("savecolor");  
        if(color != "")
            GetComponent<SpriteRenderer>().color = colCon.GetColorFromString(color);
        else
            GetComponent<SpriteRenderer>().color = colCon.GetColorFromString("2AFCFF");

		GetComponent<TrailRenderer>().startColor = new Color(
			GetComponent<SpriteRenderer>().color.r, 
			GetComponent<SpriteRenderer>().color.g, 
			GetComponent<SpriteRenderer>().color.b, 
			255);
			
		GetComponent<TrailRenderer>().endColor = new Color(
			GetComponent<SpriteRenderer>().color.r, 
			GetComponent<SpriteRenderer>().color.g, 
			GetComponent<SpriteRenderer>().color.b, 
			0);
    }

    void Update ()
    {
        if  (startGame)
        {
            score += Time.deltaTime + .05f;
            transform.Translate(Vector3.down * Time.deltaTime * movementSpeed);
            
            if (Input.GetMouseButtonDown(0))
            {
                rotationSpeed = 1.5f;
                movingLeft = !movingLeft;
                rotationAngle = .20f;
            }

            // Changing rotation angle
            if (Input.GetMouseButton(0))
            {
                t += Time.deltaTime;

                if(t > 0.5f) {
                    rotationSpeed += 5f * Time.deltaTime;
                    rotationAngle = .35f;
                }
            } else {
                rotationAngle = .20f;
            }

            if (movingLeft) 
            {
                if (transform.rotation.z > -rotationAngle)
                    transform.Rotate(0, 0, -rotationSpeed);
            }
            else
            {
                if (transform.rotation.z < rotationAngle)
                    transform.Rotate(0, 0, rotationSpeed);
            }
        }

        DeadZone();
    }

    void DeadZone ()
    {
        Vector3 stageDimensions = camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,0));
        if(transform.position.x > stageDimensions.x)
            Die();
        else if (transform.position.x < -stageDimensions.x)
            Die();
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        print("Hello");
        if (other.tag == "Obstacle")
            Die();
    }

    void Die ()
    {
        print("Player dead");
        isDead = true;
        gameObject.SetActive(false);
        shadow.gameObject.SetActive(false);

        // Save record
        PlayerPrefs.SetInt("savescore", Mathf.RoundToInt(score));
        PlayerPrefs.Save();
        Debug.Log("Record Save " + Mathf.RoundToInt(score));
    }
}
