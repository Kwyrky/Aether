﻿#region License
//   Copyright 2015 Kastellanos Nikolaos
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
#endregion

using tainicom.Aether.Elementary;
using System;

namespace tainicom.Aether.Engine
{
    public class AetherContext : IDisposable
    {
        readonly string ContentDirectory;

        public AetherContext(string contentDirectory)
        {
            this.ContentDirectory = contentDirectory;
        }

        ~AetherContext()
        {
            Dispose(false);
        }

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected bool isDisposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (isDisposed) return;
            if (disposing)
            {   
            }
            
            isDisposed = true;
        }

        #endregion
        
    }
}
