#region Copyright (c) 2004-2018, Typemock     http://www.typemock.com
/************************************************************************************
                 
 Copyright © 2004-2018 Typemock Ltd

 This code is protected by international laws

 ***********************************************************************************/
#endregion
using System;

namespace TypeMock
{
    internal class ReaderWriterLock
    {
        private readonly System.Threading.ReaderWriterLock sync = new System.Threading.ReaderWriterLock();

        internal IDisposable AcquireRead()
        {
            return new ReaderScope(sync);
        }

        internal IDisposable AcquireWrite()
        {
            return new WriterScope(sync);
        }

        internal class WriterScope : IDisposable
        {
            private readonly System.Threading.ReaderWriterLock sync;

            public WriterScope(System.Threading.ReaderWriterLock sync)
            {
                this.sync = sync;
                sync.AcquireWriterLock(-1);
            }

            public void Dispose()
            {
                sync.ReleaseWriterLock();
            }
        }

        internal class ReaderScope : IDisposable
        {
            private readonly System.Threading.ReaderWriterLock sync;

            public ReaderScope(System.Threading.ReaderWriterLock sync)
            {
                this.sync = sync;
                sync.AcquireReaderLock(-1);
            }

            public void Dispose()
            {
                sync.ReleaseReaderLock();
            }
        }
    }
}