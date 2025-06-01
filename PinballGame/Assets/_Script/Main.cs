using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ќсновной класс, осуществл€ющий управление игрой.
/// </summary>
public class Main : MonoBehaviour
{
    public static Main S;                               // ќбъект-одиночка

    [Header("Set in Inspector")]
    [SerializeField] private GameObject ball;           // »гровой объект "ћ€ч"
    [SerializeField] private List<ObstacleProperties> Obstacles;

    [Header("Set Dynamically")]
    [SerializeField] private Vector3 ballOriginalPos;         // Ќачальна€ позици€ м€ча

    private Dictionary<string, ObstacleProperties> ObstaclePropertie;

    private int PlayerScore;
    public int Score {  get { return PlayerScore; } set { PlayerScore = value; } }
    
    void Awake()
    {
        S = this;

        // —охранить начальную позицию м€ча
        ballOriginalPos = ball.transform.localPosition;

        SetGameProperties();
    }

    private void SetGameProperties()
    {
        if (ObstaclePropertie == null)
            ObstaclePropertie = new Dictionary<string, ObstacleProperties>();

        foreach (ObstacleProperties obs in Obstacles)
            ObstaclePropertie.Add(obs.Id, obs);
    }

    void Update()
    {
        if (EndTriggerControl.S.onTrig)
        {
            // ≈сли м€ч зашел в триггер, то переместить его в начальную позицию
            ball.transform.localPosition = ballOriginalPos;
        }
    }

    // ћетод обновл€ет очки пользовател€
    public void UpdatePlayerScore(string id)
    {
        Score += ObstaclePropertie[id].PointPerCollision;
    }
}