using UnityEngine;

public class Comunicacion : MonoBehaviour
{
    
    public bool canShoot = true;
    private float speed;
    public GameObject objectToSpawn;
    public GameObject target;
    public Rigidbody2D rb;
    public Sprite normalSprite;
    public Animator animator;
    public GameManager manager;
    const int n = 0;
    magazine mag;
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

        Quaternion rotation = transform.rotation;
        Vector2 forward = rotation * Vector2.up;
        Vector2 dir = target.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        float velocity = Vector3.Magnitude(rb.velocity);
        rb.rotation = -angle;
        animator.SetFloat("Speed", velocity);
        animator.SetFloat("Health", hp._health);

        if (hp._health <= 0)
        {
            loadOver();
        }

        switch(n)
        {
            case n when transform.position.x > 24:
                transform.position = (new Vector2(-23, transform.position.y));
                break;
            case n when transform.position.x < -24:
                transform.position = (new Vector2(23, transform.position.y));
                break;
            case n when transform.position.y > 11.5f:
                transform.position = (new Vector2(transform.position.x, -11f));
                break;
            case n when transform.position.y < -11.5f:
                transform.position = (new Vector2(transform.position.x, 11f));
                break;
        }

        //Cant be in switch because you couldnt shoot and thrust at the same time
        if (Input.GetKey(KeyCode.Space)) 
        {
            rb.velocity += forward * speed * Time.deltaTime;
            animator.SetBool("Thrust", true);
        }
        else
        {
            animator.SetBool("Thrust", false);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && canShoot == true)
        {
            mag.leftInMag--;
            //Shorter variations dont work
            Instantiate(objectToSpawn, new Vector2(transform.position.x, transform.position.y), new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w));
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
    
    public void loadOver()
    {
        StartCoroutine(manager.loadgameOver());
    }
}