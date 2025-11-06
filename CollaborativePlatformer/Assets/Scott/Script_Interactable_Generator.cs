using UnityEngine;
using UnityEngine.UI;

public class Script_Interactable_Generator : Script_Interactable_Base
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private bool lightv = true;
    public Light lightObj;

    
    public override void Interacted()
    {
        print("GENINTERACTED");
        if (GetInteractable() == true)
        {
            SetInteractable(false);
            gameInstance.GeneratorReactivated();
            ToggleLight();
        };
       
        

    }

    public void ToggleLight()
    {
        lightv = !lightv;
        if (lightv)
        {
            lightObj.color = Color.white;
        }
        if (!lightv)
        {
             lightObj.color = Color.red;
        }
    }
    
    public void DeactivateGenerator()
    {
        SetInteractable(true);
        ToggleLight();
        
    }
}
