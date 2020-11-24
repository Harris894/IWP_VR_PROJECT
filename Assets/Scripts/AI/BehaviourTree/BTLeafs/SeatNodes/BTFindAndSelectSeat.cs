using UnityEngine.AI;

[BTSeat(typeof(BTFindAndSelectSeat))]
public class BTFindAndSelectSeat : BTNode
{
    public override BTResult Execute()
    {
        BTResult result = BTResult.FAILURE;
        Seat seat = SeatManager.SelectNearestReachableSeat(context.contextOwner, out NavMeshPath _path);

        if (seat != null)
        {
            context.activeSeat = seat;
            context.navAgent.SetPath(_path);
            
            result = BTResult.SUCCESS;
        }

        return result;
    }
}
