using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class Script_PlayerFlashlight : MonoBehaviour
{
    public float drain_Amount;
    

    public float drain_Time;
    GameObject flashlight;

    float maxcharge_Percent = 1;

    private Script_UI_Handler ui_Handler;

    Awaitable timer;
    float charge_Percent;
    bool enabledVal = true;
    Light lightVal;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public AudioSource newAudio;

    public float chargineRate;

    bool chargingNow = false;
    void Start()
    {   
        charge_Percent = maxcharge_Percent;
        flashlight = GameObject.Find("FLight");
        lightVal = flashlight.GetComponent<Light>();
        ui_Handler = GameObject.Find("Canvas").GetComponent<Script_UI_Handler>();
        ui_Handler.SetSliderPercentage(maxcharge_Percent);
         CalculatePercentage();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnFlashlight(InputValue value)
    {
        // Read value from control. The type depends on what type of controls.
        // the action is bound to.
        if (charge_Percent > 0f)
        {   
            enabledVal = !enabledVal;
            // IMPORTANT:
            newAudio.Play();
            lightVal.enabled = enabledVal;
           
        }
      

        // The given InputValue is only valid for the duration of the callback. Storing the InputValue references somewhere and calling Get<T>() later does not work correctly.
    }

    public async void CalculatePercentage()
    {   
        timer = Awaitable.WaitForSecondsAsync(drain_Time);
        await timer;
        if (enabledVal)
        {
            SetPercentage(charge_Percent - drain_Amount);
            
        }

        if (charge_Percent == 0f)
        {
            enabledVal = false;
            newAudio.Play();
            lightVal.enabled = enabledVal;
        }
        CalculatePercentage();

    }

    public void SetPercentage(float perc)
    {   
      
        charge_Percent =  Math.Clamp(perc, 0,maxcharge_Percent);
        ui_Handler.SetSliderPercentage(charge_Percent);
        if (charge_Percent >= maxcharge_Percent)
        {
            chargingNow = false;
        }
    }

    public async void ChargeFlashlight(float wait)
    {
       
        await Awaitable.WaitForSecondsAsync(wait);
        if (charge_Percent < maxcharge_Percent)
        {
            SetPercentage(charge_Percent + 0.2f);
            ChargeFlashlight(wait);
        }


        if (charge_Percent == 0f)
        {
            enabledVal = false;
            newAudio.Play();
            lightVal.enabled = enabledVal;
        }
        if (chargingNow)
        {
            ChargeFlashlight(wait); 
        }
        
    }
    
    public void StartCharge()
    {

        if (!chargingNow)
        {   
            chargingNow = true;
            ChargeFlashlight(chargineRate);
        }
     
        
    }
        
}


