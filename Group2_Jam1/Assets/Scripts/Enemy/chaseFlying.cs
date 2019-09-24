using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chaseFlying : MonoBehaviour
{
    private Transform player;
    private Animator anim;
    private GameObject playerObj;
    private int damage = 15;
    private int playerHP;
    private float initialTimer = 1f;
    private float afterTimer = 2.4f;
    private float timeCounter = 0f;
    private bool afterFirst = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerObj = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, this.transform.position) < 27)
        {
            Vector3 direction = player.position - this.transform.position;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

            anim.SetBool("isIdle", false);
            if (direction.magnitude > 1.6)
            {
                this.transform.Translate(0, 0, 0.15f);
                anim.SetBool("isFlying", true);
                anim.SetBool("isAttacking", false);
            }
            else
            {
                anim.SetBool("isAttacking", true);
                anim.SetBool("isFlying", false);

                if (timeCounter > initialTimer && !afterFirst)
                {
                    playerObj.SendMessage("takeDamage", damage);
                    FindObjectOfType<AudioManager>().Play("Damage");
                    afterFirst = true;
                    timeCounter = 0f;
                }
                else
                {
                    timeCounter = timeCounter + Time.deltaTime;
                }

                if (timeCounter > afterTimer && afterFirst)
                {
                    playerObj.SendMessage("takeDamage", damage);
                    FindObjectOfType<AudioManager>().Play("Damage");
                    timeCounter = 0f;
                }
                else
                {
                    timeCounter = timeCounter + Time.deltaTime;
                }
            }
        }
        else
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isFlying", false);
            anim.SetBool("isAttacking", false);
        }
    }
}
