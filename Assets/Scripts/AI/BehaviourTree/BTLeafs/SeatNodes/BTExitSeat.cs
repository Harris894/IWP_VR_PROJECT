using System;
[BTSeat(typeof(BTExitSeat))]
public class BTExitSeat : BTNode
{
    public override BTResult Execute()
    {
        SeatManager.OnSeatExit(context.activeSeat);

        context.activeSeat.OnExit();
        context.activeSeat = null;
        
        context.navAgent.ResetPath();
        context.contextOwner.currentState = AIState.LEAVING;

        return BTResult.SUCCESS;
    }
}
