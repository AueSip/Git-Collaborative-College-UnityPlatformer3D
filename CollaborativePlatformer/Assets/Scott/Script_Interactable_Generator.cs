using UnityEngine;
using UnityEngine.UI;

public class Script_Interactable_Generator : Script_Interactable_Base
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private bool lightv = true;
    public Light lightObj;

    readonly float timeForGreen = 0.75f;

    public AudioSource sound_Generator_Activated;
    public AudioSource sound_Generator_Enabled;
    
    public override void Interacted(GameObject player)
    {   
        print("GENINTERACTED");
        if (GetInteractable() == true)
        {
            SetInteractable(false);
            gameInstance.GeneratorReactivated();
            
            ToggleGreenLight();
        };
       
        

    }

    public void ToggleLight()
    {
        lightv = !lightv;
        if (lightv)
        {
            lightObj.color = Color.white;
            sound_Generator_Enabled.Play();
        }
        if (!lightv)
        {
            lightObj.color = Color.red;
            sound_Generator_Enabled.Stop();
        }
    }

    public void DeactivateGenerator()
    {
        SetInteractable(true);
        ToggleLight();

    }
    
    public async void ToggleGreenLight()
    {
        lightObj.color = Color.green;
        sound_Generator_Activated.Play();
        await Awaitable.WaitForSecondsAsync(timeForGreen);
        ToggleLight();

    }
}
