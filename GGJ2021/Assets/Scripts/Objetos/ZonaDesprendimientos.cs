using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaDesprendimientos : MonoBehaviour
{
    [SerializeField] private GameObject objetos;
    
    private void Start()
    {
        //Para que no parezca tan planeado, lo ideal es usar Random.Range
        InvokeRepeating("Objetos", 0, Random.Range(0.2f,0.5f));
    }
    void Objetos()
    {
        int numObj = Random.Range(1,4);
        float limiteIzquierdo = transform.position.x - 8;
        float limiteDerecho = transform.position.x + 8;
        for (int i = 1; i < numObj; i++)
        {
            //print(i + "objetos");
            //Creará un numero de objetos  
            Instantiate(objetos, new Vector2(Random.Range(limiteIzquierdo, limiteDerecho),  //posicion en X
            transform.position.y+Random.Range(4,10)), Quaternion.identity); //Posicion en Y para evitar que estén en la misma fila
        }
    }


}
