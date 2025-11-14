using System;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class MemorizeLine : MonoBehaviour
{
    [SerializeField] private Line[] _lines;
    private Line _line;
    private string _lineText;
    private string[] _possibleLines;
    
    [SerializeField] private GameObject _memorizePanel;
    [SerializeField] private TMP_Text _memorizeText;

    [SerializeField] private GameObject _performPanel;
    [SerializeField] private TMP_Text[] _options;
    
    [SerializeField] private bool _memorized = false;

    private void Start()
    {
        _memorizePanel.SetActive(!_memorized);
        _performPanel.SetActive(_memorized);
        if (_memorized)
        {
            if (_line == null)
            {
                _line = _lines[0];
                _lineText = _line.GetLine;
                _possibleLines = _line.GetAllLines;
            }

            for (int i = 0; i < 3; i++)
            {
                _options[i].text = _possibleLines[i];
            }
        }
        else
        {
            _line = _lines[Random.Range(0, _lines.Length)];
            _lineText = _line.GetLine;
            _memorizeText.text = _lineText;
            _memorized = true;
        }
    }

    public void SelectLine(bool isCorrect)
    {
        if (isCorrect) Debug.Log("Correct!!!!! :))) WOW!!!!! HOORAY");
        else Debug.Log("Wrong!!!!! :(");
    }
}
