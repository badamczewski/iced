/*
Copyright (C) 2018-2019 de4dot@gmail.com

Permission is hereby granted, free of charge, to any person obtaining
a copy of this software and associated documentation files (the
"Software"), to deal in the Software without restriction, including
without limitation the rights to use, copy, modify, merge, publish,
distribute, sublicense, and/or sell copies of the Software, and to
permit persons to whom the Software is furnished to do so, subject to
the following conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

#if !NO_INSTR_INFO
using System;
using System.Collections.Generic;
using Iced.Intel;

namespace Iced.UnitTests.Intel {
	static partial class ToEnumConverter {
		public static bool TryConditionCode(string value, out ConditionCode conditionCode) => conditionCodeDict.TryGetValue(value, out conditionCode);
		public static ConditionCode GetConditionCode(string value) => TryConditionCode(value, out var conditionCode) ? conditionCode : throw new InvalidOperationException($"Invalid ConditionCode value: {value}");

		static readonly Dictionary<string, ConditionCode> conditionCodeDict =
			// GENERATOR-BEGIN: ConditionCodeHash
			// ⚠️This was generated by GENERATOR!🦹‍♂️
			new Dictionary<string, ConditionCode>(17, StringComparer.Ordinal) {
				{ "None", ConditionCode.None },
				{ "o", ConditionCode.o },
				{ "no", ConditionCode.no },
				{ "b", ConditionCode.b },
				{ "ae", ConditionCode.ae },
				{ "e", ConditionCode.e },
				{ "ne", ConditionCode.ne },
				{ "be", ConditionCode.be },
				{ "a", ConditionCode.a },
				{ "s", ConditionCode.s },
				{ "ns", ConditionCode.ns },
				{ "p", ConditionCode.p },
				{ "np", ConditionCode.np },
				{ "l", ConditionCode.l },
				{ "ge", ConditionCode.ge },
				{ "le", ConditionCode.le },
				{ "g", ConditionCode.g },
			};
			// GENERATOR-END: ConditionCodeHash
	}
}
#endif
