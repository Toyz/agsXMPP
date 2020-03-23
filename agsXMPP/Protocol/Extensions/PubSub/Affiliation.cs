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

using AgsXMPP.Xml.Dom;

namespace AgsXMPP.Protocol.Extensions.pubsub
{
	/*
        <affiliation node='node1' jid='francisco@denmark.lit' affiliation='owner'/>
    */
	public class Affiliation : Element
	{
		#region << Constructors >>
		public Affiliation()
		{
			this.TagName = "affiliation";
			this.Namespace = Namespaces.PUBSUB;
		}

		public Affiliation(Jid jid, AffiliationType affiliation)
		{
			this.Jid = jid;
			this.AffiliationType = affiliation;
		}

		public Affiliation(string node, Jid jid, AffiliationType affiliation) : this(jid, affiliation)
		{
			this.Node = node;
		}
		#endregion

		public Jid Jid
		{
			get
			{
				if (this.HasAttribute("jid"))
					return new Jid(this.GetAttribute("jid"));
				else
					return null;
			}
			set
			{
				if (value != null)
					this.SetAttribute("jid", value.ToString());
			}
		}

		public string Node
		{
			get { return this.GetAttribute("node"); }
			set { this.SetAttribute("node", value); }
		}

		public AffiliationType AffiliationType
		{
			get
			{
				return (AffiliationType)this.GetAttributeEnum("affiliation", typeof(AffiliationType));
			}
			set
			{
				this.SetAttribute("affiliation", value.ToString());
			}
		}
	}
}
