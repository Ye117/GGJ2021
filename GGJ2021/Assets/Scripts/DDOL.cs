using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class DDOL : MonoBehaviour
{
    public static DDOL instance;

    private void Awake()
    {
        //No destruye el objeto por si quiero añadir scripts en este objeto,por ejemplo de AudioManager
        DontDestroyOnLoad(this);
        //Carga la pantalla principal directo
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    private void Update()
    {
        //Eliminar
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SceneManager.LoadScene("Respawn");
    }
    public IEnumerator ReiniciarEscena()  //Reinicia la Escena pero en Jugador la posicion depende de la colisión de la zona de respawn
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        yield return null;
    }


}
