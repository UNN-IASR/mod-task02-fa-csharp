using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fans {
    public class State {
        public string Name;
        public Dictionary<char, State> Transitions;
        public bool IsAcceptState;
    }


    public class FA1 {
        static State s1 = new State {
            Name = "s1",
            Transitions = new Dictionary<char, State>(),
            IsAcceptState = false
        };
        State s2 = new State {
            Name = "s2",
            Transitions = new Dictionary<char, State>(),
            IsAcceptState = false
        };
        State s3 = new State {
            Name = "s3",
            Transitions = new Dictionary<char, State>(),
            IsAcceptState = false
        };
        State s4 = new State {
            Name = "s4",
            Transitions = new Dictionary<char, State>(),
            IsAcceptState = true
        };
        State s5 = new State {
            Name = "s5",
            Transitions = new Dictionary<char, State>(),
            IsAcceptState = false
        };
        State s6 = new State {
            Name = "s6",
            Transitions = new Dictionary<char, State>(),
            IsAcceptState = false
        };
        State initialState = s1;

        public FA1() {
            s1.Transitions['0'] = s2;
            s1.Transitions['1'] = s3;
            s2.Transitions['1'] = s4;
            s2.Transitions['0'] = s5;
            s3.Transitions['0'] = s4;
            s3.Transitions['1'] = s3;
            s4.Transitions['0'] = s5;
            s4.Transitions['1'] = s4;
            s5.Transitions['1'] = s5;
            s5.Transitions['0'] = s6;
            s6.Transitions['1'] = s6;
            s6.Transitions['0'] = s5;
        }
        public bool? Run(IEnumerable<char> s) {
            State current = initialState;
            foreach (var c in s) {
                current = current.Transitions[c];
                if (current == null)
                    return null;
            }
            return current.IsAcceptState;
        }
    }

    public class FA2 {
        static State s1 = new State {
            Name = "s1",
            Transitions = new Dictionary<char, State>(),
            IsAcceptState = true
        };
        State s2 = new State {
            Name = "s2",
            Transitions = new Dictionary<char, State>(),
            IsAcceptState = false
        };
        State s3 = new State {
            Name = "s3",
            Transitions = new Dictionary<char, State>(),
            IsAcceptState = false
        };
        State s4 = new State {
            Name = "s4",
            Transitions = new Dictionary<char, State>(),
            IsAcceptState = false
        };
        State initialState = s1;
        public FA2() {
            s1.Transitions['1'] = s2;
            s1.Transitions['0'] = s3;
            s2.Transitions['1'] = s1;
            s2.Transitions['0'] = s4;
            s3.Transitions['0'] = s1;
            s3.Transitions['1'] = s4;
            s4.Transitions['1'] = s3;
            s4.Transitions['0'] = s2;
		}
        public bool? Run(IEnumerable<char> s) {
            State current = initialState;
            foreach (var c in s) {
                current = current.Transitions[c];
                if (current == null)
                    return null;
            }
            return current.IsAcceptState;
        }
    }

    class Program {
        static void Main(string[] args) {
            String s = "01111";
            FA1 fa1 = new FA1();
            bool? result1 = fa1.Run(s);
            Console.WriteLine(result1);
            FA2 fa2 = new FA2();
            bool? result2 = fa2.Run(s);
            Console.WriteLine(result2);
        }
    }
}