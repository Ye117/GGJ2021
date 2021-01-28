using UnityEngine;

public class PlataformaNormal : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Jugador")
        {
            Camara.instance.giroNormal = true;
            print("Va a empezar a girar hacia la posicion original");
        }
    }
}
