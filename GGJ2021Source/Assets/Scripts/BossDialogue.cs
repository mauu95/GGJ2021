using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDialogue : PlanetDialogue
{
    Enemy boss;
    private void Awake() {
        boss = GetComponentInParent<Enemy>();
    }
    
    protected override void DialogueEnd()
    {
        boss.active = true;
    }

    
}
