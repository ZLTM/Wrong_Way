using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hide_monster : MonoBehaviour
{
    public  GameObject Monster;

    private void OnTriggerEnter(Collider other)
    {
        controlador_moustro controlador_moustro = Monster.GetComponent<controlador_moustro>();
        controlador_moustro.activado = false;      
    }
}
