using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCoordinator : MonoBehaviour
{
    //This class should eventually be able to send these modifiers to BulletBehaviour so that it can modify the damage
    //but right now I can't find a quick solution for figuring out which limb should be used and i just want to finish the hitbox system so w/e
    public float headDamagePercent;
    public float armDamagePercent;
    public float torsoDamagePercent;
    public float legDamagePercent;

    public float GetModifier() {
        return 1;
    }
}
