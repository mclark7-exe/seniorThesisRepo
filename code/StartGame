using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class NextScene : MonoBehaviour
{
    private Camera _camera;
    private GameObject _showtimeButton;
    [SerializeField] private int _cameraZoomSpeed = 20;
    private bool _zooming = false;
    
    public void StartGame()
    {
        _camera = FindFirstObjectByType<Camera>();
        _showtimeButton = GameObject.Find("Showtime Button");
        _zooming = true;
        StartCoroutine(WaitForFunction());
        
    }

    IEnumerator WaitForFunction()
    {
        _showtimeButton.SetActive(false);
        yield return new WaitForSeconds(1f);
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void Update()
    {
        if (_zooming) _camera.orthographicSize = Mathf.MoveTowards(_camera.orthographicSize, 0,  _cameraZoomSpeed * Time.deltaTime);
    }
}
