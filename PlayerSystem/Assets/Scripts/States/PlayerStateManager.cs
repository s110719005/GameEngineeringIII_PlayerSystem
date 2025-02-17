using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public enum Direction
{
    Down = 0,
    Top = 1,
    Left = 2,
    Right = 3
}
public class PlayerStateManager : MonoBehaviour
{
    public static PlayerStateManager Instance;
    [Header("Player State")]
    [SerializeField]
    private StateBase initialState;
    [SerializeField]
    private StateBase idleState;
    public StateBase IdleState => idleState;
    [SerializeField]
    private StateBase walkState;
    public StateBase WalkState => walkState;
    [SerializeField]
    private StateBase toolState;
    public StateBase ToolState => toolState;
    
    private Direction currentDirection;
    public Direction CurrentDirection => currentDirection;
    private StateBase currentState;
    [Header("Player")]
    [SerializeField]
    private GameObject player;
    public GameObject Player => player;
    [SerializeField]
    private GameObject playerVisual;
    public GameObject PlayerVisual => playerVisual;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private GameObject selectionUI;
    // Start is called before the first frame update
    private int playerGridX;
    private int playerGridY;
    private int selectionGridX;
    private int selectionGridY;
    public int SelectionGridX => selectionGridX;
    public int SelectionGridY => selectionGridY;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        currentDirection = Direction.Down;
        currentState = initialState;
        initialState.OnEnter();
    }

    // Update is called once per frame
    void Update()
    {
        currentState.OnUpdate();
        playerGridX = (int)(player.transform.position.x);
        playerGridY = (int)(player.transform.position.y);
        switch(CurrentDirection)
        {
            case Direction.Down:
                selectionGridX = playerGridX;
                selectionGridY = playerGridY - 1;
                break;
            case Direction.Top:
                selectionGridX = playerGridX;
                selectionGridY = playerGridY + 1;
                break;
            case Direction.Left:
                selectionGridX = playerGridX - 1;
                selectionGridY = playerGridY;
                break;
            case Direction.Right:
                selectionGridX = playerGridX + 1;
                selectionGridY = playerGridY;
                break;
            default:
                selectionGridX = playerGridX;
                selectionGridY = playerGridY;
                break;
        }
        selectionUI.transform.position = new Vector2(selectionGridX, selectionGridY);

    }

    public void ChangeState(StateBase nextState)
    {
        if(currentState == nextState) { return; }
        currentState.OnExit();
        currentState = nextState;
        currentState.OnEnter();
    }

    public void SetAnimation(string animationName)
    {
        animator.Play(animationName);
    }
    public void SetDirection(Direction direction)
    {
        currentDirection = direction;
        if(direction == Direction.Left)
        {
            playerVisual.transform.localScale = new Vector3( -Mathf.Abs(playerVisual.transform.localScale.x), playerVisual.transform.localScale.y, playerVisual.transform.localScale.z);
        }
        else if(direction == Direction.Right)
        {
            playerVisual.transform.localScale = new Vector3( Mathf.Abs(playerVisual.transform.localScale.x), playerVisual.transform.localScale.y, playerVisual.transform.localScale.z);
        }
    }
}
