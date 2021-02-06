using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Genetal Settings")]
    [Space]
    [SerializeField] private GameObject _objectsContainer;
    [SerializeField] private float _delayBetweenEvents;

    [Header("Enemies Settings")]
    [Space]
    [SerializeField] private GameObject[] _enemiesPrefabs;
    [SerializeField] private AnimationCurve _spawnEnemyRateFromScore;

    [Header("Asteroids Settings")]
    [Space]
    [SerializeField] private GameObject[] _asteroids;
    [SerializeField] private int _minAsteroidsNumber;
    [SerializeField] private int _maxAsteroidsNumber;
    [SerializeField] private float _minSpawnAsteroidsTime;
    [SerializeField] private float _maxSpawnAsteroidsTime;
    [SerializeField] private float _timeBetweenAsteroids;

    [Header("Boss Settings")]
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private GameObject[] _bossPrefabs;
    [SerializeField] private int _destroyedEnemiesNumberForSpawnBoss;
    [SerializeField] private int _stepDestroyedEnemiesNumberForNextPawnBoss;


    private float _spawnEnemyRate;
    private bool _canSpawnEnemies;
    private bool _canSpawnAsteroids;

    private float _nextSpawnAsteroidsTime;

    public static SpawnManager Instance { get; set; }
    void Awake()
    {
        Instance = this;
        _spawnEnemyRate = _spawnEnemyRateFromScore[0].value;
        _canSpawnEnemies = true;
        _canSpawnAsteroids = true;
        _nextSpawnAsteroidsTime = Time.time + Random.Range(_minSpawnAsteroidsTime, _maxSpawnAsteroidsTime);
    }
    void Start()
    {
        StartSpawnProccess();
    }

    public void StartSpawnProccess()
    {
            StartCoroutine("SpawnEnemies");
            StartCoroutine("SpawnAsteroids");
    }

    private IEnumerator SpawnEnemies()
    {
        while (!GameManager.Instance.IsGameOver)
        {
            if (_canSpawnEnemies)
            {
                GameObject newEnemy = Instantiate(GetRandomEnemy());
                newEnemy.transform.SetParent(_objectsContainer.transform, false);
                if(GameManager.Instance.DestroyedEnemiesCount >= _destroyedEnemiesNumberForSpawnBoss)
                {
                    _destroyedEnemiesNumberForSpawnBoss += _stepDestroyedEnemiesNumberForNextPawnBoss;
                    GameManager.Instance.DestroyedEnemiesCount = 0;
                    yield return new WaitForSeconds(_delayBetweenEvents);
                    SpawnBoss();
                }
                yield return new WaitForSeconds(_spawnEnemyRate);
            }
            yield return null;
        }
    }

    private IEnumerator SpawnAsteroids()
    {
        while (!GameManager.Instance.IsGameOver)
        {
            if (_canSpawnAsteroids && Time.time >= _nextSpawnAsteroidsTime)
            {
                _canSpawnEnemies = false;
                _canSpawnAsteroids = false;
                yield return new WaitForSeconds(_delayBetweenEvents);
                int asteroidsNum = Random.Range(_minAsteroidsNumber, _minAsteroidsNumber);
                for (int i = 0; i < asteroidsNum; i++)
                {
                    GameObject asteroid = Instantiate(GetRandomAsteroid());
                    asteroid.transform.SetParent(_objectsContainer.transform);
                    yield return new WaitForSeconds(_timeBetweenAsteroids);
                }
                yield return new WaitForSeconds(_delayBetweenEvents);
                _nextSpawnAsteroidsTime = Time.time + Random.Range(_minSpawnAsteroidsTime, _maxSpawnAsteroidsTime);
                _canSpawnEnemies = true;
                _canSpawnAsteroids = true;
            }
            yield return null;
        }
    }


    private void SpawnBoss()
    {
        _canSpawnEnemies = false;
        _canSpawnAsteroids = false;
        GameObject boss = Instantiate(GetRandomBoss());
        boss.transform.position = _spawnPoint.position;
    }

    private GameObject GetRandomBoss()
    {
        int bossIndex = Random.Range(0, _bossPrefabs.Length);
        return _bossPrefabs[bossIndex];
    }

    private GameObject GetRandomAsteroid()
    {
        int asteroidIndex = Random.Range(0, _asteroids.Length);
        return _asteroids[asteroidIndex];
    }

    private GameObject GetRandomEnemy()
    {
        List<float> chances = new List<float>();
        for (int i = 0; i < _enemiesPrefabs.Length; i++)
        {
            chances.Add(_enemiesPrefabs[i].GetComponent<SpawnChance>().spawnChanceFromScore.Evaluate(GameManager.Instance.Score));
        }

        float value = Random.Range(0, chances.Sum());
        float sum = 0;
        for (int i = 0; i < chances.Count; i++)
        {
            sum += chances[i];
            if (value < sum)
            {
                return _enemiesPrefabs[i];
            }
        }
        return _enemiesPrefabs[_enemiesPrefabs.Length - 1];
    }

    public void UpdateSpawnEnemiesRate(int score)
    {
        _spawnEnemyRate = _spawnEnemyRateFromScore.Evaluate(score);
    }

    public IEnumerator ContinueSpawn()
    {
        yield return new WaitForSeconds(_delayBetweenEvents);
        _canSpawnEnemies = true;
        _canSpawnAsteroids = true;
    }
}
