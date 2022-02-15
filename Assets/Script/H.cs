using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H : Item
{
    protected override void SetType()
    {
        base.SetType();
        type = ItemType.H;
    }
    public override void ReactionWithAnotherItem()
    {
        base.ReactionWithAnotherItem();
        if(target == ItemType.O)
        {
            print("����ˮ");
            GameObject obj = Instantiate(InstantiateObj[0]);
            obj.transform.position = transform.position;
            Destroy(targetObj);
            Destroy(gameObject);
        }
        else if(target == ItemType.Cl)
        {
            print("������");
            GameObject obj = Instantiate(InstantiateObj[1]);
            obj.transform.position = transform.position;
            Destroy(targetObj);
            Destroy(gameObject);
        }

    }
}
