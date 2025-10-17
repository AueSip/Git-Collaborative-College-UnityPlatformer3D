using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{

  GameObject playerChar;
  GameObject playerCamera;
  Vector2 v;
  Vector2 l;

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
    Looking(Time.deltaTime);

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
  
  void Looking(float deltaT)
    {
      Vector3 lookRot = new Vector3(0f, 0f, 0f);
      Vector3 playerRot = new Vector3(0f, 0f, 0f);
      playerRot.y = l.x;
      lookRot.x = l.y*-1;

      playerChar.transform.Rotate(playerRot * ReturnLookSpeed(deltaT));  
      playerCamera.transform.Rotate(lookRot * ReturnLookSpeed(deltaT));
    }

  float ReturnSpeed(float deltaT)
  {
    return SPEED * deltaT;
  }
    
  float ReturnLookSpeed(float deltaT)
    {
      return LOOKSPEED * deltaT;
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
        print("Moved");
        // IMPORTANT:
        // The given InputValue is only valid for the duration of the callback. Storing the InputValue references somewhere and calling Get<T>() later does not work correctly.
    }
}


