using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ComportamientoCamara : MonoBehaviour
{
    public NavMeshAgent personaje;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /* TODO: Lanzar un rayo al pulsar el botón, y modificar el destino de nuestro agente */
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray laser = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(laser, out hit))
            {
                personaje.destination = hit.point;
            }
        }

    }

}
