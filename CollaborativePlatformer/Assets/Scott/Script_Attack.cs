using UnityEngine;
using UnityEngine.InputSystem;
public class Script_Attack : MonoBehaviour
{

    public GameObject pf_stake;

    private bool isenabled = false;
    GameObject player;
    GameObject stake;

    GameObject stakeob;
    public int Ammo_Count = 3;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
        stake = GameObject.Find("Stake");
        stakeob = GameObject.Find("StakeObj");
    }
    


    // Update is called once per frame
    void Update()
    {

    }
    public void OnAttack(InputValue value)
    {
        if (isenabled)
        {
             AttackStake();
        }
       
    }


    void AttackStake()
    {
        if (Ammo_Count > 0)
        {
            Ammo_Count -= 1;
            Instantiate(pf_stake, stake.transform.position, stake.transform.rotation);

        }

    }

    public void DisableStake()
    {
        isenabled = false;
        stakeob.GetComponent<MeshRenderer>().enabled = false;
    }
    
    public void EnableStake()
    {
        isenabled = true;
        stakeob.GetComponent<MeshRenderer>().enabled = true;
    }
}
