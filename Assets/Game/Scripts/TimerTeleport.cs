using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine.UI;
using System.Reflection;

public class TimerTeleport : MonoBehaviour
{
    [Header("tiempo")]
    //Variables timer funcionalidad
    public float timer = 0;
    public Text textoTimer;
    public GameObject timerCanvas;
    //Variables timer Barra 
    public Image barraTimer;
    //Active trigger
    private bool activeTrigger = false;
    public GameObject spawnPoint;
    public GameObject spawnPointInicial;

    [Header("Cambio perspectiva")]
    public GameObject camera1;
    public GameObject camera2;
    //bool activeCamera = true;
    bool activePlayer = false;
    bool isActive = false;
    public GameObject Player2D;
    public GameObject Player3D;
    bool controlSpawn = false;

    // Start is called before the first frame update
    void Start()
    {
        camera1.SetActive(true);
        camera2.SetActive(false);
        Player2D.SetActive(true);
        Player3D.SetActive(false);
        Player2D.transform.position = spawnPointInicial.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (activeTrigger) { teleportTimer(); } else { activeCamera2D(); }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //UnityEngine.Debug.Log("entra")
        if (other.CompareTag("Player"))
        {
            activeTrigger = true;
            activeCamera3D();

            // GetComponent<Collider2D>().enabled = false;
            // ChangeCamera();
            // StartCoroutine(GoBack());
        }
        //else { enter = false; }
        // UnityEngine.Debug.Log($"prueba trigger{enter}");
    }

    public void teleportTimer() {
        activeTrigger = true;
        float timerInicial = timer;
        //Activar el timer
        timerCanvas.SetActive(true);
        //timer = timer - 1;//Timer corre a nivel computadora
        timer -= Time.deltaTime;//Timer a tiempo real
        //textoTimer.text = "" + timer.ToString("f0");//convertir float a string
        barraTimer.fillAmount -= 0.450f / timerInicial * Time.deltaTime;

        if (timer < 0) {
            activeTrigger = false;
            timerCanvas.SetActive(false);
            timer = timerInicial;
            controlSpawn= true;
        }
    }

   private void activeCamera2D() {
        camera1.SetActive(true);
        camera2.SetActive(false);
        Player2D.SetActive(true);
        Player3D.SetActive(false);

        if (controlSpawn)
        {
            Player2D.transform.position = spawnPoint.transform.position;
            controlSpawn = false;
        }
    }
    private void activeCamera3D() {
        camera1.SetActive(false);
        camera2.SetActive(true);
        Player2D.SetActive(false);
        Player3D.SetActive(true);
       // Player3D.transform.position = spawnPointInicial.transform.position;
    }
}
