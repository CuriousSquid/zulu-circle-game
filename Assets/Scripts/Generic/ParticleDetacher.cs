using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Generic {
    /**
     * @class ParticleDetacher
     * @brief Attach to a GameObject to detach it's child's particle system when it dies.
     * 
     * To use:
     *  [1] Attach this to a parent GameObject.
     *  [2] Attach a particle system to the child GameObject.
     */
    public class ParticleDetacher : MonoBehaviour {

        #region Variables

        new private ParticleSystem particleSystem;

        private static GameObject dynamicObjectContainer;

        #endregion

        #region Unity Methods
        // Use this for initialization
        void Start() {
            particleSystem = GetComponentInChildren<ParticleSystem>();
            Debug.Assert(null != particleSystem);
            if (null == dynamicObjectContainer)
            {
                dynamicObjectContainer = GameObject.FindGameObjectWithTag("DynamicObjectsContainer");
            }
        }

        void OnDestroy()
        {
            Detach();
        }
        #endregion

        public void Detach()
        {
            if (null == particleSystem)
            {
                Debug.LogWarning($"{name}: Particle System already detached!");
                return;
            }
            particleSystem.transform.parent = dynamicObjectContainer.transform;
            particleSystem.Emit(100);
            particleSystem.Stop();
            Destroy(particleSystem.gameObject, particleSystem.main.duration);
            //particleSystem = null;

        }
    }
}