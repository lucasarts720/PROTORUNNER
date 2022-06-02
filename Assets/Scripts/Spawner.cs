using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Obstacles;
    public Transform spawnpoint;
    public int minWait;
    public int maxWait;
    int objToSpawn;


    private void Start()
    {
        StartCoroutine(spawntimer());
        spawnpoint = GetComponent<Transform>();
    }

    IEnumerator spawntimer()
    {
        yield return new WaitForSeconds(Random.Range(minWait,maxWait));
        objToSpawn = Random.Range(0, Obstacles.Length);
        Instantiate(Obstacles[objToSpawn], spawnpoint);
        StartCoroutine(spawntimer());
    }
}
