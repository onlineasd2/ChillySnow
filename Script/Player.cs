using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class Player : MonoBehaviour {

    public float score;
    public float movementSpeed;
    private float rotationSpeed;
    public bool movingLeft;
    public AudioClip clipIsDead;
    public ParticleSystem particle;
    public GameObject particleDead;

    public Transform shadow;
    public new Camera camera;

    private float rotationAngle = .17f;

    public EventTriggerEx eventTriggerEx;
    public bool isDead = false;
    private float t = 0;
    public bool startGame = false;
    public int point = 0;
    void Start ()
    {
        particle.Stop();
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
            if(Time.timeScale != 0.0f)
            {
                score += Time.deltaTime + .05f;
                transform.Translate(Vector3.down * Time.deltaTime * movementSpeed);
            }


            // Mouse
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

                if(t > .5f) {
                    rotationSpeed += 5f * Time.deltaTime;
                    rotationAngle = .35f;
                }
            } else {
                rotationAngle = .20f;
            }

            // Touch screen
            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began) {
                    rotationSpeed = 1.5f;
                    movingLeft = !movingLeft;
                    rotationAngle = .20f;
                }
            }
            
            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Stationary) {
                    t += Time.deltaTime;

                    if(t > .5f) {
                        rotationSpeed += 5f * Time.deltaTime;
                        rotationAngle = .35f;
                    }
                }
            } else {
                rotationAngle = .20f;
            }

            if (movingLeft) 
            {
                if (transform.rotation.z > -rotationAngle)
                {
                    transform.Rotate(0, 0, -rotationSpeed);
			        particle.Play();
                } else {
                    particle.Stop();
                }
                particle.transform.rotation = Quaternion.Euler(-10, 90f, 0);
            }
            else
            {
                if (transform.rotation.z < rotationAngle)
                {
                    transform.Rotate(0, 0, rotationSpeed);
			        particle.Play();
                } else {
                    particle.Stop();
                }
                particle.transform.rotation = Quaternion.Euler(-160, 90f, 0);
            }

            
        }

        ParticleSystem();
        DeadZone();
    }

    void ParticleSystem () {
		if(eventTriggerEx.pressing) {
		} else {
			particle.Stop();
		}
    }

    void DeadZone ()
    {
        Vector3 stageDimensions = camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,0));
        if(transform.position.x > stageDimensions.x) {
            Die();
            movingLeft = true;
        }
        else if (transform.position.x < -stageDimensions.x){
            Die();
            movingLeft = false;
        }
            
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Obstacle")
            Die();
    }

    void Die ()
    {
        GameObject copyParticle = Instantiate(particleDead, transform.position, Quaternion.identity);
        
		int mute = PlayerPrefs.GetInt("savemute");

		if (mute == 0)
		{
            copyParticle.AddComponent<AudioSource>();
            copyParticle.GetComponent<AudioSource>().playOnAwake = false;
            copyParticle.GetComponent<AudioSource>().clip = clipIsDead;
            copyParticle.GetComponent<AudioSource>().Play();
		}

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
