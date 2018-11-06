using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float generatorTimer = 1.75f;


    void Start ()
    {
        Generator();

    }
	
	void Update () {
		
	}

    void CreateEnemy()
    {
      Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }

    public void Generator()
    {
        InvokeRepeating("CreateEnemy", 0f, generatorTimer);
    }
    public void CancelGen()
    {
        CancelInvoke("CreateEnemy");
    }
}
