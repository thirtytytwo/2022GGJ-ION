using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Na : Item
{
    protected override void SetType()
    {
        base.SetType();
        type = ItemType.Na;
    }

    public override void ReactionWithAnotherItem()
    {
        base.ReactionWithAnotherItem();
        if(target == ItemType.Cl || target == ItemType.HCl)
        {   
            print("Éú³ÉÑÎ");
            GameObject obj = Instantiate(InstantiateObj[0]);
            obj.transform.position = transform.position;
            Destroy(targetObj);
            Destroy(gameObject);
        }
        
    }
}
