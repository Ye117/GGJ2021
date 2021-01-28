using UnityEngine;

public class Camara : MonoBehaviour
{
    public Camera camara;

    private void Awake()
    {
        camara = GetComponent<Camera>();

    }

}
