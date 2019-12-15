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

use super::{MemorySize, Register};

// GENERATOR-BEGIN: IcedConstants
// ⚠️This was generated by GENERATOR!🦹‍♂️
pub(crate) struct IcedConstants;
impl IcedConstants {
	pub(crate) const MAX_OP_COUNT: u32 = 5;
	pub(crate) const MAX_INSTRUCTION_LENGTH: u32 = 15;
	pub(crate) const REGISTER_BITS: u32 = 8;
	pub(crate) const NUMBER_OF_CODE_VALUES: u32 = 4203;
	pub(crate) const NUMBER_OF_REGISTERS: u32 = 241;
	pub(crate) const NUMBER_OF_MEMORY_SIZES: u32 = 136;
	pub(crate) const NUMBER_OF_ENCODING_KINDS: u32 = 5;
	pub(crate) const NUMBER_OF_OP_KINDS: u32 = 26;
	pub(crate) const NUMBER_OF_CODE_SIZES: u32 = 4;
	pub(crate) const NUMBER_OF_ROUNDING_CONTROL_VALUES: u32 = 5;
	pub(crate) const VMM_FIRST: Register = Register::ZMM0;
	pub(crate) const VMM_LAST: Register = Register::ZMM31;
	pub(crate) const VMM_COUNT: u32 = 32;
	pub(crate) const XMM_LAST: Register = Register::XMM31;
	pub(crate) const YMM_LAST: Register = Register::YMM31;
	pub(crate) const ZMM_LAST: Register = Register::ZMM31;
	pub(crate) const MAX_CPUID_FEATURE_INTERNAL_VALUES: u32 = 148;
	pub(crate) const FIRST_BROADCAST_MEMORY_SIZE: MemorySize = MemorySize::Broadcast64_UInt32;
}
// GENERATOR-END: IcedConstants
