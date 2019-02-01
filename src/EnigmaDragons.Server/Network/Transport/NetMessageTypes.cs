using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EnigmaDragons.Core.Network
{
    public sealed class NetMessageTypes : IEnumerable<Type>
    {
        private readonly Dictionary<string, Type> _types;

        public NetMessageTypes(params Type[] types)
        {
            _types = types.ToDictionary(x => x.Name, x => x);
        }

        public Type Get(string name) => _types.TryGetValue(name, out var type) ? type : typeof(object);
        public bool Contains(Type type) => _types.ContainsKey(type.Name);
        public IEnumerator<Type> GetEnumerator() => _types.Values.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
