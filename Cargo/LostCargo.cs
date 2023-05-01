using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostCargo : MonoBehaviour
{
    public SpriteRenderer CrateImage;
    public CargoItem CargoItem;
    public float CargoForce = 5f;
    public void Setup(CargoItem item)
    {
        if(item.CargoSprite != null)
            CrateImage.sprite = item.CargoSprite;
        CargoItem = item;
    }
    // Start is called before the first frame update
    void Start()
    {
        var rbody = GetComponent<Rigidbody2D>();
        var x = UnityEngine.Random.Range(-1f, 1f);
        var y = 1f;
        rbody.AddForce(new Vector3(x, y, 0)* CargoForce, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DoCollide(collision);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DoCollide(collision.collider);
    }

    private void DoCollide(Collider2D collision)
    {
        var cargoIventory = collision.GetComponent<CargoInventory>();
        if (cargoIventory != null)
        {
            cargoIventory.PickupCargo(CargoItem);
            Destroy(this.gameObject);
        }
    }
}
