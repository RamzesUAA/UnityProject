using UnityEngine;

namespace N.Fridman.CameraFollow.Scripts
{
    public class CameraFollow2D : MonoBehaviour
    {
        [Header("Parameters")]
        [SerializeField] private Transform playerTransform;
        [SerializeField] private string playerTag;
        [SerializeField] [Range(0.5f, 7.5f)] private float movingSpeed = 1.5f;

        public Camera CameraObject;
        public GameObject PersObject;
        public float a = 2.8f;
        public float oldY;
        public float oldX;
        public float Ysize;
    

        void Start () 
        {
         CameraObject.orthographicSize = 5;
         oldY = PersObject.transform.position.y;
         oldX = PersObject.transform.position.x;
         a = 2.8f;
        }

        private void Awake()
        {
            
            if (this.playerTransform == null)
            {
                if (this.playerTag == "")
                {
                    this.playerTag = "Player";
                }
            
                this.playerTransform = GameObject.FindGameObjectWithTag(this.playerTag).transform;
            }


            this.transform.position = new Vector3()
            {
                x = this.playerTransform.position.x,
                y = this.playerTransform.position.y,
                z = this.playerTransform.position.z - 10,
            };
        }

        private void FixedUpdate()
        {
            if (oldX == PersObject.transform.position.x && oldY == PersObject.transform.position.y)
                {
                    Debug.Log("Стоит");
                    a = 1f; 
                    if (CameraObject.orthographicSize < 3)
                    {
                        Debug.Log("No zoom");
                    }
                    else
                    CameraObject.orthographicSize = (CameraObject.orthographicSize - 1 * Time.deltaTime);
                }
            else 
            {
                a = 2.8f;
                oldY = PersObject.transform.position.y;
                oldX = PersObject.transform.position.x;
                Debug.Log("Двигается");
                if (CameraObject.orthographicSize > 5)
                {
                    Debug.Log("No zoom");
                }
                else
                CameraObject.orthographicSize = (CameraObject.orthographicSize + 2 * Time.deltaTime * 1.5f);
                
            }
            
            
 //           {
 //               if (PersObject.transform.position.z)
 //               {
 //                   Debug.Log("Ничего");
//                }
 //               else
 //               {
 //               PersObject.transform.hasChanged = false;
 //               CameraObject.orthographicSize = 5;
 //               Debug.Log("Двигаешься" + PersObject.transform.position);
 //               }
//            }

            if (this.playerTransform)
            {
                Vector3 target = new Vector3()
                {
                    x = this.playerTransform.position.x,
                    y = this.playerTransform.position.y + a,
                    z = this.playerTransform.position.z - 10,
                };

                Vector3 pos = Vector3.Lerp(this.transform.position, target, this.movingSpeed * Time.deltaTime);
                this.transform.position = pos;

            }

            
        }
    
    }
}
