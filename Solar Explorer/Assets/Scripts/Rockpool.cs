using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rockpool : MonoBehaviour
{

    public int rockpoolsize = 8;
    public GameObject rockprefab;
    public float spawnraterandom = 0.8f;
    public float spawnupypositon = 1.4f;
    public float spawndownyposition = -1.4f;

    private GameObject[] rocks;
    private float spawnrate = 4f;
    private Vector2 objectpoolposition = new Vector2(-15f, -25f);
    private float timesincelastspawned;
    private float spawnxposition = 8f;
    private int currentrock = 0;
    private float oldupordown = 0;
    // Use this for initialization
    void Start()
    {
        spawnrate += Random.Range(-spawnraterandom, 0);
        rocks = new GameObject[rockpoolsize];
        for (int a = 0; a < rockpoolsize; a++)
        {
            rocks[a] = (GameObject)Instantiate(rockprefab, objectpoolposition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timesincelastspawned += Time.deltaTime;
        if (timesincelastspawned >= spawnrate)
        {
            timesincelastspawned = 0;
            float upordown = Random.Range(-1f, 1f);
            if (upordown >= 0 && oldupordown >= 0 || upordown < 0 && oldupordown < 0)
            {
                upordown = Random.Range(-1f, 1f);
            }
            oldupordown = upordown;
            if (upordown >= 0)
            {
                rocks[currentrock].transform.position = new Vector2(spawnxposition, spawnupypositon);
            }
            else
            {
                rocks[currentrock].transform.position = new Vector2(spawnxposition, spawndownyposition);
            }
            currentrock++;
            if (currentrock >= rockpoolsize)
            {
                currentrock = 0;
            }
            spawnrate = 4.0f;
            spawnrate += Random.Range(-spawnraterandom, 0);
        }
    }
}
