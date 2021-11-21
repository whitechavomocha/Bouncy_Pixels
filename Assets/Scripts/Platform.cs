using UnityEngine;
public class Platform : MonoBehaviour
{
    private Vector3 pos;
    private void FixedUpdate() 
    {
        pos = this.transform.position;
        pos.x -= 5 * Time.deltaTime;
        this.transform.position = pos;
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}