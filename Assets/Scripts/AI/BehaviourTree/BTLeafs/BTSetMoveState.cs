using System;
using System.Diagnostics;
using System.Threading;
[BTAgent(typeof(BTSetMoveState))]
public class BTSetMoveState : BTNode
{
    public MovementState desiredMoveState;
    public override BTResult Execute()
    {
        if (desiredMoveState == context.contextOwner.currentMoveState) return BTResult.SUCCESS;
        
        // Reset all parameters
        var movementStates = Enum.GetValues(typeof(MovementState));
        foreach (var movementState in movementStates) {
            context.animatorController.SetBool(
                movementState.ToString().ToLower(),
                false
            );
        }
        
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
