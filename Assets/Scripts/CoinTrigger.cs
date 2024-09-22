using UnityEngine;

public class CoinTrigger : MonoBehaviour
{
    [SerializeField] private Coins _coins;

    private void OnTriggerEnter(Collider other)
    {
        Mover ball = other.GetComponent<Mover>();

        if (ball != null)
        {
            _coins.CalculateCount();
            gameObject.SetActive(false);
        }
    }
}
