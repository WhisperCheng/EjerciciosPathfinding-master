using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
// Hay que incluir esta dependencia!
using UnityEngine.AI;

public class MovimientoAgente : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform destino;
    public Vector3 origen;
    void Start()
    {
        /* TODO: Obtener una referencia al agente, y establecer como destino las coordenadas del objeto 'Premio' */
        origen = transform.position;
        agent = GetComponent<NavMeshAgent>();
        agent.destination = destino.position;
        Debug.Log(agent.transform.position);
    }

    // ¿Hace falta poner el Update?
    void Update()
    {
        /*if (agent.transform.position.x == destino.position.x)
        {
            Debug.Log("Activado");
            agent.destination = origen;
            //agent.destination = new Vector3(7.00f, transform.position.y, 0.74f);
        }*/
    }
}
