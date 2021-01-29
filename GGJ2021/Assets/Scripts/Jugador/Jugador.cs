/*En este script vamos a poner todo lo relacionado al comportamiento del jugador,
 como los saltos, los movimientos,etc.*/
using UnityEngine;
using UnityEngine.SceneManagement;
public class Jugador : MonoBehaviour
{
    //Componentes
    Rigidbody2D _RB;
    public Transform jugador;
    //Características del jugador
    bool vivo;
    public float velocidad;
    public float velocidadCorrer;
    public float velocidadAgachado;
    float salto;
    //bool
    bool corriendo;
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
        //Velocidad PONER MÁS ADELANTE CUANDO SE TENGA ALGO DISEÑADO PARA PONERLO EN PRÁCTICA EN LA ESCENA
        //velocidad = 50;
        //velocidadCorrer = 100;
        salto = 15;
        vivo = true;
        corriendo = false;
        agachado = false;

        //Zona respawn
        zonaRespawn = new Vector2(respawnX, respawnY);
        //Cuando aparezca se teletransportará a la zona si no es nula
        transform.position = zonaRespawn;  //Cuando se inicie la escena el jugador volverá a la posicion de guardado
    }
    private void FixedUpdate()
    {
        if (vivo)
        {
            //Movimiento lateral del jugador
            if (!corriendo  && !agachado)  //Velocidad normal si no está corriendo ni está agachado
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
        if (Input.GetKeyDown("r"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if (Input.GetKeyDown("k"))
            vivo = false;
        //print(puedesSaltar);
        //print("Agachado:" + agachado);
        //print("Corriendo:" + corriendo);

        #endregion

        //Mientras que está vivo podrá hacer todo esto
        if (vivo)
        {
            //Salto
            if (Input.GetKeyDown(KeyCode.Space) && puedesSaltar)
                _RB.velocity = new Vector2(_RB.velocity.x, salto);

            //Correr  Si pulsa Shift estará corriendo,y si no corriendo es false
            corriendo = Input.GetKey(KeyCode.LeftShift) ? true : false;
            //Agachado cuando pulsa Left Control
            agachado = Input.GetKey(KeyCode.LeftControl) ? true : false;

        }
        else  // Muerto
        // Cuando muere automaticamente se reinicia la escena  
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  // CAMBIAR CON UNA CORRUTINA

    }
  

    //Metodo de trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Pisable")
            puedesSaltar = true;
        if (collision.name == "ZonaMortal")
            vivo = false;
        //Zona de respawn
        if (collision.name == "Zona Respawn")
        {
            //Obtiene la posición en la que se encuentra la zona de respawn
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
        if (collision.gameObject.tag == "Pisable")
            puedesSaltar = false;
    }
    //Metodo de colision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Cuando colisione con el suelo podrá saltar
        if (collision.gameObject.tag == "Pisable")
        {
            //puedesSaltar = true;
            //print("Puedes saltar");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //Cuando deje de estar en contacto no podrá saltar
        //if (collision.gameObject.tag == "Pisable")
           // puedesSaltar = false;
    }
    

}

