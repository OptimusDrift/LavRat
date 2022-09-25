using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField]
    private GameObject[] objectToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Spawn(string obj)
    {
        if (obj == "Queso")
        {
            SpawnObjects(0);
            return true;
        }
        if (obj == "Veneno")
        {
            SpawnObjects(1);
            return true;
        }
        return false;
    }

    private void SpawnObjects(int obj)
    {
        objectToSpawn[obj].SetActive(true);
    }

    public void Despawn()
    {
        foreach (GameObject obj in objectToSpawn)
        {
            obj.SetActive(false);
        }
    }

}
