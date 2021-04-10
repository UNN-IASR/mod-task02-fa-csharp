using System.Collections.Generic;

namespace fans
{
    public class FA2
    {
        public State A { get; }

        public State B { get; }

        public State C { get; }

        public State D { get; }

        private State _initialState;

        public FA2()
        {
            A = new State
            {
                Name = "a",
                IsAcceptState = true,
                Transitions = new Dictionary<char, State>()
            };

            B = new State
            {
                Name = "b",
                IsAcceptState = false,
                Transitions = new Dictionary<char, State>()
            };

            C = new State
            {
                Name = "c",
                IsAcceptState = false,
                Transitions = new Dictionary<char, State>()
            };

            D = new State
            {
                Name = "d",
                IsAcceptState = false,
                Transitions = new Dictionary<char, State>()
            };

            _initialState = A;

            A.Transitions['0'] = D;
            A.Transitions['1'] = B;
            B.Transitions['0'] = C;
            B.Transitions['1'] = A;
            C.Transitions['0'] = B;
            C.Transitions['1'] = D;
            D.Transitions['0'] = A;
            D.Transitions['1'] = C;
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
