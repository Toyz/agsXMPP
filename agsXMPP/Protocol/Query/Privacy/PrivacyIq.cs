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

using AgsXMPP.Protocol.Client;

namespace AgsXMPP.Protocol.Query.Privacy
{
	/// <summary>
	/// Summary description for PrivateIq.
	/// </summary>
	public class PrivacyIq : IQ
	{
		Privacy m_Privacy = new Privacy();

		public PrivacyIq()
		{
			base.Query = this.m_Privacy;
			this.GenerateId();
		}

		public PrivacyIq(IQType type)
			: this()
		{
			this.Type = type;
		}

		public PrivacyIq(IQType type, Jid to)
			: this(type)
		{
			this.To = to;
		}

		public PrivacyIq(IQType type, Jid to, Jid from)
			: this(type, to)
		{
			this.From = from;
		}

		public new Privacy Query
		{
			get { return this.m_Privacy; }
		}
	}
}
