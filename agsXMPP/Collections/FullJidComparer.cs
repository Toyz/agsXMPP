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

using System;
using System.Collections;

namespace AgsXMPP.Collections
{
	/// <summary>
	/// Full JID comparer.
	/// </summary>
	public class FullJidComparer : IComparer
	{
		public static readonly FullJidComparer Instance = new FullJidComparer();

		/// <summary>
		/// 
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public int Compare(object x, object y)
		{
			if (x is Jid && y is Jid)
			{
				var jidX = (Jid)x;
				var jidY = (Jid)y;

				if (jidX.ToString() == jidY.ToString())
					return 0;
				else
					return string.Compare(jidX.ToString(), jidY.ToString());
			}
			throw new ArgumentException("the objects to compare must be Jids");
		}
	}
}