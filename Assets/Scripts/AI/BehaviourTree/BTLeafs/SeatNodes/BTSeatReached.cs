using UnityEngine;

[BTSeat(typeof(BTSeatReached))]
public class BTSeatReached : BTNode
{
    public override BTResult Execute()
    {
        BTResult result = BTResult.FAILURE;

        Seat currentSeat = context.activeSeat;

        Vector3 agentPosition = context.contextOwner.transform.position;
        Vector3 seatPosition = currentSeat.transform.position;

        agentPosition.y = 0;
        seatPosition.y = 0;

        if ((agentPosition - seatPosition).sqrMagnitude <= 0.1f)
        {
            currentSeat.OnSeatReached();
            context.contextOwner.currentState = AIState.WAITING_FOR_TURN;

            result = BTResult.SUCCESS;
        }

        return result;
    }
}
