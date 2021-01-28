/*Este script está dedicado solamente a la zona en el que el jugador gira su cámara*/
using UnityEngine;

public class PlataformaInversa : MonoBehaviour
{

    
    private void OnCollisionEnter2D(Collision2D collision)
     {
        if (collision.gameObject.name == "Jugador")
        {
            FindObjectOfType<Camara>().camara.transform.eulerAngles= new Vector3(0,0,180);
            print("La camara ha girado 180 grados");
        }
     }
}
