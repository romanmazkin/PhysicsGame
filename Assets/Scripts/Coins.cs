using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] private List<Transform> _coins;
    public int Count { get; set; }

    private void Start()
    {
        Count = _coins.Count;
    }

    public void CalculateCount()
    {
        Count--;
    }

    public void Respawn()
    {
        foreach (var coin in _coins)
        {
            coin.gameObject.SetActive(true);
        }

        Count = _coins.Count;
    }

    public void MakeInactive()
    {
        foreach (var coin in _coins)
        {
            coin.gameObject.SetActive(false);
        }

        Count = 0;
    }
}
