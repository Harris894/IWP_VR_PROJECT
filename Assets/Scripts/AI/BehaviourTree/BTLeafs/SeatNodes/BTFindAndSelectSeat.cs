using UnityEngine.AI;

[BTSeat(typeof(BTFindAndSelectSeat))]
public class BTFindAndSelectSeat : BTNode
{
    public override BTResult Execute()
    {
        BTResult result = BTResult.FAILURE;

        if (context.activeSeat) return result;

        Seat seat = SeatManager.SelectNearestReachableSeat(context.contextOwner, out NavMeshPath _path);
        if (seat != null)
        {
            context.activeSeat = seat;
            context.navAgent.SetPath(_path);
            context.contextOwner.currentState = AIState.WALKING;
            
            result = BTResult.SUCCESS;
        }

        return result;
    }
}
