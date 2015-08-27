using System;

namespace TeamHaven.WebApi.Models
{
	/// <summary>
	/// An Attribute Schema is comprised of an ordered list of AttributeDefiniutions.
	/// </summary>
	public class AttributeDefinition
	{
		/// <summary>
		/// The Attribute's unique ID.
		/// </summary>
		public int AttributeID { get; set; }

		/// <summary>
		/// The Attribute's name.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Indicates whether this attribute has a special meaning for TeamHaven.
		/// </summary>
		public bool Hardcoded { get; set; }

		/// <summary>
		/// The type of data contained in this attribute
		/// </summary>
		public AttributeType AttributeType { get; set; }

		/// <summary>
		/// The display text associated with this attribute.
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Flag indicating whether this TeamHaven will display this attribute when the entity is displayed in a list.
		/// </summary>
		public bool DisplayInList { get; set; }

		/// <summary>
		/// Flag indicating whether this attribute varies by category when used in a Variable Item List.
		/// </summary>
		public bool IsVariable { get; set; }

		/// <summary>
		/// Flag indicating whether this attribute is a method of contacting someone (telephone, email etc)
		/// </summary>
		public bool IsContactMethod { get; set; }

		/// <summary>
		/// Flag indicating whether this attribute is part of an address.
		/// </summary>
		public bool IsAddressPart { get; set; }

		/// <summary>
		/// Flag indicating whether this attribute is part of somebody's name.
		/// </summary>
		public bool IsFullNamePart { get; set; }

		/// <summary>
		/// Flag indicating whether this attribute must have a value.
		/// </summary>
		public bool Required { get; set; }
	}

	public enum AttributeType
	{
		/// <summary>
		/// Value can be anything.
		/// </summary>
		String = 1,

		/// <summary>
		/// Value must be the string representation of a number (encoded in the US culture)
		/// </summary>
		Number = 2,

		/// <summary>
		/// Value must be an email address
		/// </summary>
		Email = 3
	}
}
