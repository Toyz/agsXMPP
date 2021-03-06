/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Copyright (c) 2003-2020 by AG-Software, FRNathan13								 *
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

/* --------------------------------------------------------------------------
 * Copyrights
 * 
 * Portions created by or assigned to Cursive Systems, Inc. are 
 * Copyright (c) 2002-2005 Cursive Systems, Inc.  All Rights Reserved.  Contact
 * information for Cursive Systems, Inc. is available at
 * http://www.cursive.net/.
 *
 * License
 * 
 * Jabber-Net can be used under either JOSL or the GPL.  
 * See LICENSE.txt for details.
 * --------------------------------------------------------------------------*/
namespace AgsXMPP.Xml.Xpnet
{
	/// <summary>
	/// A token that was parsed.
	/// </summary>
	public class Token
	{
		private int tokenEnd = -1;
		private int nameEnd = -1;
		private char refChar1 = (char)0;
		private char refChar2 = (char)0;

		/// <summary>
		/// The end of the current token, in relation to the beginning of the buffer.
		/// </summary>
		public int TokenEnd
		{
			get { return this.tokenEnd; }
			set { this.tokenEnd = value; }
		}

		/// <summary>
		/// The end of the current token's name, in relation to the beginning of the buffer.
		/// </summary>
		public int NameEnd
		{
			get { return this.nameEnd; }
			set { this.nameEnd = value; }
		}

		//public char RefChar
		//{
		//    get {return refChar1;}
		//}

		/// <summary>
		/// The parsed-out character. &amp; for &amp;amp;
		/// </summary>
		public char RefChar1
		{
			get { return this.refChar1; }
			set { this.refChar1 = value; }
		}
		/// <summary>
		/// The second of two parsed-out characters.  TODO: find example.
		/// </summary>
		public char RefChar2
		{
			get { return this.refChar2; }
			set { this.refChar2 = value; }
		}

		/*
        public void getRefCharPair(char[] ch, int off) {
            ch[off] = refChar1;
            ch[off + 1] = refChar2;
        }
        */
	}
}