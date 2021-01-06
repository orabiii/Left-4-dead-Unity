using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject zombiePrefab;
    void Start()
    {
        /*spawnZombie();
        spawnZombie();
        spawnZombie();*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void spawnZombie()
    {
        int spawnPointX = Random.Range(-2, 2);
        int spawnPointz = Random.Range(-2, 2);
        Vector3 spawnPosition = new Vector3(spawnPointX, 0, spawnPointz);
        Instantiate(zombiePrefab, spawnPosition, Quaternion.identity);
    }
}
