using System;
using UnityEngine;

public class CarFollow : MonoBehaviour
{
    private GameObject activeCar;
    private bool carTypeSet = false;

    // Update is called once per frame
    void Update()
    {
        if(carTypeSet)
        {
            this.transform.position = activeCar.transform.position;
            this.transform.rotation = activeCar.transform.rotation;
        }
    }

    public void SetActiveCar(GameObject activeCar_)
    {
        activeCar = activeCar_;
        carTypeSet = true;
    }
}
