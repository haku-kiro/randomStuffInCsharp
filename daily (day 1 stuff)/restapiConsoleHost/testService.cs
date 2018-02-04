using System.Collections.Generic;
using Nancy;

namespace restapiConsoleHost
{
    //our nancy module:

    //On startup, nancy scans your assembly for classes that implent the NancyModule class           //OR DOES IT !!! O_O
    //Which exposes this resource

    public class TestClass : NancyModule
    {
        Dictionary<int,string> someStuff = new Dictionary<int,string>()
        {
            { 1, "Thing"},
            { 2, "Other thing"},
            { 3, "Yet another thing"}
        };


        public TestClass()
        {
            Get["/test/{num}"] = parameters => 
            {
                //getting the value in the list based on the id
                int _id = (int)parameters.num;

                string _out = string.Empty;
                someStuff.TryGetValue(parameters.num, out _out);
                return Response.AsJson(
                new
                {
                    id = parameters.num,
                    content = _out
                });
            };
        }
    }
}
