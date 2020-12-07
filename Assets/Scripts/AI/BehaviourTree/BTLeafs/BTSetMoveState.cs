[BTAgent(typeof(BTSetMoveState))]
public class BTSetMoveState : BTNode
{
    public MovementState desiredMoveState;
    public override BTResult Execute()
    {
        context.animatorController.SetBool("walk", true);
        return BTResult.SUCCESS;
    }
}
