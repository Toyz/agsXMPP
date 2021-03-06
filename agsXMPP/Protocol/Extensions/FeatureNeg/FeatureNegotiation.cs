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

using AgsXMPP.Protocol.x.data;
using AgsXMPP.Xml.Dom;

namespace AgsXMPP.Protocol.Extensions.FeatureNeg
{
	/// <summary>
	/// JEP-0020: Feature Negotiation
	/// This JEP defines a A protocol that enables two Jabber entities to mutually negotiate feature options.
	/// </summary>
	public class FeatureNegotiation : Element
	{
		/*
		<iq type='get'
			from='romeo@montague.net/orchard'
			to='juliet@capulet.com/balcony'
			id='neg1'>
			<feature xmlns='http://jabber.org/protocol/feature-neg'>
				<x xmlns='jabber:x:data' type='form'>
				<field type='list-single' var='places-to-meet'>
					<option><value>Lover's Lane</value></option>
					<option><value>Secret Grotto</value></option>
					<option><value>Verona Park</value></option>
				</field>
				<field type='list-single' var='times-to-meet'>
					<option><value>22:00</value></option>
					<option><value>22:30</value></option>
					<option><value>23:00</value></option>
					<option><value>23:30</value></option>
				</field>
				</x>
			</feature>
		</iq>
		*/

		public FeatureNegotiation()
		{
			this.TagName = "feature";
			this.Namespace = URI.FEATURE_NEG;
		}

		/// <summary>
		/// data form of type "form" which defines the available options for one or more features.
		/// Each feature is represented as an x-data "field", which MUST be of type "list-single".
		/// </summary>
		public Data Data
		{
			get
			{
				var data = this.SelectSingleElement(typeof(Data));
				if (data != null)
					return data as Data;
				else
					return null;
			}
			set
			{
				if (this.HasTag(typeof(Data)))
					this.RemoveTag(typeof(Data));

				this.AddChild(value);
			}
		}
	}
}