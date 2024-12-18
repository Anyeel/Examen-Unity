using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 10;
    [SerializeField] float direccion = 1;
    private float positionX;
    private float positionY;
    [SerializeField] string characterTag;
    private bool targetConfirmed = false;
    [SerializeField] Collectible otherCollectible;
    [SerializeField] Transform otherCollectibleTransform;
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * direccion * Time.deltaTime);
    }
    void Spawn()
    {
        randomPosition();
        transform.position = new Vector3(positionX,positionY,0);
        randomPosition();
        otherCollectibleTransform.position = new Vector3(positionX, positionY, 0);
        targetConfirmed = false;
    }
    void randomPosition()
    {
        positionX = Random.Range(-8f, 8f);
        positionY = Random.Range(-4f, 4f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(characterTag))
        {
            targetConfirmed = true;
            if (otherCollectible.targetConfirmed == true)
            {
                Spawn();
            }
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        targetConfirmed = false;
    }

}
