using UnityEngine;
using UnityEngine.EventSystems;

public class ShootAtClickPosition : MonoBehaviour
{
    public Rigidbody projectile;

    [Header("Projectile Settings")]
    public float force = 10.0f;
    public ForceMode forceMode;
    public KeyCode fireKey;

    private bool isShot = false;
    private LevelManager levelManager;

    private void Start()
    {
        levelManager = GameObject.Find("Level Manager").GetComponent<LevelManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(fireKey) && !EventSystem.current.IsPointerOverGameObject()) // checks to see if the cursor is over ui. if it is a shot wont be fired
        {
            isShot = true;
        }
        
    }
    private void FixedUpdate()
    {
        if(isShot == true)
        {
            FireProjectile();
            isShot = false;
        }
    }
    // Fires projectile at the location of the mouse curser when left mouse button is clicked
    private void FireProjectile()
    {
        Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, GetComponent<Camera>().nearClipPlane));
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Quaternion rotation = Quaternion.LookRotation(ray.direction);

        Rigidbody instance = Instantiate(projectile, spawnPosition, rotation);
        instance.AddForce(ray.direction * force, forceMode);

        levelManager.CountAmmo();
    }
}
