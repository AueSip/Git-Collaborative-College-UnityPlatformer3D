using UnityEngine;

public class Script_StakeProjectile : MonoBehaviour
{


    private bool inUse = true;
    public float SPEED = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * SPEED * Time.deltaTime;
    }

    public void Disable()
    {
        GetComponent<CapsuleCollider>().enabled = false;
        GetComponent<CapsuleCollider>().isTrigger = false;
        inUse = false;
        this.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
    }

    public bool GetActive()
    {
        return inUse;
    }

}
