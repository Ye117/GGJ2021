using UnityEngine;

public class PruebaGitHub : MonoBehaviour
{
    //Adrian, podemos usar este script para probar de que efectivamente los cambios que tu hagas y los cambios 
    // que yo haga se van a cambiar. 
    //ESTE SCRIPT LO ELIMINAREMOS CUANDO ESTEMOS SEGURO DE QUE LOS CAMBIOS SE GUARDAN
    
    
    private void Start()
    {
        //Una simple prueba
        print(1 + 2);
        //Adrian estuvo aqui
        print("Sirve");
    }
    private void Update()
    {
        float vel = 50;
        
        transform.Translate(new Vector2(Input.GetAxisRaw("Horizontal") * vel * Time.deltaTime,0));
    }

}
