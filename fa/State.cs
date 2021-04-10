using System.Collections.Generic;

namespace fans
{
    public class State
    {
        public string Name { get; set; }

        public IDictionary<char, State> Transitions { get; set; }

        public bool IsAcceptState { get; set; }
    }
}
