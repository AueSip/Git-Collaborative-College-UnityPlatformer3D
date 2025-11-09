using UnityEngine;

public class Script_GasStationStatus : MonoBehaviour
{

    public Light light_GasStation;
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
            light_GasStation.color = Color.white;
        }
        if (!powered)
        {
             light_GasStation.color = Color.red;
        }    
    }
}   
