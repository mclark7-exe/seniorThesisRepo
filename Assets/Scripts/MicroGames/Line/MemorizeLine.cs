using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
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
    [SerializeField] private GameManager _gameManager;
    
    [SerializeField] private float _loseScoreValue = -30f;
    [SerializeField] private float _winScoreValue = 30f;

    private void Start()
    {
        _gameManager = GameManager.Instance;
        Debug.Log(_gameManager);
        _memorized = _gameManager.IsLineMemorized();
        
        _memorizePanel.SetActive(!_memorized);
        _performPanel.SetActive(_memorized);
        if (_memorized)
        {
            _line = _gameManager.GetMemorizedLine();
            Debug.Log(_line.GetLine);
            if (_line == null)
            {
                _line = _lines[0];
            }
            
            _lineText = _line.GetLine;
            _possibleLines = _line.GetAllLines;

            for (int i = 0; i < 3; i++)
            {
                _options[i].text = _possibleLines[i];
            }
            
            _gameManager.SetLineMemorized(false);
        }
        else
        {
            _line = _lines[Random.Range(0, _lines.Length)];
            _lineText = _line.GetLine;
            _memorizeText.text = _lineText;
            _gameManager.SetLineMemorized(true);
            _gameManager.SetMemorizedLine(_line);
        }
    }

    public void SelectLine(int line)
    {
        if (_possibleLines[line] == _lineText) GameManager.Instance.AddScore(_winScoreValue);
        else GameManager.Instance.AddScore(_loseScoreValue);
    }
}
