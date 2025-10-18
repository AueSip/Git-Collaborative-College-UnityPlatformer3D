using UnityEngine;
using UnityEngine.InputSystem;


public class Script_PlayerFlashlight : MonoBehaviour
{
    GameObject flashlight;

    bool enabledVal = true;
    Light lightVal;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        flashlight = GameObject.Find("FLight");
        lightVal = flashlight.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnFlashlight(InputValue value)
    {
        // Read value from control. The type depends on what type of controls.
        // the action is bound to.

        enabledVal = !enabledVal;
        // IMPORTANT:

        lightVal.enabled = enabledVal;
        
        // The given InputValue is only valid for the duration of the callback. Storing the InputValue references somewhere and calling Get<T>() later does not work correctly.
    }
}
