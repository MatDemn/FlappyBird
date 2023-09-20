using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject pipePrefab;

    List<PipePairScript> spawnedPipes;

    int currentPipeIndex = 0;

    bool _canSpawn = false;

    [SerializeField]
    Transform _targetPos;

    [SerializeField]
    float _scrollSpeed;

    [SerializeField]
    float _pipesWidth;

    Vector3 scrollPos;

    private void Awake()
    {
        spawnedPipes = new List<PipePairScript>();
        for(int i = 0; i < 5; i++)
        {
            GameObject go = Instantiate(pipePrefab);
            if(go.TryGetComponent(out PipePairScript pipePair))
            {
                spawnedPipes.Add(pipePair);
                pipePair.ResetState(gameObject.transform.position + Vector3.right * i * _pipesWidth + Vector3.up * Random.Range(-2f, 2f));
            }
            
        }
        scrollPos = gameObject.transform.position + Vector3.right * 2 * _pipesWidth;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnLoop()
    {
        while(_canSpawn)
        {
            Vector3 directionVector = Vector3.left;
            spawnedPipes.ForEach(pipe => pipe.transform.position += directionVector * _scrollSpeed * Time.deltaTime);
            if(spawnedPipes[currentPipeIndex].transform.position.x < _targetPos.position.x)
            {
                int prevIndex = (currentPipeIndex - 1 + spawnedPipes.Count) % spawnedPipes.Count;
                Vector3 newPosition = new Vector3(
                    spawnedPipes[prevIndex].transform.position.x + _pipesWidth,
                    0f, 
                    0f
                ) + Vector3.up * Random.Range(-2f, 2f);
                spawnedPipes[currentPipeIndex].ResetState(newPosition);
                currentPipeIndex = (currentPipeIndex + 1) % spawnedPipes.Count;
            }
            yield return null;

        }
    }

    public void StartSpawning()
    {
        _canSpawn = true;
        StartCoroutine(spawnLoop());
    }

    public void StopSpawning()
    {
        _canSpawn = false;
    }
}
