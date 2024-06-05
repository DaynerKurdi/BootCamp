using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUiMainManager : MonoBehaviour
{
    private UiTextObject _texts;

    public void Initialize()
    {
        _texts = transform.GetChild(0).GetChild(0).GetChild(1).GetComponent<UiTextObject>();

        _texts.Initialize();

        //_texts.SetUIText();

        EventSystemReference.Instance.UpdateUiScoreEventTextHandler.AddListener(SetUIText);
    }

    public void SetUIText(int score)
    {
        _texts.SetUIText(score.ToString()); 
    }
}
