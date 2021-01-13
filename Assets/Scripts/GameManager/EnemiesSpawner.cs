using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    public int maxEnemies;
    public float timeBetweenSpawns;
    public float minDistance;

    public GameObject player;
    public GameObject smallZombie;
    public GameObject appearanceEffect;
    private GameObject appearanceEffectAux;
    public GameObject bigZombie;

    public int numEnemies = 1;
    private float count;

    private void Update()
    {
        count += Time.deltaTime;
        if (count >= timeBetweenSpawns) {
            SpawnSmallZombie();
            count = 0;
        }
    }

    public void SpawnSmallZombie() {
        if (numEnemies < maxEnemies) {
            float x = Random.Range(-8, 8);
            float y = Random.Range(-4, 3);

            Vector3 pos = player.transform.position;
            if (pos.x - x < minDistance && pos.y - y < minDistance) {
                SpawnSmallZombie();
            } else {
                Instantiate(smallZombie, new Vector3(x, y), new Quaternion());
                numEnemies++;
            }            
        }
    }

    public void SpawnBigZombie() {
        appearanceEffectAux = Instantiate(appearanceEffect, new Vector3(0, 0), new Quaternion());
        Invoke("SpawnBigZombieAux", 1);
    }

    private void SpawnBigZombieAux() {
        Instantiate(bigZombie, new Vector3(0, 0), new Quaternion());
        Destroy(appearanceEffectAux);
    }
}
