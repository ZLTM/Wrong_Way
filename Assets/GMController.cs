using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMController : MonoBehaviour
{
    public  GameObject ByMistake;
    public int danger_level;
    public int lamp_number;
    // Start is called before the first frame update

    public void danger_edit()
    {
        danger_level = danger_level+10;
        if(danger_level>=20)
        {
            ByMistake.SetActive(true);;
        }
    }

    public void increase_lamp()
    {
        lamp_number++;
    }
}
