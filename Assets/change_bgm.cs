using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_bgm : MonoBehaviour
{
    public AudioSource bgm;
    public AudioClip music;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        bgm.Stop();
        bgm.clip = music;
        bgm.Play();
    }

}
