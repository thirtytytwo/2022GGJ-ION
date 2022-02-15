using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O : Item {

    protected override void SetType()
    {
        base.SetType();
        type = ItemType.O;
    }

    public override void ReactionWithAnotherItem()
    {
        base.ReactionWithAnotherItem();
        print(target);
        if (target == ItemType.H)
        {
            GameObject obj = Instantiate(InstantiateObj[0]);
            obj.transform.position = transform.position;
            Destroy(targetObj);
            Destroy(gameObject);
        }
    }
}
    
