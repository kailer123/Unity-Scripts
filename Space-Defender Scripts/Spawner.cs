using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    // Start is called before the first frame update

    void Start()
    {
        StartCoroutine(spawnEnemy(enemy));
    }

    // Update is called once per frame
    private IEnumerator spawnEnemy(GameObject enemy)
    {
        yield return new WaitForSeconds(Random.Range(3f, 20f));
        GameObject newEnemy = Instantiate(enemy,new Vector2(transform.position.x,transform.position.y),Quaternion.identity);
        StartCoroutine(spawnEnemy(enemy));
    }
}
