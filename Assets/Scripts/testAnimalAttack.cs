using UnityEngine;
using System.Collections;

public class testAnimalAttack : MonoBehaviour
{
    private bool attacking = false;
    public float attackTimer = 0;
    public float attackRate = 0.3f;
    public float attackCd = 0;
    public float attackCdRate = 5;

    private Animator anim;
    public BoxCollider attackTrigger;
    // Use this for initialization
    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
        ResetAttack();

    }
    void Attack()
    {
        if (Input.GetMouseButtonDown(0) && !attacking && attackCd <= 0)
        {
            attacking = true;
            attackTimer = attackRate;
            attackTrigger.enabled = true;
            attackCd = attackCdRate;
        }

    }

    void ResetAttack()
    {
        if (attacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackTrigger.enabled = false;
            }
            anim.SetBool("Attacking", attacking);
        }
        else if (!attacking && attackCd > 0)
        {

            attackCd -= Time.deltaTime;
        }
    }
}

