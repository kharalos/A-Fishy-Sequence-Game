using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairManager : MonoBehaviour
{
    public Image center, left, right;
    Color original = new Color(255, 255, 255, .1f);
    Color blue = new Color(0, 255, 255, .1f);
    Color red = new Color(255, 0, 0, .1f);
    public void LeftBlue()
    {
        left.color = Color.Lerp(left.color, blue, .5f);
    }
    public void NormalizeLeft()
    {
        left.color = Color.Lerp(left.color, original, .5f);
    }
    public void RightRed()
    {
        right.color = Color.Lerp(right.color, red, .5f);
    }
    public void NormalizeRight()
    {
        right.color = Color.Lerp(right.color, original, .5f);
    }
}
