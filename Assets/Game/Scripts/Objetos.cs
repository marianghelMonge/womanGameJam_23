using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetos : MonoBehaviour
{
    
  public GameObject objeto;
  private bool playerObj=false;
  private void OnTriggerEnter2D(Collider2D other) {
    if(other.CompareTag("Player")){
        playerObj = true;
    }
  }

  private void OnTriggerExit2D(Collider2D other) {
    if(other.CompareTag("Player")){
     playerObj = false;
    }
  }

 private void Update() {
    if (Input.GetKeyDown(KeyCode.UpArrow)){
        objeto.SetActive(true);
    }
 }


}
