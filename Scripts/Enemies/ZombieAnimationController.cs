using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimationController : MonoBehaviour
{
	Animator anim; //The animation system attatched to the zombie
	ZombieBehaviour behaviour; //The zombie's behaviour, used to know what it is currently doing

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        behaviour = GetComponent<ZombieBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("IsAttacking", behaviour.GetIsAttacking());
        // Debug.Log(anim.GetFloat("attackTime"));
    }
}
