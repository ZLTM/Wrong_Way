using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open_left : MonoBehaviour
{
    int i=0;
    public  GameObject GM;
    // Start is called before the first frame update

    // Update is called once per frame
    public AudioClip door;
    public GameObject sound_source;
    AudioSource aud;
    void Start()
    {
        aud = sound_source.GetComponent<AudioSource>();
    }
    void Update()
    {
        GMController gmcontroller = GM.GetComponent<GMController>();
        if(gmcontroller.lamp_number >= 7 && i <=0)
        {
            aud.PlayOneShot(door, 1F);
            this.transform.Rotate (new Vector3(0f,88f,0f));
            i++;
        }
    }
}
