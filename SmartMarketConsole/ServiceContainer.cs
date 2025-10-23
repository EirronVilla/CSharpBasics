namespace SmartMarketConsole
{
    public class ServiceContainer
    {
        private readonly Dictionary<Type, Func<object>> _services = new();
        private readonly Dictionary<Type, object> _singletons = new();

        // Register a transient service (new instance every time)
        public void RegisterTransient<TInterface, TImplementation>()
            where TImplementation : TInterface
        {
            _services[typeof(TInterface)] = () => CreateInstance(typeof(TImplementation));
        }

        // Register a singleton service (same instance every time)
        public void RegisterSingleton<TInterface, TImplementation>()
            where TImplementation : TInterface
        {
            _services[typeof(TInterface)] = () =>
            {
                var type = typeof(TInterface);
                if (!_singletons.ContainsKey(type))
                {
                    _singletons[type] = CreateInstance(typeof(TImplementation));
                }
                return _singletons[type];
            };
        }

        // Register an existing singleton instance
        public void RegisterSingleton<TInterface>(TInterface instance)
        {
            var type = typeof(TInterface);
            _singletons[type] = instance;
            _services[type] = () => _singletons[type];
        }

        // Resolve a service
        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        private object Resolve(Type type)
        {
            if (_services.ContainsKey(type))
            {
                return _services[type]();
            }
            throw new InvalidOperationException($"Service of type {type.Name} is not registered.");
        }

        // Create an instance with constructor injection
        private object CreateInstance(Type implementationType)
        {
            var constructors = implementationType.GetConstructors();
            if (constructors.Length == 0)
            {
                throw new InvalidOperationException($"No public constructor found for {implementationType.Name}");
            }

            var constructor = constructors[0]; // Get first constructor
            var parameters = constructor.GetParameters();
            var parameterInstances = new object[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
            {
                parameterInstances[i] = Resolve(parameters[i].ParameterType);
            }

            return Activator.CreateInstance(implementationType, parameterInstances);
        }
    }
}
