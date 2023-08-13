using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetos : MonoBehaviour
{
    
    public gameObject TriggerPlayer;
    public string tagObject;

    private void OnTriggerEnter2D(Collider other) {
        //Esto podria mejorarse pero bueh no hay tiempo, RUN FOREST RUN!
       
        esconderObjetoEscenario();
    }

    private void objetoAgarrado(){
        if(Input.GetButtonDown("down")){

                
        }
    }

    private void objetoSoltado(){
        spawnObjetoSoltado();
    }

    private void spawnObjetoSoltado(){
        if(Input.GetButtonDown("up")){
            

        }
    }

    private void esconderObjetoEscenario(){

    }

    private void ActiveObjectPlayer(){
        if(other.CompareTag("bridge")){
            other.SetActive(true);
            pilar.SetActive(false);
            tesoro.SetActive(false);
            caja.SetActive(false);
        }
        if(other.CompareTag("pilar")){
            other.SetActive(true);
            bridge.SetActive(false);
            tesoro.SetActive(false);
            caja.SetActive(false);
        }
        if(other.CompareTag("tesoro")){
            other.SetActive(true);
            bridge.SetActive(false);
            pilar.SetActive(false);
            caja.SetActive(false);    
        }
        if(other.CompareTag("caja")){
            other.SetActive(true);
            bridge.SetActive(false);
            pilar.SetActive(false);
            tesoro.SetActive(false);      
        }
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
