using System.Collections.Generic;

namespace fans
{
    public class FA1
    {
        public State A { get; }

        public State B { get; }

        public State C { get; }

        private State _initialState;

        public FA1()
        {
            A = new State
            {
                Name = "a",
                IsAcceptState = false,
                Transitions = new Dictionary<char, State>()
            };

            B = new State
            {
                Name = "b",
                IsAcceptState = true,
                Transitions = new Dictionary<char, State>()
            };

            C = new State
            {
                Name = "c",
                IsAcceptState = false,
                Transitions = new Dictionary<char, State>()
            };

            _initialState = A;

            A.Transitions['0'] = B;
            A.Transitions['1'] = A;
            B.Transitions['0'] = C;
            B.Transitions['1'] = B;
            C.Transitions['0'] = C;
            C.Transitions['1'] = C;
        }

        public bool? Run(IEnumerable<char> s)
        {
            var current = _initialState;

            foreach (var item in s)
            {
                current = current.Transitions[item];

                if (current == null)
                {
                    return null;
                }
            }

            return current.IsAcceptState;
        }
    }
}
