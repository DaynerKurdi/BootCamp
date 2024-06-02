using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiTextObject : MonoBehaviour
{
    private TMP_Text _myGreatTextHolder;

    public void Init()
    {
        _myGreatTextHolder = GetComponent<TMP_Text>();
    }

    public void SetUIText(string input)
    {
        _myGreatTextHolder.text = input;
    }
}
