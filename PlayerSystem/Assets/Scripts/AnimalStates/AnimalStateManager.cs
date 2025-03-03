using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalStateManager : MonoBehaviour
{
    private AnimalState currentAnimalState;
    public int CurrentX {get {return (int)transform.position.x; } }
    public int CurrentY {get {return (int)transform.position.y - 1; } }
    [SerializeField] private AnimalState initialState;
    [SerializeField] private AnimalState wanderState;
    public AnimalState WanderState => wanderState;
    [SerializeField] private AnimalState followState;
    public AnimalState FollowState => followState;
    [SerializeField] private AnimalState searchState;
    public AnimalState SearchState => searchState;
    [SerializeField] private AnimalState eatState;
    public AnimalState EatState => eatState;
    // Start is called before the first frame update
    void Start()
    {
        currentAnimalState = initialState;
        currentAnimalState.OnEnter();
    }

    // Update is called once per frame
    void Update()
    {
        currentAnimalState.OnUpdate();
    }

    public void OnUpdate()
    {
        currentAnimalState.OnUpdate();
    }

    public void ChangeState(AnimalState newState)
    {
        if(newState == null) { Debug.Log("NO STATE REFERENCE FOUND" + newState); return;}
        if(currentAnimalState == newState) { return; }
        currentAnimalState.OnExit();
        currentAnimalState = newState;
        currentAnimalState.OnEnter();
    }
}
