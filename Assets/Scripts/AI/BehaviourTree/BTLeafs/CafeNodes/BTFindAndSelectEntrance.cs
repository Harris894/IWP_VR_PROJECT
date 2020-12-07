using UnityEngine.AI;

[BTEntrance(typeof(BTFindAndSelectEntrance))]
public class BTFindAndSelectEntrance : BTNode
{
    public override BTResult Execute()
    {
        BTResult result = BTResult.FAILURE;

        Entrance entrance = EntranceManager.SelectEntrance(context.contextOwner, out NavMeshPath _path);
        if (entrance != null)
        {
            if (context.contextOwner.currentTarget == entrance) return result;

            context.navAgent.SetPath(_path);
            context.contextOwner.currentTarget = entrance;
            context.contextOwner.currentState = AIState.LEAVING;
            
            result = BTResult.SUCCESS;
        }

        return result;
    }
}
