using UnityEngine;

public class Camara : MonoBehaviour
{
    //Componente
    public Camera camara;

    float giro;

    bool girar;
    private void Awake()
    {
        camara = GetComponent<Camera>();
        giro = 0;
        girar = false;
    }
    private void Update()
    {
        if (girar)
            giro++;
        Mathf.Clamp(giro, 0, 180);
        print("Giro:" + giro);
    }

}
