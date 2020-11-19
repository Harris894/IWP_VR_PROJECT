[BTAgent(typeof(BTIs))]
public class BTIs : BTNode
{
    public IsOp isOperation;

    public override BTResult Execute()
    {
        switch (isOperation)
        {
            case IsOp.WAITING_FOR_TURN:
                return context.contextOwner.currentState == AIState.WAITING_FOR_TURN ? BTResult.SUCCESS : BTResult.FAILURE;
            case IsOp.WAITING_FOR_ORDER:
                return context.contextOwner.currentState == AIState.WAITING_FOR_ORDER ? BTResult.SUCCESS : BTResult.FAILURE;
            case IsOp.CHOOSING_MEAL:
                return context.contextOwner.currentState == AIState.CHOOSING_MEAL ? BTResult.SUCCESS : BTResult.FAILURE;
            case IsOp.ORDERING:
                return context.contextOwner.currentState == AIState.ORDERING ? BTResult.SUCCESS : BTResult.FAILURE;
            case IsOp.REACTING:
                return context.contextOwner.currentState == AIState.REACTING ? BTResult.SUCCESS : BTResult.FAILURE;
            case IsOp.CONSUMING:
                return context.contextOwner.currentState == AIState.CONSUMING ? BTResult.SUCCESS : BTResult.FAILURE;
            case IsOp.LEAVING:
                return context.contextOwner.currentState == AIState.LEAVING ? BTResult.SUCCESS : BTResult.FAILURE;
            default:
                break;
        }
        return BTResult.FAILURE;
    }
}
