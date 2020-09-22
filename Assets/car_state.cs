using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car_state : MonoBehaviour
{
    public GameObject car;
    public GameObject wheels;
    // Start is called before the first frame update

    // Update is called once per frame
    void stop_car()
    {
        car.GetComponent<CarController >().enabled = false;
        wheels.SetActive(false);
    }

    void start_car()
    {
        car.GetComponent<CarController >().enabled = true;
        wheels.SetActive(true);
    }
}
