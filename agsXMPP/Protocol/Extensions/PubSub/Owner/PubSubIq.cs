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

namespace agsXMPP.Protocol.extensions.pubsub.Owner
{
	public class PubSubIq : client.Iq
	{
		/*
            Example 133. Owner deletes a node

            <iq type='set'
                from='hamlet@denmark.lit/elsinore'
                to='pubsub.shakespeare.lit'
                id='delete1'>
              <pubsub xmlns='http://jabber.org/protocol/pubsub#owner'>
                <delete node='blogs/princely_musings'/>
              </pubsub>
            </iq>
                
        */
		private PubSub m_PubSub = new PubSub();

		#region << Constructors >>
		public PubSubIq()
		{
			this.GenerateId();
			this.AddChild(this.m_PubSub);
		}

		public PubSubIq(IqType type) : this()
		{
			this.Type = type;
		}

		public PubSubIq(IqType type, Jid to) : this(type)
		{
			this.To = to;
		}

		public PubSubIq(IqType type, Jid to, Jid from) : this(type, to)
		{
			this.From = from;
		}
		#endregion

		public PubSub PubSub
		{
			get
			{
				return this.m_PubSub;
			}
		}


	}
}