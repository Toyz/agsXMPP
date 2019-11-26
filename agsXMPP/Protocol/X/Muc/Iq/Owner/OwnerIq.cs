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

using agsXMPP.Protocol.client;

namespace agsXMPP.Protocol.x.muc.iq.owner
{
	/*
        Example 72. Moderator Kicks Occupant

        <iq from='fluellen@shakespeare.lit/pda'
            id='kick1'
            to='harfleur@henryv.shakespeare.lit'
            type='set'>
          <query xmlns='http://jabber.org/protocol/muc#admin'>
            <item nick='pistol' role='none'>
              <reason>Avaunt, you cullion!</reason>
            </item>
          </query>
        </iq>
    */

	/// <summary>
	/// 
	/// </summary>
	public class OwnerIq : client.IQ
	{
		private Owner m_Owner = new Owner();

		public OwnerIq()
		{
			base.Query = this.m_Owner;
			this.GenerateId();
		}

		public OwnerIq(IQType type) : this()
		{
			this.Type = type;
		}

		public OwnerIq(IQType type, Jid to) : this(type)
		{
			this.To = to;
		}

		public OwnerIq(IQType type, Jid to, Jid from) : this(type, to)
		{
			this.From = from;
		}

		public new Owner Query
		{
			get
			{
				return this.m_Owner;
			}
		}
	}
}
