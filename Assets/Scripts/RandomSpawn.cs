using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject[] spawnPoints;
    private bool spawn = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (spawn)
        {
            SpawnObject();
        }
    }



    private void SpawnObject()
    {
        spawn = false;
        int random = Random.Range(0, spawnPoints.Length);
        spawnPoints[random].GetComponent<SpawnObject>().Spawn("Queso");
        foreach (GameObject spawnPoint in spawnPoints)
        {
            if (spawnPoint != spawnPoints[random]){
                spawnPoint.GetComponent<SpawnObject>().Spawn("Veneno");
            }
        }   
    }

    public void Despawn()
    {
        spawn = true;
        foreach (var item in spawnPoints)
        {
            item.GetComponent<SpawnObject>().Despawn();
        }
    }

    public Vector3 GetSuggestedPoint(){
        return spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
        
    }
}
