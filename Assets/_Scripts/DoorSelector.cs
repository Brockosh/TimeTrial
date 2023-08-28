
using System;
using System.Security.Cryptography;
using UnityEngine;
using Random = System.Random;

public class DoorSelector : MonoBehaviour
{
    [SerializeField] private Door[] doors;

   private static readonly Random RandomNumberGenerator = new Random();

    private void Awake()
    {
        MakeDoorDestroyable(GetRandomNumber(0, doors.Length), doors);
    }


    public static int GetRandomNumber(int min, int max)
    {
        lock (RandomNumberGenerator) // synchronize
        {
            int result = RandomNumberGenerator.Next(min, max);
            Debug.Log(result);
            return result;
        }
    }

    private void MakeDoorDestroyable(int randomNumber, Door[] doors)
    {
        doors[randomNumber].openable = true;
    }
}
