using UnityEngine;

public class Rocas : MonoBehaviour
{
    private void Start()
    {
        //Destruye el objeto a los 2s de aparicion
        Destroy(this.gameObject, 2);   
    }
    
}
