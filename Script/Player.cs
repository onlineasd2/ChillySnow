using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float score;
    public float movementSpeed;
    private float rotationSpeed;
    private bool movingLeft;

    private float rotationAngle = .17f;

    public bool isDead = false;
    private float t = 0;
    
    public bool startGame = false;

    void Start ()
    {
        movingLeft = true; 
    }

    void Update ()
    {
        if  (startGame)
        {
            score += Time.deltaTime;
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
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Obstacle")
            Die();
    }
    void Die ()
    {
        print("Player dead");
        isDead = true;
        gameObject.SetActive(false);
    }

}
