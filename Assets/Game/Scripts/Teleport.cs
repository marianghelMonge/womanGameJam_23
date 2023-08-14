using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Teleport : MonoBehaviour
{
    [Header("Tiempo Regresivo")]
    [SerializeField] 
    public float tiempoInicial;
    public float timer;
    [SerializeField] 
    public Text tiempoTXT;
    //public TextMeshProUGUI tiempoTxt;//Arrastrar ref en prefab

    [Header("Cambio perspectiva")]
    public GameObject camera1;
    public GameObject camera2;
    bool activeCamera = false;
    bool activePlayer = false;
    bool isActive =false;
    public GameObject Player2D;
    public GameObject Player3D;


    private void Update() {
        checkCamara2Active();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
        GetComponent<Collider2D>().enabled = false;
        ChangeCamera();
        StartCoroutine(GoBack());
        }
    }

    void ChangeCamera() {
    activeCamera = !activeCamera;
    camera1.SetActive(activeCamera);
    camera2.SetActive(!activeCamera);
    ChangePlayer();
    }

    void ChangePlayer(){
        if(camera1.activeInHierarchy){
            Player2D.SetActive(true);
            Player3D.SetActive(false);
        }else{
            Player2D.SetActive(false);
            Player3D.SetActive(true);
        } 
    }

    private void tiempoRegresivo(){
        timer -= Time.deltaTime;
        string tiempo = ""+timer.ToString("f0");
        tiempoTXT.text = tiempo;
        //timerTxt = tiempo;
        if(timer < 0){
            //ChangeCamera();
            timer = tiempoInicial;
        }
       // Debug.Log(tiempo);
    }

        IEnumerator GoBack() {
    yield return new WaitForSeconds(12f);
    ChangeCamera();
    yield return new WaitForSeconds(12f);
    GetComponent<Collider2D>().enabled = true;
    
    }

    private void checkCamara2Active(){
        if(camera2.activeInHierarchy){
            tiempoRegresivo();
        }
    }  
}
