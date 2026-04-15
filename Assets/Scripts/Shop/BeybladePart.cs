using UnityEngine;
public class BeybladePart
{
    private string id;
    private float speed;
    private float damage;
    private float health;
    private int price;
    public float Health { get { return health; } }
    public float Speed { get { return speed; } }
    public float Damage { get { return damage; } }
    public int Price { get { return price; } }
    public bool IsBought { get { return PlayerPrefs.GetInt($"{id}_BOUGHT", 0) != 0; } }
    public BeybladePart(string id, float speed, float damage, float health, int price) 
    {
        this.id = id;
        this.speed = speed;
        this.damage = damage;
        this.health = health;
        this.price = price;
    }
}