using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeScreen : MonoBehaviour {

    public Transform pdJ;

    public float duraçãoTremidaMáxima;
    public float intensidadeTremida;
    public float velocidadeTremida;

    private bool tremendo;
    private float duraçãoTremida;

    void Start () {
        tremendo = false;
    }
    
    void Update () {
        if (tremendo) {
            duraçãoTremida = duraçãoTremida - Time.deltaTime;
            TremerEmX ();
            TremerEmY ();
            if (duraçãoTremida <= 0.0f) {
                tremendo = false;
            }
        }
    }

    public void FazTremer () {
        tremendo = true;
        duraçãoTremida = duraçãoTremidaMáxima;
    }

    private void TremerEmX () {
        float camX = transform.position.x;
        float pdJX = pdJ.position.x;

        if (camX != pdJX) {
            if (camX < pdJX) {
                transform.Translate (new Vector2 (velocidadeTremida * Time.deltaTime, 0.0f));
            }
            else {
                transform.Translate (new Vector2 (- velocidadeTremida * Time.deltaTime, 0.0f));
            }
        }
    }

    private void TremerEmY () {
        float camY = transform.position.y;
        float pdJY = pdJ.position.y;

        if (camY != pdJY) {
            if (camY < pdJY) {
                transform.Translate (new Vector2 (0.0f, velocidadeTremida * Time.deltaTime));
            }
            else {
                transform.Translate (new Vector2 (0.0f, - velocidadeTremida * Time.deltaTime));
            }
        }
    }
}