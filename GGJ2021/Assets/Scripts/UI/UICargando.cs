using UnityEngine;

public class UICargando : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
        //Con hacer solo una animacion me basta
    private void OnEnable()
    {
        if (gameObject.name == "FadeIn")  //Hace FadeIn
        {
            animator.Play("Fade",0,0f);
            animator.speed = 1;
            //print("FadeIn");
        }
        
        if (gameObject.name == "FadeOut")  //Usa la misma animacion pero lo hace justo al reves
        {
            animator.StartPlayback();
            animator.Play("Fade", 0, 1f);
            animator.speed = -1f;
            //print("Fade out");

        }
    }
}
