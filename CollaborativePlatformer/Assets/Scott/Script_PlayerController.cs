using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{

  GameObject playerChar;
  GameObject playerCamera;
  Vector2 v;
  Vector2 l;

  Vector3 lookRot;

  public float SPEED = 600;
  public float LOOKSPEED = 25;
  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  { 
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
    playerChar = GameObject.Find("Player");
    playerCamera = GameObject.Find("PCamera");
    print(playerChar.name);
    print(playerCamera.name);
    }

  // Update is called once per frame
  void Update()
  {
    Movement(Time.deltaTime);
    Looking();

  }

  void FixedUpdate()
  {
     
  }

  void Movement(float deltaT)
  {
    Vector3 move = new Vector3(0f, 0f, 0f);
    move.x = v.x;
    move.z = v.y;
    playerChar.transform.position = playerChar.transform.position + (playerChar.transform.forward * (move.z * ReturnSpeed(deltaT)));
    playerChar.transform.position = playerChar.transform.position + (playerChar.transform.right * (move.x * ReturnSpeed(deltaT)));
  }
  
  void Looking()
    {
     
     
      lookRot.y += (l.x * LOOKSPEED * Time.deltaTime);

    lookRot.x += (l.y *-1 * LOOKSPEED * Time.deltaTime);
    lookRot.x = Mathf.Clamp(lookRot.x, -90f, 90f);
    playerChar.transform.eulerAngles = new Vector3(
      playerChar.transform.eulerAngles.x,
      lookRot.y + 180,
      playerChar.transform.eulerAngles.z
    );

    playerCamera.transform.eulerAngles = new Vector3(
      lookRot.x,
      playerChar.transform.eulerAngles.y,
      playerChar.transform.eulerAngles.z
    );  
    
    }

  float ReturnSpeed(float deltaT)
  {
    return SPEED * deltaT;
  }
    

 

    public void OnInteract()
    {
       print("Interacted");
    }

  // If you are interested in the value from the control that triggers an action, you can declare a parameter of type InputValue.
  public void OnMove(InputValue value)
  {
    // Read value from control. The type depends on what type of controls.
    // the action is bound to.
    v = value.Get<Vector2>();
    print("Moved");
    // IMPORTANT:
    // The given InputValue is only valid for the duration of the callback. Storing the InputValue references somewhere and calling Get<T>() later does not work correctly.
  }
  
   public void OnLook(InputValue value)
    {
    // Read value from control. The type depends on what type of controls.
    // the action is bound to.
       l = value.Get<Vector2>();
        // IMPORTANT:
        // The given InputValue is only valid for the duration of the callback. Storing the InputValue references somewhere and calling Get<T>() later does not work correctly.
    }
}


