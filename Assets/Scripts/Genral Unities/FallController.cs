using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallController : MonoBehaviour {

    public float alturaMínima;
    public Vector3 posiçãoInicial;

    void Start () {
        
    }

    void Update () {
        if (transform.position.y <= alturaMínima) {
            ReiniciarEstágio ();
        }
    }

    private void ReiniciarEstágio () {
        transform.position = posiçãoInicial;
        if (gameObject.name == "PdJ") {
            gameObject.GetComponent<Movement> ().TocarChão ();
        }
    }
}