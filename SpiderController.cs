using UnityEngine;

public class SpiderController : MonoBehaviour
{

    private const int chaseDistance = 20;

    private const int attackDistance = 7;
    public Transform player;
    public float SpiderWalkSpeed = 5;
    private Animator spiderAnim;
    private Vector3 direction;
    public SpiderState spiderState;
    public Transform shootingPoint;
    public GameObject poison;

    public void Awake()
    {
        spiderAnim = GetComponent<Animator>();
        spiderState = SpiderState.idle;
    }

    private void FixedUpdate()
    {
        direction = player.position - transform.position;

        if (Vector3.Distance(player.position, transform.position) < chaseDistance)
        {
            HandleAnimationMovementInArea();
        }
        else
        {
            HandleAnimationMovementOutArea();
        }
    }

    private void HandleAnimationMovementInArea()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.1f);

        spiderAnim.SetBool("isIdle", false);

        if (direction.magnitude > attackDistance)
        {
            transform.Translate(0, 0, 0.05f);

            spiderAnim.SetBool("isAttacking", false);
            spiderAnim.SetBool("isWalking", true);
            spiderState = SpiderState.walking;

        }
        else
        {
            spiderAnim.SetBool("isWalking", false);
            spiderAnim.SetBool("isAttacking", true);
            spiderState = SpiderState.attack;
        }
    }

    private void HandleAnimationMovementOutArea()
    {
        spiderAnim.SetBool("isAttacking", false);
        spiderAnim.SetBool("isWalking", false);
        spiderAnim.SetBool("isIdle", true);
        spiderState = SpiderState.idle;
    }

    public void DealDamage()
    {
        ShootPoison();
    }

    private void ShootPoison()
    {
        AudioManager.instance.Play("SpiderHit");
        Instantiate(poison, shootingPoint.position, shootingPoint.rotation);
    }
    public enum SpiderState
    {
        idle,
        attack,
        walking,
        stop,
    }
}
