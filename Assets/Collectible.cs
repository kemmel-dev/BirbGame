using UnityEngine;

public class Collectible : MonoBehaviour, ICollectible
{
    public CollectibleType Type;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Collect();
        }
    }

    public void Collect()
    {
        Destroy(this.gameObject);
    }
}

public interface ICollectible
{
    public void Collect();
}

public enum CollectibleType
{
    Coin
}
