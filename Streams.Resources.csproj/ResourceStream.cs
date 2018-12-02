using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streams.Resources
{
    public class ResourceReaderStream : Stream
    {
        public ResourceReaderStream(Stream stream, string key)
        {
            throw new NotImplementedException();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            // if not key found yet: SeekValue();
            // if value is not read yet: ReadFieldValue(...)
            // else return 0;
        }

        private void SeekValue()
        {
            // while not end of stream read next field pair, compare with key and skip value if it is not equal to key
        }

        public override void Flush()
        {
            // nothing to do
        }
    }

}
