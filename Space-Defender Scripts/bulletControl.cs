using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class bulletControl : MonoBehaviour
{
    // Start is called before the first frame update
    float speed = 10f;
    public GameObject control;
    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0,1) * Time.deltaTime * speed);

        if (transform.position.x > 24 || transform.position.x < -24 || transform.position.y > 11.5f || transform.position.y < -11.5f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collisio)
    {
        if (collisio.gameObject.tag == "Enemy")
        {
            Destroy(collisio.gameObject);
            Destroy(this.gameObject);
            
        }
        if (collisio.gameObject.tag == "Vintera")
        {
            Destroy(this.gameObject);

        }

    }
}

