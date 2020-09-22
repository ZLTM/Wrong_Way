using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open_right : MonoBehaviour
{
    int i=0;
    public  GameObject GM;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        GMController gmcontroller = GM.GetComponent<GMController>();
        if(gmcontroller.lamp_number >= 7 && i <=0)
        {
            this.transform.Rotate (new Vector3(0f,-88f,0f));
            i++;
        }
    }
}