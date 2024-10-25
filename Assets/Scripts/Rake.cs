using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;

public  enum STATE
{
    WALK,
    ATTACK,
    DIE,
}

public class Rake : MonoBehaviourPunCallbacks
{    
    [SerializeField] STATE state;
    [SerializeField] Animator animator;
    [SerializeField] GameObject destination;
    [SerializeField] NavMeshAgent navMeshAgent;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        state = STATE.WALK;
        destination = GameObject.Find("Nexus");
    }
    void Update()
    {
        //이동하고자 하는위치를 너어준다
        //navMeshAgent.SetDestination(destination.transform.position);
        //transform.LookAt(destination.transform.position);

        if (state == STATE.WALK)
        {
            Walk();
           
        }
        else if (state == STATE.ATTACK)
        {
            Attcak();
        }
        else if(state == STATE.DIE) 
        {
            Die();
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Nexus"))
        {
            state = STATE.ATTACK;
        }
    }


    public void Walk()
    {
        Debug.Log("Walk");
        animator.Play("Walk");
        navMeshAgent.SetDestination(destination.transform.position);
        transform.LookAt(destination.transform.position);
    }

    public void Attcak()
    {
        Debug.Log("Attcak");
        animator.Play("Attack1");
    }

    public void Die()
    {
        Debug.Log("Die!!!!");
        
        animator.Play("Die");
        PhotonNetwork.Destroy(gameObject);
    }



}
