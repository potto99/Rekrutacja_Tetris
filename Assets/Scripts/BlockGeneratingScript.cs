using UnityEngine;

public class BlockGeneratingScript : MonoBehaviour
{
    byte players;
    Transform[] blockSpawners;
    float spawnInterval;
    float spawnIntervalStopwatch;
    int[] points;
    bool gameInProgress = true;
    byte nextBlockID;

    [SerializeField] GameObject[] blocks;

    private void Start()
    {
        spawnIntervalStopwatch = spawnInterval;
        nextBlockID = generateRandomBlockID();
    }

    void Update()
    {
        if(gameInProgress)
        {
            spawnIntervalStopwatch -= Time.deltaTime;
            if (spawnIntervalStopwatch <= 0)
            {
                spawnRandomBlock(blockSpawners[0], nextBlockID);
                spawnRandomBlock(blockSpawners[1], nextBlockID);
                nextBlockID = generateRandomBlockID();
                spawnIntervalStopwatch = spawnInterval;
            }
        }
    }

    byte generateRandomBlockID()
    {
        return (byte)Random.Range(0, blocks.Length - 1);
    }

    void spawnRandomBlock(Transform blockSpawnPoint, byte blockID)
    {
        GameObject block = Instantiate(blocks[blockID], blockSpawnPoint.transform.position, Quaternion.identity);
    }
}
