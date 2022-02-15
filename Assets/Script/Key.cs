using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Item
{
    protected override void SetType()
    {
        base.SetType();
        type = ItemType.None;
    }

    public override void ReactionWithPlayer()
    {
        base.ReactionWithPlayer();
        Invoke("ChangeLevel", 1);
        isNeedToReactionWithPlayer = false;
    }
    private void ChangeLevel()
    {
        AudioManager.instance.WintheAudio();
        GameManager.instance.GoToNextLevel();
        Destroy(gameObject);
    }
}
