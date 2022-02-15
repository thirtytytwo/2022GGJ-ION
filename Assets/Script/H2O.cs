using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H2O : Item
{
    private void OnEnable()
    {
        Invoke("OverTimeDestroy", 2);
    }
    protected override void SetType()
    {
        base.SetType();
        type = ItemType.H2O;
        isNeedToReactionWithPlayer = true;
    }
    public override void ReactionWithAnotherItem()
    {
        base.ReactionWithAnotherItem();
        if (target == ItemType.NaCl)
        {
            GameObject obj1 = Instantiate(InstantiateObj[0]);//生成钠离子
            GameObject obj2 = Instantiate(InstantiateObj[1]);//生成氯离子
            obj1.transform.position = transform.position + new Vector3(-2, 0, 0);
            obj2.transform.position = transform.position + new Vector3(2, 0, 0);
            obj1.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 100);
            obj2.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 100);
            Destroy(targetObj);
            Destroy(gameObject);
        }
    }

    public override void ReactionWithPlayer()
    {
        base.ReactionWithPlayer();
        if(player != null && player.type == PlayerController.PlayerType.lightning)
        {
            GameObject obj1 = Instantiate(InstantiateObj[2]);//生成氧气
            GameObject obj2 = Instantiate(InstantiateObj[3]);//生成氢气
            obj1.transform.position = transform.position + new Vector3(-2, 0, 0);
            obj2.transform.position = transform.position + new Vector3(2, 0, 0);
            obj1.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 100);
            obj2.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 100);
            Destroy(gameObject);
        }
    }

    private void OverTimeDestroy()
    {
        Destroy(gameObject);
    }
}
