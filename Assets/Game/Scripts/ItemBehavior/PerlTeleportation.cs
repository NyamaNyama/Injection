using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Game.Scripts.ItemBehavior
{
    public class PerlTeleportation : MonoBehaviour
    {
        [SerializeField] private Vector2 teleportRange;
        [SerializeField] private float teleportCooldown;
        private float _time;

        private void Start()
        {
            _time = teleportCooldown;
        }

        private void Update()
        {
            if (_time >= teleportCooldown)
            {
                Teleport();
                _time = 0;
            }

            _time += Time.deltaTime;
        }

        private void Teleport()
        {
            Vector2 teleportPosition = new Vector2(UnityEngine.Random.Range(
                    -teleportRange.x, teleportRange.x),
                UnityEngine.Random.Range(
                    -teleportRange.y, teleportRange.y));
            transform.position = teleportPosition;
        }
    }
}