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

use super::handlers::*;
use super::*;

#[allow(non_camel_case_types)]
#[repr(C)]
pub(crate) struct OpCodeHandler_ST_STi {
	pub(crate) decode: OpCodeHandlerDecodeFn,
	pub(crate) has_modrm: bool,
	pub(crate) code: u32,
}

impl OpCodeHandler_ST_STi {
	pub(crate) fn decode(self_ptr: *const OpCodeHandler, decoder: &mut Decoder, instruction: &mut Instruction) {
		let this = unsafe { &*(self_ptr as *const Self) };
		debug_assert!(decoder.state.encoding() == EncodingKind::Legacy);
		super::instruction_internal::internal_set_code_u32(instruction, this.code);
		const_assert_eq!(0, OpKind::Register as u32);
		//super::instruction_internal::internal_set_op0_kind(instruction, OpKind::Register);
		super::instruction_internal::internal_set_op0_register_u32(instruction, Register::ST0 as u32);
		const_assert_eq!(0, OpKind::Register as u32);
		//super::instruction_internal::internal_set_op1_kind(instruction, OpKind::Register);
		super::instruction_internal::internal_set_op1_register_u32(instruction, Register::ST0 as u32 + decoder.state.rm);
	}
}

#[allow(non_camel_case_types)]
#[repr(C)]
pub(crate) struct OpCodeHandler_STi_ST {
	pub(crate) decode: OpCodeHandlerDecodeFn,
	pub(crate) has_modrm: bool,
	pub(crate) code: u32,
}

impl OpCodeHandler_STi_ST {
	pub(crate) fn decode(self_ptr: *const OpCodeHandler, decoder: &mut Decoder, instruction: &mut Instruction) {
		let this = unsafe { &*(self_ptr as *const Self) };
		debug_assert!(decoder.state.encoding() == EncodingKind::Legacy);
		super::instruction_internal::internal_set_code_u32(instruction, this.code);
		const_assert_eq!(0, OpKind::Register as u32);
		//super::instruction_internal::internal_set_op0_kind(instruction, OpKind::Register);
		super::instruction_internal::internal_set_op0_register_u32(instruction, Register::ST0 as u32 + decoder.state.rm);
		const_assert_eq!(0, OpKind::Register as u32);
		//super::instruction_internal::internal_set_op1_kind(instruction, OpKind::Register);
		super::instruction_internal::internal_set_op1_register_u32(instruction, Register::ST0 as u32);
	}
}

#[allow(non_camel_case_types)]
#[repr(C)]
pub(crate) struct OpCodeHandler_STi {
	pub(crate) decode: OpCodeHandlerDecodeFn,
	pub(crate) has_modrm: bool,
	pub(crate) code: u32,
}

impl OpCodeHandler_STi {
	pub(crate) fn decode(self_ptr: *const OpCodeHandler, decoder: &mut Decoder, instruction: &mut Instruction) {
		let this = unsafe { &*(self_ptr as *const Self) };
		debug_assert!(decoder.state.encoding() == EncodingKind::Legacy);
		super::instruction_internal::internal_set_code_u32(instruction, this.code);
		const_assert_eq!(0, OpKind::Register as u32);
		//super::instruction_internal::internal_set_op0_kind(instruction, OpKind::Register);
		super::instruction_internal::internal_set_op0_register_u32(instruction, Register::ST0 as u32 + decoder.state.rm);
	}
}

#[allow(non_camel_case_types)]
#[repr(C)]
pub(crate) struct OpCodeHandler_Mf {
	pub(crate) decode: OpCodeHandlerDecodeFn,
	pub(crate) has_modrm: bool,
	pub(crate) code16: u32,
	pub(crate) code32: u32,
}

impl OpCodeHandler_Mf {
	pub(crate) fn decode(self_ptr: *const OpCodeHandler, decoder: &mut Decoder, instruction: &mut Instruction) {
		let this = unsafe { &*(self_ptr as *const Self) };
		debug_assert!(decoder.state.encoding() == EncodingKind::Legacy);
		if decoder.state.operand_size != OpSize::Size16 {
			super::instruction_internal::internal_set_code_u32(instruction, this.code32);
		} else {
			super::instruction_internal::internal_set_code_u32(instruction, this.code16);
		}
		debug_assert!(decoder.state.mod_ != 3);
		super::instruction_internal::internal_set_op0_kind(instruction, OpKind::Memory);
		decoder.read_op_mem(instruction);
	}
}
