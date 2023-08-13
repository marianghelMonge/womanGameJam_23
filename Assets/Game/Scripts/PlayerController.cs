using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movimiento")]
    public float velocidad;

    [Header("Salto")]
    public float jumpForce;

    [Header("Componentes")]
    public Rigidbody2D rigidbody;

    [Header("Al suelo")]
    public Transform CheckUnSalto;
    public LayerMask EsSuelo;
    private bool isPlayerSuelo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        setVelocidad();
        SaltaUnaVez();
    }

    private void setVelocidad(){
        rigidbody.velocity = new Vector2(velocidad * Input.GetAxis("Horizontal"),rigidbody.velocity.y);
    }

    //getButton desde hasta - getbuttondown presion abajo
    /*private void salto(){
        if(Input.GetButtonDown("Jump")){
            
        }
    }*/

    private void SaltaUnaVez(){
         isPlayerSuelo = Physics2D.OverlapCircle(CheckUnSalto.position, .2f,EsSuelo);//verificaPlayerTocaSuelo
        if(Input.GetButtonDown("Jump")){
            if(isPlayerSuelo){
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
            }

        }
    }
}
