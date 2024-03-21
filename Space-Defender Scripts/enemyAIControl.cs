using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class enemyAIControl : MonoBehaviour
{
    GameObject target;
    public GameObject bullet;
    Rigidbody2D rb;
    float speed = 5f;
    float time; 
    public float distance;
    GameManager gManager;
    GameObject manager;
    public GameObject healthPack;
    public GameObject ammoPack;
    int randPack;
    // Start is called before the first frame update
    private void Awake()
    {
        manager = GameObject.FindWithTag("Respawn");
        gManager = manager.GetComponent<GameManager>();
    }
    void Start()
    {   
        rb = this.GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("XDD");
        time = 1;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);
        Vector2 dir = target.transform.position - transform.position;   
        float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        rb.rotation = -angle;
        time -= Time.deltaTime;
        
        if(distance >= 7.5)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, target.transform.position, speed * Time.deltaTime);
        }
        if(distance <= 17)
        {
            if (time <= 0)
            {
                Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, -angle + Random.Range(167f, 192f)));
                time = 1;
            }
        }  

    }

    void spawnPack()
    {
        randPack = Random.Range(1, 4);
        if(randPack == 3)
        {
            randPack = Random.Range(1, 3);
            if(randPack == 1)
            {
                Instantiate(healthPack, new Vector2(transform.position.x, transform.position.y), new Quaternion(0, 0, 0, 0));
            }
            else if(randPack == 2)
            {
                Instantiate(ammoPack, new Vector2(transform.position.x, transform.position.y), new Quaternion(0, 0, 0, 0));
            }
        }
    }

    public void OnDestroy()
    {
        spawnPack();
        gManager.score += 1000;
    }
}


