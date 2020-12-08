using System.Diagnostics;
using System.Threading;
[BTAgent(typeof(BTSetMoveState))]
public class BTSetMoveState : BTNode
{
    public MovementState desiredMoveState;
    public override BTResult Execute()
    {
        if (desiredMoveState == context.contextOwner.currentMoveState) return BTResult.FAILURE;
        
        string parameterName = desiredMoveState.ToString().ToLower();
        bool currentParameterValue = context.animatorController.GetBool(parameterName);

        context.animatorController.SetBool(
            parameterName,
            !context.animatorController.GetBool(parameterName)
        );

        context.contextOwner.currentMoveState = desiredMoveState;

        return BTResult.SUCCESS;
    }
}
