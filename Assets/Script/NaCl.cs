using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaCl : Item
{
    
    protected override void SetType()
    {
        base.SetType();
        type = ItemType.NaCl;
        isNeedToReactionWithAnother = true;
    }

    public override void ReactionWithAnotherItem()
    {
        base.ReactionWithAnotherItem();
        if(target == ItemType.H2O)
        {
            print("生成两个离子");
            GameObject obj1 = Instantiate(InstantiateObj[0]);
            GameObject obj2 = Instantiate(InstantiateObj[1]);
            obj1.transform.position = transform.position + new Vector3(-2, 0, 0);
            obj2.transform.position = transform.position + new Vector3(2, 0, 0);
            Destroy(gameObject);
            Destroy(targetObj);
            obj1.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 100);
            obj2.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 100);
        }
    }
}
