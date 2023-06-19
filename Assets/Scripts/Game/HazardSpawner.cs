using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardSpawner : MonoBehaviour
{
    [SerializeField]
    private float spawnRate;

    [SerializeField]
    private GameObject hazardPrefab;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            GameObject obj = Instantiate(hazardPrefab);
            obj.transform.position = new Vector3(transform.position.x, Random.Range(-5, 5), 0);
            obj.transform.parent = transform.parent;
            yield return new WaitForSeconds(spawnRate);
        }
    }
}