[BTAgent(typeof(BTDestroyAgent))]
public class BTDestroyAgent : BTNode
{
    public override BTResult Execute()
    {
        Destroy(context.contextOwner.gameObject);
UnityEngine.Debug.Log("result");
        return BTResult.SUCCESS;
    }
}
