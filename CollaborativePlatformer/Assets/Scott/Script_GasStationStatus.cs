using System.Collections.Generic;
using UnityEngine;

public class Script_GasStationStatus : MonoBehaviour
{

    public List<Light> light_GasStation;
    public bool powered;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void ToggleLight(bool Value)
    {   ;
        powered = Value;
        if (powered)
        {   
            foreach (Light light in light_GasStation)
            {
                light.color = Color.white;
            }
            
        }
        if (!powered)
        {
           foreach (Light light in light_GasStation)
            {
                light.color = Color.red;
            }
        }    
    }
}   
