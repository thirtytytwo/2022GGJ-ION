using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HCl : Item
{
    public Vector2 DeadRadiusPosAdd;//������ײԭ�������
    protected override void SetType()
    {
        base.SetType();
        type = ItemType.HCl;
        isNeedToReactionWithPlayer = true;
        isNeedToReactionWithAnother = true;
    }

    public override void ReactionWithAnotherItem()
    {
        base.ReactionWithAnotherItem();
        if (target == ItemType.Fe)
        {
            Destroy(targetObj);
            Destroy(gameObject);
        }
        else if (target == ItemType.Na)
        {
            GameObject obj = Instantiate(InstantiateObj[0]);//����NaCl
            obj.transform.position = transform.position;
            Destroy(targetObj);
            Destroy(gameObject);
        }
    }

    public override void ReactionWithPlayer()
    {
        //base.ReactionWithPlayer();
        Vector2 DeadRadiusPos = (Vector2)transform.position + DeadRadiusPosAdd;//����������ײԭ�������
        Collider2D hit = Physics2D.OverlapCircle(DeadRadiusPos, radius, layer);//ʵ�ֹ���
        if (hit != null && hit.GetComponent<PlayerController>() != null)
        {
            player = hit.transform.GetComponent<PlayerController>();
        }
        if (player != null)
        {
            print("��������");
            AudioManager.instance.PlaydeathAudio();
            player = null;
            GameManager.instance.PlayerDie();
        }
    }
    public override void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position+ (Vector3)DeadRadiusPosAdd, radius);//������ʶ
    }
}
