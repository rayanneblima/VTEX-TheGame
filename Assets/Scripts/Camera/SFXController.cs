using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour {

    public AudioSource fonteEfeitosSonoros;
    public AudioClip efeitoJump;
    public AudioClip efeitoMordida;

    void Start () {

    }
    
    void Update () {

    }

    public void SelecionarEfeitoSonoro (string nome) {
        if (nome == "jump") {
            TocarEfeitoSonoro (efeitoJump);
        }
        if (nome == "mordida") {
            TocarEfeitoSonoro (efeitoMordida);
        }
    }

    private void TocarEfeitoSonoro (AudioClip clipAtual) {
        fonteEfeitosSonoros.clip = clipAtual;
        fonteEfeitosSonoros.Play ();
    }
}