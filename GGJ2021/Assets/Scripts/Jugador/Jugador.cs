/*En este script vamos a poner todo lo relacionado al comportamiento del jugador,
 como los saltos, los movimientos,etc.*/
using UnityEngine;
using UnityEngine.SceneManagement;
public class Jugador : MonoBehaviour
{
    //Componentes
    Rigidbody2D _RB;
    //Características del jugador
    bool vivo;
    public float velocidad;
    public float velocidadCorrer;
    float salto;
    //bool
    bool corriendo;
    bool puedesSaltar;
    
    private void Awake()
    {
        //Componentes
        _RB = GetComponent<Rigidbody2D>();
        //Velocidad PONER MÁS ADELANTE CUANDO SE TENGA ALGO DISEÑADO PARA PONERLO EN PRÁCTICA EN LA ESCENA
        //velocidad = 50;
        //velocidadCorrer = 100;
        vivo = true;
        salto = 15;
        corriendo = false;
    }
    private void FixedUpdate()
    {
        if(vivo)
            //Movimiento lateral del jugador
            switch (corriendo)
            {
                case false:  
                    _RB.velocity= new Vector2(Input.GetAxisRaw("Horizontal") * velocidad * Time.fixedDeltaTime, _RB.velocity.y);
                    break;
                case true:
                    _RB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * velocidadCorrer * Time.fixedDeltaTime, _RB.velocity.y);
                    break;
            }
    }
    private void Update()
    {

        #region Eliminar
        if (Input.GetKeyDown("r"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            print(puedesSaltar);
        #endregion

        //Mientras que está vivo podrá hacer todo esto
        if (vivo)
        {
            //Salto
            if (Input.GetKeyDown(KeyCode.Space) && puedesSaltar)
                _RB.velocity = new Vector2(_RB.velocity.x, salto);

            //Correr  Si pulsa Shift estará corriendo,y si no corriendo es false
            corriendo = Input.GetKey(KeyCode.LeftShift) ? true : false;
            //print("Corriendo:" + corriendo);

        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Cuando colisione con el suelo podrá saltar
        if (collision.gameObject.tag == "Pisable")
        {
            puedesSaltar = true;
            print("Puedes saltar");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "ZonaMortal")
            vivo = false;
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //Cuando deje de estar en contacto no podrá saltar
        if (collision.gameObject.tag == "Pisable")
            puedesSaltar = false;
    }
    

}

