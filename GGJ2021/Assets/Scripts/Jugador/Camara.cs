using UnityEngine;

public class Camara : MonoBehaviour
{
    //Componente
    public Camera camara;

    public float rotacion;

    public bool giroInvertido;
    public bool giroNormal;

    //instancia
    public static Camara instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;

        camara = GetComponent<Camera>();
        rotacion = 0;
        giroInvertido = false;
        giroNormal = false;
    }
    private void Update()
    {   
        //En esta sentencia obliga a que no pueda superar los 180º
        //Vuelve al giro normal
        if (giroNormal)
        {
            rotacion -= 5 ;
            //print("Esta girando a la posicion normal");
        }

        //Cuando colisione con una plataforma girará mientras que no sea 180 o -180
        if (giroInvertido)
        {
            rotacion+= 5 ;
            //print("Está girando a la inversa");
        }

        rotacion = Mathf.Clamp(rotacion, 0, 180);
        transform.eulerAngles = new Vector3(0, 0, rotacion);
     
        //Una vez que llegue a los 180º mantendrá la rotación hasta que vuelva a tocar una plataforma que le haga girar
        MantenerRotacion();
        //print("Giro:" + rotacion);
    }
    void MantenerRotacion()
    {
        if (rotacion == 180)
            giroInvertido = false;

        if (rotacion == 0)
            giroNormal = false;
    }

}
