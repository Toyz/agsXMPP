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

using AgsXMPP.Protocol.Client;

namespace AgsXMPP.Protocol.Iq.avatar
{
	/// <summary>
	/// Summary description for AvatarIq.
	/// </summary>
	public class AvatarIq : Client.IQ
	{
		private Avatar m_Avatar = new Avatar();

		public AvatarIq()
		{
			base.Query = this.m_Avatar;
			this.GenerateId();
		}

		public AvatarIq(IQType type) : this()
		{
			this.Type = type;
		}

		public AvatarIq(IQType type, Jid to) : this(type)
		{
			this.To = to;
		}

		public AvatarIq(IQType type, Jid to, Jid from) : this(type, to)
		{
			this.From = from;
		}

		public new Avatar Query
		{
			get
			{
				return this.m_Avatar;
			}
		}


	}
}
