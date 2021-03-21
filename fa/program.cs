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
        public Dictionary<char, string> Transitions;
        public bool IsAcceptState;

        public State (string name, bool accept)
        {
            this.Name = name;
            this.IsAcceptState = accept;
        }

    }

    public class FA
    {
        public Dictionary<string, State> States;


        public bool? Run(IEnumerable<char> s)
        {
            State current = States["first_state"];
            foreach (var c in s) // цикл по всем символам 
            {
                if (current.Transitions.ContainsKey(c))
                {
                    current = States[current.Transitions[c]];
                }
                else
                {
                    return null;
                }
            }
            return current.IsAcceptState;         
        }
    }

    public class FA1 : FA
    {

        public FA1()
        {
            States = new Dictionary<string, State>
            {
                { "first_state", new State("first_state", false)},
                {"b", new State("b", false) },
                {"c", new State("c", true) },
                {"d", new State("d", false) },
                {"dead", new State("dead", false) }

            };
            States["first_state"].Transitions = new Dictionary<char, string>();
            States["d"].Transitions = new Dictionary<char, string>();
            States["b"].Transitions = new Dictionary<char, string>();
            States["c"].Transitions = new Dictionary<char, string>();
            States["dead"].Transitions = new Dictionary<char, string>();

            States["first_state"].Transitions['1'] = "d";
            States["first_state"].Transitions['0'] = "b";
            States["d"].Transitions['1'] = "d";
            States["d"].Transitions['0'] = "c";
            States["b"].Transitions['1'] = "c";
            States["b"].Transitions['0'] = "dead";
            States["c"].Transitions['1'] = "c";
            States["c"].Transitions['0'] = "dead";
            States["dead"].Transitions['1'] = "dead";
            States["dead"].Transitions['0'] = "dead";
        }
    }

    public class FA2 : FA
    {
        public FA2()
        {
            States = new Dictionary<string, State>
            {
                { "first_state", new State("first_state", true)},
                {"b", new State("b", false) },
                {"c", new State("c", false) },
                {"d",  new State("d", false)}
            };
            States["first_state"].Transitions = new Dictionary<char, string>
            {
                { '0', "b" },
                { '1', "c" }
            };
            States["b"].Transitions = new Dictionary<char, string>
            {
                { '0', "first_state" },
                { '1', "d" }
            };
            States["c"].Transitions = new Dictionary<char, string>
            {
                { '1', "first_state" },
                { '0', "d" }
            };

            States["d"].Transitions = new Dictionary<char, string>
            {
                { '1', "b" },
                { '0', "c" }
            };

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            String s = "0111";
            FA1 fa1 = new FA1();
            bool? result1 = fa1.Run(s);
            Console.WriteLine(result1);
            FA2 fa2 = new FA2();
            bool? result2 = fa2.Run(s);
            Console.WriteLine(result2);
        }
    }
}