using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorAdrian : MonoBehaviour
{
    // Start is called before the first frame update

    float velocidad;

    public string esbozo;
    public Vector3 cambioEscala;
    public bool mirandoDerecha;


    void Start()
    {
        print(esbozo);
        mirandoDerecha = true;
    }

    // Update is called once per frame
    void Update()
    {
        velocidad = 20f;

        if (Input.GetKey(KeyCode.D))
        {
            if (!mirandoDerecha)
            {
                Giro();
            }

            //transform.Translate(new Vector2(velocidad * Time.deltaTime, 0));
            transform.position += cambioEscala * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (mirandoDerecha)
            {
                Giro();
            }
            transform.position -= cambioEscala * Time.deltaTime;
        }
    }

    void Giro()
    {
        //Cambiar booleano
        mirandoDerecha = !mirandoDerecha;

        //Invertir posicion
        Vector3 escalaLocal = transform.localScale;
        escalaLocal.x *= -1;
        transform.localScale = escalaLocal;


    }
}
