using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streams.Resources
{
    public class ResourceReaderStream : Stream
    {
        public override bool CanRead => throw new NotImplementedException();

        public override bool CanSeek => throw new NotImplementedException();

        public override bool CanWrite => throw new NotImplementedException();

        public override long Length => throw new NotImplementedException();

        public override long Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        Stream _stream;
        string _key;
        byte[] _buffer = new byte[Constants.BufferSize];

        public ResourceReaderStream(Stream stream, string key)
        {
            this._stream = stream;
            this._key = key;
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            // заводим переменную isKeyFound
            // если isKeyFound == false, то
            // SeekValue(); isKeyFound = true;
            // если isKeyFound == true && IsValueFound == false, то 
            // ReadFieldValue(...); IsValueFound = true;
            // в противном случае возвращаем 0


            // if not key found yet: SeekValue();
            // if value is not read yet: ReadFieldValue(...)
            // else return 0;

            return 0;
        }

        private void ReadFieldValue()
        {
            throw new NotImplementedException();
        }

        private void SeekValue()
        {
            // while not end of stream read next field pair, compare with key and skip value if it is not equal to key


            //если не конец стрима, то
            // то буферезируем стрим с позиции 0 размером 1024

        }

        public override void Flush()
        {
            // nothing to do
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotImplementedException();
        }

        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }
    }

}
