using UnityEngine;

public class Camara : MonoBehaviour
{
    //Componente
    public Camera camara;

    public float rotacion;

    public bool girar;

    //instancia
    public static Camara instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;

        camara = GetComponent<Camera>();
        rotacion = 0;
        girar = false;
    }
    private void Update()
    {
        
        if (girar)
        {
            rotacion+=5;
            transform.eulerAngles = new Vector3(0, 0, rotacion);
            //print("Está girando");
        }

        MantenerRotacion();
        Mathf.Clamp(rotacion, 0, 180);

        print("Giro:" + rotacion);

    }
    void MantenerRotacion()
    {
        if (rotacion == 180)
        {
            girar = false;
        }
    }

}
