using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMarshallingExam.BaseClasses
{
    public abstract class Object : IDisposable
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        internal readonly DeleterHandle m_instance;

        protected Object(IntPtr ptr, Deleter deleter)
        {
            if (ptr == IntPtr.Zero)
            {
                throw new ArgumentNullException(nameof(ptr));
            }

            m_instance = new DeleterHandle(ptr, deleter);
        }

        public IntPtr Handle
        {
            get
            {
                if(m_instance.IsInvalid)
                {
                    throw new ObjectDisposedException(GetType().Name);
                }

                return m_instance.Handle;
            }
        }


        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // 관리 메모리 제거

            }

            // 비관리메모리 제거
            m_instance.Dispose();
        }

        internal void Reset(IntPtr ptr, Deleter deleter)
        {
            m_instance.Reset(ptr, deleter);
        }
    }
}
