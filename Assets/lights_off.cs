using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lights_off : MonoBehaviour
{
    public  GameObject Monster;
    public  GameObject GM;
    //public int lamp_number;

    public AudioClip trumpets;
    public GameObject sound_source;
    AudioSource aud;
    void Start()
    {
        aud = sound_source.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        aud.PlayOneShot(trumpets, 1F);
        this.GetComponent<Light>().enabled  = false;  

        controlador_moustro controlador_moustro = Monster.GetComponent<controlador_moustro>();
        controlador_moustro.velocidad = controlador_moustro.velocidad + 0.1f;    
        GM.GetComponent<GMController>().increase_lamp();
        this.gameObject.active = false;
    }
}
