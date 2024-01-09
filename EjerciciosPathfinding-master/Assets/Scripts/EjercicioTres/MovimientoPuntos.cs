using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovimientoPuntos : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3[] listaVectores ;
    public NavMeshAgent agente;
    public GameObject objetivo;
    int actual = 0;
    int longitud = 5;
    bool detectado = false;

    private void Start()
    {
        agente = GetComponent<NavMeshAgent>();
       /* TODO: Crear la lista de puntos (se puede hacer por código o desde la UI*/
       /* TODO: Establecer el primer punto como destino */
       agente.destination = listaVectores[actual];
    }

    // Update is called once per frame
    void Update()
    {
        /* El algoritmo es algo así:
         *  1 - Si hemos llegado al destino (es decir, la x y z de mi transform es igual al destino establecido en el agente)
         *  2 - Busco cual es el siguiente punto, y lo establezco como destino. ¿Qué pasa si hemos llegado al último punto?
         */
        if (agente.transform.position.x == listaVectores[actual].x && agente.transform.position.z == listaVectores[actual].z && detectado == false)
        {
            Debug.Log("Antes de sumar = " + actual);
            ++actual;
            if (actual == 4)
            {
                actual = 0;
                Debug.Log("Activado");
            }
            agente.destination = listaVectores[actual];
            Debug.Log("Despues de sumar = " + actual);
        }

        Vector3 origen = transform.position;
        Vector3 direccion = transform.forward;

        RaycastHit hit;

        if (detectado == true)
        {
            agente.destination = objetivo.transform.position;
        }

        if (Physics.Raycast(origen, direccion, out hit, longitud))
        {
            detectado = true;
        }
    }
    private void OnDrawGizmos()
    {
        Vector3 origen = transform.position;
        Vector3 direccion = transform.forward;

        Gizmos.color = Color.green;
        Gizmos.DrawRay(origen, direccion * longitud);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Personaje")
        {
            Time.timeScale = 0f;
        }
    }
}
