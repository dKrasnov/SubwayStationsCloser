using System.Collections.Generic;

namespace SubwayStationsClosers.Output
{
    public interface IOutputWriter
    {
        void Write(IEnumerable<int> data);
    }
}