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
        byte[] localBuffer = new byte[Constants.BufferSize];
        Dictionary<string, IEnumerable<byte>> dict = new Dictionary<string, IEnumerable<byte>>();


        public ResourceReaderStream(Stream stream, string key)
        {
            this._stream = stream;
            this._key = key;
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            bool isKeyFound = false;
            int result;
            int keyPosition = 0;

            while (_stream.Read(localBuffer, 0, localBuffer.Length) > 0)
            {
                isKeyFound = SeekValue(localBuffer);
                if(isKeyFound)
                {
                    keyPosition = ReadFieldValue(localBuffer, buffer, keyPosition);
                    return buffer.Length;
                }
                else
                {
                    continue;
                }
            }

            return 0;
        }


        //public override int MyMethod(byte[] buffer, int offset, int count)
        //{
        //    byte[] localBuffer = new byte[Constants.BufferSize];
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        int read;
        //        while ((read = _stream.Read(localBuffer, 0, localBuffer.Length)) > 0)
        //        {
        //            ms.Write(localBuffer, 0, read);
        //        }
        //        localStorage = ms.ToArray().ToList();
        //    }

        //    int lastPosition = 0;
        //    bool IsKey = true;
        //    string currentKey = string.Empty;
        //    byte[] currentValue;

        //    for (int i = 0; i < localStorage.Count(); i++)
        //    {    
        //        if(localStorage[i] == 0 && localStorage[i+1] == 1)
        //        {
        //            if(IsKey)
        //            {
                       
        //                string keyString = Encoding.ASCII.GetString(localStorage.GetRange(lastPosition, i - lastPosition).ToArray()); // for testing purposes
        //                dict.Add(keyString, null);
        //                IsKey = false;
        //            }
        //            else
        //            {
        //                currentValue = localStorage.GetRange(lastPosition, i-lastPosition).ToArray();
        //                string showStr = Encoding.ASCII.GetString(currentValue as Byte[]); // for testing purposes
        //                dict[currentKey] = currentValue;
        //                IsKey = true;
        //            }
        //            lastPosition = i + 2;
        //        }
        //    }


        //    // if not key found yet: SeekValue();
        //    // if value is not read yet: ReadFieldValue(...)
        //    // else return 0;

        //    if(dict.ContainsKey(_key))
        //    {
        //        return  Convert.ToInt32(dict[_key]);
        //    }

        //    return 0;
        //}

        private int ReadFieldValue(byte[] localBuffer, byte[] outputBuffer, int position)
        {
            //for (int i = 0; i < localBuffer.Length; i++)
            //{
            //    if (localBuffer[i] == 0 && localBuffer[i + 1] == 1)
            //    {
            //        i = i + 1;
            //    }
            //    else
            //        continue;
            //}
            int newPosition = 0;

            for (int i = 0; i < outputBuffer.Length; i++)
            {
                outputBuffer[i] = localBuffer[position + i];
                newPosition = position + i;
            }
            return newPosition;

        }

        private bool SeekValue(byte[] ArrayOfBytes)
        {
            // while not end of stream read next field pair, compare with key and skip value if it is not equal to key
            byte[] KeyBytes = Encoding.ASCII.GetBytes(_key);
            if (localBuffer.Except(KeyBytes).Any())
            {
                return true;
            }
            else
                return false;
            

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
