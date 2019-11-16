/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Copyright (c) 2003-2019 by AG-Software, FRNathan13								 *
 * All Rights Reserved.																 *
 * Contact information for AG-Software is available at http://www.ag-software.de	 *
 *																					 *
 * Licence:																			 *
 * The agsXMPP SDK is released under a dual licence									 *
 * agsXMPP can be used under either of two licences									 *
 * 																					 *
 * A commercial licence which is probably the most appropriate for commercial 		 *
 * corporate use and closed source projects. 										 *
 *																					 *
 * The GNU Public License (GPL) is probably most appropriate for inclusion in		 *
 * other open source projects.														 *
 *																					 *
 * See README.html for details.														 *
 *																					 *
 * For general enquiries visit our website at:										 *
 * http://www.ag-software.de														 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

//
// Bdev.Net.Dns by Rob Philpott, Big Developments Ltd. Please send all bugs/enhancements to
// rob@bigdevelopments.co.uk  This file and the code contained within is freeware and may be
// distributed and edited without restriction.
// 

using System.Text;

namespace agsXMPP.Net.Dns
{
	/// <summary>
	/// Logical representation of a pointer, but in fact a byte array reference and a position in it. This
	/// is used to read logical units (bytes, shorts, integers, domain names etc.) from a byte array, keeping
	/// the pointer updated and pointing to the next record. This type of Pointer can be considered the logical
	/// equivalent of an (unsigned char*) in C++
	/// </summary>
	internal class Pointer
	{
		// a pointer is a reference to the message and an index
		private byte[] _message;
		private int _position;


		// pointers can only be created by passing on an existing message
		public Pointer(byte[] message, int position)
		{
			this._message = message;
			this._position = position;
		}

		public int Position
		{
			get { return this._position; }
			set { this._position = value; }
		}

		/// <summary>
		/// Shallow copy function
		/// </summary>
		/// <returns></returns>
		public Pointer Copy()
		{
			return new Pointer(this._message, this._position);
		}

		/// <summary>
		/// Adjust the pointers position within the message
		/// </summary>
		/// <param name="position">new position in the message</param>
		public void SetPosition(int position)
		{
			this._position = position;
		}

		/// <summary>
		/// Overloads the + operator to allow advancing the pointer by so many bytes
		/// </summary>
		/// <param name="pointer">the initial pointer</param>
		/// <param name="offset">the offset to add to the pointer in bytes</param>
		/// <returns>a reference to a new pointer moved forward by offset bytes</returns>
		public static Pointer operator +(Pointer pointer, int offset)
		{
			return new Pointer(pointer._message, pointer._position + offset);
		}

		/// <summary>
		/// Reads a single byte at the current pointer, does not advance pointer
		/// </summary>
		/// <returns>the byte at the pointer</returns>
		public byte Peek()
		{
			return this._message[this._position];
		}

		/// <summary>
		/// Reads a single byte at the current pointer, advancing pointer
		/// </summary>
		/// <returns>the byte at the pointer</returns>
		public byte ReadByte()
		{
			return this._message[this._position++];
		}

		/// <summary>
		/// Reads two bytes to form a short at the current pointer, advancing pointer
		/// </summary>
		/// <returns>the byte at the pointer</returns>
		public short ReadShort()
		{
			return (short)(this.ReadByte() << 8 | this.ReadByte());
		}

		/// <summary>
		/// Reads four bytes to form a int at the current pointer, advancing pointer
		/// </summary>
		/// <returns>the byte at the pointer</returns>
		public int ReadInt()
		{
			return (ushort)this.ReadShort() << 16 | (ushort)this.ReadShort();
		}

		/// <summary>
		/// Reads a single byte as a char at the current pointer, advancing pointer
		/// </summary>
		/// <returns>the byte at the pointer</returns>
		public char ReadChar()
		{
			return (char)this.ReadByte();
		}

		/// <summary>
		/// Reads a domain name from the byte array. The method by which this works is described
		/// in RFC1035 - 4.1.4. Essentially to minimise the size of the message, if part of a domain
		/// name already been seen in the message, rather than repeating it, a pointer to the existing
		/// definition is used. Each word in a domain name is a label, and is preceded by its length
		/// 
		/// eg. bigdevelopments.co.uk
		/// 
		/// is [15] (size of bigdevelopments) + "bigdevelopments"
		///    [2]  "co"
		///    [2]  "uk"
		///    [1]  0 (NULL)
		/// </summary>
		/// <returns>the byte at the pointer</returns>
		public string ReadDomain()
		{
			var domain = new StringBuilder();
			var length = 0;

			// get  the length of the first label
			while ((length = this.ReadByte()) != 0)
			{
				// top 2 bits set denotes domain name compression and to reference elsewhere
				if ((length & 0xc0) == 0xc0)
				{
					// work out the existing domain name, copy this pointer
					var newPointer = this.Copy();

					// and move it to where specified here
					newPointer.SetPosition((length & 0x3f) << 8 | this.ReadByte());

					// repeat call recursively
					domain.Append(newPointer.ReadDomain());
					return domain.ToString();
				}

				// if not using compression, copy a char at a time to the domain name
				while (length > 0)
				{
					domain.Append(this.ReadChar());
					length--;
				}

				// if size of next label isn't null (end of domain name) add a period ready for next label
				if (this.Peek() != 0) domain.Append('.');
			}

			// and return
			return domain.ToString();
		}
	}
}