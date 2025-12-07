using System;
using UnityEngine;
using UnityEngine.UI;

public class ReactionBar : MonoBehaviour
{
    private GameManager _manager;
    private Image _image;

    private void Start()
    {
        _manager = GameManager.Instance;
        _image = GetComponent<Image>();
    }

    void Update()
    {
        _image.fillAmount = (_manager.GetAudienceReaction() / 100f);
    }
}
