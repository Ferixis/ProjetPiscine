using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorielTrigger : IBonus {

    public override void ApplyBonus(PlayerMoves player)
    {
        LevelManager.Instance.NextStepTuto();
    }
}
