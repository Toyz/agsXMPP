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

using System;
using System.Collections;

namespace AgsXMPP.Xml.Dom
{
	public class ElementList : CollectionBase
	{
		/// <summary>
		/// A Collection of Element Nodes
		/// </summary>		
		public ElementList()
		{
		}

		public void Add(Node e)
		{
			// can't add a empty node, so return immediately
			// Some people tried dthis which caused an error
			if (e == null)
				return;

			this.List.Add(e);
		}

		// Method implementation from the CollectionBase class
		public void Remove(int index)
		{
			if (index > this.Count - 1 || index < 0)
			{
				// Handle the error that occurs if the valid page index is       
				// not supplied.    
				// This exception will be written to the calling function             
				throw new Exception("Index out of bounds");
			}
			this.List.RemoveAt(index);
		}

		public void Remove(Element e)
		{
			this.List.Remove(e);
		}

		public Element Item(int index)
		{
			return (Element)this.List[index];
		}


	}
}