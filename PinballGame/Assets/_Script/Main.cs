using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �������� �����, �������������� ���������� �����.
/// </summary>
public class Main : MonoBehaviour
{
    public static Main S;                               // ������-��������

    [Header("Set in Inspector")]
    [SerializeField] private GameObject ball;           // ������� ������ "���"
    [SerializeField] private List<ObstacleProperties> Obstacles;

    [Header("Set Dynamically")]
    [SerializeField] private Vector3 ballOriginalPos;         // ��������� ������� ����

    private Dictionary<string, ObstacleProperties> ObstaclePropertie;

    private int PlayerScore;
    public int Score {  get { return PlayerScore; } set { PlayerScore = value; } }
    
    void Awake()
    {
        S = this;

        // ��������� ��������� ������� ����
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
            // ���� ��� ����� � �������, �� ����������� ��� � ��������� �������
            ball.transform.localPosition = ballOriginalPos;
        }
    }

    // ����� ��������� ���� ������������
    public void UpdatePlayerScore(string id)
    {
        Score += ObstaclePropertie[id].PointPerCollision;
    }
}