using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorielTriggerHide : IBonus
{
    public override void ApplyBonus(PlayerMoves player)
    {
        LevelManager.Instance.UnShowTuto();
    }

}
