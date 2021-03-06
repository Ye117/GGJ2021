using UnityEngine;

public class Camara : MonoBehaviour
{
    //Componente
    [HideInInspector] public Camera camara;
    [HideInInspector] public float rotacion;

    [HideInInspector] public bool giroInvertido;
    [HideInInspector] public bool giroNormal;

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
    private void LateUpdate()
    {
        //La posicion de la c�mara es la posici�n del jugador excepto en Z que tiene que ser en -10
        transform.position = new Vector3(FindObjectOfType<Jugador>().jugador.position.x,FindObjectOfType<Jugador>().jugador.position.y,-10);
    }
    private void Update()
    {   
        //En esta sentencia obliga a que no pueda superar los 180�
        //Vuelve al giro normal
        if (giroNormal)
        {
            rotacion -= 5 ;
            //print("Esta girando a la posicion normal");
        }

        //Cuando colisione con una plataforma girar� mientras que no sea 180 o -180
        if (giroInvertido)
        {
            rotacion+= 5 ;
            //print("Est� girando a la inversa");
        }

        rotacion = Mathf.Clamp(rotacion, 0, 180);
        transform.eulerAngles = new Vector3(0, 0, rotacion);
     
        //Una vez que llegue a los 180� mantendr� la rotaci�n hasta que vuelva a tocar una plataforma que le haga girar
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
