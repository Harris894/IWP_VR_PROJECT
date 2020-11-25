using UnityEngine;

[BTSeat(typeof(BTWalkToSeat))]

public class BTWalkToSeat : BTNode
{
    public override BTResult Execute()
    {
        BTResult result = BTResult.SUCCESS;

        Seat currentSeat = context.activeSeat;

        Vector3 agentPosition = context.contextOwner.transform.position;
        Vector3 seatPosition = currentSeat.GetNextSeat();

        agentPosition.y = 0;
        seatPosition.y = 0;

        if (!currentSeat.seatTaken)
        {
            if ((agentPosition - seatPosition).sqrMagnitude < 0.1f)
            {
                currentSeat.seatTaken = true;
                currentSeat.OnSeatReached();
            }
        }
        else result = BTResult.FAILURE;

        return result;
    }
}
