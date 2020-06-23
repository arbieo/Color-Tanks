using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PowerBar : MonoBehaviour
{
    public List<Image> pips;

    public Color activeColor = Color.yellow;
    public Color inactiveColor = Color.gray;

    public void SetPower(int power)
    {
        for (int i = 0; i<pips.Count; i++)
        {
            if (i < power)
            {
                pips[i].color = activeColor;
            }
            else 
            {
                pips[i].color = inactiveColor;
            }
        }
    }
}