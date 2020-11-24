using UnityEngine;

[BTSeat(typeof(BTSeatReached))]
public class BTSeatReached : BTNode
{
    public override BTResult Execute()
    {
        BTResult result = BTResult.FAILURE;

        Seat currentSeat = context.activeSeat;

        Vector3 agentPosition = context.contextOwner.transform.position;
        Vector3 seatPosition = currentSeat.GetNextSeat();

        agentPosition.y = 0;
        seatPosition.y = 0;

        if (!currentSeat.endSeatReached && (agentPosition - seatPosition).sqrMagnitude <= 0.1f)
        {
            currentSeat.OnSeatReached();

            if (currentSeat.endSeatReached && currentSeat.onPathEndTriggerName != "")
            {
                context.animatorController.SetTrigger(currentSeat.onPathEndTriggerName);
            }
            else if (!currentSeat.IsOnFirstSeat() && currentSeat.onSeatReachedTriggerName != "")
            {
                context.animatorController.SetTrigger(currentSeat.onSeatReachedTriggerName);
            }

            result = BTResult.SUCCESS;
        }

        return result;
    }
}
