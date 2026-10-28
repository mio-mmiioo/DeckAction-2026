using UnityEngine;

public class PlayerStateWalk : IPlayerState
{
    private Player player;
    public PLAYER_STATE state => PLAYER_STATE.P_STATE_IDLE;
    public PlayerStateWalk(Player p) => player = p;

    public void Entry()
    {

    }

    public void Update()
    {

    }

    public void Exit()
    {

    }
}
