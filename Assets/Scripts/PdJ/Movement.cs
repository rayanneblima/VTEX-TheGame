using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float velocidadeHorizontal;
    public float forçaDePulo;
    public float forçaDePuloDuplo;
    public bool noChão;
    private bool podePuloAdicional;

    public Vector3 novaPosiçãoInicial;

    void Start () {
        noChão = true;
        podePuloAdicional = true;
        novaPosiçãoInicial = transform.position;
        GetComponent<FallController> ().posiçãoInicial = novaPosiçãoInicial;
    }

    public void MudançaEstágio (int númeroEstágio) {
        if (númeroEstágio == 1) {
            novaPosiçãoInicial = new Vector3 (-6.0f, -3.25f, 0.0f);
            GetComponent<FallController> ().posiçãoInicial = novaPosiçãoInicial;
            transform.position = novaPosiçãoInicial;
        }

        if (númeroEstágio == 2) {
            novaPosiçãoInicial = new Vector3 (36.0f, -3.25f, 0.0f);
            GetComponent<FallController> ().posiçãoInicial = novaPosiçãoInicial;
            transform.position = novaPosiçãoInicial;
        }
    }

    void Update () {
        VerificarEntradas ();
    }

    private void VerificarEntradas () {
        if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.J)) {
            Pular ();
        }

        if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) {
            Andar (true);
        }

        if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) {
            Andar (false);
        }
    }

    private void Pular () {
        if (noChão) {
            gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0.0f, forçaDePulo));
            SairDoChão ();
        }
        else {
            if (podePuloAdicional) {
                gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (gameObject.GetComponent<Rigidbody2D> ().velocity.x, 0.0f);
                gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0.0f, forçaDePuloDuplo));
                podePuloAdicional = false;
            }
        }
    }

    private void Andar (bool paraDireita) {
        if (paraDireita) {
            transform.Translate (new Vector2 (velocidadeHorizontal * Time.deltaTime, 0.0f));
            gameObject.GetComponent<SpriteRenderer> ().flipX = false;
        }
        else {
            transform.Translate (new Vector2 (- velocidadeHorizontal * Time.deltaTime, 0.0f));
            gameObject.GetComponent<SpriteRenderer> ().flipX = true;
        }
    }

    public void TocarChão () {
        noChão = true;
        podePuloAdicional = true;
    }

    public void SairDoChão () {
        noChão = false;
    }
}