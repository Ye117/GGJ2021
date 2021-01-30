/*En este script vamos a poner todo lo relacionado al comportamiento del jugador,
 como los saltos, los movimientos,etc.*/
using UnityEngine;
using UnityEngine.SceneManagement;
public class Jugador : MonoBehaviour
{
    
    //Componentes
    public Rigidbody2D _RB;
    [HideInInspector] public Transform jugador;
    //Caracter�sticas del jugador
    bool vivo;
    public float velocidad;
    public float velocidadCorrer;
    public float velocidadAgachado;
    float salto;
    //bool
    bool corriendo;  // En vez de un caminando ahora mismo simplemente he puesto !corriendo y !agachado para que sea caminar
    bool agachado;
    bool puedesSaltar;
    //PlayerPrefs
    float respawnX,respawnY;
    Vector2 zonaRespawn;
    
    private void Awake()
    {
        //PlayerPrefs
        respawnX = PlayerPrefs.GetFloat("ZonaRespawnX");
        respawnY = PlayerPrefs.GetFloat("ZonaRespawnY");
        //Componentes
        _RB = GetComponent<Rigidbody2D>();
        jugador = GetComponent<Transform>();
        //Velocidad PONER M�S ADELANTE CUANDO SE TENGA ALGO DISE�ADO PARA PONERLO EN PR�CTICA EN LA ESCENA
        //velocidad = 50;
        //velocidadCorrer = 100;
        salto = 15;
        vivo = true;
        corriendo = false;
        agachado = false;

        //Zona respawn
        zonaRespawn = new Vector2(respawnX, respawnY);
        //Cuando aparezca se teletransportar� a la zona si no es nula 
        //Ponerlo m�s adelante
        //transform.position = zonaRespawn;  //Cuando se inicie la escena el jugador volver� a la posicion de guardado
    }
    private void FixedUpdate()
    {
        if (vivo)
        {
            //Movimiento lateral del jugador
            if (!corriendo  && !agachado)  //Velocidad normal si no est� corriendo ni est� agachado
                _RB.velocity= new Vector2(Input.GetAxisRaw("Horizontal") * velocidad * Time.fixedDeltaTime, _RB.velocity.y);
            else if(corriendo)  //Velocidad corriendo
                _RB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * velocidadCorrer * Time.fixedDeltaTime, _RB.velocity.y);
            else if(agachado) //Velocidad agachado
                 _RB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * velocidadAgachado * Time.fixedDeltaTime, _RB.velocity.y);   
        }
    }
    private void Update()
    {
        #region Eliminar
        if (Input.GetKeyDown("r"))  //Reiniciar
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if (Input.GetKeyDown("k"))  //Morir
            vivo = false;
        //print(puedesSaltar);
        //print("Agachado:" + agachado);
        //print("Corriendo:" + corriendo);

        #endregion

        //Mientras que est� vivo podr� hacer todo esto
        if (vivo)
        {
            //Si est� activado el Fungus no se podr� mover
            FungusDialogos();
            //Salto
            if (Input.GetKeyDown(KeyCode.Space) && puedesSaltar)
                _RB.velocity = new Vector2(_RB.velocity.x, salto);

            //Correr  Si pulsa Shift estar� corriendo,y si no corriendo es false
            corriendo = Input.GetKey(KeyCode.LeftShift) ? true : false;

            //Agachado cuando pulsa Left Control
            agachado = Input.GetKey(KeyCode.LeftControl) ? true : false;

            //Por si acaso a�ado esto para que correr tenga prioridad sobre agacharse 
            if (corriendo)
                agachado = false;
            
        }
        else  // Muerto
              // Cuando muere automaticamente se reinicia la escena  //A�adirle alg�n tiempo
            StartCoroutine(FindObjectOfType<DDOL>().ReiniciarEscena());

    }

    #region Metodos
    void FungusDialogos()
    {
        var dialogo = Fungus.SayDialog.GetSayDialog();
        var menu = Fungus.MenuDialog.GetMenuDialog();

        if(dialogo.isActiveAndEnabled || menu.isActiveAndEnabled)
        {
            _RB.bodyType = RigidbodyType2D.Static ;  //Cuando este activado el cuerpo ser� est�tico,no podr� moverse
            /*
            velocidad = 0;
            velocidadAgachado = 0;
            velocidadCorrer = 0;
            */
        }
        else
        {
            _RB.bodyType = RigidbodyType2D.Dynamic;  //Cuando se desactive el Fungus siempre ser� din�mico
            /*
            velocidad = 500;
            velocidadAgachado = 200;
            velocidadCorrer = 750;
            */
        }
    }
    #endregion

    //Metodos de colisiones
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Pisando cualquier superficie podr� saltar
        if (collision.gameObject.layer == 6)
            puedesSaltar = true;

        //La zona mortal son huecos al vac�o
        if (collision.name == "ZonaMortal")
            vivo = false;


        //Zona de respawn
        if (collision.name == "Zona Respawn")
        {
            //Obtiene la posici�n en la que se encuentra la zona de respawn
            respawnX=collision.gameObject.transform.position.x;
            respawnY=collision.gameObject.transform.position.y;

            //print("La posicion del respawn es :" + collision.gameObject.transform.position);
            //print("X:" + respawnX);
            //print("Y:" + respawnY);

            //Guarda la posicion de la zona de respawn
            PlayerPrefs.SetFloat("ZonaRespawnX", respawnX);
            PlayerPrefs.SetFloat("ZonaRespawnY", respawnY);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
            puedesSaltar = false;
    }
    //Metodo de colision
    private void OnCollisionEnter2D(Collision2D collision)  //Revisar, como en Fungus tambien tiene trigger  se usa Unityengine
    {
        //Cuando colisione con el suelo podr� saltar
        if (collision.gameObject.tag == "Pisable")
        {
            //puedesSaltar = true;
            //print("Puedes saltar");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //Cuando deje de estar en contacto no podr� saltar
        //if (collision.gameObject.tag == "Pisable")
           // puedesSaltar = false;
    }
    

}

