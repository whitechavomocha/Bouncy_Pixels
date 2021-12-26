using System.Collections;
using UnityEngine;

namespace Ball
{
    public class Ball : MonoBehaviour
    {
        private Rigidbody2D rb2d;

        // Use this for initialization
        void Start()
        {
            rb2d = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            if (rb2d.velocity == Vector2.zero)
            {
                Destroy(this);
            }
        }
    }
}