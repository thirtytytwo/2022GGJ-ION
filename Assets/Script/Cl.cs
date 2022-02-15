using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cl : Item
{
    protected override void SetType()
    {
        base.SetType();
        type = ItemType.Cl;
    }

    public override void ReactionWithAnotherItem()
    {
        base.ReactionWithAnotherItem();
        if(target == ItemType.Na)
        {
            print("生成盐");
            GameObject obj = Instantiate(InstantiateObj[0]);
            obj.transform.position = transform.position;
            Destroy(targetObj);
            Destroy(gameObject);
        }
        else if(target == ItemType.H)
        {
            print("生成酸");
            GameObject obj = Instantiate(InstantiateObj[1]);
            obj.transform.position = transform.position;
            Destroy(targetObj);
            Destroy(gameObject);
        }
    }
}
