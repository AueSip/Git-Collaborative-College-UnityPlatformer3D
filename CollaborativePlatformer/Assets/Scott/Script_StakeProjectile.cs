using UnityEngine;

public class Script_StakeProjectile : MonoBehaviour
{

   
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
        this.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
        Destroy(this.gameObject, 2);
    }

}
