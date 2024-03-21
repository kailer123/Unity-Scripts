using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class enemeProjectiles : MonoBehaviour
{


    // Start is called before the first frame update
    GameObject player;
    float speed = 10f;
    health hp;
    void Start()
    {
        player = GameObject.FindWithTag("XDD");
        hp = player.GetComponent<health>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0, -1) * Time.deltaTime * speed);

        if(transform.position.y < -100 || transform.position.y > 100 || transform.position.x < -100 || transform.position.x > 100)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collisio)
    {
        if (collisio.gameObject.tag == "XDD")
        {
            hp._health -= 10;
            Destroy(this.gameObject);
        }

    }
    
}