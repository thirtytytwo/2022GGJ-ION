using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H2 : Item
{
    public float forward;//��������Ծ�������
    public float up;//��������Ծ�������
    public float upForce;//��������
    protected override void SetType()
    {
        base.SetType();
        type = ItemType.H2;
    }

    public override void ReactionWithPlayer()
    {
        base.ReactionWithPlayer();
        player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * upForce, ForceMode2D.Force);
        if (Input.GetButtonDown("Jump"))
        {
            AudioManager.instance.PlayJumpStep();
            Vector2 dir = new Vector2(transform.right.x, transform.up.y);
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(forward * (transform.right == new Vector3(1, 0, 0) ? 1 : -1) * 10, up * 10));//�����ϵ���Ծ
        }
        Invoke("OverTimeDestroy", 1);
    }

    public override void Throw()
    {
        isNeedToReactionWithPlayer = false;
        player.GetComponent<Rigidbody2D>().AddForce(Vector2.down * -up);
        transform.SetParent(null);
        isNeedToReactionWithAnother = true;
    }

    private void OverTimeDestroy()
    {
        transform.SetParent(null);
        Destroy(gameObject);
    }
}
