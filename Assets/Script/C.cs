using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C : Item
{
    protected override void SetType()
    {
        base.SetType();
        type = ItemType.C;
    }
}
