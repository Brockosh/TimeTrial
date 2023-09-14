using UnityEngine;
using Random = System.Random;
/// <summary>
/// Class to control spawning of doors.
/// </summary>
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
        lock (RandomNumberGenerator) 
        {
            int result = RandomNumberGenerator.Next(min, max);
            return result;
        }
    }

    private void MakeDoorDestroyable(int randomNumber, Door[] doors)
    {
        doors[randomNumber].openable = true;
    }
}
