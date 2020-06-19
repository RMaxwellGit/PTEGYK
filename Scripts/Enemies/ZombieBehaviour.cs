using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviour : MonoBehaviour
{
	public float speed;
    public float attackRange;
    public float attackDamage;
    public float turnScaleFactor;

	GameObject player;
	Rigidbody myBody;

    public float attackDetectionStart;
    BoxCollider attackCollider;

    bool isAttacking;
    bool isDamaging;

    public float lengthToReturnToStandardValues;
    bool recentlySpawned;

    public ZombieSoundController soundController;

    // Start is called before the first frame update
    void Start()
    {
        player = References.player;
        myBody = GetComponent<Rigidbody>();

        isAttacking = false;

        if (player) {
            transform.LookAt(player.transform.position);
        }
        StartCoroutine(EntryBehaviour(lengthToReturnToStandardValues));
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAttacking) {
            if (Proximity.CheckFacing(transform.Find("ZombieLookPosition").gameObject, player, attackRange)) {
                StartCoroutine("DoAttack");
            } else {
                if ((player != null)&&(!recentlySpawned)) {
                    //turn towards the player
                    Vector3 relativePos = player.transform.position - transform.position;
                    Quaternion lookDir = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(relativePos, Vector3.up), Time.deltaTime/turnScaleFactor);
                    transform.rotation = lookDir;
                    //Move towards the player
                    myBody.velocity = transform.forward * speed;
                }
            }
        }
        
        myBody.velocity += (Physics.gravity/References.entityGravMod);
    }

    public bool GetIsAttacking() {
        return isAttacking;
    }

    public bool GetIsDamaging() {
        return isDamaging;
    }

    IEnumerator DoAttack() {
        isAttacking = true;
        //play an attack sound
        soundController.PlayAttackSound();
        //stop moving until the attack animation is done
        myBody.velocity = transform.forward * 0;
        //get attack anim length
        float attackLength = GetComponent<AnimLengthFinder>().GetAnimLength();
        //Attack collision only matter when the melee attack should be dealing damage, so wait to start checking for collisions
        yield return new WaitForSeconds(attackDetectionStart);
        //when that timer ends, start checking for collisions with the swiping arm and the player
        // start a timer for the length of the rest of the attack
        isDamaging = true;
        yield return new WaitForSeconds(attackLength - attackDetectionStart);
        isAttacking = false;
        isDamaging = false;
        yield return null;
    }

    IEnumerator EntryBehaviour(float length) {
        float temp = speed;
        speed *= 2;
        recentlySpawned = true;

        yield return new WaitForSeconds(length);

        speed = temp;
        recentlySpawned = false;
    }
}
