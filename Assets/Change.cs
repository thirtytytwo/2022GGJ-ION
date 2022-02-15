using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change : MonoBehaviour
{
    public void Click()
    {
        GameManager.instance.GoToNextLevel();
    }
}
