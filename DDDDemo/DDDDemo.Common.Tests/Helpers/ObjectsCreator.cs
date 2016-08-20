using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDDemo.Common.Tests.Helpers
{
    public class ObjectsCreator
    {
        public IReadOnlyCollection<object> CreatedInstances { get; }

        private ObjectsCreator(List<object> createdInstances)
        {
            CreatedInstances = createdInstances;
        }

        public static ObjectsCreator CreateNew(Func<Type, object> instanceCreatorFunction = null)
        {
            instanceCreatorFunction = instanceCreatorFunction ?? Activator.CreateInstance;

            var createdObjects = new List<object>();
            Func<Type, object> creatorFunction = type =>
            {
                var instance = instanceCreatorFunction(type);
                createdObjects.Add(instance);
                return instance;
            };

            return new ObjectsCreator(createdObjects);
        }
    }
}
