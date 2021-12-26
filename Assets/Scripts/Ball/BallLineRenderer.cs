//using UnityEngine;

//namespace Ball
//{
//    public class BallLineRenderer : MonoBehaviour
//    {
//        [SerializeField] private LineRenderer lineRenderer;
//        private Transform pivot;

//        private void Start()
//        {
//            pivot = FindObjectOfType<Pivot>().GetComponent<Transform>();
//        }

//        // Update is called once per frame
//        private void Update()
//        {
//            lineRenderer.SetPosition(0, pivot.transform.position);
//            lineRenderer.SetPosition(1, this.transform.position);
//        }
//    }
//}