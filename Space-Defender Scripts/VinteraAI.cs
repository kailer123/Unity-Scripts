using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VinteraAI : MonoBehaviour
{
    public GameObject HealthBarRed;
    Image image;

    GameObject target;
    public GameObject minigun;
    public GameObject raketomet;
    [SerializeField]public GameObject esp32;

    Rigidbody2D rb;
    [SerializeField]public GameObject rocket;
    float speed = 2.5f;
    public float rocketTime = 6f;
    public float distance;
    bool canRotate = true;
    public bool canMove = true;
    public int vinteraHp = 100;
    public Animator animator;
    public bool isDead = false;
    public bool canShoot = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("XDD");
        image = HealthBarRed.GetComponent<Image>();
    }

    private void FixedUpdate()
    {
        rocketTime -= Time.deltaTime;
    }
    // Update is called once per frame
    void Update()
    {
        if(isDead ==  false) { 
            distance = Vector2.Distance(transform.position, target.transform.position);
            Vector2 dir = target.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;

            if(canRotate == true)
            {
                if (transform.position.x > target.transform.position.x)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                    rb.rotation = -angle;
                }
                else if (transform.position.x < target.transform.position.x)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                    rb.rotation = -angle;
                }
            }
        
            if (distance >= 7.5f && canMove == true)
            {
                Pursue(angle, dir, distance);
            }
            if (rocketTime <= 0)
            {
                StartCoroutine(FireRocket(rocket, angle));

            } else if (rocketTime > 0 && canShoot)
            {
                StartCoroutine(MachineGun(angle));
            }
        }
    }
    private void Pursue(float angle, Vector2 dir, float distance)
    {  
        transform.position = Vector2.MoveTowards(this.transform.position, target.transform.position, speed * Time.deltaTime);
    }
    IEnumerator FireRocket(GameObject rocket, float angle)
    {
        canMove = false;
        canShoot = false;
        rocketTime = Random.Range(7, 15);
        yield return new WaitForSeconds(2f);
        Instantiate(rocket, raketomet.transform.position, Quaternion.Euler(0, 0, -angle));
        yield return new WaitForSeconds(1f);
        canMove = true;
        
    }

    IEnumerator MachineGun(float angle)
    {    
        canShoot = false;
        Instantiate(esp32, minigun.transform.position, Quaternion.Euler(0, 0, -angle + Random.Range(-20,20)));
        yield return new WaitForSeconds(0.4f);
        canShoot = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            image.fillAmount -= 0.05f;
            vinteraHp -= 5;
            if (vinteraHp <= 0)
            {
                StartCoroutine(VinteraUmrel());
            }
        }
    }

    IEnumerator VinteraUmrel()
    {
        isDead = true;
        animator.SetBool("isDead", isDead);
        yield return new WaitForSeconds(0.2f);
        transform.localScale = new Vector3(10, 10, 0);
        yield return new WaitForSeconds(1.8f);
        SceneManager.LoadScene(1);
        Destroy(this.gameObject);
  
    }
}
