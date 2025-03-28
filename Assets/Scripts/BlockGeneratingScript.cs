using UnityEngine;
using TMPro;

public class BlockGeneratingScript : MonoBehaviour
{
    [SerializeField] Transform[] blockSpawners;
    [SerializeField] float spawnInterval;
    [SerializeField] TMP_Text player1PointsWindow;
    [SerializeField] TMP_Text player2PointsWindow;
    float spawnIntervalStopwatch;
    int player1Points = 0;
    int player2Points = 0;
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
                spawnRandomBlock(blockSpawners[0], true);
                spawnRandomBlock(blockSpawners[1], false);
                nextBlockID = generateRandomBlockID();
                spawnIntervalStopwatch = spawnInterval;
            }
        }
    }

    byte generateRandomBlockID()
    {
        return (byte)Random.Range(0, blocks.Length - 1);
    }

    void spawnRandomBlock(Transform blockSpawnPoint, bool isPlayer1Owner)
    {
        GameObject block = Instantiate(blocks[nextBlockID], blockSpawnPoint.transform.position, Quaternion.identity);
        
        int randomColorNumber = Random.Range(0, 6);
        Color32 randomColor = Color.white;
        if(randomColorNumber == 0) { randomColor = Color.blue; }
        else if(randomColorNumber == 1) { randomColor = Color.red; }
        else if(randomColorNumber == 2) { randomColor = Color.green; }
        else if(randomColorNumber == 3) { randomColor = Color.cyan; }
        else if(randomColorNumber == 4) { randomColor = Color.yellow; }
        else if(randomColorNumber == 5) { randomColor = Color.magenta; }

        foreach(Transform blockBasic in block.GetComponent<Transform>())
        {
            blockBasic.GetComponent<SpriteRenderer>().color = randomColor;
            blockBasic.gameObject.GetComponent<BlockScript>().Inicialize(isPlayer1Owner, spawnInterval);
        }
    }

    public void AddPoints(int points, bool player1)
    {
        if(player1)
        { 
            player1Points += points;
            player1PointsWindow.text = player1Points.ToString();
        }
        else    
        {
            player2Points += points;
            player2PointsWindow.text = player2Points.ToString();
        }
    }
}
