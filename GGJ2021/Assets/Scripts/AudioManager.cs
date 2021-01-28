using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //Componentes


    //Aquí se pondrá todos los AudioClips que se vaya a usar




    public AudioManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        DontDestroyOnLoad(this);

    }

}
