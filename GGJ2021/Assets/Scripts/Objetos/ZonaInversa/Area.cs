using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Jugador")
        {
            if (gameObject.tag == "AreaInvertida")
            {  //Cambiar a ser posible
                //Camara.instance.giroInvertido = true;
                FindObjectOfType<Jugador>()._RB.gravityScale = -1;
            }
            if (gameObject.tag == "AreaNormal")
            {
                Camara.instance.giroNormal = true;
                FindObjectOfType<Jugador>()._RB.gravityScale = 2;
            }
        }
    }
}
