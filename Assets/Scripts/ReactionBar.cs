using System;
using UnityEngine;
using UnityEngine.UI;

public class ReactionBar : MonoBehaviour
{
    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    void Update()
    {
        _image.fillAmount = (GameManager.GetAudienceReaction() / 100f);
    }
}
