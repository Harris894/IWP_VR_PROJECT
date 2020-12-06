using UnityEngine;

[BTAgent(typeof(BTDestinationReached))]

public class BTDestinationReached : BTNode
{
    /// <summary>
    /// Move the agent towards the active destination. Then trigger the `OnDestinationReached` event of the destination.
    /// </summary>
    /// <returns>Success if </returns>
    public override BTResult Execute()
    {
        BTResult result = BTResult.FAILURE;

        IDestination destination = context.contextOwner.currentTarget;

        Vector3 agentPosition = context.contextOwner.transform.position;
        Vector3 destinationPosition = destination.GetPosition();

        agentPosition.y = 0;
        destinationPosition.y = 0;

        if ((agentPosition - destinationPosition).sqrMagnitude < context.navAgent.height)
        {
            destination.OnDestinationReached();
            result = BTResult.SUCCESS;
        }
            UnityEngine.Debug.Log((agentPosition - destinationPosition).sqrMagnitude);

        return result;
    }
}
