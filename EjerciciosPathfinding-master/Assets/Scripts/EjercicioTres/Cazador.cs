using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cazador : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject objetivo;
    float distancia;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        distancia = Vector3.Distance(agent.transform.position, objetivo.transform.position);
        //Debug.Log("La distancia entre los dos es: " +  distancia);
        if (distancia < 2)
        {
            Vector3 resultado = agent.transform.position - objetivo.transform.position;

            agent.destination = (transform.position + resultado.normalized * 1);

            Debug.Log(resultado.normalized);

        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Vector3 resultado = agent.transform.position - objetivo.transform.position;
        Gizmos.DrawRay(agent.transform.position, resultado * 3);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Personaje")
        {
            Destroy(gameObject);
        }
    }
}
