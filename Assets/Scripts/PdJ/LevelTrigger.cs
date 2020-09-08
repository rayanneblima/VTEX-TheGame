using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTrigger : MonoBehaviour {

    public Transform câmera;
    public Transform pdJ;

    void Start () {

    }
    
    void Update () {

    }

    private void OnTriggerEnter2D (Collider2D collision) {
        if (collision.name == "PdJ" && gameObject.name == "Teletransporte #1") {
            pdJ.GetComponent<Movement> ().MudançaEstágio (1);
            câmera.GetComponent<Follow> ().MudançaEstágio (1);
        }
        if (collision.name == "PdJ" && gameObject.name == "Teletransporte #2") {
            pdJ.GetComponent<Movement> ().MudançaEstágio (2);
            câmera.GetComponent<Follow> ().MudançaEstágio (2);
        }
        if (collision.name == "PdJ" && gameObject.name == "Teletransporte #End") {

        }
    }
}