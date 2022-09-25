using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Transform spawn;
    [SerializeField]
    private float inteligencia = 0.3f;
    [SerializeField]
    private GameObject spawner;
    private NavMeshAgent agent;
    private int generacion = 0;
    private int muertes = 0;
    private int comida = 0;
    private int alimetado = 0;
    private bool moving = false;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!moving)
        {
            agent.SetDestination(spawner.GetComponent<RandomSpawn>().GetSuggestedPoint());
            moving = true;
        }
    }

    private bool EatFood(){
        agent.Warp(spawn.position);
        spawner.GetComponent<RandomSpawn>().Despawn();
        moving = false;
        return Random.Range(0f,1f) > inteligencia;
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Queso")
        {
            if (!EatFood())
            {
                alimetado++;
                inteligencia -= 0.1f;
                comida++;
            }
        }
        if (other.gameObject.tag == "Veneno")
        {
            if (EatFood())
            {
                muertes++;
                inteligencia += 0.1f;
                comida++;
            }
        }
        generacion++;
        Debug.Log("Comida: " + comida + " Muertes: " + muertes + " Generacion: " + generacion + " Alimentado: " + alimetado);
    }
}
