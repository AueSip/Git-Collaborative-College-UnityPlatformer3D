using UnityEngine;
using UnityEngine.InputSystem;
public class Script_Attack : MonoBehaviour
{

    public GameObject pf_stake;

    GameObject player;
    GameObject stake;
    public int Ammo_Count = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
        stake = GameObject.Find("Stake");
    }
    


    // Update is called once per frame
    void Update()
    {

    }
    public void OnAttack(InputValue value)
    {
        AttackStake();
    }
    

    void AttackStake()
    {
        if (Ammo_Count > 0)
        {
            Ammo_Count -= 1;
            Instantiate(pf_stake, stake.transform.position, stake.transform.rotation);
        }
        
    }
}
