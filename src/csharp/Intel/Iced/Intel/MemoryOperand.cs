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

using System;
using System.Text;

#if !NO_ENCODER
namespace Iced.Intel {
	/// <summary>
	/// Memory operand
	/// </summary>
	public readonly struct MemoryOperand : IEquatable<MemoryOperand> {
		/// <summary>
		/// Segment override or <see cref="Register.None"/>
		/// </summary>
		public readonly Register SegmentPrefix;

		/// <summary>
		/// Base register or <see cref="Register.None"/>
		/// </summary>
		public readonly Register Base;

		/// <summary>
		/// Index register or <see cref="Register.None"/>
		/// </summary>
		public readonly Register Index;

		/// <summary>
		/// Index register scale (1, 2, 4, or 8)
		/// </summary>
		public readonly int Scale;

		/// <summary>
		/// Memory displacement
		/// </summary>
		public readonly int Displacement;

		/// <summary>
		/// 0 (no displ), 1 (16/32/64-bit, but use 2/4/8 if it doesn't fit in a <see cref="sbyte"/>), 2 (16-bit), 4 (32-bit) or 8 (64-bit)
		/// </summary>
		public readonly int DisplSize;

		/// <summary>
		/// <see langword="true"/> if it's broadcasted memory (EVEX instructions)
		/// </summary>
		public readonly bool IsBroadcast;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="base">Base register or <see cref="Register.None"/></param>
		/// <param name="index">Index register or <see cref="Register.None"/></param>
		/// <param name="scale">Index register scale (1, 2, 4, or 8)</param>
		/// <param name="displacement">Memory displacement</param>
		/// <param name="displSize">0 (no displ), 1 (16/32/64-bit, but use 2/4/8 if it doesn't fit in a <see cref="sbyte"/>), 2 (16-bit), 4 (32-bit) or 8 (64-bit)</param>
		/// <param name="isBroadcast"><see langword="true"/> if it's broadcasted memory (EVEX instructions)</param>
		/// <param name="segmentPrefix">Segment override or <see cref="Register.None"/></param>
		public MemoryOperand(Register @base, Register index, int scale, int displacement, int displSize, bool isBroadcast, Register segmentPrefix) {
			SegmentPrefix = segmentPrefix;
			Base = @base;
			Index = index;
			Scale = scale;
			Displacement = displacement;
			DisplSize = displSize;
			IsBroadcast = isBroadcast;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="base">Base register or <see cref="Register.None"/></param>
		/// <param name="index">Index register or <see cref="Register.None"/></param>
		/// <param name="scale">Index register scale (1, 2, 4, or 8)</param>
		/// <param name="isBroadcast"><see langword="true"/> if it's broadcasted memory (EVEX instructions)</param>
		/// <param name="segmentPrefix">Segment override or <see cref="Register.None"/></param>
		public MemoryOperand(Register @base, Register index, int scale, bool isBroadcast, Register segmentPrefix) {
			SegmentPrefix = segmentPrefix;
			Base = @base;
			Index = index;
			Scale = scale;
			Displacement = 0;
			DisplSize = 0;
			IsBroadcast = isBroadcast;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="base">Base register or <see cref="Register.None"/></param>
		/// <param name="displacement">Memory displacement</param>
		/// <param name="displSize">0 (no displ), 1 (16/32/64-bit, but use 2/4/8 if it doesn't fit in a <see cref="sbyte"/>), 2 (16-bit), 4 (32-bit) or 8 (64-bit)</param>
		/// <param name="isBroadcast"><see langword="true"/> if it's broadcasted memory (EVEX instructions)</param>
		/// <param name="segmentPrefix">Segment override or <see cref="Register.None"/></param>
		public MemoryOperand(Register @base, int displacement, int displSize, bool isBroadcast, Register segmentPrefix) {
			SegmentPrefix = segmentPrefix;
			Base = @base;
			Index = Register.None;
			Scale = 1;
			Displacement = displacement;
			DisplSize = displSize;
			IsBroadcast = isBroadcast;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="index">Index register or <see cref="Register.None"/></param>
		/// <param name="scale">Index register scale (1, 2, 4, or 8)</param>
		/// <param name="displacement">Memory displacement</param>
		/// <param name="displSize">0 (no displ), 1 (16/32/64-bit, but use 2/4/8 if it doesn't fit in a <see cref="sbyte"/>), 2 (16-bit), 4 (32-bit) or 8 (64-bit)</param>
		/// <param name="isBroadcast"><see langword="true"/> if it's broadcasted memory (EVEX instructions)</param>
		/// <param name="segmentPrefix">Segment override or <see cref="Register.None"/></param>
		public MemoryOperand(Register index, int scale, int displacement, int displSize, bool isBroadcast, Register segmentPrefix) {
			SegmentPrefix = segmentPrefix;
			Base = Register.None;
			Index = index;
			Scale = scale;
			Displacement = displacement;
			DisplSize = displSize;
			IsBroadcast = isBroadcast;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="base">Base register or <see cref="Register.None"/></param>
		/// <param name="displacement">Memory displacement</param>
		/// <param name="isBroadcast"><see langword="true"/> if it's broadcasted memory (EVEX instructions)</param>
		/// <param name="segmentPrefix">Segment override or <see cref="Register.None"/></param>
		public MemoryOperand(Register @base, int displacement, bool isBroadcast, Register segmentPrefix) {
			SegmentPrefix = segmentPrefix;
			Base = @base;
			Index = Register.None;
			Scale = 1;
			Displacement = displacement;
			DisplSize = 1;
			IsBroadcast = isBroadcast;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="base">Base register or <see cref="Register.None"/></param>
		/// <param name="index">Index register or <see cref="Register.None"/></param>
		/// <param name="scale">Index register scale (1, 2, 4, or 8)</param>
		/// <param name="displacement">Memory displacement</param>
		/// <param name="displSize">0 (no displ), 1 (16/32/64-bit, but use 2/4/8 if it doesn't fit in a <see cref="sbyte"/>), 2 (16-bit), 4 (32-bit) or 8 (64-bit)</param>
		public MemoryOperand(Register @base, Register index, int scale, int displacement, int displSize) {
			SegmentPrefix = Register.None;
			Base = @base;
			Index = index;
			Scale = scale;
			Displacement = displacement;
			DisplSize = displSize;
			IsBroadcast = false;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="base">Base register or <see cref="Register.None"/></param>
		/// <param name="index">Index register or <see cref="Register.None"/></param>
		/// <param name="scale">Index register scale (1, 2, 4, or 8)</param>
		public MemoryOperand(Register @base, Register index, int scale) {
			SegmentPrefix = Register.None;
			Base = @base;
			Index = index;
			Scale = scale;
			Displacement = 0;
			DisplSize = 0;
			IsBroadcast = false;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="base">Base register or <see cref="Register.None"/></param>
		/// <param name="index">Index register or <see cref="Register.None"/></param>
		public MemoryOperand(Register @base, Register index) {
			SegmentPrefix = Register.None;
			Base = @base;
			Index = index;
			Scale = 1;
			Displacement = 0;
			DisplSize = 0;
			IsBroadcast = false;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="base">Base register or <see cref="Register.None"/></param>
		/// <param name="displacement">Memory displacement</param>
		/// <param name="displSize">0 (no displ), 1 (16/32/64-bit, but use 2/4/8 if it doesn't fit in a <see cref="sbyte"/>), 2 (16-bit), 4 (32-bit) or 8 (64-bit)</param>
		public MemoryOperand(Register @base, int displacement, int displSize) {
			SegmentPrefix = Register.None;
			Base = @base;
			Index = Register.None;
			Scale = 1;
			Displacement = displacement;
			DisplSize = displSize;
			IsBroadcast = false;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="index">Index register or <see cref="Register.None"/></param>
		/// <param name="scale">Index register scale (1, 2, 4, or 8)</param>
		/// <param name="displacement">Memory displacement</param>
		/// <param name="displSize">0 (no displ), 1 (16/32/64-bit, but use 2/4/8 if it doesn't fit in a <see cref="sbyte"/>), 2 (16-bit), 4 (32-bit) or 8 (64-bit)</param>
		public MemoryOperand(Register index, int scale, int displacement, int displSize) {
			SegmentPrefix = Register.None;
			Base = Register.None;
			Index = index;
			Scale = scale;
			Displacement = displacement;
			DisplSize = displSize;
			IsBroadcast = false;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="base">Base register or <see cref="Register.None"/></param>
		/// <param name="displacement">Memory displacement</param>
		public MemoryOperand(Register @base, int displacement) {
			SegmentPrefix = Register.None;
			Base = @base;
			Index = Register.None;
			Scale = 1;
			Displacement = displacement;
			DisplSize = 1;
			IsBroadcast = false;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="base">Base register or <see cref="Register.None"/></param>
		public MemoryOperand(Register @base) {
			SegmentPrefix = Register.None;
			Base = @base;
			Index = Register.None;
			Scale = 1;
			Displacement = 0;
			DisplSize = 0;
			IsBroadcast = false;
		}

		/// <inheritdoc />
		public override string ToString() {
			var text = new StringBuilder();

			if (IsBroadcast) {
				text.Append("bcst");
			}
			
			if (SegmentPrefix != Register.None) {
				if (IsBroadcast) text.Append(' ');
				text.Append(SegmentPrefix.ToString().ToLowerInvariant());
				text.Append(':');
			}

			text.Append('[');
			if (Base != Register.None) {
				text.Append(Base.ToString().ToLowerInvariant());
				text.Append(" + ");
			}
			if (Index != Register.None) {
				text.Append(Index.ToString().ToLowerInvariant());
				if (Scale > 1) {
					text.Append($" * {Scale}");
				}
			}

			if (Displacement != 0) {
				var displacement = Displacement; 
				text.Append(Displacement < 0 ? " - " : " + ");
				if (displacement < 0) displacement = -displacement;
				text.Append(displacement);
			}

			text.Append(']');

			text.Append($" (DisplSize: {DisplSize})");

			return text.ToString();
		}

		/// <inheritdoc />
		public bool Equals(MemoryOperand other) => SegmentPrefix == other.SegmentPrefix && Base == other.Base && Index == other.Index && Scale == other.Scale && Displacement == other.Displacement && DisplSize == other.DisplSize && IsBroadcast == other.IsBroadcast;

		/// <inheritdoc />
        public override bool Equals(object? obj) => obj is MemoryOperand other && Equals(other);

		/// <inheritdoc />
		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = (int) SegmentPrefix;
				hashCode = (hashCode * 397) ^ (int) Base;
				hashCode = (hashCode * 397) ^ (int) Index;
				hashCode = (hashCode * 397) ^ Scale;
				hashCode = (hashCode * 397) ^ Displacement;
				hashCode = (hashCode * 397) ^ DisplSize;
				hashCode = (hashCode * 397) ^ IsBroadcast.GetHashCode();
				return hashCode;
			}
		}

		/// <summary>
		/// Equality operator for <see cref="MemoryOperand"/>.
		/// </summary>
		/// <param name="left">Left operand</param>
		/// <param name="right">Right operand</param>
		/// <returns><c>true</c> if equal; otherwise <c>false</c></returns>
		public static bool operator ==(MemoryOperand left, MemoryOperand right) => left.Equals(right);

		/// <summary>
		/// Inequality operator for <see cref="MemoryOperand"/>.
		/// </summary>
		/// <param name="left">Left operand</param>
		/// <param name="right">Right operand</param>
		/// <returns><c>true</c> if not equal; otherwise <c>false</c></returns>
		public static bool operator !=(MemoryOperand left, MemoryOperand right) => !left.Equals(right);
	}
}
#endif
