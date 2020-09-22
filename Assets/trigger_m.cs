using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_m : MonoBehaviour
{
    controlador_moustro control_m;
    // Start is called before the first frame update
    void Start()
    {
        control_m= GetComponentInParent<controlador_moustro>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            control_m.StartCoroutine("action1");
        }
        
    }
}
