using UnityEngine;

public class DDOL : MonoBehaviour
{
    public static DDOL instance;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

}
