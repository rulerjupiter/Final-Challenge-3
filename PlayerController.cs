using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float tilt;
    public Boundary boundary;
    public AudioSource musicSource;

    public AudioClip musicClipOne;

    private Rigidbody rb;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
   
    public int score;

    private float nextFire;
    public Vector3 endPosition;
   
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.position = endPosition;
     
       
  
        
    }

  
    void Update()
    {

        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);

        }
        if (Input.GetButton("Fire1") && Time.time > nextFire)

        {
            nextFire = Time.time + fireRate;
            musicSource.clip = musicClipOne;
            musicSource.Play();
        }

        if (Input.GetButtonUp("Fire1"))
        {
            this.GetComponent<Renderer>().material.color = Color.HSVToRGB(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            musicSource.Stop();
        }
        

    }



        void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;

        rb.position = new Vector3
        (
             Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
             0.0f,
             Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);


     
    }

 

    }




