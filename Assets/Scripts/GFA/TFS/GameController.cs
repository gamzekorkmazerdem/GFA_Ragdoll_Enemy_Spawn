using GFA.TPS.MatchSystem;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] 
    private MatchInstance _matchInstance;
    
    [SerializeField]
    private GameObject _player;

    private void Awake()
    {
        _matchInstance.Reset();
        _matchInstance.Player = _player;
    }

    private void Update()
    {
        _matchInstance.AddTime(Time.deltaTime);
    }
}
