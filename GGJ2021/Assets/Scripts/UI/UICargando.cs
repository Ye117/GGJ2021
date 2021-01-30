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
        
    }
}
