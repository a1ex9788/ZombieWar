using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesCounter : MonoBehaviour
{
    public static Text counter;

    private static EnemiesSpawner enemiesSpawner;

    private void Start()
    {
        counter = GameObject.Find("Counter").GetComponent<Text>();
        enemiesSpawner = FindObjectOfType<EnemiesSpawner>();
    }

    public static void SumOne() {
        int aux = int.Parse(counter.text) + 1;
        counter.text = aux + "";
        if (aux % 5 == 0) {
            enemiesSpawner.SpawnBigZombie();
        }
    }
}
