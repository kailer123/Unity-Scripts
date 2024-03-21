using UnityEngine;
using System.Collections;
using System.IO.Ports;
using TMPro;
using UnityEditor;
using System;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.SceneManagement;

public class Comunicacion : MonoBehaviour
{
    //SerialPort stream = new SerialPort("COM4", 115200);
    
    public float fps;
    private float speed;
    public GameObject objectToSpawn;
    public GameObject target;
    magazine mag;
    public Rigidbody2D rb;
    public bool canShoot = true;
    public Sprite normalSprite;
    public Animator animator;
    health hp;
    void Awake()
    {
        mag = GetComponent<magazine>();
        rb = GetComponent<Rigidbody2D>();
        hp = GetComponent<health>();
    }
    void Start()
    {
        speed = 40f;
    }

    void Update()
    {

        if (hp._health <= 0)
        {
            lostGame();
        }

        fps = 1 / (Time.deltaTime);

        Quaternion rotation = transform.rotation;
        Vector2 forward = rotation * Vector2.up;
        Vector2 dir = target.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        rb.rotation = -angle;
        float velocity = Vector3.Magnitude(rb.velocity);
        animator.SetFloat("Speed", velocity);

        if (transform.position.x > 24)
        {
            transform.position = (new Vector2(-23,transform.position.y));
        }else if (transform.position.x < -24)
        {
            transform.position = (new Vector2(23, transform.position.y));
        }
        else if (transform.position.y > 11.5f)
        {
            transform.position = (new Vector2(transform.position.x, -11f));
        }
        else if (transform.position.y < -11.5f)
        {
            transform.position = (new Vector2(transform.position.x, 11f));
        }

        if (Input.GetKey(KeyCode.Space)) //Check if all values are recieved
        {
            rb.velocity += forward * speed * Time.deltaTime;
            
        }
        if (Input.GetKey(KeyCode.LeftControl)) //Check if all values are recieved
        {
            rb.drag = 15;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && canShoot == true)
        {
            mag.leftInMag--;
            Instantiate(objectToSpawn, new Vector2(transform.position.x, transform.position.y), new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w));
        }
        if (Input.GetKey(KeyCode.LeftControl) == false)
        {
            rb.drag = 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "rasberry")
        {
            hp._health -= 5;
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "ESP32")
        {
            hp._health -= 5;
            Destroy(collision.gameObject);
        }
    }

    void lostGame()
    {
        SceneManager.LoadSceneAsync(0);
    }
}