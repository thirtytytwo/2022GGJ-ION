using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H2 : Item
{
    public float forward;//氢气上跳跃横向的力
    public float up;//氢气上跳跃纵向的里
    public float upForce;//上升的力
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
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(forward * (transform.right == new Vector3(1, 0, 0) ? 1 : -1) * 10, up * 10));//氢气上的跳跃
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
