using UnityEngine;

public class Rocas : MonoBehaviour
{
    float vel;
    private void Start()
    {
        //Destruye el objeto a los 2s de aparicion
        Destroy(this.gameObject, 10);   
    }
    private void Update()
    {
        vel -= 0.1f;
        transform.Translate(new Vector2(0, vel*Time.deltaTime));

    }

}
