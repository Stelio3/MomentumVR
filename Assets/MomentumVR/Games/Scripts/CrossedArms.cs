using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossedArms : Singleton<CrossedArms>
{
    [SerializeField]
    Transform[] BallPositions, ZonesPositions;

    private int ballPosition, zonePosition;
    public void Spanw(GameObject ball, GameObject zone)
    {
        ballPosition = Random.Range(0, BallPositions.Length);
        zonePosition = Random.Range(0, ZonesPositions.Length);
        while (ballPosition == zonePosition)
        {
            zonePosition = Random.Range(0, ZonesPositions.Length);
        }
        Instantiate(ball, BallPositions[ballPosition]);
        Instantiate(zone, ZonesPositions[zonePosition]);
    }
}
