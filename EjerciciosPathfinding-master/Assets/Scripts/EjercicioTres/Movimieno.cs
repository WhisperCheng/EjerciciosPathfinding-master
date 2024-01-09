using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimieno : MonoBehaviour
{
    Rigidbody cuerpo;
    public float velocidad;
    float movHorizontal, movVertical;
    // Start is called before the first frame update
    void Start()
    {
        cuerpo = GetComponent<Rigidbody>();
        velocidad = 3;
    }

    // Update is called once per frame
    void Update()
    {
        movHorizontal = Input.GetAxis("Horizontal");
        movVertical = Input.GetAxis("Vertical");

        cuerpo.velocity = new Vector3 (movHorizontal * velocidad, cuerpo.velocity.y, movVertical * velocidad);
    }
}
