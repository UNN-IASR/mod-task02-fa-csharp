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
    public static State a =  new State()
    {
      Name = "a",
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };

    public static State b = new State()
    {
      Name = "b",
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };

    public static State c =  new State()
    {
      Name = "c",
      IsAcceptState = false,
      Transitions =  new Dictionary<char, State>(),
    };

    public static State d  = new State()
    {
      Name = "d",
      IsAcceptState = true,
      Transitions = new Dictionary<char, State>()
    };

    public static State NoComingBack = new State()
    {
      Name = "NoComingBack",
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };

    public FA1()
    {
        a.Transitions['0'] = c;
        a.Transitions['1'] = b;
        b.Transitions['0'] = d;
        b.Transitions['1'] = b;
        c.Transitions['0'] = NoComingBack;
        c.Transitions['1'] = d;
        d.Transitions['0'] = NoComingBack;
        d.Transitions['1'] = d;
        NoComingBack.Transitions['0'] = NoComingBack;
        NoComingBack.Transitions['1'] = NoComingBack;
    }

    State initial_state = a;

    public bool? Run(IEnumerable<char> s)
    {
      State current = initial_state;
      foreach (var c in s){
        current = current.Transitions[c];
      }
      return current.IsAcceptState;
    }
  }

  public class FA2
  {
    public static State init =  new State()
    {
      Name = "init",
      IsAcceptState = true,
      Transitions = new Dictionary<char, State>()
    };

    public static State a1 = new State()
    {
      Name = "a1",
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };

    public static State a2 =  new State()
    {
      Name = "a2",
      IsAcceptState = false,
      Transitions =  new Dictionary<char, State>(),
    };

    public static State b1  = new State()
    {
      Name = "b1",
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };

    public static State b2 = new State()
    {
      Name = "b2",
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };

    public FA2()
    {
      init.Transitions['0'] = a1;
      init.Transitions['1'] = b1;
      a1.Transitions['0'] = init;
      a1.Transitions['1'] = a2;
      a2.Transitions['0'] = b1;
      a2.Transitions['1'] = a1;
      b1.Transitions['0'] = b2;
      b1.Transitions['1'] = init;
      b2.Transitions['0'] = b1;
      b2.Transitions['1'] = a1;
    }

    State initial_state = init;

    public bool? Run(IEnumerable<char> s)
    {
      State current = initial_state;
      foreach (var c in s){
        current = current.Transitions[c];
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