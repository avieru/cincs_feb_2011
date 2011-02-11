using System;
using System.Collections;
using System.Collections.Generic;

namespace nothinbutdotnetstore.web.core.stub
{
    public class StubSetOfCommands : IEnumerable<RequestCommand>
    {
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<RequestCommand> GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}