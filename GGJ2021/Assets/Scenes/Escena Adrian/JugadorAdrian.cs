using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorAdrian : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector3 cambioEscala;
    public bool mirandoDerecha;
    public Sprite caraPersonaje;
 



    void Start()
    {
        mirandoDerecha = true;


    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(this.GetComponent<SpriteRenderer>().color);
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

        if (Input.GetKeyUp(KeyCode.A))
        {
            transform.position -= cambioEscala * Time.deltaTime * 5;
        }
    }

    /// <summary>
    /// Cambia la orientación del objeto
    /// </summary>
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
