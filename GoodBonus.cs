using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RollABall
{


 public sealed class GoodBonus : InteractiveObject, IFlying, IFlickering
 {
  [SerializeField] private float _minFlightDistance = 1.0f;
  [SerializeField] private float _maxFlightDistance = 5.0f;
  private float _flightDistance;
  private Material _material;

  private void Awake()
  {
   _flightDistance = Random.Range(_minFlightDistance, _maxFlightDistance);
   _material = GetComponent<MeshRenderer>().materials[0];
  }

  protected override void Interaction()
  {
   //AddBonus
  }

  public void Fly()
  {
   transform.localPosition = new Vector3(transform.localPosition.x, Mathf.PingPong(Time.time,_flightDistance), transform.localPosition.z);
  }

  public void Flicker()
  {
   _material.color = new Color(Mathf.PingPong(Time.time, 1.0f), _material.color.g, _material.color.b, Mathf.PingPong(Time.time, 1.0f));
  }
 }

}
