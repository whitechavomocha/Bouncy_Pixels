//DRAGGING CODES
//using UnityEngine;
//using UnityEngine.InputSystem;

//namespace Ball
//{
//    public class BallHandler : MonoBehaviour
//    {
//        public static BallHandler Instance;
//        [SerializeField] private GameObject ballPrefab;
//        [SerializeField] private Rigidbody2D pivot;
//        [SerializeField] [Range(0.1f, 1f)] private float detachDelay = .15f;
//        [SerializeField] [Range(1f, 5f)] private float respawnDelay = 1f;

//        [HideInInspector]
//        public Rigidbody2D ballRb;

//        private SpringJoint2D ballSJ;
//        private Camera cam;
//        private bool isDragging;
//        private BallLineRenderer lineRenderer;

//        private void Awake()
//        {
//            Instance = this;
//        }

//        private void Start()
//        {
//            cam = Camera.main;

//            SpawnNewBall();
//        }

//        private void Update()
//        {
//            if (ballRb == null) { return; }

//            if (!Touchscreen.current.primaryTouch.press.IsPressed())
//            {
//                if (isDragging)
//                {
//                    LaunchBall();
//                }

//                isDragging = false;
//                return;
//            }

//            isDragging = true;
//            ballRb.isKinematic = true;

//            Vector2 touchPos = Touchscreen.current.primaryTouch.position.ReadValue();
//            Vector3 worldPos = cam.ScreenToWorldPoint(touchPos);

//            ballRb.position = new Vector3(worldPos.x, worldPos.y, 0f);
//        }

//        public void SpawnNewBall()
//        {
//            GameObject ball = Instantiate(ballPrefab, pivot.position, Quaternion.identity);
//            ballRb = ball.GetComponent<Rigidbody2D>();
//            ballSJ = ball.GetComponent<SpringJoint2D>();
//            lineRenderer = ball.GetComponent<BallLineRenderer>();
//            ballSJ.connectedBody = pivot;
//        }

//        public void LaunchBall()
//        {
//            ballRb.isKinematic = false;
//            ballRb = null;
//            lineRenderer.DestroyLine();
//            Invoke(nameof(DetachBall), detachDelay);
//        }

//        private void DetachBall()
//        {
//            ballSJ.enabled = false;
//            ballSJ = null;

//            Invoke(nameof(SpawnNewBall), respawnDelay);
//        }
//    }
//}

using UnityEngine;
using UnityEngine.InputSystem;

namespace Ball
{
    public class BallHandler : MonoBehaviour
    {
        public static BallHandler Instance;

        [SerializeField] private GameObject ballPrefab;
        [SerializeField] private Rigidbody2D pivot;
        private GameObject ball;
        private Camera cam;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            cam = Camera.main;
            ball = Instantiate(ballPrefab, pivot.transform.position, Quaternion.identity);
            ball.transform.position = pivot.transform.position;
        }

        private void Update()
        {
            Vector2 touchPos = Touchscreen.current.primaryTouch.position.ReadValue();
            Vector3 worldPos = cam.ScreenToWorldPoint(touchPos);

            ball.transform.position = new Vector3(worldPos.x, worldPos.y, 0f);
        }
    }
}