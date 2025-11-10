using UnityEngine;
using UnityEngine.InputSystem;

public class Script_PlayerController : MonoBehaviour
{

  GameObject playerChar;
  GameObject playerCamera;

  public Script_Interact InteractComp;
  Vector2 v;
  Vector2 l;

  Vector3 lookRot;

  public float SPEED = 600;
  public float LOOKSPEED = 25;
  // Start is called once before the first execution of Update after the MonoBehaviour is created

  private Script_UI_Handler ui_Handler;
  //Simple inventory where you hold only one item at a time
  private string inventory_Item;

  void Start()
  { 
    playerChar = GameObject.Find("PF_Player");
    playerCamera = GameObject.Find("PCamera");
    ui_Handler = GameObject.Find("Canvas").GetComponent<Script_UI_Handler>();
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
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

  //This grabs the interaction script
  public void OnInteract(InputValue value)
  {
    InteractComp.CallInteract(playerChar);
  }
    

  //Set the inventory item and get item
  public string SetInventoryItem(string itemName)
  {
    inventory_Item = itemName;
    ui_Handler.SetItemInHand(inventory_Item);
    return inventory_Item;
    }

 public string GetInventoryItem()
  {
    return inventory_Item;
    }

  // If you are interested in the value from the control that triggers an action, you can declare a parameter of type InputValue.
  public void OnMove(InputValue value)
  {
    // Read value from control. The type depends on what type of controls.
    // the action is bound to.
    v = value.Get<Vector2>();
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


