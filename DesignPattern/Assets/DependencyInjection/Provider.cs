using UnityEngine;

namespace DependencyInjection
{
    public class Provider : MonoBehaviour, IDependencyProvider
    {
        [Provide]
        public ServiceA ProvideServiceA()
        {
            ServiceA serviceA = new ServiceA();
            serviceA.Initialize("from Provider");
            return serviceA;
        }
        
        [Provide]
        public ServiceB ProvideServiceB()
        {
            ServiceB serviceB = new ServiceB();
            serviceB.Initialize("from Provider");
            return serviceB;
        }
        
        [Provide]
        public FactoryA ProvideFactoryA()
        {
            FactoryA factoryA = new FactoryA();
            return factoryA;
        }
    }

    public class ServiceA
    {
        public void Initialize(string mes = null)
        {
            Debug.Log("ServiceA initialized" + (mes != null ? " with message: " + mes : ""));
        }
    }
    
    public class ServiceB
    {
        public void Initialize(string mes = null)
        {
            Debug.Log("ServiceB initialized" + (mes != null ? " with message: " + mes : ""));
        }
    }

    public class FactoryA
    {
        ServiceA serviceA;
        
        public ServiceA CreateServiceA()
        {
            if (serviceA == null)
            {
                serviceA = new ServiceA();
            }

            return serviceA;
        }
    }
}