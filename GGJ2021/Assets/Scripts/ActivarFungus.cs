using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarFungus : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Jugador")
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }
}
