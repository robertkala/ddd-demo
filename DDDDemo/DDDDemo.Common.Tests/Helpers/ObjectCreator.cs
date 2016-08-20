using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDDemo.Common.Tests.Helpers
{
    public class ObjectCreator
    {
        public Func<Type, object> InstanceCreatorFunction { get; }
        public IReadOnlyCollection<object> CreatedInstances { get; }

        private ObjectCreator(Func<Type, object> instanceCreatorFunction, List<object> createdInstances)
        {
            InstanceCreatorFunction = instanceCreatorFunction;
            CreatedInstances = createdInstances;
        }

        public static ObjectCreator CreateNew(Func<Type, object> instanceCreatorFunction = null)
        {
            if (instanceCreatorFunction == null)
            {
                instanceCreatorFunction = Activator.CreateInstance;
            }

            var createdObjects = new List<object>();
            Func<Type, object> creatorFunction = type =>
            {
                var instance = instanceCreatorFunction(type);
                createdObjects.Add(instance);
                return instance;
            };

            return new ObjectCreator(creatorFunction, createdObjects);
        }
    }
}
