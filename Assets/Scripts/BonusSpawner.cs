using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BonusSpawner : MonoBehaviour
{
    [SerializeField] private List<BonusData> _bonuseData;

    [SerializeField] private int _poolCount;
    [SerializeField] private GameObject _bonusPrefab;

    [SerializeField] private float _minHeight;
    [SerializeField] private float _maxHeight;
    [SerializeField] private float _time;

    [Header("The higher this value, the less often bonuses fall out")]
    [SerializeField] private int _rarity;

    [Inject] private DiContainer _diContainer;

    private Queue<GameObject> _currentBonuses;

    public float Time 
    {   
        get { return _time; }
        private set { }
    }

    private void Awake()
    {
        EventManager.AddListener<StopMovementEvent>(StopSpawn);
        EventManager.AddListener<ContinueMovementEvent>(ContinueSpawn);
    }

    private void Start()
    {
        _currentBonuses = new Queue<GameObject>();

        for (var i = 0; i < _poolCount; i++)
        {
            var prefab = _diContainer.InstantiatePrefab(_bonusPrefab, transform.position, Quaternion.identity, transform);
            prefab.SetActive(false);
            _currentBonuses.Enqueue(prefab);
        }

        Bonus.OnRemove += ReturnBonus;
    }

    public void StartSpawn()
    {
        InvokeRepeating(nameof(Spawn), _time, _time);
    }

    public void ContinueSpawn(ContinueMovementEvent evt)
    {
        StartSpawn();
    }

    public void StopSpawn(StopMovementEvent evt)
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        if (_currentBonuses.Count > 0 && Random.Range(0, _rarity) == 0)
        {
            var bonus = _currentBonuses.Dequeue();
            bonus.SetActive(true);
            bonus.GetComponent<Bonus>().Initialization(_bonuseData[Random.Range(0, _bonuseData.Count)]);
            bonus.transform.position += Vector3.up * Random.Range(_minHeight, _maxHeight);
        }
    }

    public void ReturnBonus(GameObject bonus)
    {
        bonus.transform.position = transform.position;
        bonus.SetActive(false);
        _currentBonuses.Enqueue(bonus);
    }
}
