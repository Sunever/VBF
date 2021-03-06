﻿// Copyright 2012 Fan Shi
// 
// This file is part of the VBF project.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.Collections.ObjectModel;

namespace VBF.MiniSharp
{
    public class CodeClassType : TypeBase
    {
        public CodeClassType()
        {
            Methods = new Collection<Method>();
            StaticMethods = new Collection<Method>();
            Fields = new VariableCollection<Field>();
        }

        public bool IsStatic { get; set; }
        public CodeClassType BaseType { get; set; }
        public Collection<Method> Methods { get; private set; }
        public Collection<Method> StaticMethods { get; private set; }
        public VariableCollection<Field> Fields { get; private set; }

        public override bool IsAssignableFrom(TypeBase type)
        {
            CodeClassType otherClassType = type as CodeClassType;

            if (otherClassType == null)
            {
                return false;
            }

            if (otherClassType == this)
            {
                return true;
            }
            else
            {
                return IsAssignableFrom(otherClassType.BaseType);
            }
        }

    }
}
