using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

    public Transform pdJ;
    public float velocidadeCâmera;
    private float margemDescansoCâmera;

    public float xMínimoCâmera;
    public float xMáximoCâmera;
    public float yMínimoCâmera;
    public float yMáximoCâmera;

    private bool mudouEstágio;

    void Start () {
        margemDescansoCâmera = 0.1f;
        mudouEstágio = false;
    }

    public bool VerificarMudança () {
        if (mudouEstágio) {
            mudouEstágio = false;
            return true;
        }
        return false;
    }
    
    void Update () {
        CorrigirX ();
        CorrigirY ();
    }

    public void MudançaEstágio (int númeroEstágio) {
        if (númeroEstágio == 1) {
            xMínimoCâmera = -4.0f;
            xMáximoCâmera = 4.0f;
            yMínimoCâmera = -5.0f;
            yMáximoCâmera = 5.0f;
            transform.position = new Vector3 (transform.position.x - 42.0f, transform.position.y, - 10.0f);
            mudouEstágio = true;
        }

        if (númeroEstágio == 2) {
            xMínimoCâmera = 38.0f;
            xMáximoCâmera = 46.0f;
            yMínimoCâmera = -5.0f;
            yMáximoCâmera = 19.0f;
            transform.position = new Vector3 (transform.position.x + 36.0f, transform.position.y, - 10.0f);
            mudouEstágio = true;
        }
    }

    private void CorrigirX () {
        float camX = transform.position.x;
        float pdJX = pdJ.position.x;

        if (Mathf.Abs (camX - pdJX) > margemDescansoCâmera) {
            if (camX < pdJX) {
                if (camX < xMáximoCâmera) {
                    transform.Translate (new Vector2 (velocidadeCâmera * Time.deltaTime, 0.0f));
                }
            }
            else {
                if (camX > xMínimoCâmera) {
                    transform.Translate (new Vector2 (- velocidadeCâmera * Time.deltaTime, 0.0f));
                }
            }
        }
    }

    private void CorrigirY () {
        float camY = transform.position.y;
        float pdJY = pdJ.position.y;

        if (Mathf.Abs (camY - pdJY) > margemDescansoCâmera) {
            if (camY < pdJY) {
                if (camY < yMáximoCâmera) {
                    transform.Translate (new Vector2 (0.0f, velocidadeCâmera * Time.deltaTime));
                }
            }
            else {
                if (camY > yMínimoCâmera) {
                    transform.Translate (new Vector2 (0.0f, - velocidadeCâmera * Time.deltaTime));
                }
            }
        }
    }
}