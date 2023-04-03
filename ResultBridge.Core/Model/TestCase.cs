using System.Collections.Generic;

namespace ResultBridge.Core.Model
{
    public class TestCase
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool WasExecuted { get; private set; }
        public Result Result { get; private set; }
        public bool WasSuccessful { get; private set; }
        public IList<Category> Categories { get; private set; }
    }
}