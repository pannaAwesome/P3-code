using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Classes
{
    public enum ArticleState { Created, Submitted, RobotReady, Completed, Error };

    public class Shared
    {
        public static Dictionary<int, string> StateDictionary = new Dictionary<int, string>()
        {
            { 0, "Created" },
            { 1, "Submitted" },
            { 2, "Robot ready" },
            { 3, "Completed" },
            { 4, "Error" }
        };
    }
}
