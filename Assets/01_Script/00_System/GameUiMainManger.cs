using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUiMainManager : MonoBehaviour
{
    [SerializeField]
    private UiTextObject _texts;

    public void Initialization()
    {
        _texts = transform.GetChild(0).GetChild(0).GetChild(1).GetComponent<UiTextObject>();

        _texts.Init();

        _texts.SetUIText("Yay");
    }

    public void SetUIText(string text)
    {
        _texts.SetUIText(text); 
    }
}
