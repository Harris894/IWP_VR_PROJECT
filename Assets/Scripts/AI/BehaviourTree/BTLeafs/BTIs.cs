[BTAgent(typeof(BTIs))]
public class BTIs : BTNode
{
    public IsOp isOperation;

    public override BTResult Execute()
    {
        switch (isOperation)
        {
            case IsOp.WALKING:
UnityEngine.Debug.Log(isOperation);
                return context.contextOwner.currentState == AIState.WALKING ? BTResult.SUCCESS : BTResult.FAILURE;
            case IsOp.ENTERING:
UnityEngine.Debug.Log(isOperation);
                return context.contextOwner.currentState == AIState.ENTERING ? BTResult.SUCCESS : BTResult.FAILURE;
            case IsOp.WAITING_FOR_TURN:
UnityEngine.Debug.Log(isOperation);
                return context.contextOwner.currentState == AIState.WAITING_FOR_TURN ? BTResult.SUCCESS : BTResult.FAILURE;
            case IsOp.WAITING_FOR_ORDER:
UnityEngine.Debug.Log(isOperation);
                return context.contextOwner.currentState == AIState.WAITING_FOR_ORDER ? BTResult.SUCCESS : BTResult.FAILURE;
            case IsOp.CHOOSING_MEAL:
UnityEngine.Debug.Log(isOperation);
                return context.contextOwner.currentState == AIState.CHOOSING_MEAL ? BTResult.SUCCESS : BTResult.FAILURE;
            case IsOp.ORDERING:
UnityEngine.Debug.Log(isOperation);
                return context.contextOwner.currentState == AIState.ORDERING ? BTResult.SUCCESS : BTResult.FAILURE;
            case IsOp.REACTING:
UnityEngine.Debug.Log(isOperation);
                return context.contextOwner.currentState == AIState.REACTING ? BTResult.SUCCESS : BTResult.FAILURE;
            case IsOp.CONSUMING:
UnityEngine.Debug.Log(isOperation);
                return context.contextOwner.currentState == AIState.CONSUMING ? BTResult.SUCCESS : BTResult.FAILURE;
            case IsOp.LEAVING:
UnityEngine.Debug.Log(isOperation);
                return context.contextOwner.currentState == AIState.LEAVING ? BTResult.SUCCESS : BTResult.FAILURE;
            default:
UnityEngine.Debug.Log(isOperation);
                break;
        }
        return BTResult.FAILURE;
    }
}
