using UnityEngine;

namespace FiveElement.Stage3
{
    public class Camera : MonoBehaviour
    {
        [SerializeField] private GameObject player = null;
        private float xMin = -5.6f;
        private float xMax = 5.6f;
        private float yMin = -3.2f;
        private float yMax = 3.2f;

        private void Update()
        {
            if(player != null)
            {
                float x = Mathf.Clamp(player.transform.position.x, xMin, xMax);
                float y = Mathf.Clamp(player.transform.position.y, yMin, yMax);
                gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
            }
        }
    }
}