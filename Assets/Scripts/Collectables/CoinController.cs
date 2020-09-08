using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {

    public Transform câmera;

    private Vector3 posiçãoOriginal;

    private float velocidadeFlutuação;
    private float alturaMínima;
    private float alturaMáxima;
    private bool subindo;

    private float velocidadeGiro;

    private float escalaMáxima;
    private float escalaMínima;
    private float taxaDiminuição;
    private float taxaAumento;
    private bool diminuindo;

    private bool podeSerColetada;

    void Start () {
        posiçãoOriginal = transform.position;
        subindo = true;
        velocidadeFlutuação = 0.25f;
        alturaMínima = 0.25f;
        alturaMáxima = 0.25f;

        velocidadeGiro = 90.0f;

        escalaMáxima = 2.0f;
        escalaMínima = 0.95f;
        taxaDiminuição = 0.995f;
        taxaAumento = 1.01f;
        diminuindo = true;

        podeSerColetada = true;
    }
    
    void Update () {
        Flutuar ();
        Girar ();
        Pulsar ();

        VerificadorRessurgimento ();
    }

    private void VerificadorRessurgimento () {
        if (câmera.GetComponent<Follow> ().VerificarMudança()) {
            GetComponent<SpriteRenderer> ().enabled = true;
            podeSerColetada = true;
        }
    }

    private void Pulsar () {
        if (diminuindo) {
            transform.localScale = transform.localScale * taxaDiminuição;
            if (transform.localScale.magnitude <= escalaMínima) {
                diminuindo = false;
            }
        }
        else {
            transform.localScale = transform.localScale * taxaAumento;
            if (transform.localScale.magnitude >= escalaMáxima) {
                diminuindo = true;
            }
        }
    }

    private void Girar () {
        transform.Rotate (new Vector3 (0.0f, 0.0f, velocidadeGiro * Time.deltaTime));
    }

    private void Flutuar () {
        if (subindo) {
            transform.Translate (new Vector3 (0.0f, velocidadeFlutuação * Time.deltaTime, 0.0f), Space.World);
            if (transform.position.y >= posiçãoOriginal.y + alturaMáxima) {
                subindo = false;
            }
        }
        else {
            transform.Translate (new Vector3 (0.0f, - velocidadeFlutuação * Time.deltaTime, 0.0f), Space.World);
            if (transform.position.y <= posiçãoOriginal.y - alturaMínima) {
                subindo = true;
            }
        }
    }
    
    private void OnTriggerEnter2D (Collider2D collision) {
        if (collision.name == "PdJ" && podeSerColetada) {
            câmera.GetComponent<SFXController> ().SelecionarEfeitoSonoro ("mordida");
            GetComponent<SpriteRenderer>().enabled = false;
            podeSerColetada = false;
        }
    }
}