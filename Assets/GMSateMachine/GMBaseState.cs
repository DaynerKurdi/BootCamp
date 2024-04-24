public abstract class GMBaseState 
{
    public abstract void OnEnterState(GameManager manger);

    public abstract void OnUpdateState(GameManager manager);

    public abstract void OnExitState(GameManager manager);
}

public class InitState : GMBaseState
{
    public override void OnEnterState(GameManager manger)
    {
        manger.InitStateOnEnterState();
    }

    public override void OnUpdateState(GameManager manager)
    {
        manager.InitStateOnUpdateState();
    }

    public override void OnExitState(GameManager manager)
    {
        manager.InitStateOnExitState();
    }

}

public class LoadDataState : GMBaseState
{
    public override void OnEnterState(GameManager manger)
    {
        manger.DataLoadStateOnEnterState();
    }

    public override void OnUpdateState(GameManager manager)
    {
        manager.DataLoadStateOnUpdateState();
    }

    public override void OnExitState(GameManager manager)
    {
        manager.DataLoadStateOnExitState();
    }
}
