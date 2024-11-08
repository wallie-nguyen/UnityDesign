using UnityEngine;

namespace UnityServicesLocator
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(ServiceLocator))]
    public abstract class Bootstrapper : MonoBehaviour
    {
        private ServiceLocator container;
        
        /// <summary>
        /// Get the ServiceLocator instance.
        /// </summary>
        public ServiceLocator Container => container.OrNull() ?? (container = GetComponent<ServiceLocator>());
        
        private bool hasBeenBootstrapped;
        
        private void Awake()
        {
            BootstrapOnDemand();
        }
        
        public void BootstrapOnDemand()
        {
            if (hasBeenBootstrapped) return;
            hasBeenBootstrapped = true;
            Bootstrap();
        }
        
        protected abstract void Bootstrap();
    }
}