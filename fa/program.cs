using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fans
{
  public class State
  {
    public string Name;
    public Dictionary<char, State> Transitions;
    public bool IsAcceptState;
  }


  public class FA1
  {
        public static State a = new State()
        {
            Name = "a",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State b = new State()
        {
            Name = "b",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State c = new State()
        {
            Name = "c",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State d = new State()
        {
            Name = "d",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };
        public FA1()
        {
            a.Transitions['0'] = c;
            a.Transitions['1'] = b;
            b.Transitions['0'] = d;
            b.Transitions['1'] = b;
            c.Transitions['1'] = d;
            c.Transitions['0'] = null;
            d.Transitions['1'] = d;
            d.Transitions['0'] = null;
        }
        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s) 
            {
                current = current.Transitions[c];
                if (current == null)              
                    return false;
            }
            return current.IsAcceptState;
        }
        State InitialState = a;
  }

  public class FA2
  {
        public static State a = new State()
        {
            Name = "a",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };
        public State b = new State()
        {
            Name = "b",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State c = new State()
        {
            Name = "c",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State d = new State()
        {
            Name = "d",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public FA2()
        {
            a.Transitions['0'] = c;
            a.Transitions['1'] = b;
            b.Transitions['0'] = d;
            b.Transitions['1'] = a;
            c.Transitions['0'] = a;
            c.Transitions['1'] = d;
            d.Transitions['0'] = b;
            d.Transitions['1'] = c;
        }
        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s)
            {
                current = current.Transitions[c];
                if (current == null)
                    return false;
            }
            return current.IsAcceptState;
        }
        State InitialState = a;
    }
}
