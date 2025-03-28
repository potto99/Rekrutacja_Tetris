using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class BlockScript : MonoBehaviour
{
    [SerializeField] float moveForce;
    bool ownerIsPlayer1;
    float moveTime;
    Rigidbody2D Rigidbody2D;

    private Vector2 _moveDirection;

    public InputActionReference movePlayer1;
    public InputActionReference movePlayer2;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Inicialize(bool isownerPlayer1, float moveTime)
    {
        if (isownerPlayer1 == true) { ownerIsPlayer1 = true; }
        else { ownerIsPlayer1 = false; }
        this.moveTime = moveTime;
    }


    void Update()
    {
        if (moveTime > 0)
        {
            moveTime -= Time.deltaTime;

            if (ownerIsPlayer1) { _moveDirection = movePlayer1.action.ReadValue<Vector2>(); }
            else { _moveDirection = movePlayer2.action.ReadValue<Vector2>(); }
        }
    }

    void FixedUpdate()
    {
        if (moveTime > 0)
        {
            Rigidbody2D.linearVelocityX = _moveDirection.x * moveForce;
        }
    }
}
