using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Interact : MonoBehaviour
    {
        [SerializeField] GUIStyle _crossHairStyle;
        [SerializeField] LayerMask _layerMask; //this is for the interaction
        [SerializeField] bool _showToolTip;
        public string action, button, instructions;
        // Update is called once per frame
        void Update()
        {
            // create a line
            Ray interactionRay;
            // set our origin and direction
            interactionRay = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            // store data from collision
            RaycastHit hitInfo;

            if (Physics.Raycast(interactionRay, out hitInfo, 10,_layerMask))
            {
                Debug.DrawRay(interactionRay.origin, transform.forward * 10,Color.green);
                _showToolTip = true;
                if(Input.GetKeyDown(KeyCode.E))
                {
                    #region NO GROSS
                    //if(hitInfo.collider.tag == "NPC")
                    //{
                    //    if (hitInfo.collider.GetComponent<NPC.LinearIMGUIDlg>())
                    //    {
                    //        hitInfo.collider.GetComponent<NPC.LinearIMGUIDlg>().showDlg = true;
                    //    }
                    //}
                    //if(hitInfo.collider.CompareTag("Chest"))
                    //{
                    //    // check if script is on chest
                    //    // if it is active
                    //}
                    //if (hitInfo.collider.tag == "Item")
                    //{
                    //    // check if script is on chest
                    //    // if it is active
                    //}
                    #endregion
                    #region YES GOOD
                    if(hitInfo.collider.TryGetComponent<IInteractable>(out IInteractable interact))
                    {
                        interact.OnInteraction();
                    }
                    #endregion
                }
            }
        }
    }
}

