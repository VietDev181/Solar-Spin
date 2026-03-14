public interface IGameStateMachine
{
    GameStateType CurrentStateType { get; }
    void ChangeState(GameStateType type);
    void Update();
}