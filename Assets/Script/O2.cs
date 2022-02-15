using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O2 : Item
{
    protected override void SetType()
    {
        base.SetType();
        type = ItemType.O2;
    }

    public override void ReactionWithAnotherItem()
    {
        base.ReactionWithAnotherItem();
        if (target == ItemType.C && player.type == PlayerController.PlayerType.Fire)
        {
            Destroy(targetObj);
            Destroy(gameObject);
        }
        Invoke("LateSetBool", 1f);
    }

    private void LateSetBool()//��Ի��ȡ��ɫʵʱ����̬�����õģ���ʱһ��رշ�Ӧ�Ľӿ�
    {
        isNeedToReactionWithAnother = false;
    }
}
