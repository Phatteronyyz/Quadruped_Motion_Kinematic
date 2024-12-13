using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class walkmotionselect : MonoBehaviour
{
    public bool walkmotion;
    public void DropDown(int index)
    {
        switch(index)
        {
            case 0:
                walkmotion = false;
                break;
            case 1:
                walkmotion = true;
                break;
        }
    }
}
