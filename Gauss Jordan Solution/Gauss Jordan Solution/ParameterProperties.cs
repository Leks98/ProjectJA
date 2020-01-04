using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauss_Jordan_Solution
{
    public sealed class ParameterProperties
    {
        private Dictionary<string, bool> programmingLanguages;
         public int threadsNumber { get; set; }
         public string inFileName { get; set; }
        public Dictionary<string, long> programExecutionTime;

        private static ParameterProperties instance = null;
        private static readonly object padlock = new object();

        ParameterProperties()
        {
            programmingLanguages= new Dictionary<string, bool>();
            programmingLanguages.Add("C++", false);
            programmingLanguages.Add("ASM", false);
        }
        public Dictionary<string, bool> ProgrammingLanguages 
        {
            get { return this.programmingLanguages; }
            set { this.programmingLanguages = new Dictionary<string,bool>(value);  }
        }
      
        public static ParameterProperties Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new ParameterProperties();
                    }
                    return instance;
                }
            }
        }
    }
}
