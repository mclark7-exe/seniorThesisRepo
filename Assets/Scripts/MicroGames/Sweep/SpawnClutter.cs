using UnityEngine;

public class SpawnClutter : MonoBehaviour
{
    [SerializeField] int _minClutter = 6;
    [SerializeField] int _maxClutter = 12;
    [SerializeField] GameObject _clutterPrefab;
    [SerializeField] float _minX, _maxX, _minY, _maxY, _minScale, _maxScale;

    void Start()
    {
        for (int i = 0; i < Random.Range(_minClutter, _maxClutter); i++)
        {
            float x = Random.Range(_minX, _maxX);
            float y = Random.Range(_minY, _maxY);
            float scale = Random.Range(_minScale, _maxScale);
            
            Quaternion rotation = Quaternion.Euler(0,0,Random.Range(0,360));
            GameObject newClutter = Instantiate(_clutterPrefab, new Vector3(x, y, 0), rotation);
            newClutter.transform.localScale = new Vector3(scale, scale, 1);
        }
    }

}
