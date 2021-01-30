using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;
public class MenuPrincipal : MonoBehaviour
{
    public void EmpezarJuego()
    {
        //Activar FadeIn 
        StartCoroutine(CargarEscenaInicial());
    }
    public void Salir()
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
