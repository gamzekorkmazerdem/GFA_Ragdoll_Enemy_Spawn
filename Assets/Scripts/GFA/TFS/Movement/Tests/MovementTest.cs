using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace GFA.TPS.Movement.Test
{
    public class MovementTest : MonoBehaviour
    {
        // mekaniði doðrudan test etmek için kullanýlacak
        [SerializeField]
        private Vector2 _movementInput;

        [SerializeField]
        private CharacterMovement _characterMovement;

        private void Update()
        {
            //// if(Input.GetKeyDown(KeyCode.Space) ile aþaðýdaki satýr ayný
            //if (UnityEngine.InputSystem.Keyboard.current.spaceKey.wasReleasedThisFrame)
            //{
            //    // space e basýldýðýnda 10 birimlik external force eklensin ve yavaþlayarak ilerlesin
            //    //_characterMovement.ExternalForces += new Vector3(10, 0, 0);
            //}

            _characterMovement.MovementInput = _movementInput;
        }


    }
}

