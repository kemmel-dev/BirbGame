using Plugins.Unify.Core;

namespace Birds
{
    public class BirdMono : UnifyBehaviour
    {
        public Bird Bird { get; } = new Bird(50);
    }
}