using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaDesprendimientos : MonoBehaviour
{
    [SerializeField] private GameObject objetos;
    
    private void Start()
    {
        //Para que no parezca tan planeado, lo ideal es usar Random.Range
        //InvokeRepeating("Objetos", 0, 1f);
    }
    private void Update()
    {
        //ELIMINAR
        if (Input.GetKeyDown("o"))
            Objetos();
    }

    void Objetos()
    {
        int numObj = Random.Range(1,6);
        float limiteIzquierdo = transform.position.x-5;
        float limiteDerecho = transform.position.y + 5;
        float posicion;
        for (int i = 1; i < numObj; i++)
        {
            print(i + "objetos");
            Instantiate(objetos, new Vector2(Random.Range(limiteIzquierdo, limiteDerecho),transform.position.y) , Quaternion.identity);
        }
    }


}
