using UnityEngine;

/**
 * @class Singleton
 * @brief Classes that inherit from this are singletons.
 */
namespace Assets.Scripts.Generic
{
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        protected static T instance;

        /*
         * @brief Gets the singleton instance or logs an error if none exists in the scene.
         * @returns The instance of the singleton in the scene.
         */
        public static T Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = (T) FindObjectOfType(typeof(T));

                    if (instance == null)
                    {
                        Debug.LogError($"An instance of {typeof(T)} is needed in the scene, but there is none.");
                    }
                }

                return instance;
            }
        }
    }
}
