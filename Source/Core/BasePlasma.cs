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

using System.Collections.ObjectModel;
using System.Diagnostics;
using tainicom.Aether.Elementary;
using tainicom.Aether.Elementary.Serialization;

namespace tainicom.Aether.Core
{
    public class BasePlasma : Collection<IAether>, IPlasma, IAetherSerialization
    {
        protected override void InsertItem(int index, IAether item)
        {
            Debug.Assert(!this.Contains(item));
            base.InsertItem(index, item);
            
            IAetherNotify notify = item as IAetherNotify;
            if (notify != null) notify.OnAttachedTo(this);
        }

        protected override void RemoveItem(int index)
        {
            IAetherNotify notify = this[index] as IAetherNotify;
            if (notify != null) notify.OnDettachedFrom(this);

            base.RemoveItem(index);
        }
        
        #if (WINDOWS)
        public virtual void Save(IAetherWriter writer)
        {
            writer.WriteParticles("Particles", this);
        }
        #endif

        public virtual void Load(IAetherReader reader)
        {
            reader.ReadParticles("Particles", this);
        }
    }
}