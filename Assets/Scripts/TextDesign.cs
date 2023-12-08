using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextDesign : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TextMeshProUGUI text2;
    void Update()
    {
        Color randomColor = new Color(Random.value, Random.value, Random.value, 1f);
        text.color = randomColor;
        text2.color = randomColor;
    }
}
