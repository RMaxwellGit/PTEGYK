using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttackColliderBehaviour : MonoBehaviour
{
	ZombieBehaviour behaviour;

    // Start is called before the first frame update
    void Start()
    {
        behaviour = GetComponentInParent<ZombieBehaviour>();
    }

    public void OnTriggerEnter(Collider otherCollider) {
    	GameObject hitObject = otherCollider.gameObject;

        if (behaviour != null) {     
        	if (behaviour.GetIsDamaging() == true) {

        		if (hitObject.GetComponent<PlayerInputHandler>() != null) {
        			HealthSystem playerHealth = hitObject.GetComponent<HealthSystem>();

        			playerHealth.DoDamage(behaviour.attackDamage);
        		}
        	}
        } else {
            behaviour = GetComponentInParent<ZombieBehaviour>();
        }
    }
}
