using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpeedUp : PowerUpBase
{
    [Header("Speed Up")]
    public float speedMultiply = 2f;


    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.Instance.SpeedUp(speedMultiply);
        PlayerController.Instance.Bounce();
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.Instance.ResetSpeed();
    }
}
