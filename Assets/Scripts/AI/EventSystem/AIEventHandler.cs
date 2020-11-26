using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[Serializable]
public class AIEventHandler
{
    [SerializeField] bool canHandleEvents = true;
    Animator animatorController;
    NavMeshAgent navAgent;
    AIComponent aiComponent;

    List<TargetHitInfo> unprocessedHitInfoList = new List<TargetHitInfo>();
    AIEventSystem eventSystem;

    public void Initialize(AIComponent _aiComponent, Animator _animator, NavMeshAgent _navAgent)
    {
        if (canHandleEvents)
        {
            aiComponent = _aiComponent;
            animatorController = _animator;
            navAgent = _navAgent;
            eventSystem = AIEventSystem.GetInstance();
            eventSystem.aiGroupEvent += OnEvent;
        }
    }

    internal void Update()
    {
        if (unprocessedHitInfoList.Count != 0)
        {
            ProcessHits();
        }
    }

    void ProcessHits()
    {
        animatorController.SetTrigger("Hurt");
        aiComponent.currentState = AIState.REACTING;
        navAgent.ResetPath();

        foreach (TargetHitInfo _hitInfo in unprocessedHitInfoList)
        {
            aiComponent.currentTarget = _hitInfo.hitSource;
            eventSystem.PropagateEvents(aiComponent, _hitInfo.hitSource, StimType.HURT, StimType.THREATENING_SOUND);
        }

        unprocessedHitInfoList.Clear();
    }

    public void OnTargetHit(TargetHitInfo _hitInfo)
    {
        if (canHandleEvents)
        {
            unprocessedHitInfoList.Add(_hitInfo);
        }
    }

    void OnEvent(AIEventData _event)
    {
        if (IsValidEvent(_event))
        {
            switch (_event.stimType)
            {
                case StimType.HURT:
                case StimType.THREATENING_SOUND:
                    if (aiComponent.currentState != AIState.REACTING)
                    {
                        aiComponent.currentState = AIState.REACTING;
                        aiComponent.currentTarget = _event.eventInstigator;
                        navAgent.ResetPath();
                    }
                    break;
                default:
                    break;
            }
        }
    }

    private bool IsValidEvent(AIEventData _event)
    {
        bool isValid = false;

        if (_event.sourceAgent != aiComponent as IEventSource)
        {
            switch (_event.stimType)
            {
                case StimType.HURT:
                    isValid = aiComponent.sensorySystem.IsEventSourceVisible(_event.eventInstigator);
                    break;
                default:
                    isValid = (_event.sourcePosition - aiComponent.transform.position).sqrMagnitude < _event.radius * _event.radius;
                    break;
            }
        }

        return isValid;
    }

    internal void OnDestroy()
    {
        if (eventSystem != null)
        {
            eventSystem.aiGroupEvent -= OnEvent;
        }
    }
}
