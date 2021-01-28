using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class MenuPrincipal : MonoBehaviour
{
    void EmpezarJuego()
    {
        StartCoroutine(CargarEscenaInicial());
    }
    void Salir()
    {
        Application.Quit();
    }
    IEnumerator CargarEscenaInicial()
    {
        AsyncOperation carga = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        while (!carga.isDone)
            yield return null;
    }
   
}
