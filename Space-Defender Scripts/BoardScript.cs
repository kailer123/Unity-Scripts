using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardScript : MonoBehaviour
{
    float speed = 10f;
    float timeToLive = 5f;

    GameObject player;
    health hp;

    private void Awake()
    {
        player = GameObject.FindWithTag("XDD");
        hp = player.GetComponent<health>();
    }
    private void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;

        if (timeToLive <= 0)
        {
            Destroy(this.gameObject);
        }

        if (transform.position.y < -100 || transform.position.y > 100 || transform.position.x < -100 || transform.position.x > 100)
        {
            Destroy(this.gameObject);
        }
    }
}
