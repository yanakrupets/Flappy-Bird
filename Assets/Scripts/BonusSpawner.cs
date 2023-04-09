using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BonusSpawner : Spawner
{
    [SerializeField] private List<BonusData> _bonuseData;

    [SerializeField] private int _poolCount;
    [SerializeField] private GameObject _bonusPrefab;

    [SerializeField] private float _minHeight;
    [SerializeField] private float _maxHeight;
    [SerializeField] private float _time;

    [Header("The higher this value, the less often bonuses fall out")]
    [SerializeField] private int _rarity;

    private Queue<GameObject> _bonuses;

    public float Time 
    {   
        get { return _time; }
        private set { }
    }

    private void Start()
    {
        _bonuses = new Queue<GameObject>();

        for (var i = 0; i < _poolCount; i++)
        {
            var prefab = _diContainer.InstantiatePrefab(_bonusPrefab, transform.position, Quaternion.identity, transform);
            prefab.SetActive(false);
            _bonuses.Enqueue(prefab);
        }

        Bonus.OnRemove += ReturnBonus;
    }

    public override void StartSpawn(StartSpawnEvent evt)
    {
        InvokeRepeating(nameof(Spawn), _time, _time);
    }

    public override void StopSpawn(StopSpawnEvent evt)
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        if (_bonuses.Count > 0 && Random.Range(0, _rarity) == 0)
        {
            var bonus = _bonuses.Dequeue();
            bonus.SetActive(true);
            bonus.GetComponent<Bonus>().Initialization(_bonuseData[Random.Range(0, _bonuseData.Count)]);
            bonus.transform.position += Vector3.up * Random.Range(_minHeight, _maxHeight);
        }
    }

    private void ReturnBonus(GameObject bonus)
    {
        bonus.transform.position = transform.position;
        bonus.SetActive(false);
        _bonuses.Enqueue(bonus);
    }
}
