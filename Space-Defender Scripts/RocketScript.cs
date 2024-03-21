using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour
{
    GameObject player;
    float speed = 10f;
    health hp;
    float timeToLive = 1.5f;
    [SerializeField] public GameObject raspberryPi;
    public float radius = 5f;
    public int numberOfObjects = 8;
    private void Awake()
    {
        player = GameObject.FindWithTag("XDD");
        hp = player.GetComponent<health>();
    }
    private void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;

        float angleIncrement = 360f / numberOfObjects;

        
        if (timeToLive <= 0)
        {
            for (int i = 0; i < numberOfObjects; i++)
            {
                float angle = i * angleIncrement;
                Quaternion rotation = Quaternion.Euler(0f, 0f, -angle);

                Instantiate(raspberryPi, transform.position, rotation);
                Destroy(this.gameObject);
            }
            
            /*Instantiate(raspberryPi, transform.position + new Vector3(0, 1, 0), new Quaternion(0, 0, 0, 0));
            Instantiate(raspberryPi, transform.position + new Vector3(-1, 1, 0), new Quaternion(0, 0, 0, 45));
            Instantiate(raspberryPi, transform.position + new Vector3(-1, 0, 0), new Quaternion(0, 0, 0, 90));
            Instantiate(raspberryPi, transform.position + new Vector3(-1, -1, 0), new Quaternion(0, 0, 0, 135));
            Instantiate(raspberryPi, transform.position + new Vector3(0, -1, 0), new Quaternion(0, 0, 0, 180));
            Instantiate(raspberryPi, transform.position + new Vector3(1, -1, 0), new Quaternion(0, 0, 0, 225));
            Instantiate(raspberryPi, transform.position + new Vector3(1, 0, 0), new Quaternion(0, 0, 0, 270));
            Instantiate(raspberryPi, transform.position + new Vector3(1, 1, 0), new Quaternion(0, 0, 0, 315));
            Destroy(this.gameObject);*/
        }
    }

    private void FixedUpdate()
    {
        timeToLive -= Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "XDD")
        {
            hp._health -= 50;
            Destroy(this.gameObject);
        }
    }
}
