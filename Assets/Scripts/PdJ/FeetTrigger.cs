using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetTrigger : MonoBehaviour {

    public Transform pdJ;
    public Transform câmera;

    void Start () {

    }

    void Update () {

    }

    private void OnCollisionEnter2D (Collision2D collision) {
        if (collision.gameObject.tag == "Pisável" && !pdJ.GetComponent<Movement>().noChão) {
            pdJ.GetComponent<Movement> ().TocarChão ();
            câmera.GetComponent<ShakeScreen> ().FazTremer ();
        }
    }

    private void OnCollisionExit2D (Collision2D collision) {
        // Só acessar quando sair do chão na vertical.
        if (collision.gameObject.tag == "Pisável") {
            pdJ.GetComponent<Movement> ().SairDoChão ();
            câmera.GetComponent<SFXController> ().SelecionarEfeitoSonoro ("jump");
        }
    }
}