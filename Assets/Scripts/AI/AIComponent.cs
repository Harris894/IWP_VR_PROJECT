using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public class AIComponent : MonoBehaviour, IWeaponTarget, IEventSource   
{
    public BehaviourTreeType behaviourTreeType;
    public SensorySystem sensorySystem;
    public AIEventHandler eventHandler;

    internal AIState currentState = AIState.ENTERING;
    internal IDestination currentTarget = null;

    Animator animatorController;
    NavMeshAgent navAgent;
    BTContext aiContext;

    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        animatorController = GetComponent<Animator>();

        aiContext = new BTContext(this, animatorController, navAgent);
    }

    private void Start()
    {
        sensorySystem.Initialize(this, navAgent);
        eventHandler.Initialize(this, animatorController, navAgent);
        BehaviourTreeRuntimeData.RegisterAgentContext(behaviourTreeType, aiContext);
    }

    public void OnTargetHit(TargetHitInfo _hitInfo)
    {
        eventHandler.OnTargetHit(_hitInfo);
    }

    public void ListenToPlayer()
    {
        eventHandler.ListenToPlayer();
    }

    public void RespondToPlayer()
    {
        eventHandler.RespondToPlayer();
    }

    public void CustomerLeaves()
    {
        eventHandler.CustomerLeaves();
    }

    void Update()
    {
        sensorySystem.Update();
        eventHandler.Update();
    }

    void OnDestroy()
    {
        eventHandler.OnDestroy();
        BehaviourTreeRuntimeData.UnregisterAgentContext(behaviourTreeType, aiContext);
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
