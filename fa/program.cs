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
            Transitions = new Dictionary<char, State>(),
            IsAcceptState = false,
        };
        public static State b = new State()
        {
            Name = "b",
            Transitions = new Dictionary<char, State>(),
            IsAcceptState = false,
        };
        public static State c = new State()
        {
            Name = "c",
            Transitions = new Dictionary<char, State>(),
            IsAcceptState = true,
        };
        public static State d = new State()
        {
            Name = "d",
            Transitions = new Dictionary<char, State>(),
            IsAcceptState = false,
        };
        public static State e = new State()
        {
            Name = "e",
            Transitions = new Dictionary<char, State>(),
            IsAcceptState = false,
        };
        State InitialState = a;
        public FA1()
        {
            a.Transitions['0'] = b;
            a.Transitions['1'] = d;
            b.Transitions['1'] = c;
            b.Transitions['0'] = e;
            c.Transitions['0'] = e;
            c.Transitions['1'] = c;
            d.Transitions['0'] = c;
            d.Transitions['1'] = d;
            e.Transitions['0'] = e;
            e.Transitions['1'] = e;
        }
    public bool? Run(IEnumerable<char> s)
    {
        State current = a;
        foreach (var c in s)
        {
            Console.WriteLine(current.Name);
            current = current.Transitions[c];
            if (current == e)
            {return false;}
            if (current == null)
                    return null;
            
        }
        return current.IsAcceptState;
        
    }
  }

  public class FA2
  {
      public static State a = new State()
        {
            Name = "a",
            Transitions = new Dictionary<char, State>(),
            IsAcceptState = false,
        };
        public static State b = new State()
        {
            Name = "b",
            Transitions = new Dictionary<char, State>(),
            IsAcceptState = true,
        };
        public static State c = new State()
        {
            Name = "c",
            Transitions = new Dictionary<char, State>(),
            IsAcceptState = false
        };
        public static State d = new State()
        {
            Name = "d",
            Transitions = new Dictionary<char, State>(),
            IsAcceptState = false
        };
        public FA2()
        {
            a.Transitions['0'] = d;
            a.Transitions['1'] = b;
            b.Transitions['1'] = a;
            b.Transitions['0'] = c;
            c.Transitions['0'] = b;
            c.Transitions['1'] = d;
            d.Transitions['0'] = a;
            d.Transitions['1'] = c;

        }
    public bool? Run(IEnumerable<char> s)
    {
      State current = b;
        foreach (var c in s)
        {
            Console.WriteLine(current.Name);
            current = current.Transitions[c];
            
           
            if (current == null)
                    return null;
            
        }
        return current.IsAcceptState;
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
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