using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpFly : PowerUpBase
{
    [Header("Fly")]
    public float flyHeight = 2f;


    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.Instance.Fly(flyHeight, duration);
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.Instance.Landing();
    }
}
