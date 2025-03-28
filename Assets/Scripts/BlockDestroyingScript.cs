using NUnit.Framework;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BlockDestroyingScript : MonoBehaviour
{
    byte collidingBlocksCounter;
    List<RaycastHit2D> blocksInTrigger = new List<RaycastHit2D>();
    Collider2D collisionCollider;
    [SerializeField] bool isPlayer1Owner;
    [SerializeField] BlockGeneratingScript BlockGeneratingScript;
    
    void Start()
    {
        collisionCollider = GetComponent<Collider2D>();
    }

    void checkForAmountOfBlocksInLine()
    {
        collisionCollider.Cast(Vector2.zero, blocksInTrigger);
        if(blocksInTrigger.Count > 15 )
        {
            BlockGeneratingScript.AddPoints(blocksInTrigger.Count, isPlayer1Owner);
            foreach (RaycastHit2D block in blocksInTrigger)
            {
                Destroy(block.transform.gameObject);
            }
        }
        blocksInTrigger.Clear();
    }

    void Update()
    {
        checkForAmountOfBlocksInLine();
    }
}
